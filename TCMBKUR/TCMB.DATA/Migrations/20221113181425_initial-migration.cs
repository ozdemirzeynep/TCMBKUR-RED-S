using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMB.DATA.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDataKur_RequestData_RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropIndex(
                name: "IX_ResponseDataKur_RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropColumn(
                name: "EfektifAlisKuru",
                table: "ResponseDataKur");

            migrationBuilder.DropColumn(
                name: "EfektifSatisKuru",
                table: "ResponseDataKur");

            migrationBuilder.DropColumn(
                name: "RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropColumn(
                name: "SatisKuru",
                table: "ResponseDataKur");

            migrationBuilder.AlterColumn<int>(
                name: "Birimi",
                table: "ResponseDataKur",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "ResponseDataKur",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "ResponseDataKur");

            migrationBuilder.AlterColumn<int>(
                name: "Birimi",
                table: "ResponseDataKur",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EfektifAlisKuru",
                table: "ResponseDataKur",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EfektifSatisKuru",
                table: "ResponseDataKur",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RequestDataId",
                table: "ResponseDataKur",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SatisKuru",
                table: "ResponseDataKur",
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
    }
}
