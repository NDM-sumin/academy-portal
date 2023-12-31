using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class fixnextsemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Semesters_NextSemesterId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_NextSemesterId",
                table: "Semesters");

            migrationBuilder.RenameColumn(
                name: "NextSemesterId",
                table: "Semesters",
                newName: "PrevSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_PrevSemesterId",
                table: "Semesters",
                column: "PrevSemesterId",
                unique: true,
                filter: "[PrevSemesterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Semesters_PrevSemesterId",
                table: "Semesters",
                column: "PrevSemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Semesters_PrevSemesterId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_PrevSemesterId",
                table: "Semesters");

            migrationBuilder.RenameColumn(
                name: "PrevSemesterId",
                table: "Semesters",
                newName: "NextSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_NextSemesterId",
                table: "Semesters",
                column: "NextSemesterId",
                unique: true,
                filter: "[NextSemesterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Semesters_NextSemesterId",
                table: "Semesters",
                column: "NextSemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");
        }
    }
}
