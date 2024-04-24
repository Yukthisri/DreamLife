using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamLife.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "MemberLevels",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "MemberLevels",
                newName: "Position");

            migrationBuilder.AddColumn<string>(
                name: "GrandParentId",
                table: "MemberLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelId",
                table: "MemberLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "MemberLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrandParentId",
                table: "MemberLevels");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "MemberLevels");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MemberLevels");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MemberLevels",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "MemberLevels",
                newName: "Level");
        }
    }
}
