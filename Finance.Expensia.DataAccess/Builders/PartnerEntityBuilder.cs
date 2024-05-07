using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class PartnerEntityBuilder : EntityBaseBuilder<Partner>
    {
        public override void Configure(EntityTypeBuilder<Partner> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.PartnerName)
                .HasMaxLength(150);

            builder
                .Property(e => e.Description)
                .HasMaxLength(250);
        }    
    }
}
