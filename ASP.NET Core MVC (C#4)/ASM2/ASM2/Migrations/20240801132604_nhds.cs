using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM2.Migrations
{
    public partial class nhds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "donHangs",
                columns: table => new
                {
                    MaDonHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDonHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    khachhangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donHangs", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_donHangs_khachHangs_khachhangId",
                        column: x => x.khachhangId,
                        principalTable: "khachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "donHangs",
                columns: new[] { "MaDonHang", "NgayDat", "TenDonHang", "khachhangId" },
                values: new object[] { "DH01", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sach", null });

            migrationBuilder.InsertData(
                table: "khachHangs",
                columns: new[] { "Id", "DiaChi", "HoTen", "Tuoi" },
                values: new object[] { new Guid("14cfb6d5-52b5-4cb6-a4ab-61e028a776e5"), "Vinh Loc - Phung Xa", "Nguyen Hong Minh", 20 });

            migrationBuilder.CreateIndex(
                name: "IX_donHangs_khachhangId",
                table: "donHangs",
                column: "khachhangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donHangs");

            migrationBuilder.DropTable(
                name: "khachHangs");
        }
    }
}
