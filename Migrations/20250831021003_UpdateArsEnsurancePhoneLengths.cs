using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArsEnsurancePhoneLengths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "EnsurancePhone2",
                table: "ArsEnsurance",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnsurancePhone",
                table: "ArsEnsurance",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnsuranceFax",
                table: "ArsEnsurance",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "EnsurancePhone2",
                table: "ArsEnsurance",
                type: "varchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnsurancePhone",
                table: "ArsEnsurance",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnsuranceFax",
                table: "ArsEnsurance",
                type: "varchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
