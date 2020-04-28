using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class ChangePermissionToWorkgroupRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_AspNetRoles_RoleId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_Workgroups_WorkgroupId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_AspNetRoles_RoleId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_Workgroups_WorkgroupId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionsToWorkgroupRoles",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_WorkgroupId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DeleteData(
                table: "PermissionsToWorkgroupRoles",
                keyColumns: new[] { "PermissionId", "WorkgroupId", "RoleId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DropColumn(
                name: "WorkgroupId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.AlterColumn<int>(
                name: "WorkgroupId",
                table: "RoleToWorkgroup",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "RoleToWorkgroup",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoleToWorkgroupId",
                table: "PermissionsToWorkgroupRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "PermissionsToWorkgroupRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkgroupId1",
                table: "PermissionsToWorkgroupRoles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionsToWorkgroupRoles",
                table: "PermissionsToWorkgroupRoles",
                columns: new[] { "PermissionId", "RoleToWorkgroupId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b9e3ccce-01aa-468b-9059-8bfb7fc9047c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d1118685-e2c3-441e-810d-1f0b0d37f1d5");

            migrationBuilder.InsertData(
                table: "PermissionsToWorkgroupRoles",
                columns: new[] { "PermissionId", "RoleToWorkgroupId", "RoleId1", "WorkgroupId1" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleToWorkgroupId",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleToWorkgroupId");

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
                name: "FK_PermissionsToWorkgroupRoles_RoleToWorkgroup_RoleToWorkgroup~",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleToWorkgroupId",
                principalTable: "RoleToWorkgroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_Workgroups_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles",
                column: "WorkgroupId1",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_AspNetRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_RoleToWorkgroup_RoleToWorkgroup~",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_Workgroups_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_AspNetRoles_RoleId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleToWorkgroup_Workgroups_WorkgroupId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionsToWorkgroupRoles",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleToWorkgroupId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsToWorkgroupRoles_WorkgroupId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DeleteData(
                table: "PermissionsToWorkgroupRoles",
                keyColumns: new[] { "PermissionId", "RoleToWorkgroupId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DropColumn(
                name: "RoleToWorkgroupId",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.DropColumn(
                name: "WorkgroupId1",
                table: "PermissionsToWorkgroupRoles");

            migrationBuilder.AlterColumn<int>(
                name: "WorkgroupId",
                table: "RoleToWorkgroup",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "RoleToWorkgroup",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkgroupId",
                table: "PermissionsToWorkgroupRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "PermissionsToWorkgroupRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionsToWorkgroupRoles",
                table: "PermissionsToWorkgroupRoles",
                columns: new[] { "PermissionId", "WorkgroupId", "RoleId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "43733f09-2ff3-4cbf-bdbb-0ea5f9ec5d77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "94b4a28f-70a4-4b1c-98f4-eba793b2884d");

            migrationBuilder.InsertData(
                table: "PermissionsToWorkgroupRoles",
                columns: new[] { "PermissionId", "WorkgroupId", "RoleId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsToWorkgroupRoles_RoleId",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsToWorkgroupRoles_WorkgroupId",
                table: "PermissionsToWorkgroupRoles",
                column: "WorkgroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_AspNetRoles_RoleId",
                table: "PermissionsToWorkgroupRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsToWorkgroupRoles_Workgroups_WorkgroupId",
                table: "PermissionsToWorkgroupRoles",
                column: "WorkgroupId",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
