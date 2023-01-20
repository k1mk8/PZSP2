using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class SurveyRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Servey",
                table: "Servey");

            migrationBuilder.RenameTable(
                name: "Servey",
                newName: "Survey");

            migrationBuilder.RenameColumn(
                name: "ServeyDate",
                table: "Survey",
                newName: "SurveyDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Survey",
                table: "Survey",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Survey",
                table: "Survey");

            migrationBuilder.RenameTable(
                name: "Survey",
                newName: "Servey");

            migrationBuilder.RenameColumn(
                name: "SurveyDate",
                table: "Servey",
                newName: "ServeyDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servey",
                table: "Servey",
                column: "Id");
        }
    }
}
