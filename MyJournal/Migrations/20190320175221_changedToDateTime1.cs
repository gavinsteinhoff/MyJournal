﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class changedToDateTime1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownTime",
                table: "DailyInformations");

            migrationBuilder.DropColumn(
                name: "UpTime",
                table: "DailyInformations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DownTime",
                table: "DailyInformations",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpTime",
                table: "DailyInformations",
                nullable: false);
        }
    }
}