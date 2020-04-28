using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UMIS.DAL.Domain.Migrations
{
    public partial class init_common_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    AllowedOnlyForOwner = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DataType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    AllowedOnlyForOwner = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    AllowedOnlyForOwner = table.Column<bool>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_CatalogTypes_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    SNILS = table.Column<string>(nullable: true),
                    OMC = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: false),
                    DisabilityDescriptionId = table.Column<int>(nullable: true),
                    WorkHistoryId = table.Column<int>(nullable: true),
                    AllergyAnamnesisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_WorkHistories_WorkHistoryId",
                        column: x => x.WorkHistoryId,
                        principalTable: "WorkHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogToCatalogField",
                columns: table => new
                {
                    CatalogId = table.Column<int>(nullable: false),
                    CatalogFieldId = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<string>(nullable: true),
                    DefaultValue2 = table.Column<string>(nullable: true),
                    Units = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogToCatalogField", x => new { x.CatalogId, x.CatalogFieldId });
                    table.ForeignKey(
                        name: "FK_CatalogToCatalogField_CatalogFields_CatalogFieldId",
                        column: x => x.CatalogFieldId,
                        principalTable: "CatalogFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogToCatalogField_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergyAnamneses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyAnamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllergyAnamneses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisabilityDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    DisabilityGroup = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabilityDescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    AnamnesisType = table.Column<int>(nullable: false),
                    MedicalHistoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediacalAnamneses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    AnamnesisType = table.Column<int>(nullable: false),
                    MedicalHistoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediacalAnamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediacalAnamneses_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    MedicalExaminationType = table.Column<int>(nullable: false),
                    MedicalHistoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExaminations_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistoryNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    MedicalHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryNotes_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    PhysicalExaminationType = table.Column<int>(nullable: false),
                    MedicalHistoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalExaminations_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysiologicalIndications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    MedicalHistoryId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysiologicalIndications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysiologicalIndications_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalTestResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    MedicalExaminationId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalTestResult_MedicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalTestResult_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    AssignmentType = table.Column<int>(nullable: false),
                    MedicalHistoryId = table.Column<int>(nullable: false),
                    MedicalTestResultId = table.Column<int>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true),
                    PhysiologicalExaminationResultId = table.Column<int>(nullable: true),
                    PhysiologicalExaminationId = table.Column<int>(nullable: true),
                    PhysiologicalIndicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_MedicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_MedicalTestResult_MedicalTestResultId",
                        column: x => x.MedicalTestResultId,
                        principalTable: "MedicalTestResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_PhysicalExaminations_PhysiologicalExaminationRes~",
                        column: x => x.PhysiologicalExaminationResultId,
                        principalTable: "PhysicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_PhysiologicalIndications_PhysiologicalIndication~",
                        column: x => x.PhysiologicalIndicationId,
                        principalTable: "PhysiologicalIndications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    AllowedOnlyForOwner = table.Column<bool>(nullable: false),
                    CatalogToCatalogFieldCatalogId = table.Column<int>(nullable: true),
                    CatalogToCatalogFieldCatalogFieldId = table.Column<int>(nullable: true),
                    CatalogToCatalogFieldId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Value2 = table.Column<string>(nullable: true),
                    DianosisId = table.Column<int>(nullable: true),
                    MediacalAnamnesisId = table.Column<int>(nullable: true),
                    PhysiologicalIndicationId = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    MedicalHistoryId = table.Column<int>(nullable: true),
                    WorkHistoryId = table.Column<int>(nullable: true),
                    AllergyAnamnesisId = table.Column<int>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true),
                    DisabilityDescriptionId = table.Column<int>(nullable: true),
                    PhysicalExaminationId = table.Column<int>(nullable: true),
                    MedicalHistoryNoteId = table.Column<int>(nullable: true),
                    AssignmentId = table.Column<int>(nullable: true),
                    DiagnosisId = table.Column<int>(nullable: true),
                    MedicalTestResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_AllergyAnamneses_AllergyAnamnesisId",
                        column: x => x.AllergyAnamnesisId,
                        principalTable: "AllergyAnamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_DisabilityDescriptions_DisabilityDescrip~",
                        column: x => x.DisabilityDescriptionId,
                        principalTable: "DisabilityDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_MediacalAnamneses_MediacalAnamnesisId",
                        column: x => x.MediacalAnamnesisId,
                        principalTable: "MediacalAnamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_MedicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_MedicalHistoryNotes_MedicalHistoryNoteId",
                        column: x => x.MedicalHistoryNoteId,
                        principalTable: "MedicalHistoryNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_MedicalTestResult_MedicalTestResultId",
                        column: x => x.MedicalTestResultId,
                        principalTable: "MedicalTestResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_PhysicalExaminations_PhysicalExamination~",
                        column: x => x.PhysicalExaminationId,
                        principalTable: "PhysicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_PhysiologicalIndications_PhysiologicalIn~",
                        column: x => x.PhysiologicalIndicationId,
                        principalTable: "PhysiologicalIndications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_WorkHistories_WorkHistoryId",
                        column: x => x.WorkHistoryId,
                        principalTable: "WorkHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogFieldValues_CatalogToCatalogField_CatalogToCatalogFi~",
                        columns: x => new { x.CatalogToCatalogFieldCatalogId, x.CatalogToCatalogFieldCatalogFieldId },
                        principalTable: "CatalogToCatalogField",
                        principalColumns: new[] { "CatalogId", "CatalogFieldId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyAnamneses_PatientId",
                table: "AllergyAnamneses",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_MedicalExaminationId",
                table: "Assignment",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_MedicalHistoryId",
                table: "Assignment",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_MedicalTestResultId",
                table: "Assignment",
                column: "MedicalTestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_PhysiologicalExaminationResultId",
                table: "Assignment",
                column: "PhysiologicalExaminationResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_PhysiologicalIndicationId",
                table: "Assignment",
                column: "PhysiologicalIndicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_AllergyAnamnesisId",
                table: "CatalogFieldValues",
                column: "AllergyAnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_AssignmentId",
                table: "CatalogFieldValues",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_DiagnosisId",
                table: "CatalogFieldValues",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_DisabilityDescriptionId",
                table: "CatalogFieldValues",
                column: "DisabilityDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_MediacalAnamnesisId",
                table: "CatalogFieldValues",
                column: "MediacalAnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_MedicalExaminationId",
                table: "CatalogFieldValues",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_MedicalHistoryId",
                table: "CatalogFieldValues",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_MedicalHistoryNoteId",
                table: "CatalogFieldValues",
                column: "MedicalHistoryNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_MedicalTestResultId",
                table: "CatalogFieldValues",
                column: "MedicalTestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_PatientId",
                table: "CatalogFieldValues",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_PhysicalExaminationId",
                table: "CatalogFieldValues",
                column: "PhysicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_PhysiologicalIndicationId",
                table: "CatalogFieldValues",
                column: "PhysiologicalIndicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_WorkHistoryId",
                table: "CatalogFieldValues",
                column: "WorkHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFieldValues_CatalogToCatalogFieldCatalogId_CatalogTo~",
                table: "CatalogFieldValues",
                columns: new[] { "CatalogToCatalogFieldCatalogId", "CatalogToCatalogFieldCatalogFieldId" });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CatalogTypeId",
                table: "Catalogs",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogToCatalogField_CatalogFieldId",
                table: "CatalogToCatalogField",
                column: "CatalogFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_MedicalHistoryId",
                table: "Diagnoses",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityDescriptions_PatientId",
                table: "DisabilityDescriptions",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediacalAnamneses_MedicalHistoryId",
                table: "MediacalAnamneses",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_MedicalHistoryId",
                table: "MedicalExaminations",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryNotes_MedicalHistoryId",
                table: "MedicalHistoryNotes",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTestResult_MedicalExaminationId",
                table: "MedicalTestResult",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTestResult_PatientId",
                table: "MedicalTestResult",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_WorkHistoryId",
                table: "Patients",
                column: "WorkHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExaminations_MedicalHistoryId",
                table: "PhysicalExaminations",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysiologicalIndications_MedicalHistoryId",
                table: "PhysiologicalIndications",
                column: "MedicalHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogFieldValues");

            migrationBuilder.DropTable(
                name: "AllergyAnamneses");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "DisabilityDescriptions");

            migrationBuilder.DropTable(
                name: "MediacalAnamneses");

            migrationBuilder.DropTable(
                name: "MedicalHistoryNotes");

            migrationBuilder.DropTable(
                name: "CatalogToCatalogField");

            migrationBuilder.DropTable(
                name: "MedicalTestResult");

            migrationBuilder.DropTable(
                name: "PhysicalExaminations");

            migrationBuilder.DropTable(
                name: "PhysiologicalIndications");

            migrationBuilder.DropTable(
                name: "CatalogFields");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "MedicalExaminations");

            migrationBuilder.DropTable(
                name: "CatalogTypes");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "WorkHistories");
        }
    }
}
