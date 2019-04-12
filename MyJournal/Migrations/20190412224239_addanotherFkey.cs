using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class addanotherFkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CustomTemplates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomTemplates_ApplicationUserId",
                table: "CustomTemplates",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTemplates_ApplicationUser_ApplicationUserId",
                table: "CustomTemplates",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomTemplates_ApplicationUser_ApplicationUserId",
                table: "CustomTemplates");

            migrationBuilder.DropIndex(
                name: "IX_CustomTemplates_ApplicationUserId",
                table: "CustomTemplates");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CustomTemplates");
        }
    }
}
