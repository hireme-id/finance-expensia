using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class UserCompanyEntityBuilder : EntityBaseBuilder<UserCompany>
    {
        public override void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            base.Configure(builder);

            builder
                .HasMany(e => e.UserCompanyRoles)
                .WithOne(e => e.UserCompany)
                .HasForeignKey(e => e.UserCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
