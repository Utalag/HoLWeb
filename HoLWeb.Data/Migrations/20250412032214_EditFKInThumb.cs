using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditFKInThumb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_ImgThumb",
                table: "ThumbnailImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_ImgThumb",
                table: "ThumbnailImages");

            migrationBuilder.DropIndex(
                name: "IX_ThumbnailImages_CharacterId",
                table: "ThumbnailImages");

            migrationBuilder.DropIndex(
                name: "IX_ThumbnailImages_RaceId",
                table: "ThumbnailImages");

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailImageId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailImageId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThumbnailImageId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Races_ThumbnailImageId",
                table: "Races",
                column: "ThumbnailImageId",
                unique: true,
                filter: "[ThumbnailImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ThumbnailImageId",
                table: "Characters",
                column: "ThumbnailImageId",
                unique: true,
                filter: "[ThumbnailImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_ImgThumb",
                table: "Characters",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_ImgThumb",
                table: "Races",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_ImgThumb",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_ImgThumb",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_ThumbnailImageId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ThumbnailImageId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailImages_CharacterId",
                table: "ThumbnailImages",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailImages_RaceId",
                table: "ThumbnailImages",
                column: "RaceId",
                unique: true,
                filter: "[RaceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_ImgThumb",
                table: "ThumbnailImages",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_ImgThumb",
                table: "ThumbnailImages",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
