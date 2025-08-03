using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class VariasTablasSonMuchas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientDirections_AddressId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressId",
                table: "Patients");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patient_Identification",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "ArsPlansId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PatientEmergencieContact",
                table: "Patients",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PatientFisRecord",
                table: "Patients",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DateDoctorId",
                table: "MedicEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConsultationType",
                columns: table => new
                {
                    ConsultationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstConsultation = table.Column<int>(type: "int", nullable: false),
                    FollowUpConsultation = table.Column<int>(type: "int", nullable: false),
                    ProcedureConsultation = table.Column<int>(type: "int", nullable: false),
                    Others = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationType", x => x.ConsultationTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DateDoctors",
                columns: table => new
                {
                    DateDoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateDoctorSintoms = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoctorIndicatedAnalisis = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoctorTreatment = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoctorNotes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoctorNextDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MedicEvaluationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDoctors", x => x.DateDoctorId);
                    table.ForeignKey(
                        name: "FK_DateDoctors_MedicEvaluations_MedicEvaluationId",
                        column: x => x.MedicEvaluationId,
                        principalTable: "MedicEvaluations",
                        principalColumn: "MedicEvaluationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DoctorAddresses",
                columns: table => new
                {
                    DoctorAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorHouseNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorStreet = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAddresses", x => x.DoctorAddressId);
                    table.ForeignKey(
                        name: "FK_DoctorAddresses_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorLastName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorPhone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorEmail = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorIdCard = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorPassport = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorSpeciality = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorAddressId = table.Column<int>(type: "int", nullable: false),
                    DoctorExecatur = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_DoctorAddresses_DoctorAddressId",
                        column: x => x.DoctorAddressId,
                        principalTable: "DoctorAddresses",
                        principalColumn: "DoctorAddressId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DateMedics",
                columns: table => new
                {
                    DateMedicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DateMedicDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HospitalMedicDate = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationTypeId = table.Column<int>(type: "int", nullable: false),
                    DateDoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMedics", x => x.DateMedicId);
                    table.ForeignKey(
                        name: "FK_DateMedics_ConsultationType_ConsultationTypeId",
                        column: x => x.ConsultationTypeId,
                        principalTable: "ConsultationType",
                        principalColumn: "ConsultationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateMedics_DateDoctors_DateDoctorId",
                        column: x => x.DateDoctorId,
                        principalTable: "DateDoctors",
                        principalColumn: "DateDoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateMedics_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateMedics_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DoctorEnsurances",
                columns: table => new
                {
                    DoctorEnsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ArsEnsuranceId = table.Column<int>(type: "int", nullable: false),
                    MedicCode = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEnsurances", x => x.DoctorEnsuranceId);
                    table.ForeignKey(
                        name: "FK_DoctorEnsurances_ArsEnsurance_ArsEnsuranceId",
                        column: x => x.ArsEnsuranceId,
                        principalTable: "ArsEnsurance",
                        principalColumn: "ArsEnsuranceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorEnsurances_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    FollowUpMedicRecord = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SignsMedicRecord = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_MedicRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatientDoctors",
                columns: table => new
                {
                    PatientDoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDoctors", x => x.PatientDoctorId);
                    table.ForeignKey(
                        name: "FK_PatientDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDoctors_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ArsPlansId",
                table: "Patients",
                column: "ArsPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodId",
                table: "Patients",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_DateDoctors_MedicEvaluationId",
                table: "DateDoctors",
                column: "MedicEvaluationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DateMedics_ConsultationTypeId",
                table: "DateMedics",
                column: "ConsultationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMedics_DateDoctorId",
                table: "DateMedics",
                column: "DateDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMedics_DoctorId",
                table: "DateMedics",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMedics_PatientId",
                table: "DateMedics",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAddresses_SectorId",
                table: "DoctorAddresses",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEnsurances_ArsEnsuranceId",
                table: "DoctorEnsurances",
                column: "ArsEnsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEnsurances_DoctorId",
                table: "DoctorEnsurances",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorAddressId",
                table: "Doctors",
                column: "DoctorAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicRecords_DoctorId",
                table: "MedicRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicRecords_PatientId",
                table: "MedicRecords",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctor_DoctorId_PatientId",
                table: "PatientDoctors",
                columns: new[] { "DoctorId", "PatientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctors_PatientId",
                table: "PatientDoctors",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ArsPlans_ArsPlansId",
                table: "Patients",
                column: "ArsPlansId",
                principalTable: "ArsPlans",
                principalColumn: "ArsPlansId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Blood_BloodId",
                table: "Patients",
                column: "BloodId",
                principalTable: "Blood",
                principalColumn: "BloodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientDirections_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "PatientDirections",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ArsPlans_ArsPlansId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Blood_BloodId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientDirections_AddressId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "DateMedics");

            migrationBuilder.DropTable(
                name: "DoctorEnsurances");

            migrationBuilder.DropTable(
                name: "MedicRecords");

            migrationBuilder.DropTable(
                name: "PatientDoctors");

            migrationBuilder.DropTable(
                name: "ConsultationType");

            migrationBuilder.DropTable(
                name: "DateDoctors");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "DoctorAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ArsPlansId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ArsPlansId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BloodId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientEmergencieContact",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientFisRecord",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateDoctorId",
                table: "MedicEvaluations");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patient_Identification",
                table: "Patients",
                sql: "PatientIdCard IS NOT NULL OR PatientPassport IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientDirections_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "PatientDirections",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
