using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class addedStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyInformtionUser",
                table: "DailyInformtions",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "DailyInformtionDateTime",
                table: "DailyInformtions",
                newName: "DailyInformationDateTime");

            migrationBuilder.AddColumn<int>(
                name: "GeneratedMood",
                table: "DailyInformtions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoursSlept",
                table: "DailyInformtions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinWorkedOut",
                table: "DailyInformtions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedMood",
                table: "DailyInformtions");

            migrationBuilder.DropColumn(
                name: "HoursSlept",
                table: "DailyInformtions");

            migrationBuilder.DropColumn(
                name: "MinWorkedOut",
                table: "DailyInformtions");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "DailyInformtions",
                newName: "DailyInformtionUser");

            migrationBuilder.RenameColumn(
                name: "DailyInformationDateTime",
                table: "DailyInformtions",
                newName: "DailyInformtionDateTime");
        }
    }
}
