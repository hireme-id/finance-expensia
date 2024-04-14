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
    public class OutgoingPaymentDetailAttachmentEntityBuilder : EntityBaseBuilder<OutgoingPaymentDetailAttachment>
    {
        public override void Configure(EntityTypeBuilder<OutgoingPaymentDetailAttachment> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.FileName)
                .HasMaxLength(150);

            builder
                .Property(e => e.FileUrl)
                .HasMaxLength(200);

            builder
                .Property(e => e.ContentType)
                .HasMaxLength(150);

            builder
                .HasOne(e => e.OutgoingPaymentDetail)
                .WithMany(e => e.OutgoingPaymentDetailAttachments)
                .HasForeignKey(e => e.OutgoingPaymentDetailId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
