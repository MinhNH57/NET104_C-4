using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice02.Migrations
{
    public partial class hi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "ID", "Name", "Origin", "Price", "year" },
                values: new object[] { new Guid("8d8c8d91-792b-42ad-8296-002d18b1da4b"), "Rolex 1912", "US", 1788.0, 1910 });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "ID", "Name", "Origin", "Price", "year" },
                values: new object[] { new Guid("ac208ecd-2f22-416f-88a3-fee0f59d526f"), "Rolex 1989", "UK", 5000.0, 1970 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watches");
        }
    }
}
