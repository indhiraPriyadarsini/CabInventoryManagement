using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabInventoryManagement.Migrations
{
    public partial class Bookingfkeyreferenceremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdref",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIdref",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
