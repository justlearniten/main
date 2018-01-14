using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mainweb.Data.Migrations
{
    public partial class trainer5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasWhheels",
                table: "TrainerCar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "Trainer",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasWhheels",
                table: "TrainerCar");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "Trainer");
        }
    }
}
