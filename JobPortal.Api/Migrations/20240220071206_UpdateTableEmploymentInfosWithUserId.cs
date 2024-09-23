using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableEmploymentInfosWithUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "EmploymentInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentInfos_UserId",
                table: "EmploymentInfos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentInfos_Users_UserId",
                table: "EmploymentInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentInfos_Users_UserId",
                table: "EmploymentInfos");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentInfos_UserId",
                table: "EmploymentInfos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmploymentInfos");
        }
    }
}
