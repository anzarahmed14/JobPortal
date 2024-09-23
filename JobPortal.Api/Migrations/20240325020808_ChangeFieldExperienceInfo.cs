using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFieldExperienceInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "ExperienceInfos");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "ExperienceInfos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExperienceInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ExperienceInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyWorking",
                table: "ExperienceInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ExperienceInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExperienceInfos");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ExperienceInfos");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyWorking",
                table: "ExperienceInfos");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ExperienceInfos");

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "ExperienceInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                table: "ExperienceInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
