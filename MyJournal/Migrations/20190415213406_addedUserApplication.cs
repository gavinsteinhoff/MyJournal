using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyJournal.Migrations
{
    public partial class addedUserApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sharings_AspNetUsers_ApplicationUserGiverId",
                table: "Sharings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sharings_AspNetUsers_ApplicationUserReceiverId",
                table: "Sharings");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserReceiverId",
                table: "Sharings",
                newName: "GiverId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserGiverId",
                table: "Sharings",
                newName: "GetterId");

            migrationBuilder.RenameIndex(
                name: "IX_Sharings_ApplicationUserReceiverId",
                table: "Sharings",
                newName: "IX_Sharings_GiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Sharings_ApplicationUserGiverId",
                table: "Sharings",
                newName: "IX_Sharings_GetterId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DailyInformations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyInformations_ApplicationUserId",
                table: "DailyInformations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyInformations_AspNetUsers_ApplicationUserId",
                table: "DailyInformations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sharings_AspNetUsers_GetterId",
                table: "Sharings",
                column: "GetterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sharings_AspNetUsers_GiverId",
                table: "Sharings",
                column: "GiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyInformations_AspNetUsers_ApplicationUserId",
                table: "DailyInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_Sharings_AspNetUsers_GetterId",
                table: "Sharings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sharings_AspNetUsers_GiverId",
                table: "Sharings");

            migrationBuilder.DropIndex(
                name: "IX_DailyInformations_ApplicationUserId",
                table: "DailyInformations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DailyInformations");

            migrationBuilder.RenameColumn(
                name: "GiverId",
                table: "Sharings",
                newName: "ApplicationUserReceiverId");

            migrationBuilder.RenameColumn(
                name: "GetterId",
                table: "Sharings",
                newName: "ApplicationUserGiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Sharings_GiverId",
                table: "Sharings",
                newName: "IX_Sharings_ApplicationUserReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Sharings_GetterId",
                table: "Sharings",
                newName: "IX_Sharings_ApplicationUserGiverId");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    GetterId = table.Column<string>(nullable: true),
                    GiverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_GetterId",
                        column: x => x.GetterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_GiverId",
                        column: x => x.GiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_GetterId",
                table: "Tests",
                column: "GetterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_GiverId",
                table: "Tests",
                column: "GiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sharings_AspNetUsers_ApplicationUserGiverId",
                table: "Sharings",
                column: "ApplicationUserGiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sharings_AspNetUsers_ApplicationUserReceiverId",
                table: "Sharings",
                column: "ApplicationUserReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
