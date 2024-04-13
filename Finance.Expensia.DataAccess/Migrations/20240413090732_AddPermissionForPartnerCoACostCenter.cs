using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionForPartnerCoACostCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CostCenter.View", "Akses untuk view cost center", 0 },
                    { new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.Partner.View", "Akses untuk view partner", 0 },
                    { new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CoA.View", "Akses untuk view coa", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("185db5f6-9fa7-48c6-97df-c2bf1d0709bc"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("3b322886-a0a5-4d4d-987a-747ddeadbe93"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("6169bee2-f5cb-4a40-b4e5-b85c0b7861c1"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("bf8e70f8-1410-469d-a110-ac5e7ea7f870"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("d2ad9345-8d2a-4147-99e1-6cb714429d33"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("f7e00cdd-64a2-43d1-8692-c22c72088e9e"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("185db5f6-9fa7-48c6-97df-c2bf1d0709bc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3b322886-a0a5-4d4d-987a-747ddeadbe93"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6169bee2-f5cb-4a40-b4e5-b85c0b7861c1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bf8e70f8-1410-469d-a110-ac5e7ea7f870"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d2ad9345-8d2a-4147-99e1-6cb714429d33"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f7e00cdd-64a2-43d1-8692-c22c72088e9e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"));
        }
    }
}
