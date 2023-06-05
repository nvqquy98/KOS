
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Login;
using KOS.Application.ViewModels.System;
using KOS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace KOS.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config ,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Đăng nhập không đúng");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<bool> AddAsync(UserCreateRequest userVm)
        {
            var user = new AppUser()
            {
                UserName = userVm.UserName,
                AvatarUrl = userVm.AvatarUrl,
                Email = userVm.Email,
                LastName = userVm.LastName,
                CreateDate = DateTime.Now,
                PhoneNumber = userVm.PhoneNumber
            };
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, userVm.Password);
            if (result.Succeeded && userVm.Roles.Count > 0)
            {
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                if (appUser != null)
                    await _userManager.AddToRolesAsync(appUser, userVm.Roles);
            }
            return true;
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<List<AppUserViewModel>> GetAllAsync()
        {
            return await _mapper.ProjectTo<AppUserViewModel>(_userManager.Users).ToListAsync();
        }

        public PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.LastName.Contains(keyword)
                || x.UserName.Contains(keyword)
                || x.Email.Contains(keyword));

            int totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.Select(x => new AppUserViewModel()
            {
                UserName = x.UserName,
                AvatarUrl = x.AvatarUrl,
                Dob = x.Dob.ToString(),
                Email = x.Email,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                CreateDate = x.CreateDate
            }).ToList();
            var paginationSet = new PagedResult<AppUserViewModel>()
            {
                Items = data,
                PageIndex = page,
                TotalRecords = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public async Task<AppUserViewModel> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = _mapper.Map<AppUser, AppUserViewModel>(user);
            userVm.Roles = roles.ToList();
            return userVm;
        }

        public async Task<ApiResult<bool>> UpdateAsync(string id, AppUserViewModel userVm)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == userVm.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }


            var user = await _userManager.FindByIdAsync(userVm.Id.ToString());

            //Remove current roles in db
            var currentRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user,
                userVm.Roles.Except(currentRoles).ToArray());

            if (result.Succeeded)
            {
                string[] needRemoveRoles = currentRoles.Except(userVm.Roles).ToArray();
                await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);

                //Update user detail
                user.LastName = userVm.LastName;
                user.Status = userVm.Status;
                user.Email = userVm.Email;
                user.PhoneNumber = userVm.PhoneNumber;
                var result1 = await _userManager.UpdateAsync(user);

                if (result1.Succeeded)
                {
                    return new ApiSuccessResult<bool>();
                }
                return new ApiErrorResult<bool>("Cập nhật không thành công");

            }

            return new ApiErrorResult<bool>("Cập nhật không thành công");


        }
    }
}

