using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
	public class OutgoingPaymentTaggingEntityBuilder : EntityBaseBuilder<OutgoingPaymentTagging>
	{
		public override void Configure(EntityTypeBuilder<OutgoingPaymentTagging> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.TagValue)
				.HasMaxLength(200);

			builder
				.HasOne(e => e.OutgoingPayment)
				.WithMany(e => e.OutgoingPaymentTaggings)
				.HasForeignKey(e => e.OutgoingPaymentId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
