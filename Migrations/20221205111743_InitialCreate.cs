using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartOfCKRTDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasLiverFailure = table.Column<bool>(type: "bit", nullable: false),
                    HasClinicallySignificantCoagulationDisorders = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
