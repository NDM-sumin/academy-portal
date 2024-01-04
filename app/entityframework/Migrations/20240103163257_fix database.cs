using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class fixdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeeDetails_StudentSemester_StudentSemesterId",
                table: "FeeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSemester_Accounts_StudentId",
                table: "StudentSemester");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSemester_Semesters_SemesterId",
                table: "StudentSemester");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSemester",
                table: "StudentSemester");

            migrationBuilder.RenameTable(
                name: "StudentSemester",
                newName: "StudentSemesters");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSemester_StudentId",
                table: "StudentSemesters",
                newName: "IX_StudentSemesters_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSemester_SemesterId_StudentId",
                table: "StudentSemesters",
                newName: "IX_StudentSemesters_SemesterId_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Slots",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Slots",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSemesters",
                table: "StudentSemesters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeeDetails_StudentSemesters_StudentSemesterId",
                table: "FeeDetails",
                column: "StudentSemesterId",
                principalTable: "StudentSemesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSemesters_Accounts_StudentId",
                table: "StudentSemesters",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSemesters_Semesters_SemesterId",
                table: "StudentSemesters",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeeDetails_StudentSemesters_StudentSemesterId",
                table: "FeeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSemesters_Accounts_StudentId",
                table: "StudentSemesters");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSemesters_Semesters_SemesterId",
                table: "StudentSemesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSemesters",
                table: "StudentSemesters");

            migrationBuilder.RenameTable(
                name: "StudentSemesters",
                newName: "StudentSemester");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSemesters_StudentId",
                table: "StudentSemester",
                newName: "IX_StudentSemester_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSemesters_SemesterId_StudentId",
                table: "StudentSemester",
                newName: "IX_StudentSemester_SemesterId_StudentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Slots",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Slots",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSemester",
                table: "StudentSemester",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeeDetails_StudentSemester_StudentSemesterId",
                table: "FeeDetails",
                column: "StudentSemesterId",
                principalTable: "StudentSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSemester_Accounts_StudentId",
                table: "StudentSemester",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSemester_Semesters_SemesterId",
                table: "StudentSemester",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
