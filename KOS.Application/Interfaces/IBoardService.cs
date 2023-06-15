using System;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Board;
using KOS.Application.ViewModels.Content.Projects;

namespace KOS.Application.Interfaces
{
	public interface IBoardService
	{
        Task<ApiResult<bool>> AddAsync(BoardCreateRequest boardCreateRequest);
        Task<ApiResult<BoardViewModel>> GetById(int id);
        Task<ApiResult<bool>> UpdateAsync(int id, BoardCreateRequest boardCreate);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<List<BoardViewModel>>> GetAllByProjectId(string projectId);

    }

}

