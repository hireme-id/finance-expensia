using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class TransactionTypeEntityBuilder : EntityBaseBuilder<TransactionType>
    {
        public override void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.Description)
                .HasMaxLength(200);

            builder
                .HasMany(e => e.OutgoingPayments)
                .WithOne(e => e.TransactionType)
                .HasForeignKey(e => e.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
