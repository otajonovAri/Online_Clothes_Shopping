using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Services;

public class UserRoleService
{
	private readonly EduDbContext _context;

	public UserRoleService(EduDbContext context)
	{
		_context = context;
	}

	public async Task AssignAsync(UserRoleDto dto)
	{
		if (await _context.UserRoles.AnyAsync(ur => ur.UserId == dto.UserId && ur.RoleId == dto.RoleId))
			throw new Exception("User already has this role");

		var userRole = new UserRole
		{
			UserId = dto.UserId,
			RoleId = dto.RoleId
		};

		_context.UserRoles.Add(userRole);
		await _context.SaveChangesAsync();
	}
}
