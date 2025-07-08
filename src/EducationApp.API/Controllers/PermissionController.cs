using EducationApp.Application.Services.Interfaces;
using EducationApp.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
	private readonly IPermissionService _permissionService;

	public PermissionController(IPermissionService permissionService)
	{
		_permissionService = permissionService;
	}

	[HttpPost]
	public async Task<IActionResult> Create(PermissionDto dto)
	{
		await _permissionService.CreateAsync(dto);
		return Ok("Permission created");
	}
}
