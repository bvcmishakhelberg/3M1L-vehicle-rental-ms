using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3M1L_vehicle_rental_ms.Migrations
{
    /// <inheritdoc />
    public partial class changetablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "Vehicle",
                newName: "VehicleModel");

            migrationBuilder.RenameColumn(
                name: "VehicleMakeModel",
                table: "Vehicle",
                newName: "VehicleManufacturer");

            migrationBuilder.AlterColumn<bool>(
                name: "VehicleAvailability",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleModel",
                table: "Vehicle",
                newName: "VehicleType");

            migrationBuilder.RenameColumn(
                name: "VehicleManufacturer",
                table: "Vehicle",
                newName: "VehicleMakeModel");

            migrationBuilder.AlterColumn<bool>(
                name: "VehicleAvailability",
                table: "Vehicle",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
