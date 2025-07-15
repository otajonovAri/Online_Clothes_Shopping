using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database
{
    public class EduDbContext(DbContextOptions<EduDbContext> options) : DbContext(options)
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupSubject> GroupSubjects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<StaffSubject> StaffSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Admin Permission
            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Name = "AdminPermission", Description = "AdminPermission", IsDeleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", IsDeleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Role { Id = 2, Name = "User", IsDeleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Seed RolePermissions
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { Id = 1, RoleId = 1, PermissionId = 1, IsDeleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );
        }
    }
}
