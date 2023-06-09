using System;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Login;
using KOS.Application.ViewModels.System;

namespace KOS.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserCreateRequest userVm);

        Task DeleteAsync(string id);

        Task<ApiResult<List<AppUserViewModel>>> GetAllAsync();

        Task<ApiResult<PagedResult<AppUserViewModel>>> GetAllPagingAsync(GetUserPagingRequest request);

        Task<AppUserViewModel> GetById(string id);


        Task<ApiResult<bool>> UpdateAsync(string id, AppUserViewModel userVm);
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> RoleAssign(string id, RoleAssignRequest request);
        Task<ApiResult<bool>> Delete(string id);


    }
}


