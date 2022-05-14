using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiabetesTrackingServer.Migrations
{
    public partial class AddPredictionmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predictions_Users_UserId1",
                table: "Predictions");

            migrationBuilder.DropIndex(
                name: "IX_Predictions_UserId1",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Predictions");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Predictions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_UserId",
                table: "Predictions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predictions_Users_UserId",
                table: "Predictions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predictions_Users_UserId",
                table: "Predictions");

            migrationBuilder.DropIndex(
                name: "IX_Predictions_UserId",
                table: "Predictions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Predictions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_UserId1",
                table: "Predictions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Predictions_Users_UserId1",
                table: "Predictions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
