using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasClinicallySignificantCoagulationDisorders",
                table: "Patient");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Patient");

            migrationBuilder.AddColumn<bool>(
                name: "HasClinicallySignificantCoagulationDisorders",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
