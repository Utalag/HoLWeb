using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Edit5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Naratives_ThumbnailImages_ThumbnailImageId",
                table: "Naratives");

            migrationBuilder.DropIndex(
                name: "IX_Naratives_ThumbnailImageId",
                table: "Naratives");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Naratives");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThumbnailImageId",
                table: "Naratives",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Naratives",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Naratives",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Naratives",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Naratives_ThumbnailImageId",
                table: "Naratives",
                column: "ThumbnailImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Naratives_ThumbnailImages_ThumbnailImageId",
                table: "Naratives",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");
        }
    }
}
