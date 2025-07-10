using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddJWtOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHas",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordSold",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHasher",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHasher",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHas",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSold",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
