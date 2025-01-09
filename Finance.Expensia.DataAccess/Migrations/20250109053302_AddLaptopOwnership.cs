using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLaptopOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LaptopOwnership",
                table: "EmployeeCosts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("19f8c778-4e36-4388-b277-441b5d952499"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("21ffa1c8-da11-449b-9115-bb0733dbfa97"),
                columns: new[] { "CalculateFormula", "IsCalculated", "IsVisible" },
                values: new object[] { "if([LaptopOwnership] == 1, 300000, 0)", true, false });

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("3ac51195-8f85-4e3b-948a-be66d76a359c"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("40c9089b-28ec-4a42-a646-ead837047274"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("477ae51c-830f-471f-8c35-d002adf21925"),
                columns: new[] { "CalculateFormula", "IsCalculated", "IsVisible" },
                values: new object[] { "if([EmployeeStatus] == 2, 6000000, 0)", true, false });

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("5a3e4b7c-3d08-412e-92a8-bb34d94bcd6d"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("90c8198b-8038-4cda-940e-7033c00bcbac"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("95e89bc6-b98b-4bb0-8543-111568bf6f4b"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("9dc90145-46a7-47a1-9610-f8fa5ca9b5ea"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("adf2853f-3b7e-4f8e-9885-9e7a451600cf"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("b9ccc7eb-79ec-4ddc-aa6a-c6646de95935"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("dd71e2c2-d6dc-4b3c-aa73-fa0dcd5f2ca1"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("eb2366dd-6ce4-44e0-849f-47e4f7bd7282"),
                columns: new[] { "CalculateFormula", "IsCalculated", "IsVisible" },
                values: new object[] { "if([NonTaxableIncome] == 0, 5000000, 8000000)", true, false });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "RoleCode", "RoleDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), new DateTime(2025, 1, 9, 10, 38, 0, 0, DateTimeKind.Utc), "", null, null, "Sales", "", 0 },
                    { new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), new DateTime(2025, 1, 9, 10, 38, 0, 0, DateTimeKind.Utc), "", null, null, "Recruitment", "", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("012fcaa6-e54f-49ed-9bce-2a3ced131b31"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("06fde6cb-f28c-4ba8-b20f-583058f5971f"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("12d8ea62-e936-42ae-81c1-fe33182f2175"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("3a229f69-00ad-4b9d-af75-13a0dd248a76"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("47f44eeb-d741-4a4f-b6cb-2421b8931fb0"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("482a7b2c-84c7-463b-bdcc-af34f578e8dc"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("55b1508f-8035-4525-b583-6c6205a47e4a"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("6a29a4bb-6c1a-4f5e-a9da-6b5483f52a87"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("7b42a768-2c00-4811-897e-a2de728b10b2"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("ae8812b7-6490-4a13-aa05-62a57af0dc16"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("b33ca67e-b746-400f-b096-990e824867b0"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("bc182dae-181d-4336-849e-7d616dedba40"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("d2e14bb7-9fa7-49d9-9aed-5c8c8f7aae3d"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 },
                    { new Guid("f242f6d1-a140-4368-8cd2-7d0940f1daf8"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("fd3da1d3-eff8-4084-a95a-1f0cfde74dd9"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), 0 },
                    { new Guid("fffe808c-a842-4bee-b1d3-b4d8a0a7682d"), new DateTime(2025, 1, 9, 11, 2, 0, 0, DateTimeKind.Utc), "", null, null, new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("012fcaa6-e54f-49ed-9bce-2a3ced131b31"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("06fde6cb-f28c-4ba8-b20f-583058f5971f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("12d8ea62-e936-42ae-81c1-fe33182f2175"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3a229f69-00ad-4b9d-af75-13a0dd248a76"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("47f44eeb-d741-4a4f-b6cb-2421b8931fb0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("482a7b2c-84c7-463b-bdcc-af34f578e8dc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("55b1508f-8035-4525-b583-6c6205a47e4a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6a29a4bb-6c1a-4f5e-a9da-6b5483f52a87"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7b42a768-2c00-4811-897e-a2de728b10b2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ae8812b7-6490-4a13-aa05-62a57af0dc16"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b33ca67e-b746-400f-b096-990e824867b0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bc182dae-181d-4336-849e-7d616dedba40"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d2e14bb7-9fa7-49d9-9aed-5c8c8f7aae3d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f242f6d1-a140-4368-8cd2-7d0940f1daf8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fd3da1d3-eff8-4084-a95a-1f0cfde74dd9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fffe808c-a842-4bee-b1d3-b4d8a0a7682d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"));

            migrationBuilder.DropColumn(
                name: "LaptopOwnership",
                table: "EmployeeCosts");

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("19f8c778-4e36-4388-b277-441b5d952499"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("21ffa1c8-da11-449b-9115-bb0733dbfa97"),
                columns: new[] { "CalculateFormula", "IsCalculated", "IsVisible" },
                values: new object[] { "", false, true });

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("3ac51195-8f85-4e3b-948a-be66d76a359c"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("40c9089b-28ec-4a42-a646-ead837047274"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("477ae51c-830f-471f-8c35-d002adf21925"),
                columns: new[] { "CalculateFormula", "IsCalculated", "IsVisible" },
                values: new object[] { "", false, true });

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("5a3e4b7c-3d08-412e-92a8-bb34d94bcd6d"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("90c8198b-8038-4cda-940e-7033c00bcbac"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("95e89bc6-b98b-4bb0-8543-111568bf6f4b"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("9dc90145-46a7-47a1-9610-f8fa5ca9b5ea"),
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("adf2853f-3b7e-4f8e-9885-9e7a451600cf"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("b9ccc7eb-79ec-4ddc-aa6a-c6646de95935"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("dd71e2c2-d6dc-4b3c-aa73-fa0dcd5f2ca1"),
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostComponents",
                keyColumn: "Id",
                keyValue: new Guid("eb2366dd-6ce4-44e0-849f-47e4f7bd7282"),
                columns: new[] { "CalculateFormula", "IsCalculated", "IsVisible" },
                values: new object[] { "", false, true });
        }
    }
}
