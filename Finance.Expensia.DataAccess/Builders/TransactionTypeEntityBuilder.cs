using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class TransactionTypeEntityBuilder : EntityBaseBuilder<TransactionType>
    {
        public override void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.TransactionTypeCode)
                .HasMaxLength(15);

            builder
                .Property(e => e.Description)
                .HasMaxLength(200);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<TransactionType> builder)
        {
            // InitialDb
            builder
                .HasData(
                    new TransactionType { Id = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), TransactionTypeCode = "PAY", Description = "Payroll", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
                    new TransactionType { Id = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), TransactionTypeCode = "REM", Description = "Reimbursment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
                    new TransactionType { Id = new Guid("3daf8acf-70d6-40b7-bf5f-2fb2f6ba9b31"), TransactionTypeCode = "CAD", Description = "Cash Advance", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) }
                );
        }
    }
}
