using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class addedApiData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiDatas",
                columns: table => new
                {
                    ApiDataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyInformationModel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiDatas", x => x.ApiDataID);
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
                name: "Tone");

            migrationBuilder.DropTable(
                name: "DocumentTone");

            migrationBuilder.DropTable(
                name: "SentenceTone");

            migrationBuilder.DropTable(
                name: "ApiDatas");
        }
    }
}
