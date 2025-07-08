
using EducationApp.Application.Services.Interfaces;
using EducationApp.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
	private readonly IRoleService _roleService;

	public RoleController(IRoleService roleService)
	{
		_roleService = roleService;
	}

	[HttpPost]
	public async Task<IActionResult> Create(RoleDto dto)
	{
		await _roleService.CreateAsync(dto);
		return Ok("Role created");
	}

	[HttpPost("{id}/permissions")]
	public async Task<IActionResult> AssignPermission(int id, List<int> permissionIds)
	{
		foreach (var permissionId in permissionIds)
		{
			await _roleService.AssignPermissionAsync(new RolePermissionDto
			{
				RoleId = id,
				PermissionId = permissionId
			});
		}

		return Ok("Permissions assigned to role");
	}
}
