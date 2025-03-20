using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class narrativeModelAddGMandPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameMasterId",
                table: "Naratives",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NarrativeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Naratives",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameMasterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Naratives",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameMasterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Naratives",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameMasterId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Naratives_GameMasterId",
                table: "Naratives",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NarrativeId",
                table: "AspNetUsers",
                column: "NarrativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Naratives_NarrativeId",
                table: "AspNetUsers",
                column: "NarrativeId",
                principalTable: "Naratives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Naratives_AspNetUsers_GameMasterId",
                table: "Naratives",
                column: "GameMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Naratives_NarrativeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Naratives_AspNetUsers_GameMasterId",
                table: "Naratives");

            migrationBuilder.DropIndex(
                name: "IX_Naratives_GameMasterId",
                table: "Naratives");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NarrativeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GameMasterId",
                table: "Naratives");

            migrationBuilder.DropColumn(
                name: "NarrativeId",
                table: "AspNetUsers");
        }
    }
}
