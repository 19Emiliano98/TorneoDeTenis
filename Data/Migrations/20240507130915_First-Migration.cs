using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: true),
                    Hability = table.Column<int>(type: "int", nullable: false),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryTournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlayer = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryTournament_Player",
                        column: x => x.IdPlayer,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTournament = table.Column<int>(type: "int", nullable: false),
                    IdWinner = table.Column<int>(type: "int", nullable: false),
                    IdLoser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Loser",
                        column: x => x.IdLoser,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Tournament",
                        column: x => x.IdTournament,
                        principalTable: "HistoryTournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Winner",
                        column: x => x.IdWinner,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTournament_IdPlayer",
                table: "HistoryTournament",
                column: "IdPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdLoser",
                table: "Match",
                column: "IdLoser");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdTournament",
                table: "Match",
                column: "IdTournament");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdWinner",
                table: "Match",
                column: "IdWinner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "HistoryTournament");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
