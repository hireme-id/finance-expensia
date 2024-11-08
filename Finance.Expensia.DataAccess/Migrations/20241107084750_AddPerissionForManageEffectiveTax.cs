using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPerissionForManageEffectiveTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.EffectiveTax.View", "Akses untuk view effective tax", 0 },
                    { new Guid("f2c5ead1-3ea7-4206-b2dc-7790af360d75"), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.EffectiveTax.Update", "Akses untuk update effective tax", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("20c92fe2-9927-4e30-a73a-fce6953bbf8b"), new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("47cdff05-a686-4af6-be30-7159a2a01c1c"), new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("f2c5ead1-3ea7-4206-b2dc-7790af360d75"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("20c92fe2-9927-4e30-a73a-fce6953bbf8b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("47cdff05-a686-4af6-be30-7159a2a01c1c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("923d83d4-cd5d-4049-8371-a6313a101094"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f2c5ead1-3ea7-4206-b2dc-7790af360d75"));
        }
    }
}
