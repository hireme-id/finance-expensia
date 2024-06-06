using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}	
	}
}
