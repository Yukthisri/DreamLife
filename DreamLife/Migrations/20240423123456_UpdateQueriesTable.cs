using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQueriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Queries",
                newName: "Text");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Queries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PhoneNumber",
                table: "Queries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Queries");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Queries",
                newName: "Question");
        }
    }
}
