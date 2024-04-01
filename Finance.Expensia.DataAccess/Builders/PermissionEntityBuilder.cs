using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Builders
{
    internal class PermissionEntityBuilder : EntityBaseBuilder<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.PermissionCode)
                .HasMaxLength(50);

            builder
                .Property(e => e.PermissionDescription)
                .HasMaxLength(100);
        }
    }
}
