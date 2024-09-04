using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
	public class UserEntityBuilder : EntityBaseBuilder<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.Username)
				.HasMaxLength(100);

			builder
				.Property(e => e.Email)
				.HasMaxLength(100);

			builder
				.Property(e => e.Description)
				.HasMaxLength(500);

			builder
				.Property(e => e.FullName)
				.HasMaxLength(150);

			builder
				.HasMany(e => e.UserCompanies)
				.WithOne(e => e.User)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
