using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddLayoutsRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomLayouts_LayoutID",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "HotelRooms");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LayoutID",
                table: "HotelRooms",
                newName: "IX_HotelRooms_LayoutID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomLayouts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Amenities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelID", "LayoutID" });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Guy holding a coffee pot in the corner of the room");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Mentos Dispenser");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Coat-Hanging Robot");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { "Las Vegas", "Fine Hotel", "12-GET-HOTEL", "Nevada", "1234 Hotel Street" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { "Seattle", "Wow Motel", "56-WOW-MOTEL", "Washington", "5678 Motel Avenue" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { "Detroit", "Low-Costel Hostel", "910-LOW-COST", "Michigan", "9101 Hostel Circle" });

            migrationBuilder.UpdateData(
                table: "RoomLayouts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Layout", "Name" },
                values: new object[] { 3, "Deluxe" });

            migrationBuilder.UpdateData(
                table: "RoomLayouts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Layout", "Name" },
                values: new object[] { 1, "Business" });

            migrationBuilder.UpdateData(
                table: "RoomLayouts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Layout", "Name" },
                values: new object[] { 2, "Suite" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityID",
                table: "RoomAmenities",
                column: "AmenityID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_RoomLayouts_LayoutID",
                table: "HotelRooms",
                column: "LayoutID",
                principalTable: "RoomLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenityID",
                table: "RoomAmenities",
                column: "AmenityID",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_RoomLayouts_LayoutID",
                table: "RoomAmenities",
                column: "LayoutID",
                principalTable: "RoomLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_RoomLayouts_LayoutID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenityID",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_RoomLayouts_LayoutID",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenityID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRooms_LayoutID",
                table: "Rooms",
                newName: "IX_Rooms_LayoutID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomLayouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                columns: new[] { "HotelID", "LayoutID" });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RoomLayouts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Layout", "Name" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "RoomLayouts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Layout", "Name" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "RoomLayouts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Layout", "Name" },
                values: new object[] { 0, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelID",
                table: "Rooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomLayouts_LayoutID",
                table: "Rooms",
                column: "LayoutID",
                principalTable: "RoomLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
