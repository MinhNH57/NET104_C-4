using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice_01.Migrations
{
    public partial class watch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("ee76cefc-9906-4d14-8978-0bc1e1eddff5"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "ImgUrl", "Name", "SoLuong" },
                values: new object[] { new Guid("c75c4bf1-31cc-4a2b-a5ba-6e1394128933"), "Minh.png", "Iphone 14 Plus America", 147 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("c75c4bf1-31cc-4a2b-a5ba-6e1394128933"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "ImgUrl", "Name", "SoLuong" },
                values: new object[] { new Guid("ee76cefc-9906-4d14-8978-0bc1e1eddff5"), "Minh.png", "Iphone 14 Plus America", 147 });
        }
    }
}
