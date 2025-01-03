using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCostComponentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeCostComponents");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("1295d083-8086-447b-9cc0-6caa1c5266ff"),
                column: "CalculateFormula",
                value: "([29999] + [42000] + [43000] + [44000] + [59000]) * 12 + [31000] + [32000] + [40000] + [41000]");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("34ae40aa-f58d-4d37-8e26-f907a17fd6eb"),
                column: "CalculateFormula",
                value: "if([10000] < 12000000, [10000] * 0.04, 12000000 * 0.04)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("382a396b-27b1-47da-b1f1-f1a7bb04972b"),
                column: "CalculateFormula",
                value: "[10000] * 0.0054");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("56baf335-7326-455d-a9bb-517eafcbc4d3"),
                column: "CalculateFormula",
                value: "[20000] + [20100] + [21000] + [21100] + [21200] + [22000]");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("5a3e4b7c-3d08-412e-92a8-bb34d94bcd6d"),
                column: "CalculateFormula",
                value: "if([EmployeeStatus] == 2, [10000] * 0.03, 0)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("90c8198b-8038-4cda-940e-7033c00bcbac"),
                column: "CostComponentNo",
                value: 29999);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("9dc90145-46a7-47a1-9610-f8fa5ca9b5ea"),
                column: "CalculateFormula",
                value: "Ceiling([91000] / 12 / 100000) * 100000");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("ab55b484-c9b3-49fb-8692-d72374d793c3"),
                column: "CalculateFormula",
                value: "if([EmployeeStatus] == 2, [10000] * 0.01, 0)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("adf2853f-3b7e-4f8e-9885-9e7a451600cf"),
                column: "CalculateFormula",
                value: "if([10000] < 12000000, [10000] * 0.05, 12000000 * 0.05)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("bed577bb-faf2-4a03-bb99-2c72cfbc5cee"),
                column: "CalculateFormula",
                value: "[10000] * 0.0054");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("c8beedaf-1f15-4adb-9bf9-5c12e3100599"),
                column: "CalculateFormula",
                value: "[10000] * 0.02");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("ca186eb7-2745-49dd-a882-3212c94c534d"),
                column: "CalculateFormula",
                value: "if([10000] < 12000000, [10000] * 0.04, 12000000 * 0.04)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeCostComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("1295d083-8086-447b-9cc0-6caa1c5266ff"),
                column: "CalculateFormula",
                value: "[90000] * 12 + [31000] + [32000] + [40000] + [41000] + [42000] + [43000] + [44000] + [59000] * 12");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("34ae40aa-f58d-4d37-8e26-f907a17fd6eb"),
                column: "CalculateFormula",
                value: "if([10000] < 12000000, [1000] * 0.04, 12000000 * 0.04)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("382a396b-27b1-47da-b1f1-f1a7bb04972b"),
                column: "CalculateFormula",
                value: "[10000] * 0.054");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("56baf335-7326-455d-a9bb-517eafcbc4d3"),
                column: "CalculateFormula",
                value: "[20000] + [20100] + [21000] + [21100] + [21200] + [22200]");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("5a3e4b7c-3d08-412e-92a8-bb34d94bcd6d"),
                column: "CalculateFormula",
                value: "if([EmployeeType] == 2, [10000] * 0.03, 0)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("90c8198b-8038-4cda-940e-7033c00bcbac"),
                column: "CostComponentNo",
                value: 90000);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("9dc90145-46a7-47a1-9610-f8fa5ca9b5ea"),
                column: "CalculateFormula",
                value: "[ROUNDUP]([91000] / 12, -5)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("ab55b484-c9b3-49fb-8692-d72374d793c3"),
                column: "CalculateFormula",
                value: "if([EmployeeType] == 2, [10000] * 0.01, 0)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("adf2853f-3b7e-4f8e-9885-9e7a451600cf"),
                column: "CalculateFormula",
                value: "if([10000] > 12000000, [10000] * 0.05, 0)");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("bed577bb-faf2-4a03-bb99-2c72cfbc5cee"),
                column: "CalculateFormula",
                value: "[10000] * 0.054");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("c8beedaf-1f15-4adb-9bf9-5c12e3100599"),
                column: "CalculateFormula",
                value: "[1000] * 0.02");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("ca186eb7-2745-49dd-a882-3212c94c534d"),
                column: "CalculateFormula",
                value: "if([10000] < 12000000, [1000] * 0.04, 12000000 * 0.04)");
        }
    }
}
