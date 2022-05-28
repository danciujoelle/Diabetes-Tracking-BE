using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiabetesTrackingServer.Migrations
{
    public partial class Addedsportandinsulinlogmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsulinLogs",
                columns: table => new
                {
                    InsulinLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsulinIntake = table.Column<float>(type: "real", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenWasInjected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsulinLogs", x => x.InsulinLogId);
                    table.ForeignKey(
                        name: "FK_InsulinLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportLogs",
                columns: table => new
                {
                    SportLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportLogs", x => x.SportLogId);
                    table.ForeignKey(
                        name: "FK_SportLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsulinLogs_UserId",
                table: "InsulinLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SportLogs_UserId",
                table: "SportLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsulinLogs");

            migrationBuilder.DropTable(
                name: "SportLogs");
        }
    }
}
