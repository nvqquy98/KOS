using System;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.System;

namespace KOS.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync( AppRoleViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(string id);


        Task UpdateAsync(AppRoleViewModel userVm);

        //List<PermissionViewModel> GetListFunctionWithRole(string roleId);

        void SavePermission(List<PermissionViewModel> permissions, string roleId);

        //Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}

