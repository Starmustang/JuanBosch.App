using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanBosch.App.Migrations
{
    /// <inheritdoc />
    public partial class ArsEnsuranceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArsPlansEnsuranceId",
                table: "ArsPlans",
                newName: "ArsPlansId");

            migrationBuilder.AddColumn<int>(
                name: "ArsEnsuranceId",
                table: "ArsPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArsEnsurance",
                columns: table => new
                {
                    ArsEnsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnsuranceName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnsuranceDirection = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnsurancePhone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnsurancePhone2 = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnsuranceFax = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnsuranceEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnsuranceUpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EnsuranceSchedule = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArsEnsurance", x => x.ArsEnsuranceId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ArsPlans_ArsEnsuranceId",
                table: "ArsPlans",
                column: "ArsEnsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArsPlans_ArsEnsurance_ArsEnsuranceId",
                table: "ArsPlans",
                column: "ArsEnsuranceId",
                principalTable: "ArsEnsurance",
                principalColumn: "ArsEnsuranceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArsPlans_ArsEnsurance_ArsEnsuranceId",
                table: "ArsPlans");

            migrationBuilder.DropTable(
                name: "ArsEnsurance");

            migrationBuilder.DropIndex(
                name: "IX_ArsPlans_ArsEnsuranceId",
                table: "ArsPlans");

            migrationBuilder.DropColumn(
                name: "ArsEnsuranceId",
                table: "ArsPlans");

            migrationBuilder.RenameColumn(
                name: "ArsPlansId",
                table: "ArsPlans",
                newName: "ArsPlansEnsuranceId");
        }
    }
}
