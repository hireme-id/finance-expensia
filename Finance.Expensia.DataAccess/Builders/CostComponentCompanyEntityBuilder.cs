using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class CostComponentCompanyEntityBuilder : EntityBaseBuilder<CostComponentCompany>
    {
        public override void Configure(EntityTypeBuilder<CostComponentCompany> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(e => e.Company)
                .WithMany(e => e.CostComponentCompanies)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.ChartOfAccount)
                .WithMany(e => e.CostComponentCompanies)
                .HasForeignKey(e => e.ChartOfAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
