using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.WebApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConceptTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concept_templates",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    project_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concept_templates", x => x.id);
                    table.ForeignKey(
                        name: "fk_concept_templates_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concept_template_properties",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    concept_template_id = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concept_template_properties", x => new { x.concept_template_id, x.name });
                    table.ForeignKey(
                        name: "fk_concept_template_property_concept_template_id",
                        column: x => x.concept_template_id,
                        principalTable: "concept_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_concept_templates_project_id",
                table: "concept_templates",
                column: "project_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concept_template_properties");

            migrationBuilder.DropTable(
                name: "concept_templates");
        }
    }
}
