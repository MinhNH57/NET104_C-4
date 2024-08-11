using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD18406.Migrations
{
    public partial class hi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "ImgURL", "Name", "SoLuong" },
                values: new object[,]
                {
                    { new Guid("488e8028-8105-46a4-a507-2e63d7f58cc5"), "Minh.png", "Hat", 16 },
                    { new Guid("4be8c48f-84f4-419e-a436-dafd2acbc3de"), "Minh.png", "Blouse", 145 },
                    { new Guid("c0b0dfaa-c070-4db6-aecb-95c8be9cd183"), "Minh.png", "Jeans", 145 },
                    { new Guid("dea6ee03-5b68-4ff2-9c52-957aa111da8f"), "Minh.png", "Cots", 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
