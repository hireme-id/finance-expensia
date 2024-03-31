using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Finance.Expensia.DataAccess.Bases
{
    public class EntityBaseBuilder<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasQueryFilter(e => e.RowStatus == 0);
        }
    }
}
