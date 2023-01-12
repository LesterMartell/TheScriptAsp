using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScript.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Sections",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLastEdit",
                table: "Sections",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Chapters",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLastEdit",
                table: "Chapters",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Branches",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLastEdit",
                table: "Branches",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DateOfLastEdit",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "DateOfLastEdit",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "DateOfLastEdit",
                table: "Branches");

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Idbranch = table.Column<int>(name: "Id_branch", type: "INTEGER", nullable: false),
                    Idchapter = table.Column<int>(name: "Id_chapter", type: "INTEGER", nullable: false),
                    Idsection = table.Column<int>(name: "Id_section", type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });
        }
    }
}
