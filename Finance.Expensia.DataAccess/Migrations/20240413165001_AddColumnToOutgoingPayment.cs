using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToOutgoingPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChartOfAccountid",
                table: "OutgoingPaymentDetails",
                newName: "ChartOfAccountId");

            migrationBuilder.AddColumn<string>(
                name: "FromAccountName",
                table: "OutgoingPayments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromBankName",
                table: "OutgoingPayments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToAccountName",
                table: "OutgoingPayments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToBankName",
                table: "OutgoingPayments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CostCenterCode",
                table: "OutgoingPaymentDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromAccountName",
                table: "OutgoingPayments");

            migrationBuilder.DropColumn(
                name: "FromBankName",
                table: "OutgoingPayments");

            migrationBuilder.DropColumn(
                name: "ToAccountName",
                table: "OutgoingPayments");

            migrationBuilder.DropColumn(
                name: "ToBankName",
                table: "OutgoingPayments");

            migrationBuilder.DropColumn(
                name: "CostCenterCode",
                table: "OutgoingPaymentDetails");

            migrationBuilder.RenameColumn(
                name: "ChartOfAccountId",
                table: "OutgoingPaymentDetails",
                newName: "ChartOfAccountid");
        }
    }
}
