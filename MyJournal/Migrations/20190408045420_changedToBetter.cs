using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class changedToBetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
