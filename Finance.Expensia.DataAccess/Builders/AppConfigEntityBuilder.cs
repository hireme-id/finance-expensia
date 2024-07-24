using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
	public class AppConfigEntityBuilder : EntityBaseBuilder<AppConfig>
	{
		public override void Configure(EntityTypeBuilder<AppConfig> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.Key)
				.HasMaxLength(50);

			builder
				.Property(e => e.Value)
				.HasMaxLength(2000);

			builder
				.Property(e => e.Modul)
				.HasConversion<string>()
				.HasMaxLength(50);

			SeedingData(builder);
		}

		private static void SeedingData(EntityTypeBuilder<AppConfig> builder)
		{
			builder
				.HasData(
					new AppConfig { Id = new Guid("d22dfd1c-44ee-46e7-8329-ad7041a99bb9"), Key = "MaximumFileSize", Value = "1000000", Modul = "Storage", Created = new DateTime(2024, 6, 10, 0, 0, 0, DateTimeKind.Utc).AddTicks(0), CreatedBy = "SYSTEM" }
				);

			// Add seeding data with Key = "EmailForRequestor", Modul = "EmailNotification"
			builder
				.HasData(
					new AppConfig { Id = new Guid("03ccfb2a-971a-4103-9c5d-6165af915388"), Key = "EmailForRequestor", Value = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>Notifikasi Outgoing Payment</title>\r\n</head>\r\n<body>\r\n    <p>Dear Mr/Ms {{toName}},</p>\r\n    <p>\r\n        Dokumen outgoing payment dengan nomor <a href=\"{{linkDocument}}\" target=\"_blank\"><strong>{{documentNo}}</strong></a> {{remark}} telah di <strong>{{action}}</strong> oleh <strong>{{executorName}}</strong>.{{rejectReason}}\r\n</p>\r\n<p>Terima kasih.</p>\r\n</body>\r\n</html>", Modul = "EmailNotification", Created = new DateTime(2024, 6, 10, 0, 0, 0, DateTimeKind.Utc).AddTicks(0), CreatedBy = "SYSTEM" }
                );
		}
	}
}
