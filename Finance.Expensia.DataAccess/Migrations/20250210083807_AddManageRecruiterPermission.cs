using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddManageRecruiterPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruiter_Users_UserId",
                table: "Recruiter");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("5df851bf-17a7-42b8-b0eb-6517ab3a74d7"), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.Recruiter.View", "Akses untuk view recruiter", 0 },
                    { new Guid("909948bc-8af6-4a01-a3ce-307fd8a68bca"), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.Recruiter.Upsert", "Akses untuk update recruiter", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "RoleCode", "RoleDescription", "RowStatus" },
                values: new object[] { new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"), new DateTime(2025, 2, 10, 15, 35, 0, 0, DateTimeKind.Utc), "", null, null, "RecruitmentManager", "", 0 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("64249430-e111-4eef-aaf2-2d7bbb0835fe"), new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("909948bc-8af6-4a01-a3ce-307fd8a68bca"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("c817996b-3756-4252-a18d-1e44375f06d9"), new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5df851bf-17a7-42b8-b0eb-6517ab3a74d7"), new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"), 0 },
                    { new Guid("f0b1feb7-bf6b-4f08-ac01-d692ca2edfdc"), new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("909948bc-8af6-4a01-a3ce-307fd8a68bca"), new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"), 0 },
                    { new Guid("fea959df-d33b-44c4-9bfd-2526c2221af2"), new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("5df851bf-17a7-42b8-b0eb-6517ab3a74d7"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiter_Users_UserId",
                table: "Recruiter",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruiter_Users_UserId",
                table: "Recruiter");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("64249430-e111-4eef-aaf2-2d7bbb0835fe"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c817996b-3756-4252-a18d-1e44375f06d9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f0b1feb7-bf6b-4f08-ac01-d692ca2edfdc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fea959df-d33b-44c4-9bfd-2526c2221af2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5df851bf-17a7-42b8-b0eb-6517ab3a74d7"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("909948bc-8af6-4a01-a3ce-307fd8a68bca"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"));

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiter_Users_UserId",
                table: "Recruiter",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
