using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8310), "AdminPermission", false, "AdminPermission", new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8310) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8435), false, "Admin", new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8435) },
                    { 2, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8437), false, "User", new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8438) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateBirth", "Discriminator", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "Password", "PasswordHash", "PasswordSolt", "PhoneNumber", "RefreshToken", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8484), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8482), "User", "admin@example.com", "admin", 0, false, "admin", "adminadmin", "8c6976e5b5410415bde908bd4dee15dfb16e0e7f6a46cabcde2a7e4af7f6f73e", "cf5392c2-0d03-4cc7-9eb5-4a4016b4a712", "admin", "7Q+nHoS2n9yoKZwBQFq1k3eJZ4ppZjXsOiB7VoO9TisAuRY6fOHRAy2RLixz9Esnrz7HTSfqkWY+7KFkEKnTiw==", new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "PermissionId", "RoleId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8458), false, 1, 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8458) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "RoleId", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8534), false, 1, new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8534), 1 });
        }
    }
}
