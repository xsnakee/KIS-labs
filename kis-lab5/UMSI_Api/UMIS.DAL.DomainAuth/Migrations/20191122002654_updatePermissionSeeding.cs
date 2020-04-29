using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class updatePermissionSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_AspNetRoles_RoleId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_Workgroups_WorkgroupId",
                table: "RoleToWorkgroup");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4058db72-4573-434a-a47f-aea5af0c7c81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "16d485a4-ac06-4b62-95e1-8d2d4bee18f7");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActionTypeNum", "EntityTypeNum" },
                values: new object[] { 2147483647, 2147483647 });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleToWorkgroup_AspNetRoles_RoleId",
                table: "RoleToWorkgroup",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleToWorkgroup_Workgroups_WorkgroupId",
                table: "RoleToWorkgroup",
                column: "WorkgroupId",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_AspNetRoles_RoleId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_Workgroups_WorkgroupId",
                table: "RoleToWorkgroup");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f7486ab5-2a6e-468a-8c0b-8f89241d0129");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f2479799-1ce3-43a1-b405-cd9542f3984e");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActionTypeNum", "EntityTypeNum" },
                values: new object[] { null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleToWorkgroup_AspNetRoles_RoleId",
                table: "RoleToWorkgroup",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleToWorkgroup_Workgroups_WorkgroupId",
                table: "RoleToWorkgroup",
                column: "WorkgroupId",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
