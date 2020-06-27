using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolpi.Server.Data.Migrations
{
    public partial class TagType_Table_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinalized",
                table: "Tags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TagTypeId",
                table: "Tags",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagTypeId",
                table: "Tags",
                column: "TagTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagType_TagTypeId",
                table: "Tags",
                column: "TagTypeId",
                principalTable: "TagType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagType_TagTypeId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "TagType");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagTypeId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsFinalized",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagTypeId",
                table: "Tags");
        }
    }
}
