using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

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
                name: "Sharings");

            migrationBuilder.DropTable(
                name: "Tone");

            migrationBuilder.DropTable(
                name: "SentenceTone");

            migrationBuilder.DropTable(
                name: "ApiDatas");

            migrationBuilder.DropTable(
                name: "DailyInformations");

            migrationBuilder.DropTable(
                name: "DocumentTone");
        }
    }
}
