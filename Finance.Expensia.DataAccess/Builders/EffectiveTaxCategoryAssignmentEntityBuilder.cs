using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class EffectiveTaxCategoryAssignmentEntityBuilder : EntityBaseBuilder<EffectiveTaxCategoryAssignment>
    {
        public override void Configure(EntityTypeBuilder<EffectiveTaxCategoryAssignment> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.NonTaxableIncome)
                .HasConversion<string>()
                .HasMaxLength(5);

            builder
                .Property(e => e.EffectiveTaxCategory)
                .HasConversion<string>()
                .HasMaxLength(25);

            builder
                .HasIndex(e => new { e.NonTaxableIncome, e.EffectiveTaxCategory })
                .IsUnique();

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<EffectiveTaxCategoryAssignment> builder)
        {
            builder.HasData(
                new EffectiveTaxCategoryAssignment { Id = new Guid("3537701a-9ad0-4054-8df6-68c1d899890c"), NonTaxableIncome = NonTaxableIncome.TK0, EffectiveTaxCategory = EffectiveTaxCategory.A, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },
                new EffectiveTaxCategoryAssignment { Id = new Guid("80b13c4e-355a-489b-8157-1931e63c15a1"), NonTaxableIncome = NonTaxableIncome.TK1, EffectiveTaxCategory = EffectiveTaxCategory.A, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },
                new EffectiveTaxCategoryAssignment { Id = new Guid("62dbf9f5-fef0-4b0e-b0cb-38053f1508ce"), NonTaxableIncome = NonTaxableIncome.TK2, EffectiveTaxCategory = EffectiveTaxCategory.B, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },
                new EffectiveTaxCategoryAssignment { Id = new Guid("c69d1233-797a-4ddf-8dd7-e56f7b8ad781"), NonTaxableIncome = NonTaxableIncome.TK3, EffectiveTaxCategory = EffectiveTaxCategory.B, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },

                new EffectiveTaxCategoryAssignment { Id = new Guid("47952a3f-5971-4de1-967e-7e3dfff8f2ba"), NonTaxableIncome = NonTaxableIncome.K0, EffectiveTaxCategory = EffectiveTaxCategory.A, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },
                new EffectiveTaxCategoryAssignment { Id = new Guid("a8f900c0-1a38-4a24-a45b-9f7aa630074a"), NonTaxableIncome = NonTaxableIncome.K1, EffectiveTaxCategory = EffectiveTaxCategory.B, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },
                new EffectiveTaxCategoryAssignment { Id = new Guid("b1d7a3bf-3548-4ba7-8e0b-a98a1d712a29"), NonTaxableIncome = NonTaxableIncome.K2, EffectiveTaxCategory = EffectiveTaxCategory.B, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 },
                new EffectiveTaxCategoryAssignment { Id = new Guid("00637935-bfea-4604-ad8a-843f5b0c8c53"), NonTaxableIncome = NonTaxableIncome.K3, EffectiveTaxCategory = EffectiveTaxCategory.C, Created = new DateTime(2024, 11, 6, 9, 33, 0, DateTimeKind.Utc), RowStatus = 0 }
            );
        }
    }
}
