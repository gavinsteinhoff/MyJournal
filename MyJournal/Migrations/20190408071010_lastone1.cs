using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class lastone1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tone_ApiDatas_ApiDataID",
                table: "Tone");

            migrationBuilder.DropIndex(
                name: "IX_Tone_ApiDataID",
                table: "Tone");

            migrationBuilder.DropColumn(
                name: "ApiDataID",
                table: "Tone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApiDataID",
                table: "Tone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tone_ApiDataID",
                table: "Tone",
                column: "ApiDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tone_ApiDatas_ApiDataID",
                table: "Tone",
                column: "ApiDataID",
                principalTable: "ApiDatas",
                principalColumn: "ApiDataID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
