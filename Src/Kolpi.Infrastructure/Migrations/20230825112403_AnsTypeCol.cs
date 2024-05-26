using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolpi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnsTypeCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AnswerOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 25, 17, 9, 3, 92, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 25, 17, 9, 3, 92, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 25, 17, 9, 3, 92, DateTimeKind.Local).AddTicks(1692));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AnswerOptions");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 24, 11, 12, 23, 485, DateTimeKind.Local).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 24, 11, 12, 23, 485, DateTimeKind.Local).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 24, 11, 12, 23, 485, DateTimeKind.Local).AddTicks(3666));
        }
    }
}
