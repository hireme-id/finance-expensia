using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class EmployeeEntityBuilder : EntityBaseBuilder<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.EmployeeNo)
                .HasMaxLength(15);

            builder
                .Property(e => e.EmployeeName)
                .HasMaxLength(150);
        }
    }
}
