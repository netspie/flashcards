using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.WebApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTagTableToTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tag_projects_project_id",
                table: "tag");

            migrationBuilder.DropForeignKey(
                name: "fk_tag_tag_parent_tag_id",
                table: "tag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tag",
                table: "tag");

            migrationBuilder.RenameTable(
                name: "tag",
                newName: "tags");

            migrationBuilder.RenameIndex(
                name: "ix_tag_project_id",
                table: "tags",
                newName: "ix_tags_project_id");

            migrationBuilder.RenameIndex(
                name: "ix_tag_parent_tag_id",
                table: "tags",
                newName: "ix_tags_parent_tag_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tags",
                table: "tags",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_projects_project_id",
                table: "tags",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_tags_tags_parent_tag_id",
                table: "tags",
                column: "parent_tag_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_projects_project_id",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "fk_tags_tags_parent_tag_id",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tags",
                table: "tags");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "tag");

            migrationBuilder.RenameIndex(
                name: "ix_tags_project_id",
                table: "tag",
                newName: "ix_tag_project_id");

            migrationBuilder.RenameIndex(
                name: "ix_tags_parent_tag_id",
                table: "tag",
                newName: "ix_tag_parent_tag_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tag",
                table: "tag",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tag_projects_project_id",
                table: "tag",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_tag_tag_parent_tag_id",
                table: "tag",
                column: "parent_tag_id",
                principalTable: "tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
