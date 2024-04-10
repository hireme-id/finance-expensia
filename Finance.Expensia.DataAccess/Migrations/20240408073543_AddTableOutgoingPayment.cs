using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOutgoingPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutgoingPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Requestor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExpectedTransfer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromBankAliasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromBankAliasName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FromAccountNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ToBankAliasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToBankAliasName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ToAccountNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutgoingPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutgoingPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ChartOfAccountid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChartOfAccountNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostCenterName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingPaymentDetails_OutgoingPayments_OutgoingPaymentId",
                        column: x => x.OutgoingPaymentId,
                        principalTable: "OutgoingPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutgointPaymentDetailAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutgoingPaymentDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgointPaymentDetailAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgointPaymentDetailAttachments_OutgoingPaymentDetails_OutgoingPaymentDetailId",
                        column: x => x.OutgoingPaymentDetailId,
                        principalTable: "OutgoingPaymentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPaymentDetails_OutgoingPaymentId",
                table: "OutgoingPaymentDetails",
                column: "OutgoingPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgointPaymentDetailAttachments_OutgoingPaymentDetailId",
                table: "OutgointPaymentDetailAttachments",
                column: "OutgoingPaymentDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutgointPaymentDetailAttachments");

            migrationBuilder.DropTable(
                name: "OutgoingPaymentDetails");

            migrationBuilder.DropTable(
                name: "OutgoingPayments");
        }
    }
}
