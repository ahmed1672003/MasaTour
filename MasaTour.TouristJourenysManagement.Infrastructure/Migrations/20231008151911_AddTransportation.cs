using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasaTour.TouristTripsManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTransportation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransporationClasses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameDE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PriceEGPPerKilometer = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PriceGbpPerKilometer = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PriceEURPerKilometer = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PriceUSDPerKilometer = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DescriptionAR = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DescriptionDE = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransporationClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transporations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ModelAR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModelEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModelDE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    DesceiptionAR = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DesceiptionEN = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DesceiptionDE = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransporationClassId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transporations_TransporationClasses_TransporationClassId",
                        column: x => x.TransporationClassId,
                        principalTable: "TransporationClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransporationClasses_NameAR",
                table: "TransporationClasses",
                column: "NameAR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransporationClasses_NameDE",
                table: "TransporationClasses",
                column: "NameDE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransporationClasses_NameEN",
                table: "TransporationClasses",
                column: "NameEN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transporations_TransporationClassId",
                table: "Transporations",
                column: "TransporationClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transporations");

            migrationBuilder.DropTable(
                name: "TransporationClasses");
        }
    }
}
