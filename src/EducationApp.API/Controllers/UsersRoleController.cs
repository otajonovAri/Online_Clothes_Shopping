using EducationApp.Application.Service.UserRoleServices;
using EducationApp.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersRoleController(IUserRoleService userRoleService) : ControllerBase
{
    [HttpPost("{id}/roles")]
	public async Task<IActionResult> AssignRoles(int id, List<int> roleIds)
	{
		foreach (var roleId in roleIds)
		{
			await userRoleService.AssignAsync(new UserRoleDto
			{
				UserId = id,
				RoleId = roleId
			});
		}
		return Ok("Roles assigned to user");
	}
}
