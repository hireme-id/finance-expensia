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
    public class ApprovalInboxEntityBuilder : EntityBaseBuilder<ApprovalInbox>
    {
        public override void Configure(EntityTypeBuilder<ApprovalInbox> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.TransactionNo)
                .HasMaxLength(200);

            builder
                .Property(e => e.ApprovalStatus)
                .HasConversion<string>()
                .HasMaxLength(200);

            builder
                .Property(e => e.ApprovalRoleCode)
                .HasMaxLength(30);
        }
    }
}
