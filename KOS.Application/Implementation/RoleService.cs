﻿using System;
using AutoMapper;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.System;
using KOS.Data.Entities;
using KOS.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KOS.Application.Implementation
{
    public class RoleService : IRoleService
    {
        private RoleManager<AppRole> _roleManager;
        //private IRepository<Function, string> _functionRepository;
        //private IRepository<Permission, int> _permissionRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public RoleService(RoleManager<AppRole> roleManager,
            IUnitOfWork unitOfWork,
        
             IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
           
            _mapper = mapper;
        }

        public async Task<bool> AddAsync( AppRoleViewModel roleVm)
        {
            var role = new AppRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleVm.Name,
                Description = roleVm.Description
            };
            var result = await _roleManager.CreateAsync(role);
           
            
            _unitOfWork.Commit();
            return result.Succeeded;
        }

        //public Task<bool> CheckPermission(string functionId, string action, string[] roles)
        //{
        //    //var functions = _functionRepository.FindAll();
        //    //var permissions = _permissionRepository.FindAll();
        //    //var query = from f in functions
        //    //            join p in permissions on f.Id equals p.FunctionId
        //    //            join r in _roleManager.Roles on p.RoleId equals r.Id
        //    //            where roles.Contains(r.Name) && f.Id == functionId
        //    //            && ((p.CanCreate && action == "Create")
        //    //            || (p.CanUpdate && action == "Update")
        //    //            || (p.CanDelete && action == "Delete")
        //    //            || (p.CanRead && action == "Read"))
        //    //            select p;
        //    //return query.AnyAsync();
        //}

        public async Task DeleteAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
        }

        public async Task<List<AppRoleViewModel>> GetAllAsync()
        {
            return await _mapper.ProjectTo<AppRoleViewModel>(_roleManager.Roles).ToListAsync();
        }

        public PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _roleManager.Roles;
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword));

            int totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = _mapper.ProjectTo<AppRoleViewModel>(query).ToList();
            var paginationSet = new PagedResult<AppRoleViewModel>()
            {
                Items = data,
                PageIndex = page,
                TotalRecords = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public async Task<AppRoleViewModel> GetById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<AppRole, AppRoleViewModel>(role);
        }

        //public List<PermissionViewModel> GetListFunctionWithRole(string roleId)
        //{
        //    //var functions = _functionRepository.FindAll();
        //    //var permissions = _permissionRepository.FindAll();

        //    //var query = from f in functions
        //    //            join p in permissions on f.Id equals p.FunctionId into fp
        //    //            from p in fp.DefaultIfEmpty()
        //    //            where p != null && p.RoleId == roleId
        //    //            select new PermissionViewModel()
        //    //            {
        //    //                RoleId = roleId,
        //    //                FunctionId = f.Id,
        //    //                CanCreate = p != null ? p.CanCreate : false,
        //    //                CanDelete = p != null ? p.CanDelete : false,
        //    //                CanRead = p != null ? p.CanRead : false,
        //    //                CanUpdate = p != null ? p.CanUpdate : false
        //    //            };
        //    //return query.ToList();
        //}

        public void SavePermission(List<PermissionViewModel> permissionVms, string roleId)
        {
            //var permissions = _mapper.Map<List<PermissionViewModel>, List<Permission>>(permissionVms);
            //var oldPermission = _permissionRepository.FindAll().Where(x => x.RoleId == roleId).ToList();
            //if (oldPermission.Count > 0)
            //{
            //    _permissionRepository.RemoveMultiple(oldPermission);
            //}
            //foreach (var permission in permissions)
            //{
            //    _permissionRepository.Add(permission);
            //}
            //_unitOfWork.Commit();
        }

        public async Task UpdateAsync(AppRoleViewModel roleVm)
        {
            var role = await _roleManager.FindByIdAsync(roleVm.Id);
            role.Description = roleVm.Description;
            role.Name = roleVm.Name;
            await _roleManager.UpdateAsync(role);
        }
    }
}

