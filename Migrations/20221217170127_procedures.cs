using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class procedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    ProcedureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ECMO = table.Column<bool>(type: "bit", nullable: false),
                    Filter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtracorporealClearingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitrateConcentrate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnplanedTermination = table.Column<bool>(type: "bit", nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodReturn = table.Column<bool>(type: "bit", nullable: false),
                    PatientDeath = table.Column<bool>(type: "bit", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    SessionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeparinBolusDose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ACT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeparinDose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FraxiparinDose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FraxiparinDosingTiming = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AntiXa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CitratesConcentration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalciumCompensationPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IonizedCalcium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCalcium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HCO3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Citrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalciumCompensationMol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QBDose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QDDose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Predilution = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Postdilution = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UFDose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TMP = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureSession", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedure");

            migrationBuilder.DropTable(
                name: "ProcedureSession");
        }
    }
}
