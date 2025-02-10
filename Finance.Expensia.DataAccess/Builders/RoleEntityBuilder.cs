using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
	public class RoleEntityBuilder : EntityBaseBuilder<Role>
	{
		public override void Configure(EntityTypeBuilder<Role> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.RoleCode)
				.HasMaxLength(30);

			builder
				.Property(e => e.RoleDescription)
				.HasMaxLength(100);

			builder
				.HasMany(e => e.UserRoles)
				.WithOne(e => e.Role)
				.HasForeignKey(e => e.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasMany(e => e.RolePermissions)
				.WithOne(e => e.Role)
				.HasForeignKey(e => e.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			SeedingData(builder);
		}

		private static void SeedingData(EntityTypeBuilder<Role> builder)
		{
			builder
				.HasData(
					new Role { Id = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), RoleCode = "User", RoleDescription = "User yang dapat membuat pengajuan dan melihat pengajuan yang dia buat sendiri", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
					new Role { Id = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), RoleCode = "Manager", RoleDescription = "User yang dapat membuat pengajuan dan melihat semua pengajuan, dan bisa approve", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
					new Role { Id = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), RoleCode = "Accounting", RoleDescription = "User yang dapat membuat pengajuan dan melihat semua pengajuan, dan bisa approve", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
					new Role { Id = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), RoleCode = "Finance", RoleDescription = "User yang dapat membuat pengajuan dan melihat semua pengajuan, dan bisa approve", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
					new Role { Id = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), RoleCode = "Approval", RoleDescription = "User yang dapat membuat pengajuan dan melihat semua pengajuan, dan bisa approve", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
					new Role { Id = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), RoleCode = "Releaser", RoleDescription = "User yang dapat membuat pengajuan dan melihat semua pengajuan, dan bisa approve", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
					new Role { Id = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), RoleCode = "Administrator", RoleDescription = "User yang dapat melakukan konfigurasi modul-modul utama dari sistem", Created = new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600) },
                    new Role { Id = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), RoleCode = "Recruitment", RoleDescription = "", Created = new DateTime(2025, 1, 9, 10, 38, 0, 0, DateTimeKind.Utc) },
                    new Role { Id = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), RoleCode = "Sales", RoleDescription = "", Created = new DateTime(2025, 1, 9, 10, 38, 0, 0, DateTimeKind.Utc) },
					new Role { Id = new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"), RoleCode = "RecruitmentManager", RoleDescription = "", Created = new DateTime(2025, 2, 10, 15, 35, 0, 0, DateTimeKind.Utc) }
				);
		}
	}
}
