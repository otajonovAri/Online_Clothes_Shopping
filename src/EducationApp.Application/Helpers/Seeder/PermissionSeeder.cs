using EducationApp.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.Application.Helpers.Seeder;

public static class PermissionSeeder
{
    public static async Task SeedPermissionsAsync(EduDbContext context)
    {
        var enumValues = Enum.GetValues(typeof(Core.Permission)).Cast<Core.Permission>()
            .Select(e => new Core.Entities.Permission
            {
                Name = e.ToString(),
                Description = e.ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            });

        var existingPermissions = await context.Permissions.ToListAsync();

        var newPermissions = enumValues
            .Where(p => !existingPermissions.Any(ep => ep.Name == p.Name))
            .ToList();

        if (newPermissions.Any())
        {
            context.Permissions.AddRange(newPermissions);
            await context.SaveChangesAsync();
        }
    }
}
