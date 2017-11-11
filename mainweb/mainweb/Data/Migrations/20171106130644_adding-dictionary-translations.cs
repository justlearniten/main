using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mainweb.Data.Migrations
{
    public partial class addingdictionarytranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Dictionary_DictionaryEntryId",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                table: "Translation");

            migrationBuilder.RenameTable(
                name: "Translation",
                newName: "Translations");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_DictionaryEntryId",
                table: "Translations",
                newName: "IX_Translations_DictionaryEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                table: "Translations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Dictionary_DictionaryEntryId",
                table: "Translations",
                column: "DictionaryEntryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Dictionary_DictionaryEntryId",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                table: "Translations");

            migrationBuilder.RenameTable(
                name: "Translations",
                newName: "Translation");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_DictionaryEntryId",
                table: "Translation",
                newName: "IX_Translation_DictionaryEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                table: "Translation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Dictionary_DictionaryEntryId",
                table: "Translation",
                column: "DictionaryEntryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
