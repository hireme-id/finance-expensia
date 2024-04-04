using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PerubahanTableCostCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCenters_ChartOfAccounts_ChartOfAccountId",
                table: "CostCenters");

            migrationBuilder.RenameColumn(
                name: "ChartOfAccountId",
                table: "CostCenters",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCenters_ChartOfAccountId",
                table: "CostCenters",
                newName: "IX_CostCenters_CompanyId");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "MyPermission", "Ijin untuk mendapatkan permission", 0 },
                    { new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(2372), "", null, null, "RefreshToken", "Ijin untuk melakukan refresh token", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "RoleCode", "RoleDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600), "", null, null, "Approval", "User Approval", 0 },
                    { new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(7600), "", null, null, "Requestor", "User Requestor", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Email", "FullName", "Modified", "ModifiedBy", "PhotoProfileUrl", "ResetToken", "ResetTokenExpiration", "RowStatus", "Username" },
                values: new object[] { new Guid("11d61a5b-3236-4a35-8527-cd664d7ee230"), new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(2195), "", "", "wa.pradana01@gmail.com", "Wisnu Adhi Pradana", null, null, "https://cdns.klimg.com/mav-prod-resized/480x/ori/feedImage/2023/7/27/1690436761467-vyccu.jpeg", null, null, 0, "wa.pradana01@gmail.com" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("0cf91c77-4a12-4547-bac2-695d0f14741a"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 },
                    { new Guid("cfdceb82-2708-4dcc-a4e4-90aa76db8ea7"), new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "RoleId", "RowStatus", "UserId" },
                values: new object[] { new Guid("05b4bc20-a31f-4d5e-b739-6b6e46994976"), new DateTime(2024, 2, 25, 15, 15, 29, 22, DateTimeKind.Utc).AddTicks(9233), "", null, null, new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), 0, new Guid("11d61a5b-3236-4a35-8527-cd664d7ee230") });

            migrationBuilder.AddForeignKey(
                name: "FK_CostCenters_Companies_CompanyId",
                table: "CostCenters",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCenters_Companies_CompanyId",
                table: "CostCenters");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0cf91c77-4a12-4547-bac2-695d0f14741a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cfdceb82-2708-4dcc-a4e4-90aa76db8ea7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("05b4bc20-a31f-4d5e-b739-6b6e46994976"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11d61a5b-3236-4a35-8527-cd664d7ee230"));

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CostCenters",
                newName: "ChartOfAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCenters_CompanyId",
                table: "CostCenters",
                newName: "IX_CostCenters_ChartOfAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCenters_ChartOfAccounts_ChartOfAccountId",
                table: "CostCenters",
                column: "ChartOfAccountId",
                principalTable: "ChartOfAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
