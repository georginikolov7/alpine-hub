using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedManagerSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9c2a65ae-5259-410a-96c3-f4667516f42c"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c8a3f1-e2d9-4639-819a-255e5c1b39f9", "DIMITRICHKO@TEST.COM", "MANAGER", "AQAAAAIAAYagAAAAEB+eAlm8mCN9e1DhOu1pmTfahUxosZKfxEmN7U2HJwxp6Uxk/DnFS1tP9fyRNj0a7g==", "9C2A65AE-5259-410A-96C3-F4667516F42A" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c4fc4fc3-283e-46be-a9a3-f35032d91570"), 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "783590b0-d9be-4a8d-8502-f08533641e1a", "user@test.com", false, "John", "Doe", false, null, "USER@TEST.COM", "SKIER", "AQAAAAIAAYagAAAAEEK20CIdmSSdVCXLCrg7Oakn3hyafYbjXJHLUQ7zCC/xdJi2wQ2yb12s2ycAVPjefQ==", null, false, "9C2F65AE-5259-410A-96C3-F4667516F42C", false, "Skier" });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("12ae3ac0-3387-4652-8b50-a919d1f2bc98"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("3d7bc92c-141a-4fbb-91c2-881da59c8cdb"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("da6d08bd-041d-4f5c-adc1-a3fb580b7b3e"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Passes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price" },
                values: new object[,]
                {
                    { new Guid("30078d66-52da-438f-8187-b7ed45b31ab0"), null, false, "Afternoon child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 20m },
                    { new Guid("3602e22d-ae41-4757-a3eb-52aebd6c14fa"), null, false, "All day student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m },
                    { new Guid("75ee3ca1-3998-42c5-b2af-372149a0f056"), null, false, "All day child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m },
                    { new Guid("8258ed75-0080-46d2-bf9b-54138bb998b6"), null, false, "Morning student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 25m },
                    { new Guid("91f3d918-ffd4-456c-87c4-f75c48b0e90e"), null, false, "Afternoon student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 25m },
                    { new Guid("98eee19b-0e0f-402a-85e4-d7f7be3b9236"), null, false, "Morning adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 30m },
                    { new Guid("a6ba74b3-6f9d-4dd2-8855-e64cce3c4cfe"), null, false, "All day adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m },
                    { new Guid("ad982085-f2b3-4522-b6e2-ce27a076b4e3"), null, false, "Morning child pass", new Guid("3d8819ca-f1cf-48cd-c851-08dd19791faa"), new Guid("235024b0-64b9-4e2e-a0ee-48d0a2750953"), 20m },
                    { new Guid("f74b66ff-ff7a-4c8b-a134-5e693b0d1e7a"), null, false, "Afternoon adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("727c219a-0e3a-4eeb-9215-8602cbd62372"), 30m }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("57d099f3-6a24-44f9-bb75-5eae910d509a"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("58ae1685-7ac3-49df-88ff-1dc9b408b38d"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("ad4de646-c424-4c7b-98eb-e99913899ce7"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c4fc4fc3-283e-46be-a9a3-f35032d91570"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("12ae3ac0-3387-4652-8b50-a919d1f2bc98"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("3d7bc92c-141a-4fbb-91c2-881da59c8cdb"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("da6d08bd-041d-4f5c-adc1-a3fb580b7b3e"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("30078d66-52da-438f-8187-b7ed45b31ab0"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("3602e22d-ae41-4757-a3eb-52aebd6c14fa"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("75ee3ca1-3998-42c5-b2af-372149a0f056"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("8258ed75-0080-46d2-bf9b-54138bb998b6"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("91f3d918-ffd4-456c-87c4-f75c48b0e90e"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("98eee19b-0e0f-402a-85e4-d7f7be3b9236"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("a6ba74b3-6f9d-4dd2-8855-e64cce3c4cfe"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("ad982085-f2b3-4522-b6e2-ce27a076b4e3"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("f74b66ff-ff7a-4c8b-a134-5e693b0d1e7a"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("57d099f3-6a24-44f9-bb75-5eae910d509a"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("58ae1685-7ac3-49df-88ff-1dc9b408b38d"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("ad4de646-c424-4c7b-98eb-e99913899ce7"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9c2a65ae-5259-410a-96c3-f4667516f42c"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c7455dc-9f0d-42bd-94a7-10adb6e0c87c", null, null, "AQAAAAIAAYagAAAAEGlAkUnwDSXhIwIg+Eb5xEeVRI/75hykJ299aantmkwdALGN0HbfJQTM7I/EvYiwrA==", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b612ca3d-9393-43bf-82dc-1309c7aee037"), 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6e932620-f15b-40db-bbc5-5e2581928745", "user@test.com", false, "John", "Doe", false, null, "USER@TEST.COM", "SKIER", "AQAAAAIAAYagAAAAEHft89Uj/WbKBjH88T3l0cgAEbJbMJ1TC5cUgkWUkG8pCYU4hmZm2YMxV9j1O5mZMg==", null, false, null, false, "Skier" });

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
        }
    }
}
