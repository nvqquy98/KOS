using System;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Projects;
using KOS.Application.ViewModels.Login;

namespace KOS.Application.Interfaces
{
	public interface IProjectService
	{
        Task<ApiResult<bool>> AddAsync(ProjectCreateRequest projectCreateRequest);


        Task<ApiResult<List<ProjectViewModel>>> GetAllAsync();


        Task<ProjectViewModel> GetById(string id);


        Task<ApiResult<bool>> UpdateAsync(string id, ProjectViewModel userVm);
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Delete(string id);

    }
}

