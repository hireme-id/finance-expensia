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
					new AppConfig { Id = new Guid("d22dfd1c-44ee-46e7-8329-ad7041a99bb9"), Key = "MaximumFileSize", Value = "1000000", Modul = "Storage", StartDate = new DateTime(2024, 6, 10, 0, 0, 0, DateTimeKind.Utc).AddTicks(0), Created = new DateTime(2024, 6, 10, 0, 0, 0, DateTimeKind.Utc).AddTicks(0), CreatedBy = "SYSTEM" }
				);
		}
	}
}
