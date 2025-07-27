using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffStatus",
                table: "Users",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffStatus",
                table: "Users");
        }
    }
}
