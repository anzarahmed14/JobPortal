using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNoticePeriodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoticePeriod",
                table: "EmploymentInfos");

            migrationBuilder.AddColumn<long>(
                name: "NoticePeriodId",
                table: "EmploymentInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "NoticePeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticePeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticePeriods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentInfos_NoticePeriodId",
                table: "EmploymentInfos",
                column: "NoticePeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentInfos_NoticePeriods_NoticePeriodId",
                table: "EmploymentInfos",
                column: "NoticePeriodId",
                principalTable: "NoticePeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentInfos_NoticePeriods_NoticePeriodId",
                table: "EmploymentInfos");

            migrationBuilder.DropTable(
                name: "NoticePeriods");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentInfos_NoticePeriodId",
                table: "EmploymentInfos");

            migrationBuilder.DropColumn(
                name: "NoticePeriodId",
                table: "EmploymentInfos");

            migrationBuilder.AddColumn<int>(
                name: "NoticePeriod",
                table: "EmploymentInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
