using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMB.DATA.Migrations
{
    public partial class EditTableMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kodu",
                table: "ResponseDataKur",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kodu",
                table: "ResponseDataKur");
        }
    }
}
