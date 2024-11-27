using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedLiftTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("6c670604-4c9a-4066-b0b1-5974955ef7f9"));

            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("e400e024-3f0f-4ad6-84b5-b6392c1a7cfd"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("5279b012-1187-4ef8-bad2-440d3c2dca45"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("74dfc2a7-0ed4-42ca-a0e1-99070021ab0c"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("b8e3e16a-df12-4a92-8fd3-0d28482c6ccd"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("870a9ac9-153b-4f33-94d7-c9c70c455393"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("b307d0ac-a44a-4e9f-bb00-8cabad6d0afb"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("c99d8323-b7ae-48b6-b299-739ffc547e1b"));

            migrationBuilder.InsertData(
                table: "LiftTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Gondola" },
                    { new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Chairlift" }
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

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingHour", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningHour", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("2161da1d-ce7a-4046-b746-6a561edd8b00"), 25, 2000, new TimeOnly(16, 30, 0), true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("288f7ebf-47e4-425c-8ee6-60fa2335bff2"), 12, 1200, new TimeOnly(16, 0, 0), false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("394b2841-38ba-4a4c-bfe8-18ca181f1053"), 10, 1300, new TimeOnly(16, 30, 0), true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"));

            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"));

            migrationBuilder.InsertData(
                table: "LiftTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6c670604-4c9a-4066-b0b1-5974955ef7f9"), "Chairlift" },
                    { new Guid("e400e024-3f0f-4ad6-84b5-b6392c1a7cfd"), "Gondola" }
                });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingHour", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningHour", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("5279b012-1187-4ef8-bad2-440d3c2dca45"), 12, 1200, new TimeOnly(16, 0, 0), false, 1500, new Guid("458000dd-f5b8-455c-b0be-71db4ec53f1f"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("74dfc2a7-0ed4-42ca-a0e1-99070021ab0c"), 10, 1300, new TimeOnly(16, 30, 0), true, 1300, new Guid("458000dd-f5b8-455c-b0be-71db4ec53f1f"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("b8e3e16a-df12-4a92-8fd3-0d28482c6ccd"), 25, 2000, new TimeOnly(16, 30, 0), true, 2500, new Guid("eb42a879-b6b2-4c50-b8d4-4336e97e67a6"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("870a9ac9-153b-4f33-94d7-c9c70c455393"), 2, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("b307d0ac-a44a-4e9f-bb00-8cabad6d0afb"), 0, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("c99d8323-b7ae-48b6-b299-739ffc547e1b"), 4, true, 2000, 1300, "Wolf ride", 0, 2200 }
                });
        }
    }
}
