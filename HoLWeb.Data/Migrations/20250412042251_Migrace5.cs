using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migrace5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worlds_ThumbnailImages_ThumbnailImageId",
                table: "Worlds");

            migrationBuilder.DropIndex(
                name: "IX_Worlds_ThumbnailImageId",
                table: "Worlds");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Worlds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThumbnailImageId",
                table: "Worlds",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Worlds",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Worlds",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Worlds",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_ThumbnailImageId",
                table: "Worlds",
                column: "ThumbnailImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worlds_ThumbnailImages_ThumbnailImageId",
                table: "Worlds",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");
        }
    }
}
