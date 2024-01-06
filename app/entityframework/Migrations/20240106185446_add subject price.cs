using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class addsubjectprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MajorSubjects_MajorId_SubjectId",
                table: "MajorSubjects");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Subjects",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_MajorSubjects_MajorId_SubjectId_SemesterId",
                table: "MajorSubjects",
                columns: new[] { "MajorId", "SubjectId", "SemesterId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MajorSubjects_MajorId_SubjectId_SemesterId",
                table: "MajorSubjects");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Subjects");

            migrationBuilder.CreateIndex(
                name: "IX_MajorSubjects_MajorId_SubjectId",
                table: "MajorSubjects",
                columns: new[] { "MajorId", "SubjectId" },
                unique: true);
        }
    }
}
