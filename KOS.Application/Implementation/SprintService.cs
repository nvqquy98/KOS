using System;
using AutoMapper;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Board;
using KOS.Application.ViewModels.Content.Sprint;
using KOS.Data.Entities;
using KOS.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KOS.Application.Implementation
{
    public class SprintService : ISprintService
    {
        private IRepository<Sprint, int> _sprintRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public SprintService(IRepository<Sprint, int> sprintRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<ApiResult<bool>> AddAsync(SprintCreateRequest sprintCreateRequest)
        {

            var board = new Sprint()
            {
                Name = sprintCreateRequest.Name,
                Description = sprintCreateRequest.Description,
                IsActive = sprintCreateRequest.IsActive,
                BoardId = sprintCreateRequest.BoardId,
                CreateDate = sprintCreateRequest.CreateDate,
                LastModifiedDate = sprintCreateRequest.LastModifiedDate
            };
            _sprintRepository.Add(board);
            Save();
            return new ApiSuccessResult<bool>();

        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var board = _sprintRepository.FindById(id);
            if (board == null)
            {
                return new ApiErrorResult<bool>("board không tồn tại");
            }
            try
            {
                _sprintRepository.Remove(board);
                this.Save();

                return new ApiSuccessResult<bool>();

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>("Xóa không thành công");

            }
        }

        public async Task<ApiResult<List<SprintViewModel>>> GetAllByBoardId(int boardId)
        {
            var boards = _sprintRepository.FindAll(x => x.BoardId == boardId);
            var result = await _mapper.ProjectTo<SprintViewModel>(boards).ToListAsync();
            if (result.Count > 0)
            {
                return new ApiSuccessResult<List<SprintViewModel>>(result);
            }
            else
            {
                return new ApiErrorResult<List<SprintViewModel>>("board không tồn tại");
            }
        }

        public async Task<ApiResult<SprintViewModel>> GetById(int id)
        {
            var board = _sprintRepository.FindById(id);
            var result = _mapper.Map<Sprint, SprintViewModel>(board);
            return new ApiSuccessResult<SprintViewModel>(result);

        }

        public async Task<ApiResult<bool>> UpdateAsync(int id, SprintUpdateRequest boardCreate)
        {
            var sprint = _sprintRepository.FindById(id);
            if (sprint == null)
            {
                return new ApiErrorResult<bool>("khong tim thay du an");

            }
            sprint.Name = boardCreate.Name;
            sprint.Description = boardCreate.Description;
            sprint.IsActive = boardCreate.IsActive;

            sprint.LastModifiedDate = boardCreate.LastModifiedDate;
            sprint.StartTime = boardCreate.StartTime;
            sprint.EndTime = boardCreate.EndTime;
            sprint.BoardId = boardCreate.BoardId;
            sprint.StartUserId = boardCreate.StartUserId;

            _sprintRepository.Update(sprint);
            this.Save();
            return new ApiSuccessResult<bool>(true);
        }
    }
}

