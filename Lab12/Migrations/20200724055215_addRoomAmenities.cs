using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addRoomAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RoomLayouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Amenities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    LayoutID = table.Column<int>(nullable: false),
                    AmenityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.LayoutID, x.AmenityID });
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    LayoutID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => new { x.HotelID, x.LayoutID });
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomLayouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "RoomLayouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LayoutID",
                table: "Rooms",
                column: "LayoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RoomLayouts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Amenities");
        }
    }
}
