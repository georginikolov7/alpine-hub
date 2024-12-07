using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("3f858536-d76b-4546-b0be-c1750fafcdbf"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("4d8b2fdd-0c7c-48d3-8496-ba6d1c107636"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("b6244383-f167-4d6f-939f-5da3d5306cc3"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "PassAgeGroups",
                columns: new[] { "Id", "MaxAge", "MinAge", "Name" },
                values: new object[,]
                {
                    { new Guid("28700d0a-478e-476c-a2cb-cc56af2f7310"), 12, 6, "Child" },
                    { new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), 64, 18, "Adult" },
                    { new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), 26, 12, "Student" }
                });

            migrationBuilder.InsertData(
                table: "PassPeriods",
                columns: new[] { "Id", "DaysCount", "Name", "ValidFromHour", "ValidToHour" },
                values: new object[,]
                {
                    { new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 1, "Morning", new TimeOnly(8, 30, 0), new TimeOnly(12, 30, 0) },
                    { new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 1, "Afternoon", new TimeOnly(12, 30, 0), new TimeOnly(16, 30, 0) },
                    { new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 1, "All day", new TimeOnly(8, 30, 0), new TimeOnly(16, 30, 0) }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("78f2c895-0262-48e3-be55-6da50f91cf49"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("ce81be69-f712-415c-835f-3efade7fe848"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("ee750bd3-269b-432d-84a7-a9a2acd52bd1"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 }
                });

            migrationBuilder.InsertData(
                table: "Passes",
                columns: new[] { "Id", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price", "ValidFromDate", "ValidToDate" },
                values: new object[,]
                {
                    { new Guid("081ae014-ad2c-47c8-99d5-9ff9557679e2"), false, "Allday student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79f86e60-ccbb-47da-b631-b92752d79811"), false, "Allday child pass", new Guid("28700d0a-478e-476c-a2cb-cc56af2f7310"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8757c0ce-b79f-46d8-b0cf-7083b0911920"), false, "Allday adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("3f858536-d76b-4546-b0be-c1750fafcdbf"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("4d8b2fdd-0c7c-48d3-8496-ba6d1c107636"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("b6244383-f167-4d6f-939f-5da3d5306cc3"));

            migrationBuilder.DeleteData(
                table: "PassPeriods",
                keyColumn: "Id",
                keyValue: new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"));

            migrationBuilder.DeleteData(
                table: "PassPeriods",
                keyColumn: "Id",
                keyValue: new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("081ae014-ad2c-47c8-99d5-9ff9557679e2"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("79f86e60-ccbb-47da-b631-b92752d79811"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("8757c0ce-b79f-46d8-b0cf-7083b0911920"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("78f2c895-0262-48e3-be55-6da50f91cf49"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("ce81be69-f712-415c-835f-3efade7fe848"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("ee750bd3-269b-432d-84a7-a9a2acd52bd1"));

            migrationBuilder.DeleteData(
                table: "PassAgeGroups",
                keyColumn: "Id",
                keyValue: new Guid("28700d0a-478e-476c-a2cb-cc56af2f7310"));

            migrationBuilder.DeleteData(
                table: "PassAgeGroups",
                keyColumn: "Id",
                keyValue: new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"));

            migrationBuilder.DeleteData(
                table: "PassAgeGroups",
                keyColumn: "Id",
                keyValue: new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"));

            migrationBuilder.DeleteData(
                table: "PassPeriods",
                keyColumn: "Id",
                keyValue: new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"));

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
    }
}
