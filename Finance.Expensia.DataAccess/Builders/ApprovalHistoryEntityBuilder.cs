using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
                .Property(e => e.ExecutorRoleCode)
                .HasMaxLength(30);

            builder
                .Property(e => e.ExecutorRoleDesc)
                .HasMaxLength(100);

            builder
                .Property(e => e.ExecutorName)
                .HasMaxLength(150);

            builder
                .Property(e => e.Remark)
                .HasMaxLength(300);

            builder
                .Property(e => e.MinAmount)
                .HasColumnType("money");

            builder
                .Property(e => e.MaxAmount)
                .HasColumnType("money");
        }
    }
}
