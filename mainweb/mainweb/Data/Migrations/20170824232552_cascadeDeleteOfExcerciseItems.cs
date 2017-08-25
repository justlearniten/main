using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mainweb.Data.Migrations
{
    public partial class cascadeDeleteOfExcerciseItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExcerciseId1",
                table: "ExcerciseItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExcerciseItem_ExcerciseId1",
                table: "ExcerciseItem",
                column: "ExcerciseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcerciseItem_Excercise_ExcerciseId1",
                table: "ExcerciseItem",
                column: "ExcerciseId1",
                principalTable: "Excercise",
                principalColumn: "ExcerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcerciseItem_Excercise_ExcerciseId1",
                table: "ExcerciseItem");

            migrationBuilder.DropIndex(
                name: "IX_ExcerciseItem_ExcerciseId1",
                table: "ExcerciseItem");

            migrationBuilder.DropColumn(
                name: "ExcerciseId1",
                table: "ExcerciseItem");
        }
    }
}
