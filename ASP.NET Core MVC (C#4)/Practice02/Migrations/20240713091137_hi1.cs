using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice02.Migrations
{
    public partial class hi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "ID",
                keyValue: new Guid("8d8c8d91-792b-42ad-8296-002d18b1da4b"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "ID",
                keyValue: new Guid("ac208ecd-2f22-416f-88a3-fee0f59d526f"));

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Watches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "ID", "Img", "Name", "Origin", "Price", "year" },
                values: new object[] { new Guid("4735b16f-f6b8-4f8b-a1fa-279f0b4295d7"), "Minh.png", "Rolex 1989", "UK", 5000.0, 1970 });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "ID", "Img", "Name", "Origin", "Price", "year" },
                values: new object[] { new Guid("621d0aae-20e3-41bf-8531-cce6cb3501ed"), "Minh.png", "Rolex 1912", "US", 1788.0, 1910 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "ID",
                keyValue: new Guid("4735b16f-f6b8-4f8b-a1fa-279f0b4295d7"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "ID",
                keyValue: new Guid("621d0aae-20e3-41bf-8531-cce6cb3501ed"));

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Watches");

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "ID", "Name", "Origin", "Price", "year" },
                values: new object[] { new Guid("8d8c8d91-792b-42ad-8296-002d18b1da4b"), "Rolex 1912", "US", 1788.0, 1910 });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "ID", "Name", "Origin", "Price", "year" },
                values: new object[] { new Guid("ac208ecd-2f22-416f-88a3-fee0f59d526f"), "Rolex 1989", "UK", 5000.0, 1970 });
        }
    }
}
