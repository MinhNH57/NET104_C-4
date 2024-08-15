using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeThiThuLan1.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    MaDonHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDonHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    khachhangID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_DonHangs_KhachHangs_khachhangID",
                        column: x => x.khachhangID,
                        principalTable: "KhachHangs",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "DonHangs",
                columns: new[] { "MaDonHang", "NgayDat", "TenDonHang", "khachhangID" },
                values: new object[] { "DH01", new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giay", null });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "ID", "DiaChi", "Name", "Tuoi" },
                values: new object[] { new Guid("b661f182-772d-42c0-8809-e124d47370ce"), "Vinh Loc", "Nguyen Hong Minh", 20 });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_khachhangID",
                table: "DonHangs",
                column: "khachhangID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
