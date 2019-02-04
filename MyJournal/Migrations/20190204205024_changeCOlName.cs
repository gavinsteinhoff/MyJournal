using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class changeCOlName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JournalUser",
                table: "DailyInformtions",
                newName: "DailyInformtionUser");

            migrationBuilder.RenameColumn(
                name: "JournalDateTime",
                table: "DailyInformtions",
                newName: "DailyInformtionDateTime");

            migrationBuilder.RenameColumn(
                name: "JournalID",
                table: "DailyInformtions",
                newName: "DailyInformtionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyInformtionUser",
                table: "DailyInformtions",
                newName: "JournalUser");

            migrationBuilder.RenameColumn(
                name: "DailyInformtionDateTime",
                table: "DailyInformtions",
                newName: "JournalDateTime");

            migrationBuilder.RenameColumn(
                name: "DailyInformtionID",
                table: "DailyInformtions",
                newName: "JournalID");
        }
    }
}
