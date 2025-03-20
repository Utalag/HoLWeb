using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class BindingApplicationDataToWorld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameMasterId",
                table: "Worlds",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Worlds_Players",
                columns: table => new
                {
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds_Players", x => new { x.PlayersId, x.WorldsId });
                    table.ForeignKey(
                        name: "FK_Worlds_Players_AspNetUsers_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worlds_Players_Worlds_WorldsId",
                        column: x => x.WorldsId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Worlds",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameMasterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Worlds",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameMasterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Worlds",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameMasterId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_GameMasterId",
                table: "Worlds",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_Players_WorldsId",
                table: "Worlds_Players",
                column: "WorldsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMaster_World",
                table: "Worlds",
                column: "GameMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMaster_World",
                table: "Worlds");

            migrationBuilder.DropTable(
                name: "Worlds_Players");

            migrationBuilder.DropIndex(
                name: "IX_Worlds_GameMasterId",
                table: "Worlds");

            migrationBuilder.DropColumn(
                name: "GameMasterId",
                table: "Worlds");
        }
    }
}
