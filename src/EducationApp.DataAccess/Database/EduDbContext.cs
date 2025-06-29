using System.Reflection;
using EducationApp.Application.Entities;
using EducationApp.Core.Entities;
using EducationApp.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database
{
    public class EduDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRoom> GroupRooms { get; set; }
        public DbSet<GroupSubject> GroupSubjects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public EduDbContext(DbContextOptions<EduDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CustomAttributeData>();
            modelBuilder.Ignore<System.Type>();

            modelBuilder.ApplyConfiguration(new GroupRoomConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}
