using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    VillaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.VillaId);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "VillaId", "Amenity", "CreatedDate", "ImageUrl", "Occupancy", "Rate", "Sqft", "UpdatedDate", "VillaDetails", "VillaName" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7490), "https://dotnetmastery.com/bluevillaimages/villa3.jpg", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Royal Villa" },
                    { 2, "", new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7505), "https://dotnetmastery.com/bluevillaimages/villa1.jpg", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Premium Pool Villa" },
                    { 3, "", new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7507), "https://dotnetmastery.com/bluevillaimages/villa4.jpg", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Luxury Pool Villa" },
                    { 4, "", new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7509), "https://dotnetmastery.com/bluevillaimages/villa5.jpg", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Villa" },
                    { 5, "", new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7510), "https://dotnetmastery.com/bluevillaimages/villa2.jpg", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Pool Villa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
