using JuanBosch.App.Models.Users;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JuanBosch.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET api/roles
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }

        // POST api/roles
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _roleService.CreateRoleAsync(request.Name, request.Description);
            if (result.Succeeded) return Ok(new { message = "Role created" });

            foreach (var e in result.Errors) ModelState.AddModelError(e.Code ?? string.Empty, e.Description);
            return BadRequest(ModelState);
        }

        // PUT api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, UpdateRoleRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _roleService.UpdateRoleAsync(id, request.Name, request.Description);
            if (result.Succeeded) return Ok(new { message = "Role updated" });

            foreach (var e in result.Errors) ModelState.AddModelError(e.Code ?? string.Empty, e.Description);
            return BadRequest(ModelState);
        }

        // DELETE api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result.Succeeded) return Ok(new { message = "Role deleted" });

            foreach (var e in result.Errors) ModelState.AddModelError(e.Code ?? string.Empty, e.Description);
            return BadRequest(ModelState);
        }

        // POST api/roles/{roleName}/users/{userId}
        [HttpPost("{roleName}/users/{userId}")]
        public async Task<IActionResult> AddUserToRole(string roleName, string userId)
        {
            var result = await _roleService.AddUserToRoleAsync(userId, roleName);
            if (result.Succeeded) return Ok(new { message = "User added to role" });

            foreach (var e in result.Errors) ModelState.AddModelError(e.Code ?? string.Empty, e.Description);
            return BadRequest(ModelState);
        }

        // DELETE api/roles/{roleName}/users/{userId}
        [HttpDelete("{roleName}/users/{userId}")]
        public async Task<IActionResult> RemoveUserFromRole(string roleName, string userId)
        {
            var result = await _roleService.RemoveUserFromRoleAsync(userId, roleName);
            if (result.Succeeded) return Ok(new { message = "User removed from role" });

            foreach (var e in result.Errors) ModelState.AddModelError(e.Code ?? string.Empty, e.Description);
            return BadRequest(ModelState);
        }

        // GET api/roles/users/{userId}/roles
        [HttpGet("users/{userId}/roles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var roles = await _roleService.GetUserRolesAsync(userId);
            return Ok(roles);
        }
    }

    public class CreateRoleRequest
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
    }

    public class UpdateRoleRequest
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
