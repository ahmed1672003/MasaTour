using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasaTour.TouristTripsManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alterww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_TransportationClasses_TransporationClassId",
                table: "Transportations");

            migrationBuilder.RenameColumn(
                name: "TransporationClassId",
                table: "Transportations",
                newName: "TransportationClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Transportations_TransporationClassId",
                table: "Transportations",
                newName: "IX_Transportations_TransportationClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_TransportationClasses_TransportationClassId",
                table: "Transportations",
                column: "TransportationClassId",
                principalTable: "TransportationClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_TransportationClasses_TransportationClassId",
                table: "Transportations");

            migrationBuilder.RenameColumn(
                name: "TransportationClassId",
                table: "Transportations",
                newName: "TransporationClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Transportations_TransportationClassId",
                table: "Transportations",
                newName: "IX_Transportations_TransporationClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_TransportationClasses_TransporationClassId",
                table: "Transportations",
                column: "TransporationClassId",
                principalTable: "TransportationClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
