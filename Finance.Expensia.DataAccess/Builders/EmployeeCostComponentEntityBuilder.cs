using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class EmployeeCostComponentEntityBuilder : EntityBaseBuilder<EmployeeCostComponent>
    {
        public override void Configure(EntityTypeBuilder<EmployeeCostComponent> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.CostComponentName)
                .HasMaxLength(100);

            builder
                .Property(e => e.Remark)
                .HasMaxLength(100);

            builder
                .Property(e => e.CalculateFormula)
                .HasMaxLength(200);

            builder
                .Property(e => e.CostComponentType)
                .HasConversion<string>()
                .HasMaxLength(10);

            builder
                .Property(e => e.CostComponentCategory)
                .HasConversion<string>()
                .HasMaxLength(25);

            builder
                .HasOne(e => e.EmployeeCost)
                .WithMany(e => e.EmployeeCostComponents)
                .HasForeignKey(e => e.EmployeeCostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.CostComponent)
                .WithMany(e => e.EmployeeCostComponents)
                .HasForeignKey(e => e.CostComponentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
