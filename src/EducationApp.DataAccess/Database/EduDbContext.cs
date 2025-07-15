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

            // Seed super admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    DateBirth = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    Email = "admin@example.com",
                    FirstName = "admin",
                    Gender = Core.Enums.Gender.Male,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                    LastName = "admin",
                    Password = "admin",
                    PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb16e0e7f6a46cabcde2a7e4af7f6f73e",
                    PasswordSolt = "cf5392c2-0d03-4cc7-9eb5-4a4016b4a712",
                    PhoneNumber = "admin",
                    RefreshToken = "7Q+nHoS2n9yoKZwBQFq1k3eJZ4ppZjXsOiB7VoO9TisAuRY6fOHRAy2RLixz9Esnrz7HTSfqkWY+7KFkEKnTiw==",
                }
            );

            // Seed UserRoles for super admin
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    RoleId = 1,
                    UserId = 1
                }
            );
        }
    }
}
