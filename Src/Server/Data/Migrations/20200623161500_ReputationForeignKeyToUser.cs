using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolpi.Server.Data.Migrations
{
    public partial class ReputationForeignKeyToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Reputations_ReputationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReputationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReputationId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReputationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReputationId",
                table: "Users",
                column: "ReputationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Reputations_ReputationId",
                table: "Users",
                column: "ReputationId",
                principalTable: "Reputations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
