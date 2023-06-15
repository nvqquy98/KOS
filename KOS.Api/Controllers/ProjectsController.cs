using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOS.Api.Extensions;
using KOS.Application.Implementation;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Content.Projects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KOS.Api.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET: /<controller>/
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] ProjectCreateRequest request)
        {
            string id = User.GetUserId();
            request.OwnerUserId = id;
            var result = await _projectService.AddAsync(request);
            
            return Ok(result);

        }
        //PUT: http://localhost/api/projects/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProjectUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.UpdateAsync(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //Delete: http://localhost/api/projects/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.Delete(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/project
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.GetAllAsync();
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/project
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.GetById(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/project
        [HttpGet("paging")]
        public async Task<IActionResult> GetProjectPaging(GetProjectPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.GetAllPagingAsync(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}

