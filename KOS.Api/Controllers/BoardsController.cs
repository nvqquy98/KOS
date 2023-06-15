using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOS.Api.Extensions;
using KOS.Application.Implementation;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.Content.Board;
using KOS.Application.ViewModels.Content.Projects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KOS.Api.Controllers
{
    public class BoardsController : BaseController
    {

        private readonly IBoardService _boardService;

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }
        // GET: /<controller>/
        [HttpPost]
        public async Task<IActionResult> PostBoard([FromBody] BoardCreateRequest request)
        {
            var result = await _boardService.AddAsync(request);

            return Ok(result);

        }
        //PUT: http://localhost/api/boards/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BoardCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _boardService.UpdateAsync(id, request);
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

            var result = await _boardService.Delete(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/project
        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetBoardsByProjectId(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _boardService.GetAllByProjectId(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //get: http://localhost/api/boards/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _boardService.GetById(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

