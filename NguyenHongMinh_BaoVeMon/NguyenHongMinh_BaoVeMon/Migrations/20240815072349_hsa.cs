using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenHongMinh_BaoVeMon.Migrations
{
    public partial class hsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "toanhas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toanhas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Canhos",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienTich = table.Column<double>(type: "float", nullable: false),
                    So = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toaNhaID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canhos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Canhos_toanhas_toaNhaID",
                        column: x => x.toaNhaID,
                        principalTable: "toanhas",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Canhos",
                columns: new[] { "ID", "DienTich", "Name", "So", "toaNhaID" },
                values: new object[] { "CH01", 290.0, "Nha1", "20", null });

            migrationBuilder.CreateIndex(
                name: "IX_Canhos_toaNhaID",
                table: "Canhos",
                column: "toaNhaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canhos");

            migrationBuilder.DropTable(
                name: "toanhas");
        }
    }
}
