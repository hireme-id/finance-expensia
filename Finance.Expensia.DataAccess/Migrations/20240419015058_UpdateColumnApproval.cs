using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalRuleId",
                table: "ApprovalInboxes");

            migrationBuilder.DropColumn(
                name: "ApprovalRuleId",
                table: "ApprovalHistories");

            migrationBuilder.RenameColumn(
                name: "ApprovalRoleDesc",
                table: "ApprovalHistories",
                newName: "ExecutorRoleDesc");

            migrationBuilder.RenameColumn(
                name: "ApprovalRoleCode",
                table: "ApprovalHistories",
                newName: "ExecutorRoleCode");

            migrationBuilder.RenameColumn(
                name: "ApprovalName",
                table: "ApprovalHistories",
                newName: "ExecutorName");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxAmount",
                table: "ApprovalInboxes",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinAmount",
                table: "ApprovalInboxes",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxAmount",
                table: "ApprovalHistories",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinAmount",
                table: "ApprovalHistories",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAmount",
                table: "ApprovalInboxes");

            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "ApprovalInboxes");

            migrationBuilder.DropColumn(
                name: "MaxAmount",
                table: "ApprovalHistories");

            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "ApprovalHistories");

            migrationBuilder.RenameColumn(
                name: "ExecutorRoleDesc",
                table: "ApprovalHistories",
                newName: "ApprovalRoleDesc");

            migrationBuilder.RenameColumn(
                name: "ExecutorRoleCode",
                table: "ApprovalHistories",
                newName: "ApprovalRoleCode");

            migrationBuilder.RenameColumn(
                name: "ExecutorName",
                table: "ApprovalHistories",
                newName: "ApprovalName");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalRuleId",
                table: "ApprovalInboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalRuleId",
                table: "ApprovalHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
