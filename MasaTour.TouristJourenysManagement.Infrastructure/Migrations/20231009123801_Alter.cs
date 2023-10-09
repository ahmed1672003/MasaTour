using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasaTour.TouristTripsManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelAR",
                table: "Transporations");

            migrationBuilder.DropColumn(
                name: "ModelDE",
                table: "Transporations");

            migrationBuilder.RenameColumn(
                name: "ModelEN",
                table: "Transporations",
                newName: "Model");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Transporations",
                newName: "ModelEN");

            migrationBuilder.AddColumn<string>(
                name: "ModelAR",
                table: "Transporations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelDE",
                table: "Transporations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
