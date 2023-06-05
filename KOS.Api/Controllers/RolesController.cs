using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOS.Application.Implementation;
using KOS.Application.Interfaces;
using KOS.Application.ViewModels.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KOS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AppRoleViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleService.AddAsync(request);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}

