using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateMedicToUseEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateMedics_ConsultationType_ConsultationTypeId",
                table: "DateMedics");

            migrationBuilder.DropTable(
                name: "ConsultationType");

            migrationBuilder.DropIndex(
                name: "IX_DateMedics_ConsultationTypeId",
                table: "DateMedics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultationType",
                columns: table => new
                {
                    ConsultationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstConsultation = table.Column<int>(type: "int", nullable: false),
                    FollowUpConsultation = table.Column<int>(type: "int", nullable: false),
                    Others = table.Column<int>(type: "int", nullable: false),
                    ProcedureConsultation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationType", x => x.ConsultationTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DateMedics_ConsultationTypeId",
                table: "DateMedics",
                column: "ConsultationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateMedics_ConsultationType_ConsultationTypeId",
                table: "DateMedics",
                column: "ConsultationTypeId",
                principalTable: "ConsultationType",
                principalColumn: "ConsultationTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
