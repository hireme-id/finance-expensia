using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Finance.Expensia.DataAccess.Builders
{
    public class ApprovalRuleEntityBuilder : EntityBaseBuilder<ApprovalRule>
    {
        public override void Configure(EntityTypeBuilder<ApprovalRule> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.MinAmount)
                .HasColumnType("money");

            builder
                .Property(e => e.MaxAmount)
                .HasColumnType("money");

            builder
                .Property(e => e.RoleCode)
                .HasMaxLength(30);
        }
    }
}
