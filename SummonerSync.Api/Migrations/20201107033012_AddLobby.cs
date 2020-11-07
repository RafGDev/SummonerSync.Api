using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SummonerSync.Api.Migrations
{
    public partial class AddLobby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Summoners",
                table: "Summoners");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Summoners");

            migrationBuilder.AddColumn<int>(
                name: "SummonerId",
                table: "Summoners",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "LobbyId",
                table: "Summoners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summoners",
                table: "Summoners",
                column: "SummonerId");

            migrationBuilder.CreateTable(
                name: "Lobby",
                columns: table => new
                {
                    LobbyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobby", x => x.LobbyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Summoners_LobbyId",
                table: "Summoners",
                column: "LobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Summoners_Lobby_LobbyId",
                table: "Summoners",
                column: "LobbyId",
                principalTable: "Lobby",
                principalColumn: "LobbyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summoners_Lobby_LobbyId",
                table: "Summoners");

            migrationBuilder.DropTable(
                name: "Lobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summoners",
                table: "Summoners");

            migrationBuilder.DropIndex(
                name: "IX_Summoners_LobbyId",
                table: "Summoners");

            migrationBuilder.DropColumn(
                name: "SummonerId",
                table: "Summoners");

            migrationBuilder.DropColumn(
                name: "LobbyId",
                table: "Summoners");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Summoners",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summoners",
                table: "Summoners",
                column: "Id");
        }
    }
}
