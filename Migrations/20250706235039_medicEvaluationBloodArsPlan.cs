using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class medicEvaluationBloodArsPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "PatientDirections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "PatientDirections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "PatientDirections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArsPlans",
                columns: table => new
                {
                    ArsPlansEnsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AfiliationNumberArs = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArsPlansName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoveragePlanArs = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InternationalCoverage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsPlanActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaxLimitArs = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArsPlans", x => x.ArsPlansEnsuranceId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicEvaluations",
                columns: table => new
                {
                    MedicEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeightEva = table.Column<int>(type: "int", nullable: false),
                    PresurreEva = table.Column<int>(type: "int", nullable: false),
                    BreathingEva = table.Column<int>(type: "int", nullable: false),
                    HeartRateEva = table.Column<string>(type: "varchar(900)", maxLength: 900, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OtherInfoEva = table.Column<string>(type: "varchar(900)", maxLength: 900, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeightEva = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreviousSickNessEva = table.Column<string>(type: "varchar(900)", maxLength: 900, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicEvaluations", x => x.MedicEvaluationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDirections_CountryId",
                table: "PatientDirections",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDirections_MunicipalityId",
                table: "PatientDirections",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDirections_ProvinceId",
                table: "PatientDirections",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDirections_Countries_CountryId",
                table: "PatientDirections",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDirections_Municipalities_MunicipalityId",
                table: "PatientDirections",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "MunicipalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDirections_Provinces_ProvinceId",
                table: "PatientDirections",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDirections_Countries_CountryId",
                table: "PatientDirections");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDirections_Municipalities_MunicipalityId",
                table: "PatientDirections");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDirections_Provinces_ProvinceId",
                table: "PatientDirections");

            migrationBuilder.DropTable(
                name: "ArsPlans");

            migrationBuilder.DropTable(
                name: "MedicEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_PatientDirections_CountryId",
                table: "PatientDirections");

            migrationBuilder.DropIndex(
                name: "IX_PatientDirections_MunicipalityId",
                table: "PatientDirections");

            migrationBuilder.DropIndex(
                name: "IX_PatientDirections_ProvinceId",
                table: "PatientDirections");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "PatientDirections");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "PatientDirections");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "PatientDirections");
        }
    }
}
