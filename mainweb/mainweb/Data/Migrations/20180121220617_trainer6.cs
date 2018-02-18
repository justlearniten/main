using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data.Migrations
{
    public partial class trainer6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectResponse_TrainerCar_TrainerCarId",
                table: "CorrectResponse");

            migrationBuilder.DropIndex(
                name: "IX_CorrectResponse_TrainerCarId",
                table: "CorrectResponse");

            migrationBuilder.DropColumn(
                name: "TrainerCarId",
                table: "CorrectResponse");

            migrationBuilder.CreateTable(
                name: "TrainerCorrectResponse",
                columns: table => new
                {
                    TrainerCorrectResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: false),
                    TrainerCarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCorrectResponse", x => x.TrainerCorrectResponseId);
                    table.ForeignKey(
                        name: "FK_TrainerCorrectResponse_TrainerCar_TrainerCarId",
                        column: x => x.TrainerCarId,
                        principalTable: "TrainerCar",
                        principalColumn: "TrainerCarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCorrectResponse_TrainerCarId",
                table: "TrainerCorrectResponse",
                column: "TrainerCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerCorrectResponse");

            migrationBuilder.AddColumn<int>(
                name: "TrainerCarId",
                table: "CorrectResponse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectResponse_TrainerCarId",
                table: "CorrectResponse",
                column: "TrainerCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectResponse_TrainerCar_TrainerCarId",
                table: "CorrectResponse",
                column: "TrainerCarId",
                principalTable: "TrainerCar",
                principalColumn: "TrainerCarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
