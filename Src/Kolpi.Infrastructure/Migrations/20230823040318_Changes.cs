using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolpi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Questions_QuestionsId",
                table: "QuestionTag");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "QuestionTag",
                newName: "QuestionId");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 9, 48, 18, 535, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 9, 48, 18, 535, DateTimeKind.Local).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 9, 48, 18, 535, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Questions_QuestionId",
                table: "QuestionTag",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Questions_QuestionId",
                table: "QuestionTag");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "QuestionTag",
                newName: "QuestionsId");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 9, 11, 11, 316, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 9, 11, 11, 316, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 9, 11, 11, 316, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Questions_QuestionsId",
                table: "QuestionTag",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
