using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UMIS.DAL.DomainAuth.Migrations
{
    public partial class ChangeWorkgroupToUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserToWorkgroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleToWorkgroup",
                table: "RoleToWorkgroup");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "RoleToWorkgroup",
                keyColumns: new[] { "WorkgroupId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RoleToWorkgroup",
                nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleToWorkgroup",
                table: "RoleToWorkgroup",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserToRoleWorkgroup",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleToWorkgroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRoleWorkgroup", x => new { x.UserId, x.RoleToWorkgroupId });
                    table.ForeignKey(
                        name: "FK_UserToRoleWorkgroup_RoleToWorkgroup_RoleToWorkgroupId",
                        column: x => x.RoleToWorkgroupId,
                        principalTable: "RoleToWorkgroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRoleWorkgroup_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "RoleToWorkgroup",
                columns: new[] { "Id", "RoleId", "WorkgroupId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RoleToWorkgroup_WorkgroupId",
                table: "RoleToWorkgroup",
                column: "WorkgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoleWorkgroup_RoleToWorkgroupId",
                table: "UserToRoleWorkgroup",
                column: "RoleToWorkgroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToRoleWorkgroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleToWorkgroup",
                table: "RoleToWorkgroup");

            migrationBuilder.DropIndex(
                name: "IX_RoleToWorkgroup_WorkgroupId",
                table: "RoleToWorkgroup");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoleToWorkgroup");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleToWorkgroup",
                table: "RoleToWorkgroup",
                columns: new[] { "WorkgroupId", "RoleId" });

            migrationBuilder.CreateTable(
                name: "UserToWorkgroup",
                columns: table => new
                {
                    WorkgroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToWorkgroup", x => new { x.WorkgroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserToWorkgroup_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToWorkgroup_Workgroups_WorkgroupId",
                        column: x => x.WorkgroupId,
                        principalTable: "Workgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e9df5267-ba18-49e0-a877-554ab40c2ff7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8e6da75b-607e-4515-a863-aee99af6d769");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToWorkgroup_UserId",
                table: "UserToWorkgroup",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
