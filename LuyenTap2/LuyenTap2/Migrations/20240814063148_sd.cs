using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuyenTap2.Migrations
{
    public partial class sd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhoaHocName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.MaKhoaHoc);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    ChuyenNghanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    khoahocMaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinhViens_KhoaHocs_khoahocMaKhoaHoc",
                        column: x => x.khoahocMaKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "MaKhoaHoc");
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "ChuyenNghanh", "HoTen", "Tuoi", "khoahocMaKhoaHoc" },
                values: new object[] { new Guid("0b7540f7-996e-4736-b0b9-37d4837a8fa0"), "CNTT", "Nguyen Hong Minh", 20, null });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_khoahocMaKhoaHoc",
                table: "SinhViens",
                column: "khoahocMaKhoaHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "KhoaHocs");
        }
    }
}
