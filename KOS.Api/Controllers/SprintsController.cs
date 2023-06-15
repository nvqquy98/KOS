using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Content.Board;
using KOS.Application.ViewModels.Content.Sprint;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KOS.Api.Controllers
{
    public class SprintsController : Controller
    {

        private readonly ISprintService _sprintService;

        public SprintsController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }
        // GET: /<controller>/
        [HttpPost]
        public async Task<IActionResult> PostBoard([FromBody] SprintCreateRequest request)
        {
            var result = await _sprintService.AddAsync(request);

            return Ok(result);

        }
        //PUT: http://localhost/api/boards/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SprintUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sprintService.UpdateAsync(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //Delete: http://localhost/api/projects/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sprintService.Delete(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/project
        [HttpGet("board/{id}")]
        public async Task<IActionResult> GetSprintByBoardId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sprintService.GetAllByBoardId(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/boards/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSprint(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sprintService.GetById(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

