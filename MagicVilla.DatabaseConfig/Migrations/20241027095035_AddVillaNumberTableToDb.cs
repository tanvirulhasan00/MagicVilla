using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "VillaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 27, 15, 50, 34, 381, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 15, 10, 53, 16, DateTimeKind.Local).AddTicks(7510));
        }
    }
}
