using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomLayouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomLayouts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                column: "ID",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null },
                    { 2, null, null, null, null, null },
                    { 3, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "RoomLayouts",
                columns: new[] { "ID", "Layout" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "RoomLayouts");
        }
    }
}
