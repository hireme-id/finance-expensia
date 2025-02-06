using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeCostStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeCostStatus",
                table: "EmployeeCosts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("56d9aee8-1346-419e-a209-e516a1e3f7e0"),
                column: "CalculateFormula",
                value: "if([10000] < 12000000, [10000] * 0.01, 12000000 * 0.01)");

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("26f9dfc3-6e9e-4730-aa64-c770a73df603"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("a9280e1c-9f6a-4fd4-9849-eb2e2d3f19f5"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("26f9dfc3-6e9e-4730-aa64-c770a73df603"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a9280e1c-9f6a-4fd4-9849-eb2e2d3f19f5"));

            migrationBuilder.DropColumn(
                name: "EmployeeCostStatus",
                table: "EmployeeCosts");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("56d9aee8-1346-419e-a209-e516a1e3f7e0"),
                column: "CalculateFormula",
                value: "[10000] * 0.01");
        }
    }
}
