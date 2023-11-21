using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    public partial class success_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingsSateDescription_Bookings_bookingID",
                table: "BookingsSateDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingsSateDescription",
                table: "BookingsSateDescription");

            migrationBuilder.RenameTable(
                name: "BookingsSateDescription",
                newName: "BookingStateDescription");

            migrationBuilder.RenameIndex(
                name: "IX_BookingsSateDescription_bookingID",
                table: "BookingStateDescription",
                newName: "IX_BookingStateDescription_bookingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingStateDescription",
                table: "BookingStateDescription",
                column: "stateID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingStateDescription_Bookings_bookingID",
                table: "BookingStateDescription",
                column: "bookingID",
                principalTable: "Bookings",
                principalColumn: "bookingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingStateDescription_Bookings_bookingID",
                table: "BookingStateDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingStateDescription",
                table: "BookingStateDescription");

            migrationBuilder.RenameTable(
                name: "BookingStateDescription",
                newName: "BookingsSateDescription");

            migrationBuilder.RenameIndex(
                name: "IX_BookingStateDescription_bookingID",
                table: "BookingsSateDescription",
                newName: "IX_BookingsSateDescription_bookingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingsSateDescription",
                table: "BookingsSateDescription",
                column: "stateID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingsSateDescription_Bookings_bookingID",
                table: "BookingsSateDescription",
                column: "bookingID",
                principalTable: "Bookings",
                principalColumn: "bookingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
