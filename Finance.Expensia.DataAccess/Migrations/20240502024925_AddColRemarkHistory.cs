using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddColRemarkHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "ApprovalHistories",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "ApprovalHistories");
        }
    }
}
