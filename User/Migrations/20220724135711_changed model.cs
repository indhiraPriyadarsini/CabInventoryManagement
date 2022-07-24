using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabInventoryManagement.Migrations
{
    public partial class changedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Route",
                table: "Booking",
                newName: "Onboarding");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Onboarding",
                table: "Booking",
                newName: "Route");
        }
    }
}
