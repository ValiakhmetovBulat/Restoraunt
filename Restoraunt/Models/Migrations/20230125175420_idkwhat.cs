using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoraunt.Migrations
{
    /// <inheritdoc />
    public partial class idkwhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_PositionTypes_PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_Sections_SectionId",
                table: "MenuPositions");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "MenuPositions",
                newName: "MenuSectionTypeFK");

            migrationBuilder.RenameColumn(
                name: "PositionTypeId",
                table: "MenuPositions",
                newName: "MenuSectionFK");

            migrationBuilder.RenameIndex(
                name: "IX_MenuPositions_SectionId",
                table: "MenuPositions",
                newName: "IX_MenuPositions_MenuSectionTypeFK");

            migrationBuilder.RenameIndex(
                name: "IX_MenuPositions_PositionTypeId",
                table: "MenuPositions",
                newName: "IX_MenuPositions_MenuSectionFK");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_PositionTypes_MenuSectionTypeFK",
                table: "MenuPositions",
                column: "MenuSectionTypeFK",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_Sections_MenuSectionFK",
                table: "MenuPositions",
                column: "MenuSectionFK",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_PositionTypes_MenuSectionTypeFK",
                table: "MenuPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_Sections_MenuSectionFK",
                table: "MenuPositions");

            migrationBuilder.RenameColumn(
                name: "MenuSectionTypeFK",
                table: "MenuPositions",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "MenuSectionFK",
                table: "MenuPositions",
                newName: "PositionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuPositions_MenuSectionTypeFK",
                table: "MenuPositions",
                newName: "IX_MenuPositions_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuPositions_MenuSectionFK",
                table: "MenuPositions",
                newName: "IX_MenuPositions_PositionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_PositionTypes_PositionTypeId",
                table: "MenuPositions",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_Sections_SectionId",
                table: "MenuPositions",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
