using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class UpdateMIgrationEntitySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AllowedOnlyForOwner", "ConcurrencyStamp" },
                values: new object[] { true, "04cf33fd-c072-4432-8b92-8e42521f0637" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AllowedOnlyForOwner", "ConcurrencyStamp" },
                values: new object[] { true, "ebe98301-9859-4866-9b02-94bdb3896c1e" });

            migrationBuilder.InsertData(
                table: "RoleToWorkgroup",
                columns: new[] { "Id", "RoleId", "WorkgroupId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Workgroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "AllowedOnlyForOwner",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleToWorkgroup",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AllowedOnlyForOwner", "ConcurrencyStamp" },
                values: new object[] { false, "bcb888bf-0bd1-4aad-898a-596415eb9cac" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AllowedOnlyForOwner", "ConcurrencyStamp" },
                values: new object[] { false, "79410487-1611-4bd3-aacc-15a2fecaa223" });

            migrationBuilder.UpdateData(
                table: "Workgroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "AllowedOnlyForOwner",
                value: false);
        }
    }
}
