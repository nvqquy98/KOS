using System;
using AutoMapper;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Projects;
using KOS.Application.ViewModels.Login;
using KOS.Application.ViewModels.System;
using KOS.Data.Entities;
using KOS.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KOS.Application.Implementation
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project, string> _projectRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public ProjectService(IRepository<Project, string> projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<ApiResult<bool>> AddAsync(ProjectCreateRequest projectCreateRequest)
        {
            var project = new Project()
            {
                Id = Guid.NewGuid().ToString(),
                Description = projectCreateRequest.Description,
                AvatarUrl = projectCreateRequest.AvatarUrl,
                CreateDate = DateTime.Now,
                Name = projectCreateRequest.Name,
                OwnerUserId = projectCreateRequest?.OwnerUserId

            };
            _projectRepository.Add(project);
            this.Save();
            
            return new ApiSuccessResult<bool>(true);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public  async Task<ApiResult<List<ProjectViewModel>>> GetAllAsync()
        {
            var query = _projectRepository.FindAll();
            var result = await _mapper.ProjectTo<ProjectViewModel>(query).ToListAsync();
            if (result.Count > 0)
            {
                return new ApiSuccessResult<List<ProjectViewModel>>(result);
            }
            else
            {
                return new ApiErrorResult<List<ProjectViewModel>>("project không tồn tại");
            }
        }

        public async Task<ApiResult<ProjectViewModel>> GetById(string id)
        {
            var project = _projectRepository.FindById(id);
            var result = _mapper.Map<Project, ProjectViewModel>(project);
            return new ApiSuccessResult<ProjectViewModel>(result);

        }

        public async Task<ApiResult<bool>> UpdateAsync(string id, ProjectUpdateRequest projectUpdateRequest)
        {
            var project = _projectRepository.FindById(id);
            if(project == null)
            {
                return new ApiErrorResult<bool>("khong tim thay du an");

            }
            project.AvatarUrl = projectUpdateRequest.AvatarUrl;
            project.Description = projectUpdateRequest.Description;
            project.LastModifiedDate = projectUpdateRequest.LastModifiedDate;

            _projectRepository.Update(project);
            this.Save();
            return new ApiSuccessResult<bool>(true);


        }

        

        public async Task<ApiResult<bool>> Delete(string id)
        {
            var user =  _projectRepository.FindById(id);
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            try
            {
                _projectRepository.Remove(user);
                this.Save();

                return new ApiSuccessResult<bool>();

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>("Xóa không thành công");

            }


        }

        public async Task<ApiResult<PagedResult<ProjectViewModel>>> GetAllPagingAsync(GetProjectPagingRequest request)
        {

            var query = _projectRepository.FindAll();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Description.Contains(request.Keyword)
                 || x.Name.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProjectViewModel()
                {
                    Name = x.Name,
                    AvatarUrl = x.AvatarUrl,
                    Description = x.Description,
                    Id = x.Id,
                    OwnerUserId = x.OwnerUserId,
                    CreateDate = x.CreateDate,
                    LastModifiedDate = x.LastModifiedDate
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProjectViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProjectViewModel>>(pagedResult);
        }
    }
}

