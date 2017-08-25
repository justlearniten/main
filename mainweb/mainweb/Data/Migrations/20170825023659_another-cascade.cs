using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mainweb.Data.Migrations
{
    public partial class anothercascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExcerciseItemId1",
                table: "CorrectResponse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectResponse_ExcerciseItemId1",
                table: "CorrectResponse",
                column: "ExcerciseItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectResponse_ExcerciseItem_ExcerciseItemId1",
                table: "CorrectResponse",
                column: "ExcerciseItemId1",
                principalTable: "ExcerciseItem",
                principalColumn: "ExcerciseItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectResponse_ExcerciseItem_ExcerciseItemId1",
                table: "CorrectResponse");

            migrationBuilder.DropIndex(
                name: "IX_CorrectResponse_ExcerciseItemId1",
                table: "CorrectResponse");

            migrationBuilder.DropColumn(
                name: "ExcerciseItemId1",
                table: "CorrectResponse");
        }
    }
}
