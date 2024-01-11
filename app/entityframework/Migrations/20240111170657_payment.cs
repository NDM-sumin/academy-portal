using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_FeeDetails_FeeDetailId",
                table: "PaymentTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransactions_FeeDetailId",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "FeeDetailId",
                table: "PaymentTransactions");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTransactionId",
                table: "FeeDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FeeDetails_PaymentTransactionId",
                table: "FeeDetails",
                column: "PaymentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeeDetails_PaymentTransactions_PaymentTransactionId",
                table: "FeeDetails",
                column: "PaymentTransactionId",
                principalTable: "PaymentTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeeDetails_PaymentTransactions_PaymentTransactionId",
                table: "FeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_FeeDetails_PaymentTransactionId",
                table: "FeeDetails");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "FeeDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "FeeDetailId",
                table: "PaymentTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_FeeDetailId",
                table: "PaymentTransactions",
                column: "FeeDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_FeeDetails_FeeDetailId",
                table: "PaymentTransactions",
                column: "FeeDetailId",
                principalTable: "FeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
