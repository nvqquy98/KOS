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

        Task<List<AppUserViewModel>> GetAllAsync();

        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);


        Task<ApiResult<bool>> UpdateAsync(string id, AppUserViewModel userVm);
        Task<ApiResult<string>> Authencate(LoginRequest request);

    }
}


