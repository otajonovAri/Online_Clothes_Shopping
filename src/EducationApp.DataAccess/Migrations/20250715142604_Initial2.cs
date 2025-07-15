using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8310), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8310) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8458), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8458) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8435), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8435) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8437), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8534), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DateBirth", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8484), new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8482), "adminadmin", new DateTime(2025, 7, 15, 14, 26, 3, 581, DateTimeKind.Utc).AddTicks(8486) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(920), new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1054), new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1031), new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1034), new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1097), new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1098) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DateBirth", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1080), new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1078), "admin", new DateTime(2025, 7, 15, 14, 23, 27, 821, DateTimeKind.Utc).AddTicks(1082) });
        }
    }
}
