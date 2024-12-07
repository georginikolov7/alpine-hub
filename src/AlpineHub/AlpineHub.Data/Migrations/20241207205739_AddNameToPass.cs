using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("738a706f-1764-4b55-8d5c-86a43b0c0661"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("a48efe0c-066c-4362-87a8-c381211d719b"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("bb1f1124-d6dd-4f13-8c75-089a7c757af0"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("0826599c-9673-44e7-8ded-31455432d61b"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("b0a0e1c1-729a-4c7a-9eb2-28fa74487e2d"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("bfc379b4-88e3-4b67-b234-13551b13d4ac"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Passes",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                comment: "Name of pass");

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("1e44e7cf-0395-4323-b369-1b6d18c5e917"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("673e0328-babc-4728-b128-b350ce11d635"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("76a82e4c-0d55-4c56-863a-4f26e52fb438"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("7b12e226-bee0-453b-874c-9c42c6695397"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("82c8ef4c-b7b6-43f4-b793-b7098705bf05"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("e36ac13f-7b33-47c4-97f7-10c81d963eb9"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("1e44e7cf-0395-4323-b369-1b6d18c5e917"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("673e0328-babc-4728-b128-b350ce11d635"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("76a82e4c-0d55-4c56-863a-4f26e52fb438"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("7b12e226-bee0-453b-874c-9c42c6695397"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("82c8ef4c-b7b6-43f4-b793-b7098705bf05"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("e36ac13f-7b33-47c4-97f7-10c81d963eb9"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Passes");

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("738a706f-1764-4b55-8d5c-86a43b0c0661"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("a48efe0c-066c-4362-87a8-c381211d719b"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("bb1f1124-d6dd-4f13-8c75-089a7c757af0"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("0826599c-9673-44e7-8ded-31455432d61b"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("b0a0e1c1-729a-4c7a-9eb2-28fa74487e2d"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("bfc379b4-88e3-4b67-b234-13551b13d4ac"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 }
                });
        }
    }
}
