using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class CompanyEntityBuilder : EntityBaseBuilder<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.CompanyCode)
                .HasMaxLength(25);

            builder
                .Property(e => e.CompanyName)
                .HasMaxLength(150);

            builder
                .Property(e => e.Description)
                .HasMaxLength(200);

            builder
                .Property(e => e.Address)
                .HasMaxLength(250);

            builder
                .HasMany(e => e.ChartOfAccounts)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.CostCenters)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.UserCompanies)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
