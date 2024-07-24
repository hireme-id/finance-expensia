using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
			#region General
			builder
				.HasData(
					new Permission { Id = new Guid("6e19ed0e-62be-4108-a1f3-443c8b78c112"), PermissionCode = PermissionConstants.SuperPermission, PermissionDescription = "Ijin untuk akses semua endpoint", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
					new Permission { Id = new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), PermissionCode = PermissionConstants.RefreshToken, PermissionDescription = "Ijin untuk melakukan refresh token", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
					new Permission { Id = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), PermissionCode = PermissionConstants.MyPermission, PermissionDescription = "Ijin untuk mendapatkan permission", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
				);
			#endregion

			#region Master Data

			#region TransactionType
			builder
				.HasData(
					new Permission { Id = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), PermissionCode = PermissionConstants.MasterData.TransactionTypeView, PermissionDescription = "Akses untuk view transaction type", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
			#endregion

			#region Company
			builder
				.HasData(
					new Permission { Id = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), PermissionCode = PermissionConstants.MasterData.CompanyView, PermissionDescription = "Akses untuk view data company", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
			#endregion

			#region Partner
			builder
				.HasData(
					new Permission { Id = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), PermissionCode = PermissionConstants.MasterData.Partner.PartnerView, PermissionDescription = "Akses untuk view partner", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), PermissionCode = PermissionConstants.MasterData.Partner.PartnerUpsert, PermissionDescription = "Akses untuk upsert partner", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), PermissionCode = PermissionConstants.MasterData.Partner.PartnerDelete, PermissionDescription = "Akses untuk delete partner", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
			#endregion

			#region Bank Alias
			builder
				.HasData(
					new Permission { Id = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), PermissionCode = PermissionConstants.MasterData.BankAlias.BankAliasView, PermissionDescription = "Akses untuk view bank alias", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), PermissionCode = PermissionConstants.MasterData.BankAlias.BankAliasUpsert, PermissionDescription = "Akses untuk upsert bank alias", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), PermissionCode = PermissionConstants.MasterData.BankAlias.BankAliasDelete, PermissionDescription = "Akses untuk delete bank alias", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
			#endregion

			#region Chart Of Account
			builder
				.HasData(
					new Permission { Id = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), PermissionCode = PermissionConstants.MasterData.Coa.CoaView, PermissionDescription = "Akses untuk view coa", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), PermissionCode = PermissionConstants.MasterData.Coa.CoaUpsert, PermissionDescription = "Akses untuk upsert coa", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), PermissionCode = PermissionConstants.MasterData.Coa.CoaDelete, PermissionDescription = "Akses untuk delete coa", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
			#endregion

			#region Cost Center
			builder
				.HasData(
					new Permission { Id = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), PermissionCode = PermissionConstants.MasterData.CostCenter.CostCenterView, PermissionDescription = "Akses untuk view cost center", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
                    new Permission { Id = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), PermissionCode = PermissionConstants.MasterData.CostCenter.CostCenterUpsert, PermissionDescription = "Akses untuk upsert cost center", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
                    new Permission { Id = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), PermissionCode = PermissionConstants.MasterData.CostCenter.CostCenterDelete, PermissionDescription = "Akses untuk delete cost center", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
                );
			#endregion

			#endregion

			#region Outgoing Payment
			builder
			   .HasData(
				   new Permission { Id = new Guid("f5de4a8f-3b4d-4269-869e-65d72e52acec"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument, PermissionDescription = "Akses untuk view data outgoing payment atas dokumen yang dibuat sendiri", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
				   new Permission { Id = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionDescription = "Akses untuk view data outgoing payment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
				   new Permission { Id = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert, PermissionDescription = "Akses untuk melakukan insert dan update data outgoing payment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
				   new Permission { Id = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), PermissionCode = PermissionConstants.OutgoingPayment.OutgoingPaymentDelete, PermissionDescription = "Akses untuk melakukan delete data outgoing payment", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
			   );
			#endregion

			#region ApprovalInbox
			builder
				.HasData(
					new Permission { Id = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), PermissionCode = PermissionConstants.ApprovalInbox.ApprovalInboxView, PermissionDescription = "Akses untuk view data approval inbox", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
					new Permission { Id = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), PermissionCode = PermissionConstants.ApprovalInbox.ApprovalInboxUpdate, PermissionDescription = "Akses untuk melakukan update data approval inbox", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
					new Permission { Id = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), PermissionCode = PermissionConstants.ApprovalInbox.ApprovalInboxDelete, PermissionDescription = "Akses untuk melakukan delete data approval inbox", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
				);
            #endregion

            #region ApprovalRule
            builder
                .HasData(
                    new Permission { Id = new Guid("99cb47e1-28b1-46ee-a90d-b87e195b21a1"), PermissionCode = PermissionConstants.Rule.ApprovalRuleView, PermissionDescription = "Akses untuk view data approval rule", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("96f688f8-797a-49ef-8e6c-f29c40c67f76"), PermissionCode = PermissionConstants.Rule.ApprovalRuleUpsert, PermissionDescription = "Akses untuk melakukan update data approval rule", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) },
                    new Permission { Id = new Guid("692f63e0-eba2-4f81-8d60-52b387b37585"), PermissionCode = PermissionConstants.Rule.ApprovalRuleDelete, PermissionDescription = "Akses untuk melakukan delete data approval rule", Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372) }
                );
            #endregion

            #region Storage
            builder
                .HasData(
					new Permission { Id = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), PermissionCode = PermissionConstants.Storage.StorageUpload, PermissionDescription = "Akses untuk upload file", Created = new DateTime(2024, 4, 12, 0, 0, 0) },
					new Permission { Id = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), PermissionCode = PermissionConstants.Storage.StorageDownload, PermissionDescription = "Akses untuk download file", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
				);
			#endregion

            #region Workflow History
            builder
                .HasData(
                    new Permission { Id = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), PermissionCode = PermissionConstants.WorkflowHistory.WorkflowHistoryView, PermissionDescription = "Akses untuk view data workflow history", Created = new DateTime(2024, 4, 12, 0, 0, 0) }
                );
            #endregion
		}
	}
}
