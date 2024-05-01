using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPostingAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PostingAccountId",
                table: "OutgoingPaymentDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPayments_TransactionTypeId",
                table: "OutgoingPayments",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPaymentDetails_PostingAccountId",
                table: "OutgoingPaymentDetails",
                column: "PostingAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingPaymentDetails_Companies_PostingAccountId",
                table: "OutgoingPaymentDetails",
                column: "PostingAccountId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingPayments_TransactionTypes_TransactionTypeId",
                table: "OutgoingPayments",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingPaymentDetails_Companies_PostingAccountId",
                table: "OutgoingPaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingPayments_TransactionTypes_TransactionTypeId",
                table: "OutgoingPayments");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingPayments_TransactionTypeId",
                table: "OutgoingPayments");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingPaymentDetails_PostingAccountId",
                table: "OutgoingPaymentDetails");

            migrationBuilder.DropColumn(
                name: "PostingAccountId",
                table: "OutgoingPaymentDetails");
        }
    }
}
