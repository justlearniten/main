using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mainweb.Data.Migrations
{
    public partial class removecascades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectResponse_ExcerciseItem_ExcerciseItemId1",
                table: "CorrectResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_ExcerciseItem_Excercise_ExcerciseId1",
                table: "ExcerciseItem");

            migrationBuilder.DropIndex(
                name: "IX_ExcerciseItem_ExcerciseId1",
                table: "ExcerciseItem");

            migrationBuilder.DropIndex(
                name: "IX_CorrectResponse_ExcerciseItemId1",
                table: "CorrectResponse");

            migrationBuilder.DropColumn(
                name: "ExcerciseId1",
                table: "ExcerciseItem");

            migrationBuilder.DropColumn(
                name: "ExcerciseItemId1",
                table: "CorrectResponse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExcerciseId1",
                table: "ExcerciseItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExcerciseItemId1",
                table: "CorrectResponse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExcerciseItem_ExcerciseId1",
                table: "ExcerciseItem",
                column: "ExcerciseId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExcerciseItem_Excercise_ExcerciseId1",
                table: "ExcerciseItem",
                column: "ExcerciseId1",
                principalTable: "Excercise",
                principalColumn: "ExcerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
