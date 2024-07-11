using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one2Do.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDoListAndTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ToDoLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDoLists",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "ToDoLists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ToDoLists",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
