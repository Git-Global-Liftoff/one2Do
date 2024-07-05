using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one2Do.Migrations
{
    /// <inheritdoc />
    public partial class AddListTemplateAndToDoListAndTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "TaskItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ListTemplateId",
                table: "TaskItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTemplates", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ListTemplateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_ListTemplates_ListTemplateId",
                        column: x => x.ListTemplateId,
                        principalTable: "ListTemplates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ListTemplateId",
                table: "TaskItems",
                column: "ListTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ListTemplateId",
                table: "Categories",
                column: "ListTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_ListTemplates_ListTemplateId",
                table: "TaskItems",
                column: "ListTemplateId",
                principalTable: "ListTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_ListTemplates_ListTemplateId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ListTemplates");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_ListTemplateId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "ListTemplateId",
                table: "TaskItems");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
