using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeedingPermisision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "ApprovalInbox.Update", "Akses untuk melakukan update data approval inbox", 0 },
                    { new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "ApprovalInbox.View", "Akses untuk view data approval inbox", 0 },
                    { new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "OutgoingPayment.View", "Akses untuk view data outgoing payment", 0 },
                    { new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "OutgoingPayment.Delete", "Akses untuk melakukan delete data outgoing payment", 0 },
                    { new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "OutgoingPayment.Upsert", "Akses untuk melakukan insert dan update data outgoing payment", 0 },
                    { new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "ApprovalInbox.Delete", "Akses untuk melakukan delete data approval inbox", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("0af7a0a4-18a6-47a3-be87-d7cc4271e562"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("a2ffc228-87b1-4e14-a665-818e32c2996e"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("65ba5cdf-3cd2-485b-ad7c-79ce544212aa"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("8e799e9b-6170-4571-8250-3cd3db045f30"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("a47218fe-31af-4b4b-87db-ea1068b088df"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("aa8194b4-0d26-44ea-8815-b0c85d417484"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("b6e98a31-52ce-487a-9780-f0429ee627b1"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("c419a69a-c778-4e75-913d-a369657fe572"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("ff5cc455-3d81-4e75-98f5-a4f410b64b0d"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0af7a0a4-18a6-47a3-be87-d7cc4271e562"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("65ba5cdf-3cd2-485b-ad7c-79ce544212aa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8e799e9b-6170-4571-8250-3cd3db045f30"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a2ffc228-87b1-4e14-a665-818e32c2996e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a47218fe-31af-4b4b-87db-ea1068b088df"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa8194b4-0d26-44ea-8815-b0c85d417484"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b6e98a31-52ce-487a-9780-f0429ee627b1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c419a69a-c778-4e75-913d-a369657fe572"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff5cc455-3d81-4e75-98f5-a4f410b64b0d"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f9200a65-df2c-41da-bc81-e73987370c42"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"));
        }
    }
}
