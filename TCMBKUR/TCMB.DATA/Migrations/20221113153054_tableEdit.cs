using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMB.DATA.Migrations
{
    public partial class tableEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDataKurs_ResponseDatas_ResponseDataId",
                table: "ResponseDataKurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseDatas",
                table: "ResponseDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseDataKurs",
                table: "ResponseDataKurs");

            migrationBuilder.DropColumn(
                name: "Ay",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "Gun",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "Yil",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "isBugun",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "Kodu",
                table: "ResponseDataKurs");

            migrationBuilder.RenameTable(
                name: "ResponseDatas",
                newName: "ResponseData");

            migrationBuilder.RenameTable(
                name: "ResponseDataKurs",
                newName: "ResponseDataKur");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseDataKurs_ResponseDataId",
                table: "ResponseDataKur",
                newName: "IX_ResponseDataKur_ResponseDataId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "RequestData",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RequestDataId",
                table: "ResponseDataKur",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseData",
                table: "ResponseData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseDataKur",
                table: "ResponseDataKur",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDataKur_ResponseData_ResponseDataId",
                table: "ResponseDataKur",
                column: "ResponseDataId",
                principalTable: "ResponseData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDataKur_RequestData_RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDataKur_ResponseData_ResponseDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseDataKur",
                table: "ResponseDataKur");

            migrationBuilder.DropIndex(
                name: "IX_ResponseDataKur_RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseData",
                table: "ResponseData");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "RequestDataId",
                table: "ResponseDataKur");

            migrationBuilder.RenameTable(
                name: "ResponseDataKur",
                newName: "ResponseDataKurs");

            migrationBuilder.RenameTable(
                name: "ResponseData",
                newName: "ResponseDatas");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseDataKur_ResponseDataId",
                table: "ResponseDataKurs",
                newName: "IX_ResponseDataKurs_ResponseDataId");

            migrationBuilder.AddColumn<int>(
                name: "Ay",
                table: "RequestData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gun",
                table: "RequestData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Yil",
                table: "RequestData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isBugun",
                table: "RequestData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Kodu",
                table: "ResponseDataKurs",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseDataKurs",
                table: "ResponseDataKurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseDatas",
                table: "ResponseDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDataKurs_ResponseDatas_ResponseDataId",
                table: "ResponseDataKurs",
                column: "ResponseDataId",
                principalTable: "ResponseDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
