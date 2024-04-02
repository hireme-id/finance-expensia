using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class ChartOfAccountEntityBuilder : EntityBaseBuilder<ChartOfAccount>
    {
        public override void Configure(EntityTypeBuilder<ChartOfAccount> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.AccountCode)
                .HasMaxLength(150);

            builder
                .Property(e => e.AccountName)
                .HasMaxLength(250);

            builder
                .Property(e => e.AccountType)
                .HasMaxLength(150);

            builder
                .HasMany(e => e.CostCenters)
                .WithOne(e => e.ChartOfAccount)
                .HasForeignKey(e => e.ChartOfAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }    
    }
}
