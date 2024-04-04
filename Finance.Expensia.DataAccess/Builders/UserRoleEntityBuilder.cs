using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.DataAccess.Builders
{
    public class UserRoleEntityBuilder : EntityBaseBuilder<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<UserRole> builder)
        {
            // InitialDb
            builder
                .HasData(
                    new UserRole { Id = new Guid("05b4bc20-a31f-4d5e-b739-6b6e46994976"), UserId = new Guid("11d61a5b-3236-4a35-8527-cd664d7ee230"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(9233) }
                );

        }
    }
}
