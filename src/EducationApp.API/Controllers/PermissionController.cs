using EducationApp.Application.Service.PermissionServices;
using EducationApp.Application.Auth;
using EducationApp.Application.Services.Interfaces;
using EducationApp.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{	private readonly IPermissionService _permissionService;

	public PermissionController(IPermissionService permissionService)
	{
		_permissionService = permissionService;
	}

	[HttpPost]
	[PermissionAuthorize(Core.Permission.CreatePermissionPermission)]
    public async Task<IActionResult> Create(PermissionDto dto)
	{
		await _permissionService.CreateAsync(dto);
		return Ok("Permission created");
	}

	[HttpGet("get-all-permissions")]
	[PermissionAuthorize(Core.Permission.GetAllPermissionPermission)]
    public IActionResult GetAllPermissions()
	{
		var permissions = _permissionService.GetAll();
		return Ok(permissions);
    }
}
