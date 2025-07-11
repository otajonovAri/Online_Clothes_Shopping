using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EducationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupRooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "GroupSubjects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubjects_RoomId",
                table: "GroupSubjects",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Rooms_RoomId",
                table: "GroupSubjects",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Rooms_RoomId",
                table: "GroupSubjects");

            migrationBuilder.DropIndex(
                name: "IX_GroupSubjects_RoomId",
                table: "GroupSubjects");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "GroupSubjects");

            migrationBuilder.CreateTable(
                name: "GroupRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupRooms_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupRooms_GroupId",
                table: "GroupRooms",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRooms_RoomId",
                table: "GroupRooms",
                column: "RoomId");
        }
    }
}
