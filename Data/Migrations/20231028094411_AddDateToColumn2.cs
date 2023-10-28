using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "İzmir" },
                    { 3, "Ankara" },
                    { 4, "Antalya" },
                    { 5, "Muğla" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, "Company 1" },
                    { 2, "Company 2" },
                    { 3, "Company 3" },
                    { 4, "Company 4" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "AllInclusive", "CityId", "CompanyId", "ImageUrl", "IsHome", "Name", "RoomService", "Stars", "TotalRoom" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "hotel-1.jpg", true, "Swiss Hotel", true, 5, 200 },
                    { 2, true, 1, 2, "hotel-2.jpg", true, "Hilton Hotel", true, 5, 200 },
                    { 3, true, 2, 3, "hotel-3.jpg", true, "Garden Hotel", true, 5, 200 },
                    { 4, true, 2, 4, "hotel-4.jpg", false, "Plaza Hotel", true, 5, 200 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "BedsCount", "Discount", "EntryDate", "GuestCapacity", "HotelId", "ImageUrl", "InnerRoomCount", "IsEmpty", "Name", "Price", "ReleaseDate", "RoomNumber", "SquareMeters", "Tv" },
                values: new object[,]
                {
                    { 1, 4, 0.0, new DateTime(2023, 10, 25, 12, 44, 11, 727, DateTimeKind.Local).AddTicks(7055), 5, 1, "room-1.jpg", 3, true, "King", 10000.0, new DateTime(2023, 10, 27, 12, 44, 11, 727, DateTimeKind.Local).AddTicks(7072), 1, 150, true },
                    { 2, 4, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, "room-2.jpg", 3, true, "Honeymoon", 10000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 150, true },
                    { 3, 4, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "room-3.jpg", 3, true, "Honeymoon", 10000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 150, true },
                    { 4, 4, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "room-4.jpg", 3, true, "Standart", 10000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 150, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2);
        }
    }
}
