using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasaTour.TouristJourenysManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFamous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFamous",
                table: "Journeys",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFamous",
                table: "Journeys");
        }
    }
}
