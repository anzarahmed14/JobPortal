using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class JobInfoCompnayInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "JobInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_CompanyId",
                table: "JobInfos",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfos_Companies_CompanyId",
                table: "JobInfos",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInfos_Companies_CompanyId",
                table: "JobInfos");

            migrationBuilder.DropIndex(
                name: "IX_JobInfos_CompanyId",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobInfos");
        }
    }
}
