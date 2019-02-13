using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class changedNameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyInformtions");

            migrationBuilder.CreateTable(
                name: "DailyInformations",
                columns: table => new
                {
                    DailyInformationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyInformationDateTime = table.Column<DateTime>(nullable: false),
                    GeneratedMood = table.Column<int>(nullable: false),
                    HoursSlept = table.Column<int>(nullable: false),
                    JournalText = table.Column<string>(nullable: false),
                    MinWorkedOut = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    UserMood = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyInformations", x => x.DailyInformationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyInformations");

            migrationBuilder.CreateTable(
                name: "DailyInformtions",
                columns: table => new
                {
                    DailyInformtionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyInformationDateTime = table.Column<DateTime>(nullable: false),
                    GeneratedMood = table.Column<int>(nullable: false),
                    HoursSlept = table.Column<int>(nullable: false),
                    JournalText = table.Column<string>(nullable: false),
                    MinWorkedOut = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    UserMood = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyInformtions", x => x.DailyInformtionID);
                });
        }
    }
}
