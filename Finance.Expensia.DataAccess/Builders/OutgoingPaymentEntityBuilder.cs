using Finance.Expensia.DataAccess.Bases;
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
    public class OutgoingPaymentEntityBuilder : EntityBaseBuilder<OutgoingPayment>
    {
        public override void Configure(EntityTypeBuilder<OutgoingPayment> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.TransactionNo)
                .HasMaxLength(200);

            builder
                .Property(e => e.Requestor)
                .HasMaxLength(200);

            builder
                .Property(e => e.CompanyName)
                .HasMaxLength(200);

            builder
                .Property(e => e.ApprovalStatus)
                .HasConversion<string>()
                .HasMaxLength(200);

            builder
                .Property(e => e.ExpectedTransfer)
                .HasConversion<string>()
                .HasMaxLength(200);

            builder
                .Property(e => e.Remark)
                .HasMaxLength(200);


            builder
                .Property(e => e.FromBankAliasName)
                .HasMaxLength(200);

            builder
                .Property(e => e.FromAccountNo)
                .HasMaxLength(200);

            builder
                .Property(e => e.ToBankAliasName)
                .HasMaxLength(200);

            builder
                .Property(e => e.ToAccountNo)
                .HasMaxLength(200);

            builder
                .Property(e => e.TotalAmount)
                .HasColumnType("money");
        }
    }
}
