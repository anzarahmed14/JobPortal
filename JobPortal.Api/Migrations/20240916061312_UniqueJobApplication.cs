using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class UniqueJobApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId_JobId",
                table: "JobApplications",
                columns: new[] { "UserId", "JobId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobApplications_UserId_JobId",
                table: "JobApplications");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");
        }
    }
}
