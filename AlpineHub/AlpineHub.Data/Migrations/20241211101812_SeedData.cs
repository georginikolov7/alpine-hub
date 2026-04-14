using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LiftTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Gondola" },
                    { new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Chairlift" }
                });

            migrationBuilder.InsertData(
                table: "PassAgeGroups",
                columns: new[] { "Id", "MaxAge", "MinAge", "Name" },
                values: new object[,]
                {
                    { new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), 12, 6, "Child" },
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
                    { new Guid("518d51dd-99d1-4c8a-8d1b-1da84e253bbf"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("6bbd6d8b-5f3a-4957-ab5d-a2c7136496c5"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("fc1cb7e9-3a97-43bb-a662-612cc5f62b83"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 }
                });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("026a5b7a-3c58-4597-b6ac-97a2bccbc2e2"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("a80408aa-72fc-4b44-97cd-67274837c089"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("b22afe8a-f6d8-4bab-ae8f-de602d760724"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Passes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price" },
                values: new object[,]
                {
                    { new Guid("0cff3e71-c04d-4e53-bcc5-423b6ddf3eb6"), null, false, "All day adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m },
                    { new Guid("129b095a-13c8-4acb-86b2-1eb9445693eb"), null, false, "Afternoon adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 30m },
                    { new Guid("1fd6ce7d-3a4e-4da3-aaed-44c662977e38"), null, false, "All day student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m },
                    { new Guid("2a0c01fa-7784-44d2-889d-a6dc4c67dec9"), null, false, "Afternoon child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 20m },
                    { new Guid("362987f0-2fde-40e5-807a-86f969020505"), null, false, "Afternoon student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 25m },
                    { new Guid("399aa10a-5c7e-4140-98a5-1e9ce3d75b78"), null, false, "Morning child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 20m },
                    { new Guid("74c845f9-6a8d-47b4-a7ea-fd5ec8466af8"), null, false, "Morning student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 25m },
                    { new Guid("9fe2c683-9598-4fbb-b335-392ac0da0e13"), null, false, "Morning adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 30m },
                    { new Guid("c1ae2c08-937a-4722-9bbf-cbc3413473eb"), null, false, "All day child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("026a5b7a-3c58-4597-b6ac-97a2bccbc2e2"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("a80408aa-72fc-4b44-97cd-67274837c089"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("b22afe8a-f6d8-4bab-ae8f-de602d760724"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("0cff3e71-c04d-4e53-bcc5-423b6ddf3eb6"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("129b095a-13c8-4acb-86b2-1eb9445693eb"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("1fd6ce7d-3a4e-4da3-aaed-44c662977e38"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("2a0c01fa-7784-44d2-889d-a6dc4c67dec9"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("362987f0-2fde-40e5-807a-86f969020505"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("399aa10a-5c7e-4140-98a5-1e9ce3d75b78"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("74c845f9-6a8d-47b4-a7ea-fd5ec8466af8"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("9fe2c683-9598-4fbb-b335-392ac0da0e13"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("c1ae2c08-937a-4722-9bbf-cbc3413473eb"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("518d51dd-99d1-4c8a-8d1b-1da84e253bbf"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("6bbd6d8b-5f3a-4957-ab5d-a2c7136496c5"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("fc1cb7e9-3a97-43bb-a662-612cc5f62b83"));

            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"));

            migrationBuilder.DeleteData(
                table: "LiftTypes",
                keyColumn: "Id",
                keyValue: new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"));

            migrationBuilder.DeleteData(
                table: "PassAgeGroups",
                keyColumn: "Id",
                keyValue: new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"));

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
                keyValue: new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"));

            migrationBuilder.DeleteData(
                table: "PassPeriods",
                keyColumn: "Id",
                keyValue: new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"));

            migrationBuilder.DeleteData(
                table: "PassPeriods",
                keyColumn: "Id",
                keyValue: new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"));
        }
    }
}
