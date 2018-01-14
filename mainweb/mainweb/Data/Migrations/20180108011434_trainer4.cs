using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data.Migrations
{
    public partial class trainer4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerCarId",
                table: "CorrectResponse",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCar",
                columns: table => new
                {
                    TrainerCarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCar", x => x.TrainerCarId);
                    table.ForeignKey(
                        name: "FK_TrainerCar_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectResponse_TrainerCarId",
                table: "CorrectResponse",
                column: "TrainerCarId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCar_TrainerId",
                table: "TrainerCar",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectResponse_TrainerCar_TrainerCarId",
                table: "CorrectResponse",
                column: "TrainerCarId",
                principalTable: "TrainerCar",
                principalColumn: "TrainerCarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectResponse_TrainerCar_TrainerCarId",
                table: "CorrectResponse");

            migrationBuilder.DropTable(
                name: "TrainerCar");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_CorrectResponse_TrainerCarId",
                table: "CorrectResponse");

            migrationBuilder.DropColumn(
                name: "TrainerCarId",
                table: "CorrectResponse");
        }
    }
}
