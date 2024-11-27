using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Lifts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of seats of lift");

            migrationBuilder.InsertData(
                table: "LiftTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6c670604-4c9a-4066-b0b1-5974955ef7f9"), "Chairlift" },
                    { new Guid("e400e024-3f0f-4ad6-84b5-b6392c1a7cfd"), "Gondola" }
                });

            //migrationBuilder.InsertData(
            //    table: "Lifts",
            //    columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingHour", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningHour", "VerticalAscend" },
            //    values: new object[,]
            //    {
            //        { new Guid("5279b012-1187-4ef8-bad2-440d3c2dca45"), 12, 1200, new TimeOnly(16, 0, 0), false, 1500, new Guid("458000dd-f5b8-455c-b0be-71db4ec53f1f"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
            //        { new Guid("74dfc2a7-0ed4-42ca-a0e1-99070021ab0c"), 10, 1300, new TimeOnly(16, 30, 0), true, 1300, new Guid("458000dd-f5b8-455c-b0be-71db4ec53f1f"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
            //        { new Guid("b8e3e16a-df12-4a92-8fd3-0d28482c6ccd"), 25, 2000, new TimeOnly(16, 30, 0), true, 2500, new Guid("eb42a879-b6b2-4c50-b8d4-4336e97e67a6"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
            //    });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("6c670604-4c9a-4066-b0b1-5974955ef7f9"));

            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("e400e024-3f0f-4ad6-84b5-b6392c1a7cfd"));

            //migrationBuilder.DeleteData(
            //    table: "Lifts",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5279b012-1187-4ef8-bad2-440d3c2dca45"));

            //migrationBuilder.DeleteData(
            //    table: "Lifts",
            //    keyColumn: "Id",
            //    keyValue: new Guid("74dfc2a7-0ed4-42ca-a0e1-99070021ab0c"));

            //migrationBuilder.DeleteData(
            //    table: "Lifts",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b8e3e16a-df12-4a92-8fd3-0d28482c6ccd"));

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

            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Lifts");
        }
    }
}
