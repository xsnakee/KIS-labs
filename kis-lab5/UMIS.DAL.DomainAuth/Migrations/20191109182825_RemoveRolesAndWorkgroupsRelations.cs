using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class RemoveRolesAndWorkgroupsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_AspNetRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_Workgroups_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropColumn(
                name: "WorkgroupId1",
                table: "PermissionsToWorkgroupRoles");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "PermissionsToWorkgroupRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkgroupId1",
                table: "PermissionsToWorkgroupRoles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "04cf33fd-c072-4432-8b92-8e42521f0637");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ebe98301-9859-4866-9b02-94bdb3896c1e");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsToWorkgroupRoles_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles",
                column: "WorkgroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_AspNetRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_Workgroups_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles",
                column: "WorkgroupId1",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
