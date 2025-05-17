using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.WebApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTagIsAbstractField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_abstract",
                table: "tags",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_abstract",
                table: "tags");
        }
    }
}
