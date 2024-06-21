using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PermissionForCostCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CostCenter.Upsert", "Akses untuk upsert cost center", 0 },
                    { new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CostCenter.Delete", "Akses untuk delete cost center", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("1a66749f-6307-42bb-9aaf-33ef174f61a1"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("1ff0b99a-5815-4dfe-bd74-e3985818574c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("540ccc89-364d-433a-b669-df92739a043c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("621c4acd-73a5-450b-bd4b-c4683a1288ca"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("6b410e73-fa1a-494e-8374-03cb4c2d82ae"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("7a1cae33-3079-422d-8c69-c1244d0c62b0"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("aa7d6bf4-54b1-4d25-ab18-b67f183bc84a"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("ad98ff8b-9937-4fe6-ab8e-006395fbc7c5"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("bce391a4-9e1f-4483-9499-1d1610de46ea"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("c5c9fd01-d6b2-45cf-bfc2-de6c3a670d56"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("e4ac8a44-55da-41b8-9322-de69cc46e4ff"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("f96c2402-b849-4f58-9402-ad7152e5bcca"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1a66749f-6307-42bb-9aaf-33ef174f61a1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1ff0b99a-5815-4dfe-bd74-e3985818574c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("540ccc89-364d-433a-b669-df92739a043c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("621c4acd-73a5-450b-bd4b-c4683a1288ca"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6b410e73-fa1a-494e-8374-03cb4c2d82ae"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7a1cae33-3079-422d-8c69-c1244d0c62b0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa7d6bf4-54b1-4d25-ab18-b67f183bc84a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ad98ff8b-9937-4fe6-ab8e-006395fbc7c5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bce391a4-9e1f-4483-9499-1d1610de46ea"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c5c9fd01-d6b2-45cf-bfc2-de6c3a670d56"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e4ac8a44-55da-41b8-9322-de69cc46e4ff"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f96c2402-b849-4f58-9402-ad7152e5bcca"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"));
        }
    }
}
