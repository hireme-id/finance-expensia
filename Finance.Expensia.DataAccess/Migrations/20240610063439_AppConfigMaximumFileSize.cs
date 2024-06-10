using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AppConfigMaximumFileSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Id", "Created", "CreatedBy", "Key", "Modified", "ModifiedBy", "Modul", "RowStatus", "StartDate", "Value" },
                values: new object[] { new Guid("d22dfd1c-44ee-46e7-8329-ad7041a99bb9"), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "SYSTEM", "MaximumFileSize", null, null, "Storage", 0, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "1000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Id",
                keyValue: new Guid("d22dfd1c-44ee-46e7-8329-ad7041a99bb9"));
        }
    }
}
