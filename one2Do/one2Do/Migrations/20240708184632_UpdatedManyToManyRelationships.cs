using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one2Do.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedManyToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ListTemplates_ListTemplateId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ListTemplateId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ListTemplateId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ToDoLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ToDoLists",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListTemplateCategories",
                columns: table => new
                {
                    ListTemplateId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTemplateCategories", x => new { x.ListTemplateId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ListTemplateCategories_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListTemplateCategories_ListTemplates_ListTemplateId",
                        column: x => x.ListTemplateId,
                        principalTable: "ListTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListTemplateCategories_CategoriesId",
                table: "ListTemplateCategories",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListTemplateCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ListTemplateId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ListTemplateId",
                table: "Categories",
                column: "ListTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ListTemplates_ListTemplateId",
                table: "Categories",
                column: "ListTemplateId",
                principalTable: "ListTemplates",
                principalColumn: "Id");
        }
    }
}
