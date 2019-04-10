using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class fixedDoctumentTone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTone_ApiDatas_ApiDataID",
                table: "DocumentTone");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTone_ApiDataID",
                table: "DocumentTone");

            migrationBuilder.DropColumn(
                name: "ApiDataID",
                table: "DocumentTone");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTonesDocumentToneID",
                table: "ApiDatas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiDatas_DocumentTonesDocumentToneID",
                table: "ApiDatas",
                column: "DocumentTonesDocumentToneID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiDatas_DocumentTone_DocumentTonesDocumentToneID",
                table: "ApiDatas",
                column: "DocumentTonesDocumentToneID",
                principalTable: "DocumentTone",
                principalColumn: "DocumentToneID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiDatas_DocumentTone_DocumentTonesDocumentToneID",
                table: "ApiDatas");

            migrationBuilder.DropIndex(
                name: "IX_ApiDatas_DocumentTonesDocumentToneID",
                table: "ApiDatas");

            migrationBuilder.DropColumn(
                name: "DocumentTonesDocumentToneID",
                table: "ApiDatas");

            migrationBuilder.AddColumn<int>(
                name: "ApiDataID",
                table: "DocumentTone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTone_ApiDataID",
                table: "DocumentTone",
                column: "ApiDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTone_ApiDatas_ApiDataID",
                table: "DocumentTone",
                column: "ApiDataID",
                principalTable: "ApiDatas",
                principalColumn: "ApiDataID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
