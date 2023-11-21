using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    public partial class SUCCESS_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_addressID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_addressID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "addressID",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "sateID",
                table: "BookingsSateDescription",
                newName: "stateID");

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    cusAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    addressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.cusAddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Address_addressID",
                        column: x => x.addressID,
                        principalTable: "Address",
                        principalColumn: "addressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customer_customerID",
                        column: x => x.customerID,
                        principalTable: "Customer",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_addressID",
                table: "CustomerAddress",
                column: "addressID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_customerID",
                table: "CustomerAddress",
                column: "customerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.RenameColumn(
                name: "stateID",
                table: "BookingsSateDescription",
                newName: "sateID");

            migrationBuilder.AddColumn<int>(
                name: "addressID",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_addressID",
                table: "Customer",
                column: "addressID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_addressID",
                table: "Customer",
                column: "addressID",
                principalTable: "Address",
                principalColumn: "addressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
