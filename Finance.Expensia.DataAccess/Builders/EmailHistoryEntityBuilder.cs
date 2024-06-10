using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
	public class EmailHistoryEntityBuilder : EntityBaseBuilder<EmailHistory>
	{
		public override void Configure(EntityTypeBuilder<EmailHistory> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.Sender)
				.HasMaxLength(150);

			builder
				.Property(e => e.Receiver)
				.HasMaxLength(150);

			builder
				.Property(e => e.Subject)
				.HasMaxLength(150);

			builder
				.Property(e => e.Content)
				.HasMaxLength(2000);

			builder
				.Property(e => e.Error)
				.HasMaxLength(255);

			builder
				.Property(e => e.Status)
				.HasConversion<string>()
				.HasMaxLength(50);
		}
	}
}
