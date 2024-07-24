using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBodyEmailForRequestor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Id", "Created", "CreatedBy", "Key", "Modified", "ModifiedBy", "Modul", "RowStatus", "Value" },
                values: new object[] { new Guid("03ccfb2a-971a-4103-9c5d-6165af915388"), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "SYSTEM", "EmailForRequestor", null, null, "EmailNotification", 0, "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>Notifikasi Outgoing Payment</title>\r\n</head>\r\n<body>\r\n    <p>Dear Mr/Ms {{toName}},</p>\r\n    <p>\r\n        Dokumen outgoing payment dengan nomor <a href=\"{{linkDocument}}\" target=\"_blank\"><strong>{{documentNo}}</strong></a> {{remark}} telah di <strong>{{action}}</strong> oleh <strong>{{executorName}}</strong>.{{rejectReason}}\r\n</p>\r\n<p>Terima kasih.</p>\r\n</body>\r\n</html>" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Id",
                keyValue: new Guid("03ccfb2a-971a-4103-9c5d-6165af915388"));
        }
    }
}
