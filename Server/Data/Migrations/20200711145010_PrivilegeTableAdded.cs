using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolpi.Server.Data.Migrations
{
    public partial class PrivilegeTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reputations");

            migrationBuilder.CreateTable(
                name: "PrivilegeLookups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    QuestionsCount = table.Column<int>(nullable: false),
                    SubjectiveAnswersCount = table.Column<int>(nullable: false),
                    ObjectiveAnswersCount = table.Column<int>(nullable: false),
                    ReviewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilegeLookups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivilegeLookups");

            migrationBuilder.CreateTable(
                name: "Reputations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcellentBadges = table.Column<int>(type: "int", nullable: false),
                    ExcellentBadgesIcon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GoodBadges = table.Column<int>(type: "int", nullable: false),
                    GoodBadgesIcon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutstandingBadges = table.Column<int>(type: "int", nullable: false),
                    OutstandingBadgesIcon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    VeryGoodBadges = table.Column<int>(type: "int", nullable: false),
                    VeryGoodBadgesIcon = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reputations", x => x.Id);
                });
        }
    }
}
