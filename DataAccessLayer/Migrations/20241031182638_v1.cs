using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerBirthday = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomerStatus = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeNote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "BookingReservations",
                columns: table => new
                {
                    BookingReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingReservations", x => x.BookingReservationID);
                    table.ForeignKey(
                        name: "FK_BookingReservations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomInformations",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomDetailDescription = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    RoomMaxCapacity = table.Column<int>(type: "int", nullable: true),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    RoomStatus = table.Column<int>(type: "int", nullable: true),
                    RoomPricePerDate = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInformations", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_RoomInformations_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingReservationID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => new { x.BookingReservationID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_BookingDetails_BookingReservations_BookingReservationID",
                        column: x => x.BookingReservationID,
                        principalTable: "BookingReservations",
                        principalColumn: "BookingReservationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_RoomInformations_RoomID",
                        column: x => x.RoomID,
                        principalTable: "RoomInformations",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerBirthday", "CustomerFullName", "CustomerStatus", "EmailAddress", "Password", "Telephone" },
                values: new object[,]
                {
                    { 3, new DateOnly(1990, 2, 2), "William Shakespeare", 1, "WilliamShakespeare@FUMiniHotel.org", "123@", "0903939393" },
                    { 5, new DateOnly(1991, 3, 3), "Elizabeth Taylor", 1, "ElizabethTaylor@FUMiniHotel.org", "144@", "0903939377" },
                    { 8, new DateOnly(1992, 11, 10), "James Cameron", 1, "JamesCameron@FUMiniHotel.org", "443@", "0903946582" },
                    { 9, new DateOnly(1991, 12, 5), "Charles Dickens", 1, "CharlesDickens@FUMiniHotel.org", "563@", "0903955633" },
                    { 10, new DateOnly(1993, 12, 24), "George Orwell", 1, "GeorgeOrwell@FUMiniHotel.org", "177@", "0913933493" },
                    { 11, new DateOnly(1990, 9, 9), "Victoria Beckham", 1, "VictoriaBeckham@FUMiniHotel.org", "654@", "0983246773" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeID", "RoomTypeName", "TypeDescription", "TypeNote" },
                values: new object[,]
                {
                    { 1, "Standard room", "Basic amenities such as a bed, dresser, and TV.", "N/A" },
                    { 2, "Suite", "Offers more space and amenities like a living area and kitchenette.", "N/A" },
                    { 3, "Deluxe room", "Deluxe rooms with additional features like balcony or sea view.", "N/A" },
                    { 4, "Executive room", "Designed for business travelers with perks like free breakfast.", "N/A" },
                    { 5, "Family Room", "Specifically designed for families with multiple beds and additional space.", "N/A" },
                    { 6, "Connecting Room", "Rooms with a connecting door for larger groups or families.", "N/A" },
                    { 7, "Penthouse Suite", "An extravagant suite with exceptional views and exclusive amenities.", "N/A" },
                    { 8, "Bungalow", "Standalone cottage-style accommodation for privacy.", "N/A" }
                });

            migrationBuilder.InsertData(
                table: "BookingReservations",
                columns: new[] { "BookingReservationID", "BookingDate", "BookingStatus", "CustomerID", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 12, 20), 1, 3, 378.00m },
                    { 2, new DateOnly(2023, 12, 21), 1, 3, 1493.00m }
                });

            migrationBuilder.InsertData(
                table: "RoomInformations",
                columns: new[] { "RoomID", "RoomDetailDescription", "RoomMaxCapacity", "RoomNumber", "RoomPricePerDate", "RoomStatus", "RoomTypeID" },
                values: new object[,]
                {
                    { 1, "A basic room with essential amenities.", 3, "2364", 149.00m, 1, 1 },
                    { 2, "Deluxe room with additional features.", 5, "3345", 299.00m, 1, 3 },
                    { 3, "Luxurious room with separate living and sleeping areas.", 4, "4432", 199.00m, 1, 2 },
                    { 5, "Floor 3, North West window.", 5, "3342", 219.00m, 1, 5 },
                    { 7, "Floor 4, South window.", 4, "4434", 179.00m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "BookingReservationID", "RoomID", "ActualPrice", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 3, 199.00m, new DateOnly(2024, 1, 2), new DateOnly(2024, 1, 1) },
                    { 1, 7, 179.00m, new DateOnly(2024, 1, 2), new DateOnly(2024, 1, 1) },
                    { 2, 3, 199.00m, new DateOnly(2024, 1, 6), new DateOnly(2024, 1, 5) },
                    { 2, 5, 219.00m, new DateOnly(2024, 1, 9), new DateOnly(2024, 1, 5) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomID",
                table: "BookingDetails",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingReservations_CustomerID",
                table: "BookingReservations",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInformations_RoomTypeID",
                table: "RoomInformations",
                column: "RoomTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "BookingReservations");

            migrationBuilder.DropTable(
                name: "RoomInformations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
