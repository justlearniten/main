using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data.Migrations
{
    public partial class lessongroup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonGroupId",
                table: "Lessons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessonGroups",
                columns: table => new
                {
                    LessonGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonGroups", x => x.LessonGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonGroupId",
                table: "Lessons",
                column: "LessonGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_LessonGroups_LessonGroupId",
                table: "Lessons",
                column: "LessonGroupId",
                principalTable: "LessonGroups",
                principalColumn: "LessonGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_LessonGroups_LessonGroupId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "LessonGroups");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_LessonGroupId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonGroupId",
                table: "Lessons");
        }
    }
}
