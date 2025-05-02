using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.WebApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsArchivedToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_archived",
                table: "projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_archived",
                table: "projects");
        }
    }
}
