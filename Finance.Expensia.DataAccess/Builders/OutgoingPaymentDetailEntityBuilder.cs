﻿using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.DataAccess.Builders
{
    public class OutgoingPaymentDetailEntityBuilder : EntityBaseBuilder<OutgoingPaymentDetail>
    {
        public override void Configure(EntityTypeBuilder<OutgoingPaymentDetail> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.PartnerName)
                .HasMaxLength(200);

            builder
                .Property(e => e.Description)
                .HasMaxLength(200);

            builder
                .Property(e => e.ChartOfAccountNo)
                .HasMaxLength(150);

            builder
                .Property(e => e.CostCenterName)
                .HasMaxLength(200);

            builder
                .Property(e => e.Amount)
                .HasColumnType("money");

            builder
                .HasOne(e => e.OutgoingPayment)
                .WithMany(e => e.OutgoingPaymentDetails)
                .HasForeignKey(e => e.OutgoingPaymentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}