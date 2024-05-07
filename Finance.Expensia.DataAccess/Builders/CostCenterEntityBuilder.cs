using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class CostCenterEntityBuilder : EntityBaseBuilder<CostCenter>
    {
        public override void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.CostCenterCode)
                .HasMaxLength(150);

            builder
                .Property(e => e.CostCenterName)
                .HasMaxLength(250);
        }    
    }
}
