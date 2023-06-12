using System;
using AutoMapper;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Common;
using KOS.Application.ViewModels.Content.Projects;
using KOS.Application.ViewModels.Login;
using KOS.Application.ViewModels.System;
using KOS.Data.Entities;
using KOS.Infrastructure.Interfaces;

namespace KOS.Application.Implementation
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project, string> _projectRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public ProjectService(IRepository<Project, string> projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<ApiResult<bool>> AddAsync(ProjectCreateRequest projectCreateRequest)
        {
            var project = new Project()
            {
                Id = Guid.NewGuid().ToString(),
                Description = projectCreateRequest.Description,
                AvatarUrl = projectCreateRequest.AvatarUrl,
                CreateDate = DateTime.Now,
                Name = projectCreateRequest.Name,
                OwnerUserId = projectCreateRequest.OwnerUserId

            };
            _projectRepository.Add(project);
            this.Save();
            
            return new ApiSuccessResult<bool>(true);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public Task<ApiResult<List<ProjectViewModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> UpdateAsync(string id, ProjectViewModel userVm)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}

