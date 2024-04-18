﻿using Finance.Expensia.DataAccess.Bases;
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
    public class ApprovalHistoryEntityBuilder : EntityBaseBuilder<ApprovalHistory>
    {
        public override void Configure(EntityTypeBuilder<ApprovalHistory> builder)
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

            builder
                .Property(e => e.ApprovalRoleDesc)
                .HasMaxLength(100);

            builder
                .Property(e => e.ApprovalName)
                .HasMaxLength(150);
        }
    }
}