using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Finance.Expensia.DataAccess.Bases;
using Microsoft.EntityFrameworkCore;

namespace Finance.Expensia.DataAccess.Builders
{
    public class UserEntityBuilder : EntityBaseBuilder<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.Username)
                .HasMaxLength(100);

            builder
                .Property(e => e.Email)
                .HasMaxLength(100);

            builder
                .Property(e => e.Description)
                .HasMaxLength(500);

            builder
                .Property(e => e.FullName)
                .HasMaxLength(150);

            builder
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<User> builder)
        {
            // InitialDb
            builder
                .HasData(
                    new User
                    {
                        Id = new Guid("11d61a5b-3236-4a35-8527-cd664d7ee230"),
                        Username = "wa.pradana01@gmail.com",
                        Email = "wa.pradana01@gmail.com",
                        FullName = "Wisnu Adhi Pradana",
                        Description = string.Empty,
                        PhotoProfileUrl = "https://cdns.klimg.com/mav-prod-resized/480x/ori/feedImage/2023/7/27/1690436761467-vyccu.jpeg",
                        Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(2195)
                    }
                );
        }
    }
}
