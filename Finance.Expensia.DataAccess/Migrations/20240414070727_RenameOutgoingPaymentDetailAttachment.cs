using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameOutgoingPaymentDetailAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutgointPaymentDetailAttachments_OutgoingPaymentDetails_OutgoingPaymentDetailId",
                table: "OutgointPaymentDetailAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutgointPaymentDetailAttachments",
                table: "OutgointPaymentDetailAttachments");

            migrationBuilder.RenameTable(
                name: "OutgointPaymentDetailAttachments",
                newName: "OutgoingPaymentDetailAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_OutgointPaymentDetailAttachments_OutgoingPaymentDetailId",
                table: "OutgoingPaymentDetailAttachments",
                newName: "IX_OutgoingPaymentDetailAttachments_OutgoingPaymentDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutgoingPaymentDetailAttachments",
                table: "OutgoingPaymentDetailAttachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingPaymentDetailAttachments_OutgoingPaymentDetails_OutgoingPaymentDetailId",
                table: "OutgoingPaymentDetailAttachments",
                column: "OutgoingPaymentDetailId",
                principalTable: "OutgoingPaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingPaymentDetailAttachments_OutgoingPaymentDetails_OutgoingPaymentDetailId",
                table: "OutgoingPaymentDetailAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutgoingPaymentDetailAttachments",
                table: "OutgoingPaymentDetailAttachments");

            migrationBuilder.RenameTable(
                name: "OutgoingPaymentDetailAttachments",
                newName: "OutgointPaymentDetailAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_OutgoingPaymentDetailAttachments_OutgoingPaymentDetailId",
                table: "OutgointPaymentDetailAttachments",
                newName: "IX_OutgointPaymentDetailAttachments_OutgoingPaymentDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutgointPaymentDetailAttachments",
                table: "OutgointPaymentDetailAttachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutgointPaymentDetailAttachments_OutgoingPaymentDetails_OutgoingPaymentDetailId",
                table: "OutgointPaymentDetailAttachments",
                column: "OutgoingPaymentDetailId",
                principalTable: "OutgoingPaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
