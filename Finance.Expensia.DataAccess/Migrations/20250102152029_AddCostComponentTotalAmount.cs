using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCostComponentTotalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostComponentTotalAmount",
                table: "EmployeeCostComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostComponentTotalAmount",
                table: "EmployeeCostComponents");
        }
    }
}
