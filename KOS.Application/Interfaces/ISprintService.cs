using System;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Board;
using KOS.Application.ViewModels.Content.Sprint;

namespace KOS.Application.Interfaces
{
	public interface ISprintService
	{
        Task<ApiResult<bool>> AddAsync(SprintCreateRequest sprintCreateRequest);
        Task<ApiResult<SprintViewModel>> GetById(int id);
        Task<ApiResult<bool>> UpdateAsync(int id, SprintUpdateRequest boardCreate);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<List<SprintViewModel>>> GetAllByBoardId(int boardId);
    }
}

