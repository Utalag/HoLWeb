using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditGmAndPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Worlds_GameMasters");

            migrationBuilder.DropTable(
                name: "Worlds_Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Worlds_GameMasters",
                columns: table => new
                {
                    GameMastersInWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldGmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds_GameMasters", x => new { x.GameMastersInWorldId, x.WorldGmsId });
                    table.ForeignKey(
                        name: "FK_Worlds_GameMasters_AspNetUsers_GameMastersInWorldId",
                        column: x => x.GameMastersInWorldId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worlds_GameMasters_Worlds_WorldGmsId",
                        column: x => x.WorldGmsId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worlds_Players",
                columns: table => new
                {
                    PlayersInWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldPlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds_Players", x => new { x.PlayersInWorldId, x.WorldPlayersId });
                    table.ForeignKey(
                        name: "FK_Worlds_Players_AspNetUsers_PlayersInWorldId",
                        column: x => x.PlayersInWorldId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worlds_Players_Worlds_WorldPlayersId",
                        column: x => x.WorldPlayersId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_GameMasters_WorldGmsId",
                table: "Worlds_GameMasters",
                column: "WorldGmsId");

            migrationBuilder.CreateIndex(
                name: "IX_Worlds_Players_WorldPlayersId",
                table: "Worlds_Players",
                column: "WorldPlayersId");
        }
    }
}
