using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasaTour.TouristTripsManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Trips",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PhaseNumber",
                table: "TripPhases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "PhaseNumber",
                table: "TripPhases");
        }
    }
}
