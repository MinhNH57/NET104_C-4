using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM1.Migrations
{
    public partial class nh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LopHocs",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocs", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomMaLop = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopHocs_ClassroomMaLop",
                        column: x => x.ClassroomMaLop,
                        principalTable: "LopHocs",
                        principalColumn: "MaLop");
                });

            migrationBuilder.InsertData(
                table: "LopHocs",
                columns: new[] { "MaLop", "TenLop" },
                values: new object[] { "SD18401", "PTPM98" });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "Age", "ClassroomMaLop", "MaLop", "Major", "Name" },
                values: new object[] { new Guid("11811e1a-a9f7-4c9e-9fd0-ff4c7cb377be"), 20, null, "SD18401", "CNTT", "Nguyen Hong Minh" });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_ClassroomMaLop",
                table: "SinhViens",
                column: "ClassroomMaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "LopHocs");
        }
    }
}
