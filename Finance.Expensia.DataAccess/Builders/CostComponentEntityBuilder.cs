using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class CostComponentEntityBuilder : EntityBaseBuilder<CostComponent>
    {
        public override void Configure(EntityTypeBuilder<CostComponent> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.CostComponentName)
                .HasMaxLength(100);

            builder
                .Property(e => e.Remark)
                .HasMaxLength(100);

            builder
                .Property(e => e.CalculateFormula)
                .HasMaxLength(200);

            builder
                .Property(e => e.CostComponentType)
                .HasConversion<string>()
                .HasMaxLength(10);

            builder
                .Property(e => e.CostComponentCategory)
                .HasConversion<string>()
                .HasMaxLength(25);

            builder
                .HasMany(e => e.CostComponentCompanies)
                .WithOne(e => e.CostComponent)
                .HasForeignKey(e => e.CostComponentId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<CostComponent> builder)
        {
            builder.HasData(
                new CostComponent { Id = new Guid("39a90879-49d6-4700-a4d1-8faed4cadbfd"), CostComponentNo = 10000, CostComponentName = "Gaji Pokok", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Gross", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("66975408-6a57-4d2a-8826-89bb6d23ad24"), CostComponentNo = 11000, CostComponentName = "Tunjangan Makan", CostComponentType = CostComponentType.Daily, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Gross", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("881e1072-5bc8-4fc9-95cb-21b8983f05a5"), CostComponentNo = 11100, CostComponentName = "Tunjangan Transportasi", CostComponentType = CostComponentType.Daily, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Gross", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("5e232aab-e64a-4cd8-b29c-72c9164df293"), CostComponentNo = 11200, CostComponentName = "Tunjangan Kompetensi", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Gross", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("e589d8c7-6f76-4c7e-82c5-66b574752915"), CostComponentNo = 11300, CostComponentName = "Tunjangan Project", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Gross", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("36fa5613-e62a-4fc2-af9a-f7e78352064c"), CostComponentNo = 11400, CostComponentName = "Tunjangan Posisi", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Gross", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("ca186eb7-2745-49dd-a882-3212c94c534d"), CostComponentNo = 12000, CostComponentName = "BPJS Kesehatan Company (4%)", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Benefit", IsCalculated = true, CalculateFormula = "if([10000] < 12000000, [1000] * 0.04, 12000000 * 0.04)", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("bed577bb-faf2-4a03-bb99-2c72cfbc5cee"), CostComponentNo = 13000, CostComponentName = "JKK+JKM (0,54%)", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "Benefit", IsCalculated = true, CalculateFormula = "[10000] * 0.054", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("0823f31b-4b54-4776-997d-4dac67447da5"), CostComponentNo = 19000, CostComponentName = "Total Gross", CostComponentType = CostComponentType.SubTotal, CostComponentCategory = CostComponentCategory.MonthlyEarningBenefit, Remark = "", IsCalculated = true, CalculateFormula = "[10000] + [11000] + [11100] + [11200] + [11300] + [11400] + [12000] + [13000]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },

                new CostComponent { Id = new Guid("56d9aee8-1346-419e-a209-e516a1e3f7e0"), CostComponentNo = 20000, CostComponentName = "Potongan BPJS Kesehatan 1%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "Deduction", IsCalculated = true, CalculateFormula = "[10000] * 0.01", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("34ae40aa-f58d-4d37-8e26-f907a17fd6eb"), CostComponentNo = 20100, CostComponentName = "Potongan BPJS Kesehatan Company (4%)", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "Deduction", IsCalculated = true, CalculateFormula = "if([10000] < 12000000, [1000] * 0.04, 12000000 * 0.04)", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("382a396b-27b1-47da-b1f1-f1a7bb04972b"), CostComponentNo = 21000, CostComponentName = "Potongan JKK+JKM (0,54%)", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "Deduction", IsCalculated = true, CalculateFormula = "[10000] * 0.054", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("c8beedaf-1f15-4adb-9bf9-5c12e3100599"), CostComponentNo = 21100, CostComponentName = "Potongan JHT 2%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "Deduction", IsCalculated = true, CalculateFormula = "[1000] * 0.02", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("ab55b484-c9b3-49fb-8692-d72374d793c3"), CostComponentNo = 21200, CostComponentName = "Potongan JP 1%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "Deduction", IsCalculated = true, CalculateFormula = "if([EmployeeType] == 2, [10000] * 0.01, 0)", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("44e1e8ba-f73b-43a1-ad5c-972209d3dc78"), CostComponentNo = 22000, CostComponentName = "Potongan Pajak [NonTaxableIncome] / [EffectiveTaxCategory]", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "Deduction, dapat berubah tergantung dari pendapatan di bulan tersebut", IsCalculated = true, CalculateFormula = "[19000] * [TaxRate]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("56baf335-7326-455d-a9bb-517eafcbc4d3"), CostComponentNo = 29000, CostComponentName = "Total Potongan", CostComponentType = CostComponentType.SubTotal, CostComponentCategory = CostComponentCategory.MonthlyDeductionBenefit, Remark = "", IsCalculated = true, CalculateFormula = "[20000] + [20100] + [21000] + [21100] + [21200] + [22200]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },

                new CostComponent { Id = new Guid("90c8198b-8038-4cda-940e-7033c00bcbac"), CostComponentNo = 90000, CostComponentName = "Take Home Pay", CostComponentType = CostComponentType.Total, CostComponentCategory = CostComponentCategory.Total, Remark = "Estimation", IsCalculated = true, CalculateFormula = "[19000] - [29000]", IsActive = true, IsVisible = false, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },

                new CostComponent { Id = new Guid("f5138e49-ec02-43fd-885d-b1dd01789af4"), CostComponentNo = 31000, CostComponentName = "Uang Kompensasi", CostComponentType = CostComponentType.Yearly, CostComponentCategory = CostComponentCategory.YearlyBenefit, Remark = "Gross, proporsional sesuai masa kontrak", IsCalculated = true, CalculateFormula = "[10000]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("215a6ac2-ac8c-4c39-8a7c-bb80247b2b70"), CostComponentNo = 32000, CostComponentName = "Tunjangan Hari Raya", CostComponentType = CostComponentType.Yearly, CostComponentCategory = CostComponentCategory.YearlyBenefit, Remark = "Gross, proporsional sesuai masa kerja", IsCalculated = true, CalculateFormula = "[10000]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },

                new CostComponent { Id = new Guid("eb2366dd-6ce4-44e0-849f-47e4f7bd7282"), CostComponentNo = 40000, CostComponentName = "Kesehatan", CostComponentType = CostComponentType.Yearly, CostComponentCategory = CostComponentCategory.OtherBenefit, Remark = "Non Taxable", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("477ae51c-830f-471f-8c35-d002adf21925"), CostComponentNo = 41000, CostComponentName = "Asuransi", CostComponentType = CostComponentType.Yearly, CostComponentCategory = CostComponentCategory.OtherBenefit, Remark = "Non Taxable", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("95e89bc6-b98b-4bb0-8543-111568bf6f4b"), CostComponentNo = 42000, CostComponentName = "Welfare", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.OtherBenefit, Remark = "Non Taxable", IsCalculated = true, CalculateFormula = "380000", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("40c9089b-28ec-4a42-a646-ead837047274"), CostComponentNo = 43000, CostComponentName = "Liability", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.OtherBenefit, Remark = "Non Taxable", IsCalculated = true, CalculateFormula = "62500", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("21ffa1c8-da11-449b-9115-bb0733dbfa97"), CostComponentNo = 44000, CostComponentName = "Laptop", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.OtherBenefit, Remark = "Non Taxable", IsCalculated = false, CalculateFormula = string.Empty, IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },

                new CostComponent { Id = new Guid("adf2853f-3b7e-4f8e-9885-9e7a451600cf"), CostComponentNo = 50000, CostComponentName = "Pembayaran BPJS Kesehatan 5%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.GovernmentDeduction, Remark = "Deduction", IsCalculated = true, CalculateFormula = "if([10000] > 12000000, [10000] * 0.05, 0)", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("dd71e2c2-d6dc-4b3c-aa73-fa0dcd5f2ca1"), CostComponentNo = 51000, CostComponentName = "Pembayaran JKK+JKM 0,54%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.GovernmentDeduction, Remark = "Deduction", IsCalculated = true, CalculateFormula = "[10000] * 0.0054", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("19f8c778-4e36-4388-b277-441b5d952499"), CostComponentNo = 51100, CostComponentName = "Pembayaran JHT 5,7%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.GovernmentDeduction, Remark = "Deduction", IsCalculated = true, CalculateFormula = "[10000] * 0.057", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("5a3e4b7c-3d08-412e-92a8-bb34d94bcd6d"), CostComponentNo = 51200, CostComponentName = "Pembayaran JP 3%", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.GovernmentDeduction, Remark = "Deduction", IsCalculated = true, CalculateFormula = "if([EmployeeType] == 2, [10000] * 0.03, 0)", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("3ac51195-8f85-4e3b-948a-be66d76a359c"), CostComponentNo = 52000, CostComponentName = "Pembayaran Pajak [NonTaxableIncome] / [EffectiveTaxCategory]", CostComponentType = CostComponentType.Monthly, CostComponentCategory = CostComponentCategory.GovernmentDeduction, Remark = "Deduction, dapat berubah tergantung dari pendapatan di bulan tersebut", IsCalculated = true, CalculateFormula = "[19000] * [TaxRate]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("b9ccc7eb-79ec-4ddc-aa6a-c6646de95935"), CostComponentNo = 59000, CostComponentName = "Total Pembayaran Goverment ", CostComponentType = CostComponentType.SubTotal, CostComponentCategory = CostComponentCategory.GovernmentDeduction, Remark = "", IsCalculated = true, CalculateFormula = "[50000] + [51000] + [51100] + [51200] + [52000]", IsActive = true, IsVisible = true, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },

                new CostComponent { Id = new Guid("1295d083-8086-447b-9cc0-6caa1c5266ff"), CostComponentNo = 91000, CostComponentName = "Annual COGS", CostComponentType = CostComponentType.Total, CostComponentCategory = CostComponentCategory.Total, Remark = "", IsCalculated = true, CalculateFormula = "[90000] * 12 + [31000] + [32000] + [40000] + [41000] + [42000] + [43000] + [44000] + [59000] * 12", IsActive = true, IsVisible = false, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 },
                new CostComponent { Id = new Guid("9dc90145-46a7-47a1-9610-f8fa5ca9b5ea"), CostComponentNo = 92000, CostComponentName = "Monthly COGS", CostComponentType = CostComponentType.Total, CostComponentCategory = CostComponentCategory.Total, Remark = "", IsCalculated = true, CalculateFormula = "[ROUNDUP]([91000] / 12, -5)", IsActive = true, IsVisible = false, CreatedBy = "", Created = new DateTime(2024, 11, 8, 12, 56, 0, DateTimeKind.Utc), RowStatus = 0 }
            );
        }
    }
}
