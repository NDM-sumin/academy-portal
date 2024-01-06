using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class fixdatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SlotTimeTableAtWeeks");

            migrationBuilder.DropColumn(
                name: "FeeDetailId",
                table: "SlotTimeTableAtWeeks");

            migrationBuilder.DropColumn(
                name: "IsAttendance",
                table: "SlotTimeTableAtWeeks");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "SlotTimeTableAtWeeks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Attendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAttendance",
                table: "Attendances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsAttendance",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Attendances");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SlotTimeTableAtWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FeeDetailId",
                table: "SlotTimeTableAtWeeks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsAttendance",
                table: "SlotTimeTableAtWeeks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "SlotTimeTableAtWeeks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
