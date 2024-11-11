using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionForCostComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionCode", "PermissionDescription", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("bf1d72af-698e-43fa-af9f-5fabd42743f2"), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CostComponent.View", "Akses untuk view cost component", 0 },
                    { new Guid("dc97d84b-c194-4493-98c6-897f440e67a2"), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "MasterData.CostComponent.Upsert", "Akses untuk update cost component", 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "PermissionId", "RoleId", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("9a99df65-693d-4ff7-99f4-0976e764d0d6"), new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("dc97d84b-c194-4493-98c6-897f440e67a2"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 },
                    { new Guid("fe224692-bdc8-4f35-8c72-8744f22b4692"), new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910), "", null, null, new Guid("bf1d72af-698e-43fa-af9f-5fabd42743f2"), new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9a99df65-693d-4ff7-99f4-0976e764d0d6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fe224692-bdc8-4f35-8c72-8744f22b4692"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("bf1d72af-698e-43fa-af9f-5fabd42743f2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("dc97d84b-c194-4493-98c6-897f440e67a2"));
        }
    }
}
