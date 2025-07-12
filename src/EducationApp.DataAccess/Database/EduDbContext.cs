using System.Reflection;
using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database
{
    public class EduDbContext(DbContextOptions<EduDbContext> options) : DbContext(options)
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupSubject> GroupSubjects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffSubject> StaffSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Core.Entities.File> Files { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Core.Entities.File>(builder =>
            {
                builder.HasKey(u => u.Id);
            });
		}
	}
}
