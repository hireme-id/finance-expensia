using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCostComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostComponentNo = table.Column<int>(type: "int", nullable: false),
                    CostComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CostComponentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostComponentCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsCalculated = table.Column<bool>(type: "bit", nullable: false),
                    CalculateFormula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostComponentCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChartOfAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostComponentCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostComponentCompanies_ChartOfAccounts_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostComponentCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostComponentCompanies_CostComponents_CostComponentId",
                        column: x => x.CostComponentId,
                        principalTable: "CostComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CostComponents",
                columns: new[] { "Id", "CalculateFormula", "CostComponentCategory", "CostComponentName", "CostComponentNo", "CostComponentType", "Created", "CreatedBy", "IsActive", "IsCalculated", "IsVisible", "Modified", "ModifiedBy", "Remark", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("0823f31b-4b54-4776-997d-4dac67447da5"), "[10000] + [11000] + [11100] + [11200] + [11300] + [11400] + [12000] + [13000]", "MonthlyEarningBenefit", "Total Gross", 19000, "SubTotal", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "", 0 },
                    { new Guid("1295d083-8086-447b-9cc0-6caa1c5266ff"), "[90000] * 12 + [31000] + [32000] + [40000] + [41000] + [42000] + [43000] + [44000] + [59000] * 12", "Total", "Annual COGS", 91000, "Total", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, false, null, null, "", 0 },
                    { new Guid("19f8c778-4e36-4388-b277-441b5d952499"), "[10000] * 0.057", "GovernmentDeduction", "Pembayaran JHT 5,7%", 51100, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("215a6ac2-ac8c-4c39-8a7c-bb80247b2b70"), "[10000]", "YearlyBenefit", "Tunjangan Hari Raya", 32000, "Yearly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Gross, proporsional sesuai masa kerja", 0 },
                    { new Guid("21ffa1c8-da11-449b-9115-bb0733dbfa97"), "", "OtherBenefit", "Laptop", 44000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Non Taxable", 0 },
                    { new Guid("34ae40aa-f58d-4d37-8e26-f907a17fd6eb"), "if([10000] < 12000000, [1000] * 0.04, 12000000 * 0.04)", "MonthlyDeductionBenefit", "Potongan BPJS Kesehatan Company (4%)", 20100, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("36fa5613-e62a-4fc2-af9a-f7e78352064c"), "", "MonthlyEarningBenefit", "Tunjangan Posisi", 11400, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Gross", 0 },
                    { new Guid("382a396b-27b1-47da-b1f1-f1a7bb04972b"), "[10000] * 0.054", "MonthlyDeductionBenefit", "Potongan JKK+JKM (0,54%)", 21000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("39a90879-49d6-4700-a4d1-8faed4cadbfd"), "", "MonthlyEarningBenefit", "Gaji Pokok", 10000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Gross", 0 },
                    { new Guid("3ac51195-8f85-4e3b-948a-be66d76a359c"), "[19000] * [TaxRate]", "GovernmentDeduction", "Pembayaran Pajak [NonTaxableIncome] / [EffectiveTaxCategory]", 52000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction, dapat berubah tergantung dari pendapatan di bulan tersebut", 0 },
                    { new Guid("40c9089b-28ec-4a42-a646-ead837047274"), "62500", "OtherBenefit", "Liability", 43000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Non Taxable", 0 },
                    { new Guid("44e1e8ba-f73b-43a1-ad5c-972209d3dc78"), "[19000] * [TaxRate]", "MonthlyDeductionBenefit", "Potongan Pajak [NonTaxableIncome] / [EffectiveTaxCategory]", 22000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction, dapat berubah tergantung dari pendapatan di bulan tersebut", 0 },
                    { new Guid("477ae51c-830f-471f-8c35-d002adf21925"), "", "OtherBenefit", "Asuransi", 41000, "Yearly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Non Taxable", 0 },
                    { new Guid("56baf335-7326-455d-a9bb-517eafcbc4d3"), "[20000] + [20100] + [21000] + [21100] + [21200] + [22200]", "MonthlyDeductionBenefit", "Total Potongan", 29000, "SubTotal", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "", 0 },
                    { new Guid("56d9aee8-1346-419e-a209-e516a1e3f7e0"), "[10000] * 0.01", "MonthlyDeductionBenefit", "Potongan BPJS Kesehatan 1%", 20000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("5a3e4b7c-3d08-412e-92a8-bb34d94bcd6d"), "if([EmployeeType] == 2, [10000] * 0.03, 0)", "GovernmentDeduction", "Pembayaran JP 3%", 51200, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("5e232aab-e64a-4cd8-b29c-72c9164df293"), "", "MonthlyEarningBenefit", "Tunjangan Kompetensi", 11200, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Gross", 0 },
                    { new Guid("66975408-6a57-4d2a-8826-89bb6d23ad24"), "", "MonthlyEarningBenefit", "Tunjangan Makan", 11000, "Daily", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Gross", 0 },
                    { new Guid("881e1072-5bc8-4fc9-95cb-21b8983f05a5"), "", "MonthlyEarningBenefit", "Tunjangan Transportasi", 11100, "Daily", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Gross", 0 },
                    { new Guid("90c8198b-8038-4cda-940e-7033c00bcbac"), "[19000] - [29000]", "Total", "Take Home Pay", 90000, "Total", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, false, null, null, "Estimation", 0 },
                    { new Guid("95e89bc6-b98b-4bb0-8543-111568bf6f4b"), "380000", "OtherBenefit", "Welfare", 42000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Non Taxable", 0 },
                    { new Guid("9dc90145-46a7-47a1-9610-f8fa5ca9b5ea"), "[ROUNDUP]([91000] / 12, -5)", "Total", "Monthly COGS", 92000, "Total", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, false, null, null, "", 0 },
                    { new Guid("ab55b484-c9b3-49fb-8692-d72374d793c3"), "if([EmployeeType] == 2, [10000] * 0.01, 0)", "MonthlyDeductionBenefit", "Potongan JP 1%", 21200, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("adf2853f-3b7e-4f8e-9885-9e7a451600cf"), "if([10000] > 12000000, [10000] * 0.05, 0)", "GovernmentDeduction", "Pembayaran BPJS Kesehatan 5%", 50000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("b9ccc7eb-79ec-4ddc-aa6a-c6646de95935"), "[50000] + [51000] + [51100] + [51200] + [52000]", "GovernmentDeduction", "Total Pembayaran Goverment ", 59000, "SubTotal", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "", 0 },
                    { new Guid("bed577bb-faf2-4a03-bb99-2c72cfbc5cee"), "[10000] * 0.054", "MonthlyEarningBenefit", "JKK+JKM (0,54%)", 13000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Benefit", 0 },
                    { new Guid("c8beedaf-1f15-4adb-9bf9-5c12e3100599"), "[1000] * 0.02", "MonthlyDeductionBenefit", "Potongan JHT 2%", 21100, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("ca186eb7-2745-49dd-a882-3212c94c534d"), "if([10000] < 12000000, [1000] * 0.04, 12000000 * 0.04)", "MonthlyEarningBenefit", "BPJS Kesehatan Company (4%)", 12000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Benefit", 0 },
                    { new Guid("dd71e2c2-d6dc-4b3c-aa73-fa0dcd5f2ca1"), "[10000] * 0.0054", "GovernmentDeduction", "Pembayaran JKK+JKM 0,54%", 51000, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Deduction", 0 },
                    { new Guid("e589d8c7-6f76-4c7e-82c5-66b574752915"), "", "MonthlyEarningBenefit", "Tunjangan Project", 11300, "Monthly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Gross", 0 },
                    { new Guid("eb2366dd-6ce4-44e0-849f-47e4f7bd7282"), "", "OtherBenefit", "Kesehatan", 40000, "Yearly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, false, true, null, null, "Non Taxable", 0 },
                    { new Guid("f5138e49-ec02-43fd-885d-b1dd01789af4"), "[10000]", "YearlyBenefit", "Uang Kompensasi", 31000, "Yearly", new DateTime(2024, 11, 8, 12, 56, 0, 0, DateTimeKind.Utc), "", true, true, true, null, null, "Gross, proporsional sesuai masa kontrak", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostComponentCompanies_ChartOfAccountId",
                table: "CostComponentCompanies",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CostComponentCompanies_CompanyId",
                table: "CostComponentCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CostComponentCompanies_CostComponentId",
                table: "CostComponentCompanies",
                column: "CostComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostComponentCompanies");

            migrationBuilder.DropTable(
                name: "CostComponents");
        }
    }
}
