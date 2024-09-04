using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionViewRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "UserManagement.Role.View", "Akses untuk view data role", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("2907a99d-506a-488e-9c9a-78b227f48fb3"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("5af2ec99-2f5b-4551-9782-f206a8dfc2d7"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("b5667fa6-102c-4d0e-94f8-58d330462dfa"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("bf1b0281-2b32-444a-b794-80b5627a06f2"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("e2479cc8-6a54-49b9-abb7-163edaf4107e"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2907a99d-506a-488e-9c9a-78b227f48fb3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5af2ec99-2f5b-4551-9782-f206a8dfc2d7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b5667fa6-102c-4d0e-94f8-58d330462dfa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bf1b0281-2b32-444a-b794-80b5627a06f2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e2479cc8-6a54-49b9-abb7-163edaf4107e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"));
        }
    }
}
