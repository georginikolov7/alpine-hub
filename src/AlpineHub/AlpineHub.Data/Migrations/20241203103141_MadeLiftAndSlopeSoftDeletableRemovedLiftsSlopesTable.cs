using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeLiftAndSlopeSoftDeletableRemovedLiftsSlopesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlopesLifts");

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("4cae352f-5213-4c21-a90d-05e17e84aff6"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("50763d36-75dc-4f74-8190-9df99bb7c16d"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("531ae042-8f88-4b94-b8dd-410222e0462a"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("1998ba17-de83-4459-aa04-1a899957f406"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("d5f7195e-6234-4f34-9647-45c3cd15fd78"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("eb22f72b-7ae2-4cc0-99da-2826595579c4"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Slopes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete flag");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lifts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete flag");

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("1044c4d3-270b-4682-882e-3b293e3b15b7"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("b1cbc931-74a3-4e89-b63f-7725381a8e60"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("c957926f-4f90-4abd-8639-1728e24f7823"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("1a2822ca-efda-4464-a553-9c24ba87d0ff"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("a35647b6-d777-423d-b1a5-2e356b27a724"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("f6c5b151-e298-4b5c-9418-f8789aac7d48"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("1044c4d3-270b-4682-882e-3b293e3b15b7"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("b1cbc931-74a3-4e89-b63f-7725381a8e60"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("c957926f-4f90-4abd-8639-1728e24f7823"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("1a2822ca-efda-4464-a553-9c24ba87d0ff"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("a35647b6-d777-423d-b1a5-2e356b27a724"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("f6c5b151-e298-4b5c-9418-f8789aac7d48"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Slopes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lifts");

            migrationBuilder.CreateTable(
                name: "SlopesLifts",
                columns: table => new
                {
                    SlopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of slope"),
                    LiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of lift")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlopesLifts", x => new { x.SlopeId, x.LiftId });
                    table.ForeignKey(
                        name: "FK_SlopesLifts_Lifts_LiftId",
                        column: x => x.LiftId,
                        principalTable: "Lifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlopesLifts_Slopes_SlopeId",
                        column: x => x.SlopeId,
                        principalTable: "Slopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("4cae352f-5213-4c21-a90d-05e17e84aff6"), 10, 1300, new TimeOnly(16, 30, 0), true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("50763d36-75dc-4f74-8190-9df99bb7c16d"), 25, 2000, new TimeOnly(16, 30, 0), true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("531ae042-8f88-4b94-b8dd-410222e0462a"), 12, 1200, new TimeOnly(16, 0, 0), false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("1998ba17-de83-4459-aa04-1a899957f406"), 4, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("d5f7195e-6234-4f34-9647-45c3cd15fd78"), 2, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("eb22f72b-7ae2-4cc0-99da-2826595579c4"), 0, true, 300, 1350, "Lerner's paradise", 1, 1450 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlopesLifts_LiftId",
                table: "SlopesLifts",
                column: "LiftId");
        }
    }
}
