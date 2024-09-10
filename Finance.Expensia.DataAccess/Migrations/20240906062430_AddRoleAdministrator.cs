using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAdministrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("a830d1d8-07af-46a7-bb51-ea157fe4f421"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "UserManagement.ManageUser.View", "Akses untuk view manage user", 0 },
                    { new Guid("ed9a3de5-d557-46b1-9509-78fced8ad5c0"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "UserManagement.ManageUser.Update", "Akses untuk update manage user", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "RoleCode", "RoleDescription", "RowStatus" },
                values: new object[] { new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600), "", null, null, "Administrator", "User yang dapat melakukan konfigurasi modul-modul utama dari sistem", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("108aaa5e-c79d-4429-b140-fce72e1382e2"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("ed9a3de5-d557-46b1-9509-78fced8ad5c0"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("b0093f1a-86c1-41af-978d-f33865390b51"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("a830d1d8-07af-46a7-bb51-ea157fe4f421"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("108aaa5e-c79d-4429-b140-fce72e1382e2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b0093f1a-86c1-41af-978d-f33865390b51"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a830d1d8-07af-46a7-bb51-ea157fe4f421"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ed9a3de5-d557-46b1-9509-78fced8ad5c0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"));
        }
    }
}
