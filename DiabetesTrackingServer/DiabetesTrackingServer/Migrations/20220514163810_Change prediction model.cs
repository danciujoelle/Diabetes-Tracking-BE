using Microsoft.EntityFrameworkCore.Migrations;

namespace DiabetesTrackingServer.Migrations
{
    public partial class Changepredictionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "BodyMassIndex",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "Glucose",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "Insulin",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "SkinThickness",
                table: "Predictions");

            migrationBuilder.RenameColumn(
                name: "Outcome",
                table: "Predictions",
                newName: "TricepsThickness");

            migrationBuilder.AddColumn<double>(
                name: "BMI",
                table: "Predictions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiabetesPedigree",
                table: "Predictions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Diabetic",
                table: "Predictions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiastolicBloodPressure",
                table: "Predictions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlasmaGlucose",
                table: "Predictions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerumInsulin",
                table: "Predictions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BMI",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "DiabetesPedigree",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "Diabetic",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "DiastolicBloodPressure",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "PlasmaGlucose",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "SerumInsulin",
                table: "Predictions");

            migrationBuilder.RenameColumn(
                name: "TricepsThickness",
                table: "Predictions",
                newName: "Outcome");

            migrationBuilder.AddColumn<float>(
                name: "BloodPressure",
                table: "Predictions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "BodyMassIndex",
                table: "Predictions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Glucose",
                table: "Predictions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Insulin",
                table: "Predictions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SkinThickness",
                table: "Predictions",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
