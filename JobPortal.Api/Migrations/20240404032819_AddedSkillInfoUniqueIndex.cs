using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedSkillInfoUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SkillInfos_SkillId",
                table: "SkillInfos");

            migrationBuilder.CreateIndex(
                name: "IX_SkillInfos_SkillId_UserId",
                table: "SkillInfos",
                columns: new[] { "SkillId", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SkillInfos_SkillId_UserId",
                table: "SkillInfos");

            migrationBuilder.CreateIndex(
                name: "IX_SkillInfos_SkillId",
                table: "SkillInfos",
                column: "SkillId");
        }
    }
}
