using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class collumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mood",
                table: "DailyInformtions",
                newName: "UserMood");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DailyInformtions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "DailyInformtions");

            migrationBuilder.RenameColumn(
                name: "UserMood",
                table: "DailyInformtions",
                newName: "mood");
        }
    }
}
