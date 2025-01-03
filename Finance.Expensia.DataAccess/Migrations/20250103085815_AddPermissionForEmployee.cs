using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionForEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Employee:Cost:Create", "Akses untuk create data employee cost", 0 },
                    { new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Employee:Cost:Update", "Akses untuk update data employee cost", 0 },
                    { new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Employee:Cost:View", "Akses untuk view data employee cost", 0 },
                    { new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Employee:Cost:Delete", "Akses untuk delete data employee cost", 0 },
                    { new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Employee:View", "Akses untuk view data employee", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("031f512a-4e23-4cad-968d-5a541aab2f2d"), new DateTime(2024, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("38fde7bc-67c5-4caf-9603-9d261fefcf8a"), new DateTime(2025, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("8574ce80-16e8-4658-b3a1-3f2c34fe76a6"), new DateTime(2025, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("d4493d80-f8e7-4286-95d7-a4671bc49b53"), new DateTime(2025, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("ffb7bd5e-2918-4428-8cba-dc3a610159d9"), new DateTime(2024, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("031f512a-4e23-4cad-968d-5a541aab2f2d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("38fde7bc-67c5-4caf-9603-9d261fefcf8a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8574ce80-16e8-4658-b3a1-3f2c34fe76a6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d4493d80-f8e7-4286-95d7-a4671bc49b53"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ffb7bd5e-2918-4428-8cba-dc3a610159d9"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"));
        }
    }
}
