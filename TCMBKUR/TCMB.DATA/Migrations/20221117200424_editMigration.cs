using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMB.DATA.Migrations
{
    public partial class editMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "Tl",
                table: "RequestData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RequestData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tl",
                table: "RequestData",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
