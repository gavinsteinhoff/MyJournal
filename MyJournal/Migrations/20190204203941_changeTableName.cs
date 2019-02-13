using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.CreateTable(
                name: "DailyInformtions",
                columns: table => new
                {
                    JournalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JournalDateTime = table.Column<DateTime>(nullable: false),
                    JournalText = table.Column<string>(nullable: false),
                    JournalUser = table.Column<string>(nullable: true),
                    mood = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyInformtions", x => x.JournalID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyInformtions");

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    JournalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JournalDateTime = table.Column<DateTime>(nullable: false),
                    JournalText = table.Column<string>(nullable: false),
                    JournalUser = table.Column<string>(nullable: true),
                    mood = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.JournalID);
                });
        }
    }
}
