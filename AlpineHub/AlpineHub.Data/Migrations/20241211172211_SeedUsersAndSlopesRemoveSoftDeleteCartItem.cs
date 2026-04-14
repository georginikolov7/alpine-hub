using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndSlopesRemoveSoftDeleteCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CartItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Passes",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Pass price. ",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Pass price. Pass type discount is automatically deduced");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9c2a65ae-5259-410a-96c3-f4667516f42c"), 0, new DateTime(2000, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "4c7455dc-9f0d-42bd-94a7-10adb6e0c87c", "dimitrichko@test.com", false, "Dimitrichko", "Chorbadjiski", false, null, null, null, "AQAAAAIAAYagAAAAEGlAkUnwDSXhIwIg+Eb5xEeVRI/75hykJ299aantmkwdALGN0HbfJQTM7I/EvYiwrA==", null, false, null, false, "Manager" },
                    { new Guid("b612ca3d-9393-43bf-82dc-1309c7aee037"), 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6e932620-f15b-40db-bbc5-5e2581928745", "user@test.com", false, "John", "Doe", false, null, "USER@TEST.COM", "SKIER", "AQAAAAIAAYagAAAAEHft89Uj/WbKBjH88T3l0cgAEbJbMJ1TC5cUgkWUkG8pCYU4hmZm2YMxV9j1O5mZMg==", null, false, null, false, "Skier" }
                });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("2c30c11f-0efb-4005-8db6-02d05f85e364"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("3db7f073-098c-4fca-ba88-81a233c4c786"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("76ec4f80-9e83-44f7-9f38-0f4aa3ab1a38"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Passes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price" },
                values: new object[,]
                {
                    { new Guid("0b175c71-a7a3-4bb9-b87f-f4b952256048"), null, false, "Morning student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 25m },
                    { new Guid("27b2193a-2f8b-46f3-8615-e010225ab1c7"), null, false, "All day adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m },
                    { new Guid("3f9c2e1c-8990-435f-bcc6-9e6f33ae5647"), null, false, "Afternoon child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 20m },
                    { new Guid("42761706-7eea-43f4-ac87-5968323daec5"), null, false, "Morning adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 30m },
                    { new Guid("4bc48745-bbd3-43aa-bd5c-c8aba057ea6e"), null, false, "Morning child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 20m },
                    { new Guid("a30b7e49-62bf-4a9d-a45a-ad8c5794a8a9"), null, false, "All day student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m },
                    { new Guid("af570adb-ab18-4e36-b109-e87228a98160"), null, false, "All day child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m },
                    { new Guid("dc2046cd-8ff7-4f69-83ce-8d67447962a7"), null, false, "Afternoon student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 25m },
                    { new Guid("e10d9ce8-71cc-4def-a19c-93d390f5cf74"), null, false, "Afternoon adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 30m }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("5b86bc2c-d6fe-43ec-a2b1-b334248de083"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("72cdfe6b-fa5b-41a9-8e0a-94d407796c74"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 },
                    { new Guid("a4c99d89-71f7-4e82-8b60-51d0507fc99f"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 }
                });

            migrationBuilder.InsertData(
                table: "ResortManagers",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("29a945ec-9c3b-41ac-8065-edfb32974aa6"), new Guid("9c2a65ae-5259-410a-96c3-f4667516f42c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b612ca3d-9393-43bf-82dc-1309c7aee037"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("2c30c11f-0efb-4005-8db6-02d05f85e364"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("3db7f073-098c-4fca-ba88-81a233c4c786"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("76ec4f80-9e83-44f7-9f38-0f4aa3ab1a38"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("0b175c71-a7a3-4bb9-b87f-f4b952256048"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("27b2193a-2f8b-46f3-8615-e010225ab1c7"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("3f9c2e1c-8990-435f-bcc6-9e6f33ae5647"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("42761706-7eea-43f4-ac87-5968323daec5"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("4bc48745-bbd3-43aa-bd5c-c8aba057ea6e"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("a30b7e49-62bf-4a9d-a45a-ad8c5794a8a9"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("af570adb-ab18-4e36-b109-e87228a98160"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("dc2046cd-8ff7-4f69-83ce-8d67447962a7"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("e10d9ce8-71cc-4def-a19c-93d390f5cf74"));

            migrationBuilder.DeleteData(
                table: "ResortManagers",
                keyColumn: "Id",
                keyValue: new Guid("29a945ec-9c3b-41ac-8065-edfb32974aa6"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("5b86bc2c-d6fe-43ec-a2b1-b334248de083"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("72cdfe6b-fa5b-41a9-8e0a-94d407796c74"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("a4c99d89-71f7-4e82-8b60-51d0507fc99f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9c2a65ae-5259-410a-96c3-f4667516f42c"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Passes",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Pass price. Pass type discount is automatically deduced",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Pass price. ");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("518d51dd-99d1-4c8a-8d1b-1da84e253bbf"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("6bbd6d8b-5f3a-4957-ab5d-a2c7136496c5"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("fc1cb7e9-3a97-43bb-a662-612cc5f62b83"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 }
                });
        }
    }
}
