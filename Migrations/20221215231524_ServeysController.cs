using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class ServeysController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ECMO = table.Column<bool>(type: "bit", nullable: false),
                    Anuria = table.Column<bool>(type: "bit", nullable: false),
                    ArterialHypertension = table.Column<bool>(type: "bit", nullable: false),
                    Overhydration = table.Column<bool>(type: "bit", nullable: false),
                    AKI = table.Column<bool>(type: "bit", nullable: false),
                    Creatinine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Urea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IonDisorder = table.Column<bool>(type: "bit", nullable: false),
                    MetabolicAcidosis = table.Column<bool>(type: "bit", nullable: false),
                    ExogenousPoison = table.Column<bool>(type: "bit", nullable: false),
                    SepticShock = table.Column<bool>(type: "bit", nullable: false),
                    LowerNephroneSyndrom = table.Column<bool>(type: "bit", nullable: false),
                    Anticoagulation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfVascularAccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatheterThickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatheterLength = table.Column<int>(type: "int", nullable: false),
                    VascularAccessSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servey", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servey");
        }
    }
}
