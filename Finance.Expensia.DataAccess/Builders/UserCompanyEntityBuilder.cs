using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class UserCompanyEntityBuilder : EntityBaseBuilder<UserCompany>
    {
        public override void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            base.Configure(builder);
        }
    }
}
