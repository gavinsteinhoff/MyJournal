using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class everything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomTemplates",
                columns: table => new
                {
                    CustomTemplateKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Template = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTemplates", x => x.CustomTemplateKey);
                });

            migrationBuilder.CreateTable(
                name: "DailyInformations",
                columns: table => new
                {
                    DailyInformationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyInformationDateTime = table.Column<DateTime>(nullable: false),
                    DownTime = table.Column<int>(nullable: false),
                    ExcitedForTomorrow = table.Column<int>(nullable: false),
                    GeneratedMood = table.Column<int>(nullable: false),
                    HoursSlept = table.Column<int>(nullable: false),
                    JournalText = table.Column<string>(nullable: false),
                    MinExercising = table.Column<int>(nullable: false),
                    MinHobby = table.Column<int>(nullable: false),
                    MinPhone = table.Column<int>(nullable: false),
                    NumGoodThings = table.Column<int>(nullable: false),
                    NumPoorThings = table.Column<int>(nullable: false),
                    OverallDay = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UpTime = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    UserMood = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyInformations", x => x.DailyInformationID);
                });

            migrationBuilder.CreateTable(
                name: "Sharings",
                columns: table => new
                {
                    SharingKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Giver = table.Column<string>(nullable: true),
                    PermissionLevel = table.Column<int>(nullable: false),
                    Receiver = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sharings", x => x.SharingKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomTemplates");

            migrationBuilder.DropTable(
                name: "DailyInformations");

            migrationBuilder.DropTable(
                name: "Sharings");
        }
    }
}
