using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class RemoveCompositeKeysTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "LayoutID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "LayoutID", "AmenityID" },
                keyValues: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "LayoutID", "Price", "RoomNumber" },
                values: new object[] { 1, 1, 100.00m, 101 });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "LayoutID", "AmenityID" },
                values: new object[] { 1, 1 });
        }
    }
}
