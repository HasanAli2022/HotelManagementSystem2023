using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartHotelID = table.Column<int>(type: "int", nullable: false),
                    CartRoomID = table.Column<int>(type: "int", nullable: false),
                    CartRDID = table.Column<int>(type: "int", nullable: false),
                    CartPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    HotelAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HotelCity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    HotelImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHotelID = table.Column<int>(type: "int", nullable: false),
                    InvoiceRoomID = table.Column<int>(type: "int", nullable: false),
                    InvoiceRDID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceUserID = table.Column<int>(type: "int", nullable: false),
                    InvoiceTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceNetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceDateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    RDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RDImage1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RDImage2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RDImage3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RDFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RDFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RDRoomID = table.Column<int>(type: "int", nullable: false),
                    RDHotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.RDID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomPrice = table.Column<float>(type: "real", nullable: false),
                    RoomImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomHotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "RoomDetails");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
