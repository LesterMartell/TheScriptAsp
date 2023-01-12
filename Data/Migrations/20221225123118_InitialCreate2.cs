using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScript.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background_color",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Font_weight",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contents");

            migrationBuilder.AddColumn<string>(
                name: "HtmlText",
                table: "Chapters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlText",
                table: "Chapters");

            migrationBuilder.AddColumn<string>(
                name: "Background_color",
                table: "Contents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Font_weight",
                table: "Contents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Contents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
