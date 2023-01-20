using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka2.Migrations
{
    /// <inheritdoc />
    public partial class mainUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "initial",
                table: "ProcedureSession",
                newName: "Initial");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartSessionDate",
                table: "ProcedureSession",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartSessionDate",
                table: "ProcedureSession");

            migrationBuilder.RenameColumn(
                name: "Initial",
                table: "ProcedureSession",
                newName: "initial");
        }
    }
}
