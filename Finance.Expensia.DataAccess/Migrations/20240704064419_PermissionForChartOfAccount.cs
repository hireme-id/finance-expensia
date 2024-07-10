using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PermissionForChartOfAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("00356938-aa39-48cf-8e32-7cb49ce94261"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("234b5e2f-61e3-4503-b7e2-6047016c6e3a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("661d6975-c761-4ff4-b5ed-b2e6168995ba"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6ad47040-c023-4bc5-9492-2a737a114c9f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dc35b7bf-d764-4b37-8c3f-08de8c8ef312"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ee709282-f860-4fc5-9c43-9806f7fb1aad"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CoA.View", "Akses untuk view coa", 0 },
                    { new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CoA.Upsert", "Akses untuk upsert coa", 0 },
                    { new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CoA.Delete", "Akses untuk delete coa", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("03e70ba0-1194-4246-8b1f-b848af304a37"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("0981bbec-4ccc-493d-b8d7-cec43a60052d"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("152e0338-bc11-45c4-a425-908a35a5312f"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("1dfbb99d-2d48-4b09-a483-a2e9dd3636af"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("24c89712-246a-4774-b48a-c62581fef7e5"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("2821544e-5374-4599-b2a3-304510cf0881"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("3d7f85b4-8ae0-45c0-b84f-ca8fd2540468"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("3e93125c-ff1d-4a27-83af-16cac3b9c3e3"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("3f55f0df-10ce-4f2a-a152-5cf6c45a73fc"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("43dd2d57-4ffe-481d-a3e9-63c5904b7b3a"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("6d9ba54f-9d4f-4212-a3bb-9bfe46fb509d"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("6faadf01-b008-46ef-9717-aed9095c9fa2"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("71657cef-30c8-419b-a2ca-67c5e3ed8d66"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("9ae070fc-4bfa-4552-b823-87e24fb779d5"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("ca647ad1-c420-4751-9f76-aec5c17b84c4"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("d77179f3-92d1-43a0-bb94-208413d6f4dc"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("dcf19f3f-88d4-404b-b375-40c473c34262"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("eca833e4-41c9-45df-be6e-c35deb4158ee"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("03e70ba0-1194-4246-8b1f-b848af304a37"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0981bbec-4ccc-493d-b8d7-cec43a60052d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("152e0338-bc11-45c4-a425-908a35a5312f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1dfbb99d-2d48-4b09-a483-a2e9dd3636af"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("24c89712-246a-4774-b48a-c62581fef7e5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2821544e-5374-4599-b2a3-304510cf0881"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3d7f85b4-8ae0-45c0-b84f-ca8fd2540468"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3e93125c-ff1d-4a27-83af-16cac3b9c3e3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3f55f0df-10ce-4f2a-a152-5cf6c45a73fc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("43dd2d57-4ffe-481d-a3e9-63c5904b7b3a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6d9ba54f-9d4f-4212-a3bb-9bfe46fb509d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6faadf01-b008-46ef-9717-aed9095c9fa2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("71657cef-30c8-419b-a2ca-67c5e3ed8d66"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9ae070fc-4bfa-4552-b823-87e24fb779d5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ca647ad1-c420-4751-9f76-aec5c17b84c4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d77179f3-92d1-43a0-bb94-208413d6f4dc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcf19f3f-88d4-404b-b375-40c473c34262"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eca833e4-41c9-45df-be6e-c35deb4158ee"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CoA.View", "Akses untuk view coa", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("00356938-aa39-48cf-8e32-7cb49ce94261"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("234b5e2f-61e3-4503-b7e2-6047016c6e3a"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 },
                    { new Guid("661d6975-c761-4ff4-b5ed-b2e6168995ba"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("6ad47040-c023-4bc5-9492-2a737a114c9f"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("dc35b7bf-d764-4b37-8c3f-08de8c8ef312"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("ee709282-f860-4fc5-9c43-9806f7fb1aad"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 }
                });
        }
    }
}
