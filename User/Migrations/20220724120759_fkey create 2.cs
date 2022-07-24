using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabInventoryManagement.Migrations
{
    public partial class fkeycreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Users_UserId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Booking",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                newName: "IX_Booking_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Users_UserID",
                table: "Booking",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Users_UserID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Booking",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserID",
                table: "Booking",
                newName: "IX_Booking_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Users_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
