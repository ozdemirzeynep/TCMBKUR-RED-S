using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMB.DATA.Migrations
{
    public partial class EditTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestDataId",
                table: "ResponseDataKur",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ResponseDataKur_RequestDataId",
                table: "ResponseDataKur",
                column: "RequestDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDataKur_RequestData_RequestDataId",
                table: "ResponseDataKur",
                column: "RequestDataId",
                principalTable: "RequestData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDataKur_RequestData_RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropIndex(
                name: "IX_ResponseDataKur_RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropColumn(
                name: "RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "Tl",
                table: "RequestData");
        }
    }
}
