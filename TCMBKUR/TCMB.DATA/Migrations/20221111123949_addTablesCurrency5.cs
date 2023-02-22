using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCMB.DATA.Migrations
{
    public partial class addTablesCurrency5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gun = table.Column<int>(type: "integer", nullable: false),
                    Ay = table.Column<int>(type: "integer", nullable: false),
                    Yil = table.Column<int>(type: "integer", nullable: false),
                    isBugun = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hata = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseDataKurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kodu = table.Column<string>(type: "text", nullable: true),
                    Adi = table.Column<string>(type: "text", nullable: true),
                    Birimi = table.Column<int>(type: "integer", nullable: false),
                    AlisKuru = table.Column<decimal>(type: "numeric", nullable: false),
                    SatisKuru = table.Column<decimal>(type: "numeric", nullable: false),
                    EfektifAlisKuru = table.Column<decimal>(type: "numeric", nullable: false),
                    EfektifSatisKuru = table.Column<decimal>(type: "numeric", nullable: false),
                    ResponseDataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseDataKurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseDataKurs_ResponseDatas_ResponseDataId",
                        column: x => x.ResponseDataId,
                        principalTable: "ResponseDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponseDataKurs_ResponseDataId",
                table: "ResponseDataKurs",
                column: "ResponseDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestData");

            migrationBuilder.DropTable(
                name: "ResponseDataKurs");

            migrationBuilder.DropTable(
                name: "ResponseDatas");
        }
    }
}
