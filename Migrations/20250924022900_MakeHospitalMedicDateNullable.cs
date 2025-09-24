using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class MakeHospitalMedicDateNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HospitalMedicDate",
                table: "DateMedics",
                type: "varchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DateMedics",
                keyColumn: "HospitalMedicDate",
                keyValue: null,
                column: "HospitalMedicDate",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalMedicDate",
                table: "DateMedics",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
