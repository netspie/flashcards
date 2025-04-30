using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedConceptTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concept_templates",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concept_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "concept_template_properties",
                columns: table => new
                {
                    value = table.Column<string>(type: "text", nullable: false),
                    concept_template_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concept_template_properties", x => new { x.concept_template_id, x.value });
                    table.ForeignKey(
                        name: "fk_concept_template_property_concept_template_id",
                        column: x => x.concept_template_id,
                        principalTable: "concept_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
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
