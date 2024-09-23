using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSkillInfosSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillInfos_ExportLevels_ExportLevelId",
                table: "SkillInfos");

            migrationBuilder.RenameColumn(
                name: "ExportLevelId",
                table: "SkillInfos",
                newName: "ExpertLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillInfos_ExportLevelId",
                table: "SkillInfos",
                newName: "IX_SkillInfos_ExpertLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillInfos_ExportLevels_ExpertLevelId",
                table: "SkillInfos",
                column: "ExpertLevelId",
                principalTable: "ExportLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillInfos_ExportLevels_ExpertLevelId",
                table: "SkillInfos");

            migrationBuilder.RenameColumn(
                name: "ExpertLevelId",
                table: "SkillInfos",
                newName: "ExportLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillInfos_ExpertLevelId",
                table: "SkillInfos",
                newName: "IX_SkillInfos_ExportLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillInfos_ExportLevels_ExportLevelId",
                table: "SkillInfos",
                column: "ExportLevelId",
                principalTable: "ExportLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
