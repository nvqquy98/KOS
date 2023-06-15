using System;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Projects;
using KOS.Application.ViewModels.Login;
using KOS.Application.ViewModels.System;

namespace KOS.Application.Interfaces
{
	public interface IProjectService
	{
        Task<ApiResult<bool>> AddAsync(ProjectCreateRequest projectCreateRequest);


        Task<ApiResult<List<ProjectViewModel>>> GetAllAsync();


        Task<ApiResult<ProjectViewModel>> GetById(string id);


        Task<ApiResult<bool>> UpdateAsync(string id, ProjectUpdateRequest userVm);
        Task<ApiResult<bool>> Delete(string id);

        Task<ApiResult<PagedResult<ProjectViewModel>>> GetAllPagingAsync(GetProjectPagingRequest request);

    }
}

