using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice03.Migrations
{
    public partial class hiu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rings", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Rings",
                columns: new[] { "ID", "Image", "Name", "Origin" },
                values: new object[] { new Guid("12f29c76-5295-450c-980b-34312cdb6291"), "Minh", "Ring Clonium", "VietNam" });

            migrationBuilder.InsertData(
                table: "Rings",
                columns: new[] { "ID", "Image", "Name", "Origin" },
                values: new object[] { new Guid("bc49c2dd-1281-403f-b024-f03a7bdcef09"), "Minh", "Ring Gold", "VietNam" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rings");
        }
    }
}
