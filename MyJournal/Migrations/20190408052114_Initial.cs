using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class Initial : Migration
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
                    DownTime = table.Column<DateTime>(nullable: false),
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
                    UpTime = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ApiDatas",
                columns: table => new
                {
                    ApiDataID = table.Column<int>(nullable: false),
                    DailyInformationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiDatas", x => x.ApiDataID);
                    table.ForeignKey(
                        name: "FK_ApiDatas_DailyInformations_ApiDataID",
                        column: x => x.ApiDataID,
                        principalTable: "DailyInformations",
                        principalColumn: "DailyInformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTone",
                columns: table => new
                {
                    DocumentToneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApiDataID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTone", x => x.DocumentToneID);
                    table.ForeignKey(
                        name: "FK_DocumentTone_ApiDatas_ApiDataID",
                        column: x => x.ApiDataID,
                        principalTable: "ApiDatas",
                        principalColumn: "ApiDataID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SentenceTone",
                columns: table => new
                {
                    SentenceToneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApiDataID = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceTone", x => x.SentenceToneID);
                    table.ForeignKey(
                        name: "FK_SentenceTone_ApiDatas_ApiDataID",
                        column: x => x.ApiDataID,
                        principalTable: "ApiDatas",
                        principalColumn: "ApiDataID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tone",
                columns: table => new
                {
                    ToneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentToneID = table.Column<int>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    SentenceToneID = table.Column<int>(nullable: true),
                    ToneName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tone", x => x.ToneID);
                    table.ForeignKey(
                        name: "FK_Tone_DocumentTone_DocumentToneID",
                        column: x => x.DocumentToneID,
                        principalTable: "DocumentTone",
                        principalColumn: "DocumentToneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tone_SentenceTone_SentenceToneID",
                        column: x => x.SentenceToneID,
                        principalTable: "SentenceTone",
                        principalColumn: "SentenceToneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTone_ApiDataID",
                table: "DocumentTone",
                column: "ApiDataID");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceTone_ApiDataID",
                table: "SentenceTone",
                column: "ApiDataID");

            migrationBuilder.CreateIndex(
                name: "IX_Tone_DocumentToneID",
                table: "Tone",
                column: "DocumentToneID");

            migrationBuilder.CreateIndex(
                name: "IX_Tone_SentenceToneID",
                table: "Tone",
                column: "SentenceToneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomTemplates");

            migrationBuilder.DropTable(
                name: "Sharings");

            migrationBuilder.DropTable(
                name: "Tone");

            migrationBuilder.DropTable(
                name: "DocumentTone");

            migrationBuilder.DropTable(
                name: "SentenceTone");

            migrationBuilder.DropTable(
                name: "ApiDatas");

            migrationBuilder.DropTable(
                name: "DailyInformations");
        }
    }
}
