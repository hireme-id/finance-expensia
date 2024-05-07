using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class DocNumberConfigEntityBuilder : EntityBaseBuilder<DocNumberConfig>
    {
        public override void Configure(EntityTypeBuilder<DocNumberConfig> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.TransactionTypeCode)
                .HasMaxLength(15);

            builder
                .Property(e => e.CompanyCode)
                .HasMaxLength(25);
        }
    }
}
