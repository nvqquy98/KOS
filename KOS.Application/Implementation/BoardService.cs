using System;
using AutoMapper;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Board;
using KOS.Application.ViewModels.Content.Projects;
using KOS.Data.Entities;
using KOS.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KOS.Application.Implementation
{
	public class BoardService: IBoardService
    {
        private IRepository<Board, int> _boardRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public BoardService(IRepository<Board, int> boardRepository, IMapper mapper, IUnitOfWork unitOfWork)
		{
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<ApiResult<bool>> AddAsync(BoardCreateRequest boardCreateRequest)
        {
            var board = new Board()
            {
                Name = boardCreateRequest.Name,
                Description = boardCreateRequest.Description,
                IsKanban = boardCreateRequest.IsKanban,
                ProjectId = boardCreateRequest.ProjectId,
                CreateDate = boardCreateRequest.CreateDate,
                LastModifiedDate = boardCreateRequest.LastModifiedDate
            };
            _boardRepository.Add(board);
            Save();
            return new ApiSuccessResult<bool>();

        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var board = _boardRepository.FindById(id);
            if (board == null)
            {
                return new ApiErrorResult<bool>("board không tồn tại");
            }
            try
            {
                _boardRepository.Remove(board);
                this.Save();

                return new ApiSuccessResult<bool>();

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>("Xóa không thành công");

            }

        }

        public async Task<ApiResult<List<BoardViewModel>>> GetAllByProjectId(string projectId)
        {
            var boards = _boardRepository.FindAll(x => x.ProjectId == projectId);
            var result = await _mapper.ProjectTo<BoardViewModel>(boards).ToListAsync();
            if (result.Count > 0)
            {
                return new ApiSuccessResult<List<BoardViewModel>>(result);
            }
            else
            {
                return new ApiErrorResult<List<BoardViewModel>>("board không tồn tại");
            }

        }

        public async Task<ApiResult<BoardViewModel>> GetById(int id)
        {
            var board = _boardRepository.FindById(id);
            var result = _mapper.Map<Board, BoardViewModel>(board);
            return new ApiSuccessResult<BoardViewModel>(result);

        }


        public  async Task<ApiResult<bool>> UpdateAsync(int id, BoardCreateRequest boardCreate)
        {
            var board = _boardRepository.FindById(id);
            if (board == null)
            {
                return new ApiErrorResult<bool>("khong tim thay du an");

            }
            board.Name = boardCreate.Name;
            board.Description = boardCreate.Description;
            board.IsKanban = boardCreate.IsKanban;

            board.LastModifiedDate = boardCreate.LastModifiedDate;

            _boardRepository.Update(board);
            this.Save();
            return new ApiSuccessResult<bool>(true);
        }
    }
}

