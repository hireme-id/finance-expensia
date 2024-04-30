using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.TransactionType.View", "Akses untuk view transaction type", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("7dde3578-ef9d-4f05-8717-b1b035517a53"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("bb81ea29-c146-4eb1-b1ae-4c3e2f1f11b9"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7dde3578-ef9d-4f05-8717-b1b035517a53"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bb81ea29-c146-4eb1-b1ae-4c3e2f1f11b9"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"));
        }
    }
}
