using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one2Do.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDoListSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListTemplateCategories_Categories_CategoriesId",
                table: "ListTemplateCategories");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "ListTemplateCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ListTemplateCategories_CategoriesId",
                table: "ListTemplateCategories",
                newName: "IX_ListTemplateCategories_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ToDoLists",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ToDoListCategories",
                columns: table => new
                {
                    ToDoListId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ToDoListCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListCategories", x => new { x.ToDoListId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ToDoListCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoListCategories_ToDoLists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_CategoryId",
                table: "ToDoLists",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_UserId",
                table: "ToDoLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListCategories_CategoryId",
                table: "ToDoListCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListTemplateCategories_Categories_CategoryId",
                table: "ListTemplateCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_Categories_CategoryId",
                table: "ToDoLists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListTemplateCategories_Categories_CategoryId",
                table: "ListTemplateCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_Categories_CategoryId",
                table: "ToDoLists");

            migrationBuilder.DropTable(
                name: "ToDoListCategories");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_CategoryId",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_UserId",
                table: "ToDoLists");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ListTemplateCategories",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ListTemplateCategories_CategoryId",
                table: "ListTemplateCategories",
                newName: "IX_ListTemplateCategories_CategoriesId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ToDoLists",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ListTemplateCategories_Categories_CategoriesId",
                table: "ListTemplateCategories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
