using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class UserCompanyRoleEntityBuilder : EntityBaseBuilder<UserCompanyRole>
    {
        public override void Configure(EntityTypeBuilder<UserCompanyRole> builder)
        {
            base.Configure(builder);
        }
    }
}
