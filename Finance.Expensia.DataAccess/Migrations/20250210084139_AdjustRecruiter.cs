using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdjustRecruiter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruiter_Users_UserId",
                table: "Recruiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recruiter",
                table: "Recruiter");

            migrationBuilder.RenameTable(
                name: "Recruiter",
                newName: "Recruiters");

            migrationBuilder.RenameIndex(
                name: "IX_Recruiter_UserId",
                table: "Recruiters",
                newName: "IX_Recruiters_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "RecruiterCode",
                table: "Recruiters",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recruiters",
                table: "Recruiters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiters_Users_UserId",
                table: "Recruiters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruiters_Users_UserId",
                table: "Recruiters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recruiters",
                table: "Recruiters");

            migrationBuilder.RenameTable(
                name: "Recruiters",
                newName: "Recruiter");

            migrationBuilder.RenameIndex(
                name: "IX_Recruiters_UserId",
                table: "Recruiter",
                newName: "IX_Recruiter_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "RecruiterCode",
                table: "Recruiter",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recruiter",
                table: "Recruiter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiter_Users_UserId",
                table: "Recruiter",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
