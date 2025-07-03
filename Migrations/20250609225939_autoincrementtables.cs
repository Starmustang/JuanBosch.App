using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class autoincrementtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "PatientDirections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDirections_SectorId",
                table: "PatientDirections",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDirections_Sectors_SectorId",
                table: "PatientDirections",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDirections_Sectors_SectorId",
                table: "PatientDirections");

            migrationBuilder.DropIndex(
                name: "IX_PatientDirections_SectorId",
                table: "PatientDirections");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "PatientDirections");
        }
    }
}
