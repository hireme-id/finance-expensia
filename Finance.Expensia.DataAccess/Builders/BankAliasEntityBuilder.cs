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
    public class BankAliasEntityBuilder : EntityBaseBuilder<BankAlias>
    {
        public override void Configure(EntityTypeBuilder<BankAlias> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.AliasName)
                .HasMaxLength(150);

            builder
                .Property(e => e.Description)
                .HasMaxLength(200);

            builder
                .Property(e => e.BankName)
                .HasMaxLength(150);

            builder
                .Property(e => e.AccountNo)
                .HasMaxLength(150);

            builder
                .Property(e => e.AccountName)
                .HasMaxLength(150);

            builder
                .Property(e => e.Address)
                .HasMaxLength(250);

            builder
                .HasOne(e => e.Company)
                .WithMany(e => e.BankAliases)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
