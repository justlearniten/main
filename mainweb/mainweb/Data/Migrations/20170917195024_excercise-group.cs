using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data.Migrations
{
    public partial class excercisegroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcerciseTitle",
                table: "Test");

            migrationBuilder.AddColumn<int>(
                name: "ExcerciseGroupId",
                table: "Excercise",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExcerciseGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgressViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExcerciseName = table.Column<string>(nullable: true),
                    PointsAvailable = table.Column<int>(nullable: false),
                    PointsEarned = table.Column<int>(nullable: false),
                    TimeTaken = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excercise_ExcerciseGroupId",
                table: "Excercise",
                column: "ExcerciseGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excercise_ExcerciseGroups_ExcerciseGroupId",
                table: "Excercise",
                column: "ExcerciseGroupId",
                principalTable: "ExcerciseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excercise_ExcerciseGroups_ExcerciseGroupId",
                table: "Excercise");

            migrationBuilder.DropTable(
                name: "ExcerciseGroups");

            migrationBuilder.DropTable(
                name: "ProgressViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Excercise_ExcerciseGroupId",
                table: "Excercise");

            migrationBuilder.DropColumn(
                name: "ExcerciseGroupId",
                table: "Excercise");

            migrationBuilder.AddColumn<string>(
                name: "ExcerciseTitle",
                table: "Test",
                nullable: true);
        }
    }
}
