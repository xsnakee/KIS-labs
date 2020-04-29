﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UMIS.DAL.DomainAuth;

namespace UMIS.DAL.DomainAuth.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20191108083735_RestructuredBaseEntityWithOwner")]
    partial class RestructuredBaseEntityWithOwner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActionTypeNum");

                    b.Property<bool>("AllowedOnlyForOwner");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int?>("EntityTypeNum");

                    b.Property<bool>("IsRemoved");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new { Id = 1, AllowedOnlyForOwner = true, CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsRemoved = false, IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Полный доступ", OwnerId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.PermissionsToWorkgroupRole", b =>
                {
                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleToWorkgroupId");

                    b.Property<int?>("RoleId1");

                    b.Property<int?>("WorkgroupId1");

                    b.HasKey("PermissionId", "RoleToWorkgroupId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("RoleToWorkgroupId");

                    b.HasIndex("WorkgroupId1");

                    b.ToTable("PermissionsToWorkgroupRoles");

                    b.HasData(
                        new { PermissionId = 1, RoleToWorkgroupId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.RoleToWorkgroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RoleId");

                    b.Property<int?>("WorkgroupId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkgroupId");

                    b.ToTable("RoleToWorkgroup");

                    b.HasData(
                        new { Id = 1, RoleId = 1, WorkgroupId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.UserToRoleWorkgroup", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int?>("RoleToWorkgroupId");

                    b.HasKey("UserId", "RoleToWorkgroupId");

                    b.HasIndex("RoleToWorkgroupId");

                    b.ToTable("UserToRoleWorkgroup");
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowedOnlyForOwner");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsRemoved");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = 1, AllowedOnlyForOwner = false, ConcurrencyStamp = "bcb888bf-0bd1-4aad-898a-596415eb9cac", CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsRemoved = false, IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Администратор", NormalizedName = "АДМИНИСТРАТОР", OwnerId = 1 },
                        new { Id = 2, AllowedOnlyForOwner = false, ConcurrencyStamp = "79410487-1611-4bd3-aacc-15a2fecaa223", CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsRemoved = false, IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Главный врач", NormalizedName = "ГЛАВНЫЙ ВРАЧ", OwnerId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("AllowedOnlyForOwner");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsRemoved");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int>("OwnerId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.Workgroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowedOnlyForOwner");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsRemoved");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Workgroups");

                    b.HasData(
                        new { Id = 1, AllowedOnlyForOwner = false, CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsRemoved = false, IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "System", OwnerId = 1 }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.PermissionsToWorkgroupRole", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Permission", "Permission")
                        .WithMany("PermissionsToWorkgroupRole")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId1");

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.RoleToWorkgroup", "RoleToWorkgroup")
                        .WithMany()
                        .HasForeignKey("RoleToWorkgroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Workgroup")
                        .WithMany("Permissions")
                        .HasForeignKey("WorkgroupId1");
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.RoleToWorkgroup", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Role", "Role")
                        .WithMany("RoleToWorkgroup")
                        .HasForeignKey("RoleId");

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Workgroup", "Workgroup")
                        .WithMany("RoleToWorkgroup")
                        .HasForeignKey("WorkgroupId");
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.UserToRoleWorkgroup", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.RoleToWorkgroup", "RoleToWorkgroup")
                        .WithMany("UserToRoleWorkgroup")
                        .HasForeignKey("RoleToWorkgroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User", "User")
                        .WithMany("UserToRoleWorkgroup")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
