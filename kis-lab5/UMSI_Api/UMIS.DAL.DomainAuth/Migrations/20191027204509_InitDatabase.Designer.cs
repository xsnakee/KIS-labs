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
    [Migration("20191027204509_InitDatabase")]
    partial class InitDatabase
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

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new { Id = 1, CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Полный доступ", OwnerId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.PermissionsToWorkgroupRole", b =>
                {
                    b.Property<int>("PermissionId");

                    b.Property<int?>("WorkgroupId");

                    b.Property<int?>("RoleId");

                    b.HasKey("PermissionId", "WorkgroupId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkgroupId");

                    b.ToTable("PermissionsToWorkgroupRoles");

                    b.HasData(
                        new { PermissionId = 1, WorkgroupId = 1, RoleId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.RoleToWorkgroup", b =>
                {
                    b.Property<int>("WorkgroupId");

                    b.Property<int>("RoleId");

                    b.HasKey("WorkgroupId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleToWorkgroup");

                    b.HasData(
                        new { WorkgroupId = 1, RoleId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.UserToWorkgroup", b =>
                {
                    b.Property<int>("WorkgroupId");

                    b.Property<int>("UserId");

                    b.HasKey("WorkgroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserToWorkgroup");
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("OwnerId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = 1, ConcurrencyStamp = "e9df5267-ba18-49e0-a877-554ab40c2ff7", CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Администратор", NormalizedName = "АДМИНИСТРАТОР", OwnerId = 1 },
                        new { Id = 2, ConcurrencyStamp = "8e6da75b-607e-4515-a863-aee99af6d769", CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Главный врач", NormalizedName = "ГЛАВНЫЙ ВРАЧ", OwnerId = 1 }
                    );
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsSystem");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Workgroups");

                    b.HasData(
                        new { Id = 1, CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsSystem = true, LastModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "System", OwnerId = 1 }
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
                        .WithMany("WorkgroupRoles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Workgroup", "Workgroup")
                        .WithMany("Permissions")
                        .HasForeignKey("WorkgroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.RoleToWorkgroup", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Role", "Role")
                        .WithMany("Workgroups")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Workgroup", "Workgroup")
                        .WithMany("Roles")
                        .HasForeignKey("WorkgroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels.UserToWorkgroup", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User", "User")
                        .WithMany("Workgroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.Workgroup", "Workgroup")
                        .WithMany("Users")
                        .HasForeignKey("WorkgroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UMIS.DAL.Domain.Contracts.Models.Auth.Role", b =>
                {
                    b.HasOne("UMIS.DAL.Domain.Contracts.Models.Auth.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
