using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedResortManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("42abf2c8-1701-48d3-8eb8-35e601c0607a"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("af2d82b4-2d76-4198-b2d0-0d511b5cdd58"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("b363988f-c2e0-4ddd-b6a5-e19aae90bfb5"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("78239a8f-6eba-4960-bce6-84933abcb522"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("886a086a-2268-4e4d-978a-e907b19a6165"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("d787f343-0615-42e2-85cc-f343ee10e3a8"));

            migrationBuilder.CreateTable(
                name: "ResortManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key for ResortManager"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for user relation(1-1)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResortManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResortManagers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_ResortManagers_ApplicationUserId",
                table: "ResortManagers",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResortManagers");

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

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("42abf2c8-1701-48d3-8eb8-35e601c0607a"), 10, 1300, new TimeOnly(16, 30, 0), true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("af2d82b4-2d76-4198-b2d0-0d511b5cdd58"), 12, 1200, new TimeOnly(16, 0, 0), false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("b363988f-c2e0-4ddd-b6a5-e19aae90bfb5"), 25, 2000, new TimeOnly(16, 30, 0), true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("78239a8f-6eba-4960-bce6-84933abcb522"), 4, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("886a086a-2268-4e4d-978a-e907b19a6165"), 2, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("d787f343-0615-42e2-85cc-f343ee10e3a8"), 0, true, 300, 1350, "Lerner's paradise", 1, 1450 }
                });
        }
    }
}
