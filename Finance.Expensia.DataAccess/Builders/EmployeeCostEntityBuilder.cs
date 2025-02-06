using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class EmployeeCostEntityBuilder : EntityBaseBuilder<EmployeeCost>
    {
        public override void Configure(EntityTypeBuilder<EmployeeCost> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.OfferingDate)
                .HasColumnType("date");

            builder
                .Property(e => e.JobPosition)
                .HasMaxLength(100);

            builder
                .Property(e => e.EmployeeStatus)
                .HasConversion<string>()
                .HasMaxLength(10);

            builder
                .Property(e => e.JoinDate)
                .HasColumnType("date");

            builder
                .Property(e => e.EndDate)
                .HasColumnType("date");

            builder
                .Property(e => e.NonTaxableIncome)
                .HasConversion<string>()
                .HasMaxLength(5);

            builder
                .Property(e => e.EffectiveTaxCategory)
                .HasConversion<string>()
                .HasMaxLength(5);

            builder
                .Property(e => e.LaptopOwnership)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder
                .Property(e => e.Remark)
                .HasMaxLength(100);

			builder
				.Property(e => e.EmployeeCostStatus)
				.HasConversion<string>()
				.HasMaxLength(20);

			builder
                .HasOne(e => e.Company)
                .WithMany(e => e.EmployeeCosts)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.CostCenter)
                .WithMany(e => e.EmployeeCosts)
                .HasForeignKey(e => e.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeCosts)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
