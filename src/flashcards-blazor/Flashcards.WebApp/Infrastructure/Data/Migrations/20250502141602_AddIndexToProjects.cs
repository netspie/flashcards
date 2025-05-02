using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.WebApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_projects_user_id",
                table: "projects");

            migrationBuilder.CreateIndex(
                name: "ix_projects_user_id_is_archived",
                table: "projects",
                columns: new[] { "user_id", "is_archived" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_projects_user_id_is_archived",
                table: "projects");

            migrationBuilder.CreateIndex(
                name: "ix_projects_user_id",
                table: "projects",
                column: "user_id");
        }
    }
}
