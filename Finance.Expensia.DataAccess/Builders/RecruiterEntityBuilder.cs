using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
	public class RecruiterEntityBuilder : EntityBaseBuilder<Recruiter>
	{
		public override void Configure(EntityTypeBuilder<Recruiter> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.RecruiterCode)
				.HasMaxLength(5);

			builder
				.HasOne(e => e.User)
				.WithOne(e => e.Recruiter)
				.HasForeignKey<Recruiter>(e => e.UserId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
