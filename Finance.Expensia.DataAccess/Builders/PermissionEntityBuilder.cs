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

            //Outgoing Payment
            builder
                .HasData(
                    new Permission { Id = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionDescription = "Akses untuk view data outgoing payment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert, PermissionDescription = "Akses untuk melakukan insert dan update data outgoing payment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentDelete, PermissionDescription = "Akses untuk melakukan delete data outgoing payment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
                );

            //ApprovalInbox
            builder
                .HasData(
                    new Permission { Id = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), PermissionCode = PermissionConstants.ApprovalInbox.ApprovalInboxView, PermissionDescription = "Akses untuk view data approval inbox", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), PermissionCode = PermissionConstants.ApprovalInbox.ApprovalInboxUpdate, PermissionDescription = "Akses untuk melakukan update data approval inbox", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), PermissionCode = PermissionConstants.ApprovalInbox.ApprovalInboxDelete, PermissionDescription = "Akses untuk melakukan delete data approval inbox", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
                );

            //MasterData
            builder
                .HasData(
                    new Permission { Id = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), PermissionCode = PermissionConstants.MasterData.CompanyView, PermissionDescription = "Akses untuk view data company", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
                    new Permission { Id = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), PermissionCode = PermissionConstants.MasterData.BankAliasView, PermissionDescription = "Akses untuk view bank alias", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), PermissionCode = PermissionConstants.MasterData.PartnerView, PermissionDescription = "Akses untuk view partner", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), PermissionCode = PermissionConstants.MasterData.CoaView, PermissionDescription = "Akses untuk view coa", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), PermissionCode = PermissionConstants.MasterData.CostCenterView, PermissionDescription = "Akses untuk view cost center", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);

            //Storage
            builder
                .HasData(
					new Permission { Id = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), PermissionCode = PermissionConstants.Storage.StorageUpload, PermissionDescription = "Akses untuk upload file", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), PermissionCode = PermissionConstants.Storage.StorageDownload, PermissionDescription = "Akses untuk download file", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
        }
    }
}
