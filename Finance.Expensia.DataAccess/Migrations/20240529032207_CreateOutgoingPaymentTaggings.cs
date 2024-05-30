using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateOutgoingPaymentTaggings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutgoingPaymentTaggings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutgoingPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingPaymentTaggings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingPaymentTaggings_OutgoingPayments_OutgoingPaymentId",
                        column: x => x.OutgoingPaymentId,
                        principalTable: "OutgoingPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPaymentTaggings_OutgoingPaymentId",
                table: "OutgoingPaymentTaggings",
                column: "OutgoingPaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutgoingPaymentTaggings");
        }
    }
}
