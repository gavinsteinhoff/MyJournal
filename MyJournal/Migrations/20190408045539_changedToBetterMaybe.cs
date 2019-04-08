using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class changedToBetterMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApiDataID",
                table: "DailyInformations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyInformations_ApiDataID",
                table: "DailyInformations",
                column: "ApiDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyInformations_ApiDatas_ApiDataID",
                table: "DailyInformations",
                column: "ApiDataID",
                principalTable: "ApiDatas",
                principalColumn: "ApiDataID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyInformations_ApiDatas_ApiDataID",
                table: "DailyInformations");

            migrationBuilder.DropIndex(
                name: "IX_DailyInformations_ApiDataID",
                table: "DailyInformations");

            migrationBuilder.DropColumn(
                name: "ApiDataID",
                table: "DailyInformations");
        }
    }
}
