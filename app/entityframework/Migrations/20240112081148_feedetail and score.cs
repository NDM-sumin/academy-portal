using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class feedetailandscore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Accounts_StudentId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Scores",
                newName: "FeeDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_StudentId",
                table: "Scores",
                newName: "IX_Scores_FeeDetailId");

            migrationBuilder.AddColumn<Guid>(
                name: "SemesterId",
                table: "Classes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SemesterId_TeacherId",
                table: "Classes",
                columns: new[] { "SemesterId", "TeacherId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Semesters_SemesterId",
                table: "Classes",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_FeeDetails_FeeDetailId",
                table: "Scores",
                column: "FeeDetailId",
                principalTable: "FeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Semesters_SemesterId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_FeeDetails_FeeDetailId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SemesterId_TeacherId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "FeeDetailId",
                table: "Scores",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_FeeDetailId",
                table: "Scores",
                newName: "IX_Scores_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Accounts_StudentId",
                table: "Scores",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
