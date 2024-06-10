using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionWorkflowHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "WorkflowHistory.View", "Akses untuk view data workflow history", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("ff38217b-2065-4681-a15e-e73c2168b45c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("ff38217b-2065-4681-a15e-e73c2168b46c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), 0 },
                    { new Guid("ff38217b-2065-4681-a15e-e73c2168b47c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 },
                    { new Guid("ff38217b-2065-4681-a15e-e73c2168b48c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 },
                    { new Guid("ff38217b-2065-4681-a15e-e73c2168b52c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), 0 },
                    { new Guid("ff38217b-2065-4681-a15e-e73c2168b53c"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff38217b-2065-4681-a15e-e73c2168b45c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff38217b-2065-4681-a15e-e73c2168b46c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff38217b-2065-4681-a15e-e73c2168b47c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff38217b-2065-4681-a15e-e73c2168b48c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff38217b-2065-4681-a15e-e73c2168b52c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff38217b-2065-4681-a15e-e73c2168b53c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"));
        }
    }
}
