using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice04.Migrations
{
    public partial class minhd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soTrang = table.Column<int>(type: "int", nullable: false),
                    ngayxuatban = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "ID", "Title", "ngayxuatban", "soTrang" },
                values: new object[] { new Guid("db48e214-3fbf-456c-b77c-6a682720456c"), "Nham mat cho mua ha", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 187 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
