using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var result = await _projectService.AddAsync(request);
            return Ok(result);

        }

    }
}

