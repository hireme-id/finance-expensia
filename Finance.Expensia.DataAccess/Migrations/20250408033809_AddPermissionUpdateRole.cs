using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionUpdateRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("f75e356d-1b25-4b7f-bafb-24efc202c8cd"), new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "UserManagement.Role.Update", "Akses untuk update data role", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("42b37a63-a7d4-4c00-bfde-39c3ca942b1f"), new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("e423ca87-6b95-4edd-a351-f5c37e4a0455"), new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, new Guid("f75e356d-1b25-4b7f-bafb-24efc202c8cd"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("42b37a63-a7d4-4c00-bfde-39c3ca942b1f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e423ca87-6b95-4edd-a351-f5c37e4a0455"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f75e356d-1b25-4b7f-bafb-24efc202c8cd"));
        }
    }
}
