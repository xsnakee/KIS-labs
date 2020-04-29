using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class UpdatedCommonCustomizedAndPermissionEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Workgroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ActionTypeNum",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowedOnlyForOwner",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EntityTypeNum",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "AllowedOnlyForOwner",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Workgroups");

            migrationBuilder.DropColumn(
                name: "ActionTypeNum",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "AllowedOnlyForOwner",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "EntityTypeNum",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e9df9826-4e15-4d92-b250-20b985d4c638");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e712d29d-5e2d-415c-b8d6-0e3d022527f6");
        }
    }
}
