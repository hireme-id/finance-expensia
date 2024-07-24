using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRolePermissionJuly2024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("15404abb-51ca-40c1-9cdb-cff118057179"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("24c89712-246a-4774-b48a-c62581fef7e5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2c541de6-2c5f-4001-8b99-57d0e9a0d857"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2d748285-666e-4e67-8365-226f6b783142"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("370ba0cd-b788-4a37-9ee2-c6ad815222a7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3b92a1da-4800-4023-ba07-f5c206792f0f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3f55f0df-10ce-4f2a-a152-5cf6c45a73fc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("475194c9-168f-4ee8-a4f6-60b90cc9066d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5a9c2c3d-e4ea-4116-a695-352c0396bfc9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7bdaf0fd-069b-4982-8069-875da371cf2b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("905fc8f9-98f0-4006-925c-28afb2385f51"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("93604f9d-2f8e-450c-8e1a-6626a8f2b243"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c02d1d3c-a8a3-435a-b4e3-1aaa091ec8d8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c05cc819-3947-42dd-b095-76baa2f1e414"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c52346be-a185-45c6-8108-56c35fc2d31d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dba08c3b-b0d2-477d-b74d-d8473103f0ee"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fd86560c-3b51-491b-8318-dfbde48c5b84"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"),
                column: "PermissionCode",
                value: "MasterData.Coa.View");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"),
                column: "PermissionCode",
                value: "MasterData.Coa.Upsert");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"),
                column: "PermissionCode",
                value: "MasterData.Coa.Delete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"),
                column: "PermissionCode",
                value: "MasterData.CoA.View");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"),
                column: "PermissionCode",
                value: "MasterData.CoA.Upsert");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"),
                column: "PermissionCode",
                value: "MasterData.CoA.Delete");

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("15404abb-51ca-40c1-9cdb-cff118057179"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("96f688f8-797a-49ef-8e6c-f29c40c67f76"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("24c89712-246a-4774-b48a-c62581fef7e5"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("2c541de6-2c5f-4001-8b99-57d0e9a0d857"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("692f63e0-eba2-4f81-8d60-52b387b37585"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("2d748285-666e-4e67-8365-226f6b783142"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("692f63e0-eba2-4f81-8d60-52b387b37585"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("370ba0cd-b788-4a37-9ee2-c6ad815222a7"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("99cb47e1-28b1-46ee-a90d-b87e195b21a1"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("3b92a1da-4800-4023-ba07-f5c206792f0f"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("96f688f8-797a-49ef-8e6c-f29c40c67f76"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("3f55f0df-10ce-4f2a-a152-5cf6c45a73fc"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("475194c9-168f-4ee8-a4f6-60b90cc9066d"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("99cb47e1-28b1-46ee-a90d-b87e195b21a1"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("5a9c2c3d-e4ea-4116-a695-352c0396bfc9"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("96f688f8-797a-49ef-8e6c-f29c40c67f76"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("7bdaf0fd-069b-4982-8069-875da371cf2b"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("692f63e0-eba2-4f81-8d60-52b387b37585"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("905fc8f9-98f0-4006-925c-28afb2385f51"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("692f63e0-eba2-4f81-8d60-52b387b37585"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("93604f9d-2f8e-450c-8e1a-6626a8f2b243"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("99cb47e1-28b1-46ee-a90d-b87e195b21a1"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("c02d1d3c-a8a3-435a-b4e3-1aaa091ec8d8"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("99cb47e1-28b1-46ee-a90d-b87e195b21a1"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("c05cc819-3947-42dd-b095-76baa2f1e414"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("96f688f8-797a-49ef-8e6c-f29c40c67f76"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("c52346be-a185-45c6-8108-56c35fc2d31d"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("96f688f8-797a-49ef-8e6c-f29c40c67f76"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("dba08c3b-b0d2-477d-b74d-d8473103f0ee"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("99cb47e1-28b1-46ee-a90d-b87e195b21a1"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("fd86560c-3b51-491b-8318-dfbde48c5b84"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("692f63e0-eba2-4f81-8d60-52b387b37585"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 }
                });
        }
    }
}
