using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolpi.Server.Data.Migrations
{
    public partial class ColorCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagType_TagTypeId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagType",
                table: "TagType");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Reputations");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Reputations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ExamPapers");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "ExamPapers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AnswerOptions");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "AnswerOptions");

            migrationBuilder.RenameTable(
                name: "TagType",
                newName: "TagTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reputations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Reputations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ExamPapers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ExamPapers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AnswerOptions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AnswerOptions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "TagTypes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagTypes",
                table: "TagTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagTypes_TagTypeId",
                table: "Tags",
                column: "TagTypeId",
                principalTable: "TagTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagTypes_TagTypeId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagTypes",
                table: "TagTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reputations");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Reputations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ExamPapers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ExamPapers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AnswerOptions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AnswerOptions");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "TagTypes");

            migrationBuilder.RenameTable(
                name: "TagTypes",
                newName: "TagType");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Reputations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Reputations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ExamPapers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "ExamPapers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AnswerOptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "AnswerOptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagType",
                table: "TagType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagType_TagTypeId",
                table: "Tags",
                column: "TagTypeId",
                principalTable: "TagType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
