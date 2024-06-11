using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStartDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AppConfigs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AppConfigs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Id",
                keyValue: new Guid("d22dfd1c-44ee-46e7-8329-ad7041a99bb9"),
                column: "StartDate",
                value: new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
