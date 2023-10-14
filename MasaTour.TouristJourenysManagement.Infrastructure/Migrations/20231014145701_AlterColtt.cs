using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasaTour.TouristTripsManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Users",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Users",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Users",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");
        }
    }
}
