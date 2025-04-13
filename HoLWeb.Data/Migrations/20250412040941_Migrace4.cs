using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migrace4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Worlds_ThumbnailImageId",
                table: "Worlds");

            migrationBuilder.DropIndex(
                name: "IX_Races_ThumbnailImageId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Naratives_ThumbnailImageId",
                table: "Naratives");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ThumbnailImageId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "class",
                table: "ThumbnailImages");

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_ThumbnailImageId",
                table: "Worlds",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ThumbnailImageId",
                table: "Races",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Naratives_ThumbnailImageId",
                table: "Naratives",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ThumbnailImageId",
                table: "Characters",
                column: "ThumbnailImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ThumbnailImages_ThumbnailImageId",
                table: "Characters",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Naratives_ThumbnailImages_ThumbnailImageId",
                table: "Naratives",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_ThumbnailImages_ThumbnailImageId",
                table: "Races",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worlds_ThumbnailImages_ThumbnailImageId",
                table: "Worlds",
                column: "ThumbnailImageId",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");
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

            migrationBuilder.DropIndex(
                name: "IX_Worlds_ThumbnailImageId",
                table: "Worlds");

            migrationBuilder.DropIndex(
                name: "IX_Races_ThumbnailImageId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Naratives_ThumbnailImageId",
                table: "Naratives");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ThumbnailImageId",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "class",
                table: "ThumbnailImages",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_ThumbnailImageId",
                table: "Worlds",
                column: "ThumbnailImageId",
                unique: true,
                filter: "[ThumbnailImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ThumbnailImageId",
                table: "Races",
                column: "ThumbnailImageId",
                unique: true,
                filter: "[ThumbnailImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Naratives_ThumbnailImageId",
                table: "Naratives",
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
    }
}
