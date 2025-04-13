using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditFKInThumb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "ThumbnailImages");

            migrationBuilder.DropColumn(
                name: "NarrativeId",
                table: "ThumbnailImages");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "ThumbnailImages");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "ThumbnailImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "ThumbnailImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NarrativeId",
                table: "ThumbnailImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "ThumbnailImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorldId",
                table: "ThumbnailImages",
                type: "int",
                nullable: true);
        }
    }
}
