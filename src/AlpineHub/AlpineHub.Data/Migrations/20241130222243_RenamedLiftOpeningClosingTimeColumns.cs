using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedLiftOpeningClosingTimeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("2161da1d-ce7a-4046-b746-6a561edd8b00"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("288f7ebf-47e4-425c-8ee6-60fa2335bff2"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("394b2841-38ba-4a4c-bfe8-18ca181f1053"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("74b264c6-994d-4a16-bd53-8ecc5403da03"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("7adbe39f-9e3a-4608-b6c1-db8eab26f5fd"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("fb6aa1f3-9a41-4b37-80e9-286739dd9735"));

            migrationBuilder.RenameColumn(
                name: "OpenningHour",
                table: "Lifts",
                newName: "OpenningTime");

            migrationBuilder.RenameColumn(
                name: "ClosingHour",
                table: "Lifts",
                newName: "ClosingTime");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "OpenningTime",
                table: "Lifts",
                newName: "OpenningHour");

            migrationBuilder.RenameColumn(
                name: "ClosingTime",
                table: "Lifts",
                newName: "ClosingHour");

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingHour", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningHour", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("2161da1d-ce7a-4046-b746-6a561edd8b00"), 25, 2000, new TimeOnly(16, 30, 0), true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("288f7ebf-47e4-425c-8ee6-60fa2335bff2"), 12, 1200, new TimeOnly(16, 0, 0), false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("394b2841-38ba-4a4c-bfe8-18ca181f1053"), 10, 1300, new TimeOnly(16, 30, 0), true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("74b264c6-994d-4a16-bd53-8ecc5403da03"), 2, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("7adbe39f-9e3a-4608-b6c1-db8eab26f5fd"), 4, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("fb6aa1f3-9a41-4b37-80e9-286739dd9735"), 0, true, 300, 1350, "Lerner's paradise", 1, 1450 }
                });
        }
    }
}
