using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class ProceduresControllerfixed : Migration
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
					EndedOnSchedule = table.Column<bool>(type: "bit", nullable: false),
					BloodWasReturned = table.Column<bool>(type: "bit", nullable: false),
					ReasonOfUnplannedTermination = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PatientDied = table.Column<bool>(type: "bit", nullable: false),
					DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
					Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Procedure", x => x.Id);
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropTable(
				name: "Procedure");
		}
    }
}
