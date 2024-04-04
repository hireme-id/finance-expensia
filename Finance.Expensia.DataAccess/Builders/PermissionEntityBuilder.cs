using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Finance.Expensia.DataAccess.Bases;
using Microsoft.EntityFrameworkCore;
using Finance.Expensia.Shared.Constants;

namespace Finance.Expensia.DataAccess.Builders
{
    public class PermissionEntityBuilder : EntityBaseBuilder<Permission>
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

            builder
                .HasMany(e => e.RolePermissions)
                .WithOne(e => e.Permission)
                .HasForeignKey(e => e.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<Permission> builder)
        {
            //Initial Db
            builder
                .HasData(
                    new Permission { Id = new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), PermissionCode = PermissionConstants.RefreshToken, PermissionDescription = "Ijin untuk melakukan refresh token", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), PermissionCode = PermissionConstants.MyPermission, PermissionDescription = "Ijin untuk mendapatkan permission", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
                );
        }
    }
}
