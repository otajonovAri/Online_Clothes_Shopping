using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using EducationApp.Application.Entities;
using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EducationApp.DataAccess.Database
{
    public class EduDbContext(DbContextOptions<EduDbContext> options) : DbContext(options)
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRoom> GroupRooms { get; set; }
        public DbSet<GroupSubject> GroupSubjects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Room> Romms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupRoom>(builder =>
            {
                builder.HasOne(r => r.Group)
                .WithMany(r => r.GroupRooms)
                .HasForeignKey(r => r.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(r => r.Room)
                .WithMany(r => r.GroupRooms)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Group>(builder =>
            {
                builder.HasOne(r => r.Staff)
                .WithMany(r => r.Groups)
                .HasForeignKey(r => r.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GroupSubject>(builder =>
            {
                builder.HasOne(r => r.Group)
                .WithMany(r => r.GroupSubjects)
                .HasForeignKey(r => r.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(r => r.Subject)
                .WithMany(r => r.GroupSubjects)
                .HasForeignKey(r => r.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(builder =>
            {
                builder.HasOne(r => r.User)
                .WithMany(r => r.Students)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Payment>(builder =>
            {
                builder.HasOne(r => r.Student)
                .WithMany(r => r.Payments)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Staff>(builder =>
            {
                builder.HasOne(r => r.User)
                .WithMany(r => r.Staffs)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RolePermission>(builder =>
            {
                builder.HasOne(r => r.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(r => r.Permission)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(r => r.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserRole>(builder =>
            {
                builder.HasOne(r => r.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(r => r.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
