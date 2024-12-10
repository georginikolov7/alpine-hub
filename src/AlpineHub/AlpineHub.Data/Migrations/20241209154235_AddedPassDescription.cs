using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPassDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Passes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                comment: "Description of pass");

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("2ed3961c-0f1b-4ef9-878d-8ce7165c44eb"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("af06fe08-2aec-4d6e-95bc-cd29f1501f00"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 },
                    { new Guid("c77dd937-1c51-405d-a719-c2bb1cda275d"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 }
                });

            migrationBuilder.InsertData(
                table: "Passes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price", "ValidFromDate", "ValidToDate" },
                values: new object[,]
                {
                    { new Guid("44144feb-0623-455a-b1a8-b6ae6d0d9a6a"), null, false, "Allday adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("833ec471-5d32-45b0-a69f-4b8688a19688"), null, false, "Allday student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b647d2b-5919-494c-9154-198f93e84923"), null, false, "Allday child pass", new Guid("28700d0a-478e-476c-a2cb-cc56af2f7310"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("7fd477b0-f19b-4b97-bf09-cf4b4e62d059"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("8f4c85d6-67de-4aae-a761-bd634d58e5d7"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("9309e7b4-c6d6-4e57-a7d2-7cf2253017bb"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("2ed3961c-0f1b-4ef9-878d-8ce7165c44eb"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("af06fe08-2aec-4d6e-95bc-cd29f1501f00"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("c77dd937-1c51-405d-a719-c2bb1cda275d"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("44144feb-0623-455a-b1a8-b6ae6d0d9a6a"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("833ec471-5d32-45b0-a69f-4b8688a19688"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("9b647d2b-5919-494c-9154-198f93e84923"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("7fd477b0-f19b-4b97-bf09-cf4b4e62d059"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("8f4c85d6-67de-4aae-a761-bd634d58e5d7"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("9309e7b4-c6d6-4e57-a7d2-7cf2253017bb"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Passes");

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
                table: "Passes",
                columns: new[] { "Id", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price", "ValidFromDate", "ValidToDate" },
                values: new object[,]
                {
                    { new Guid("081ae014-ad2c-47c8-99d5-9ff9557679e2"), false, "Allday student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79f86e60-ccbb-47da-b631-b92752d79811"), false, "Allday child pass", new Guid("28700d0a-478e-476c-a2cb-cc56af2f7310"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8757c0ce-b79f-46d8-b0cf-7083b0911920"), false, "Allday adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
        }
    }
}
