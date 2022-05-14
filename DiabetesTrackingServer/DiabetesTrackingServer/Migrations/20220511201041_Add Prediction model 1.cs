using Microsoft.EntityFrameworkCore.Migrations;

namespace DiabetesTrackingServer.Migrations
{
    public partial class AddPredictionmodel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiabetesPrediction_Users_UserId1",
                table: "DiabetesPrediction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiabetesPrediction",
                table: "DiabetesPrediction");

            migrationBuilder.RenameTable(
                name: "DiabetesPrediction",
                newName: "Predictions");

            migrationBuilder.RenameIndex(
                name: "IX_DiabetesPrediction_UserId1",
                table: "Predictions",
                newName: "IX_Predictions_UserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predictions",
                table: "Predictions",
                column: "PredictionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predictions_Users_UserId1",
                table: "Predictions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predictions_Users_UserId1",
                table: "Predictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predictions",
                table: "Predictions");

            migrationBuilder.RenameTable(
                name: "Predictions",
                newName: "DiabetesPrediction");

            migrationBuilder.RenameIndex(
                name: "IX_Predictions_UserId1",
                table: "DiabetesPrediction",
                newName: "IX_DiabetesPrediction_UserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiabetesPrediction",
                table: "DiabetesPrediction",
                column: "PredictionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiabetesPrediction_Users_UserId1",
                table: "DiabetesPrediction",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
