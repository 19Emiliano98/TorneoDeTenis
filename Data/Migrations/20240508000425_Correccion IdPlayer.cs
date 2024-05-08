using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionIdPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryTournament_Match",
                table: "HistoryTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryTournament_Player",
                table: "HistoryTournament");

            migrationBuilder.DropIndex(
                name: "IX_HistoryTournament_IdHistoryMatch",
                table: "HistoryTournament");

            migrationBuilder.DropColumn(
                name: "IdHistoryMatch",
                table: "HistoryTournament");

            migrationBuilder.RenameColumn(
                name: "IdHistoryMatch",
                table: "Match",
                newName: "IdTournament");

            migrationBuilder.AlterColumn<int>(
                name: "IdPlayer",
                table: "HistoryTournament",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdTournament",
                table: "Match",
                column: "IdTournament");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryTournament_Player",
                table: "HistoryTournament",
                column: "IdPlayer",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament",
                table: "Match",
                column: "IdTournament",
                principalTable: "HistoryTournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryTournament_Player",
                table: "HistoryTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_IdTournament",
                table: "Match");

            migrationBuilder.RenameColumn(
                name: "IdTournament",
                table: "Match",
                newName: "IdHistoryMatch");

            migrationBuilder.AlterColumn<int>(
                name: "IdPlayer",
                table: "HistoryTournament",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHistoryMatch",
                table: "HistoryTournament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTournament_IdHistoryMatch",
                table: "HistoryTournament",
                column: "IdHistoryMatch");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryTournament_Match",
                table: "HistoryTournament",
                column: "IdHistoryMatch",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryTournament_Player",
                table: "HistoryTournament",
                column: "IdPlayer",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
