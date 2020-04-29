using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class changeRoleToWorkGroupDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowedOnlyForOwner",
                table: "RoleToWorkgroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "RoleToWorkgroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "RoleToWorkgroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "RoleToWorkgroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationDate",
                table: "RoleToWorkgroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "RoleToWorkgroup",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "69a54328-e13f-4e67-ad80-1f0cd7986aca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "be1490ac-9aaf-4b6c-a7aa-394f382455c0");

            migrationBuilder.UpdateData(
                table: "RoleToWorkgroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoleToWorkgroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedOnlyForOwner",
                table: "RoleToWorkgroup");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "RoleToWorkgroup");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "RoleToWorkgroup");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "RoleToWorkgroup");

            migrationBuilder.DropColumn(
                name: "LastModificationDate",
                table: "RoleToWorkgroup");

            migrationBuilder.DropColumn(
                name: "OwnerId",
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
        }
    }
}
