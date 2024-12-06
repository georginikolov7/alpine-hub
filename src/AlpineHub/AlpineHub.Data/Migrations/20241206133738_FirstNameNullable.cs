using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstNameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "First name of user",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "First name of user");

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("81e48916-ea51-4b83-82d5-d4de1212c5ca"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("ebcc9263-5958-4a80-846c-752a0499f9ea"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("f0b92564-f4a3-41ea-85b0-bc866267c8e2"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("0eb0391f-bcbb-4e23-9368-bea4f6a00b87"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("358e7eab-5017-4983-b2f3-01145bafbdb1"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("ac3fe261-f9fb-4d0d-a796-077eb3a5613a"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("81e48916-ea51-4b83-82d5-d4de1212c5ca"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("ebcc9263-5958-4a80-846c-752a0499f9ea"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("f0b92564-f4a3-41ea-85b0-bc866267c8e2"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("0eb0391f-bcbb-4e23-9368-bea4f6a00b87"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("358e7eab-5017-4983-b2f3-01145bafbdb1"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("ac3fe261-f9fb-4d0d-a796-077eb3a5613a"));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "First name of user",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "First name of user");

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
    }
}
