using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainLineTableAddIDFiled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TrainLineId",
                table: "AddressInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AddressInfos_TrainLineId",
                table: "AddressInfos",
                column: "TrainLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressInfos_TrainLines_TrainLineId",
                table: "AddressInfos",
                column: "TrainLineId",
                principalTable: "TrainLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressInfos_TrainLines_TrainLineId",
                table: "AddressInfos");

            migrationBuilder.DropIndex(
                name: "IX_AddressInfos_TrainLineId",
                table: "AddressInfos");

            migrationBuilder.DropColumn(
                name: "TrainLineId",
                table: "AddressInfos");
        }
    }
}
