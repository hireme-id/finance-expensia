using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferingDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPosition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    NonTaxableIncome = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EffectiveTaxCategory = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    WorkingDay = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCosts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCosts_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCosts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCostComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostComponentNo = table.Column<int>(type: "int", nullable: false),
                    CostComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CostComponentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostComponentCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsCalculated = table.Column<bool>(type: "bit", nullable: false),
                    CalculateFormula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CostComponentAmount = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCostComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCostComponents_CostComponents_CostComponentId",
                        column: x => x.CostComponentId,
                        principalTable: "CostComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCostComponents_EmployeeCosts_EmployeeCostId",
                        column: x => x.EmployeeCostId,
                        principalTable: "EmployeeCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCostComponents_CostComponentId",
                table: "EmployeeCostComponents",
                column: "CostComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCostComponents_EmployeeCostId",
                table: "EmployeeCostComponents",
                column: "EmployeeCostId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCosts_CompanyId",
                table: "EmployeeCosts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCosts_CostCenterId",
                table: "EmployeeCosts",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCosts_EmployeeId",
                table: "EmployeeCosts",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCostComponents");

            migrationBuilder.DropTable(
                name: "EmployeeCosts");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
