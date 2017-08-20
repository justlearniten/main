using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data.Migrations
{
    public partial class excercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lessons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Excercise",
                columns: table => new
                {
                    ExcerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExcerciseName = table.Column<string>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercise", x => x.ExcerciseId);
                });

            migrationBuilder.CreateTable(
                name: "ExcerciseItem",
                columns: table => new
                {
                    ExcerciseItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExcerciseId = table.Column<int>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseItem", x => x.ExcerciseItemId);
                    table.ForeignKey(
                        name: "FK_ExcerciseItem_Excercise_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Excercise",
                        principalColumn: "ExcerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorrectResponse",
                columns: table => new
                {
                    CorrectResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: false),
                    ExcerciseItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectResponse", x => x.CorrectResponseId);
                    table.ForeignKey(
                        name: "FK_CorrectResponse_ExcerciseItem_ExcerciseItemId",
                        column: x => x.ExcerciseItemId,
                        principalTable: "ExcerciseItem",
                        principalColumn: "ExcerciseItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectResponse_ExcerciseItemId",
                table: "CorrectResponse",
                column: "ExcerciseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcerciseItem_ExcerciseId",
                table: "ExcerciseItem",
                column: "ExcerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectResponse");

            migrationBuilder.DropTable(
                name: "ExcerciseItem");

            migrationBuilder.DropTable(
                name: "Excercise");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lessons",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
