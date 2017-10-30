using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data.Migrations
{
    public partial class lessongroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excercise_ExcerciseGroups_ExcerciseGroupId",
                table: "Excercise");

            migrationBuilder.DropTable(
                name: "ExcerciseGroups");

            migrationBuilder.DropIndex(
                name: "IX_Excercise_ExcerciseGroupId",
                table: "Excercise");

            migrationBuilder.DropColumn(
                name: "ExcerciseGroupId",
                table: "Excercise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
