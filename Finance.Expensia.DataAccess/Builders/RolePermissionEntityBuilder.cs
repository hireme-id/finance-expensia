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
    public class RolePermissionEntityBuilder : EntityBaseBuilder<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<RolePermission> builder)
        {
            //Initial Db
            builder
                .HasData(
                    new RolePermission { Id = new Guid("0cf91c77-4a12-4547-bac2-695d0f14741a"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("cfdceb82-2708-4dcc-a4e4-90aa76db8ea7"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
                );
        }
    }
}
