using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionEditCoAOnApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[] { new Guid("42cd2108-f0b2-46eb-8f0b-ff66948bc1e8"), new DateTime(2025, 2, 10, 9, 38, 0, 0, DateTimeKind.Utc), "", null, null, "ApprovalInbox.EditCoA", "Akses untuk melakukan update informasi CoA pada data approval inbox", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[] { new Guid("bb588f4c-0862-4dcf-899a-ababc1c0010f"), new DateTime(2024, 2, 10, 9, 39, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("42cd2108-f0b2-46eb-8f0b-ff66948bc1e8"), new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bb588f4c-0862-4dcf-899a-ababc1c0010f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("42cd2108-f0b2-46eb-8f0b-ff66948bc1e8"));
        }
    }
}
