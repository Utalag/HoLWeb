using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditFKInThumb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_ImgThumb",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Narrative_ImgThumb",
                table: "Naratives");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_ImgThumb",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_World_ImgThumb",
                table: "Worlds");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ThumbnailImages_ThumbnailImageId",
                table: "Characters",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Naratives_ThumbnailImages_ThumbnailImageId",
                table: "Naratives",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_ThumbnailImages_ThumbnailImageId",
                table: "Races",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Worlds_ThumbnailImages_ThumbnailImageId",
                table: "Worlds",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ThumbnailImages_ThumbnailImageId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Naratives_ThumbnailImages_ThumbnailImageId",
                table: "Naratives");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_ThumbnailImages_ThumbnailImageId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Worlds_ThumbnailImages_ThumbnailImageId",
                table: "Worlds");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_ImgThumb",
                table: "Characters",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Narrative_ImgThumb",
                table: "Naratives",
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

            migrationBuilder.AddForeignKey(
                name: "FK_World_ImgThumb",
                table: "Worlds",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
