using Microsoft.EntityFrameworkCore.Migrations;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class RestructuredBaseEntityWithOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowedOnlyForOwner",
                table: "Workgroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowedOnlyForOwner",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowedOnlyForOwner",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bcb888bf-0bd1-4aad-898a-596415eb9cac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "79410487-1611-4bd3-aacc-15a2fecaa223");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedOnlyForOwner",
                table: "Workgroups");

            migrationBuilder.DropColumn(
                name: "AllowedOnlyForOwner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AllowedOnlyForOwner",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AspNetRoles");

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
        }
    }
}
