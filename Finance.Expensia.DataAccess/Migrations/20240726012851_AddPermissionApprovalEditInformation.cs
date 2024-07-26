using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionApprovalEditInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("b7eafb34-d9e7-4cba-9378-8c54c0786dbf"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "ApprovalInbox.EditInformation", "Akses untuk melakukan update sebagian informasi pada data approval inbox", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[] { new Guid("5ddb81a5-aad2-4c3b-b6a7-d7ab90f1f6b6"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("b7eafb34-d9e7-4cba-9378-8c54c0786dbf"), new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5ddb81a5-aad2-4c3b-b6a7-d7ab90f1f6b6"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b7eafb34-d9e7-4cba-9378-8c54c0786dbf"));
        }
    }
}
