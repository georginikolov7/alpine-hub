using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePassTypeMakePassPeriodInTimeOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passes_PassTypes_PassTypeId",
                table: "Passes");

            migrationBuilder.DropTable(
                name: "PassTypes");

            migrationBuilder.DropIndex(
                name: "IX_Passes_PassTypeId",
                table: "Passes");

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

            migrationBuilder.DropColumn(
                name: "PassTypeId",
                table: "Passes");

            migrationBuilder.DropForeignKey(name: "FK_Passes_PassPeriods_PassPeriodId", table: "Passes");
            migrationBuilder.DropTable("PassPeriods");

            migrationBuilder.CreateTable(
                name: "PassPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table PassPeriods"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of pass period"),
                    ValidFromHour = table.Column<TimeOnly>(type: "time", nullable: false, comment: "Starting hour of pass period"),
                    ValidToHour = table.Column<TimeOnly>(type: "time", nullable: false, comment: "Ending hour of pass period"),
                    DaysCount = table.Column<int>(type: "int", nullable: false, comment: "Number of days for pass validity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassPeriods", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "Passes_PassPeriods_PassPeriodId",
                table: "Passes",
                column: "PassPeriodId",
                principalTable: "PassPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AlterColumn<TimeOnly>(
            //    name: "ValidToHour",
            //    table: "PassPeriods",
            //    type: "time",
            //    nullable: false,
            //    comment: "Ending hour of pass period",
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldComment: "Ending hour of pass period");

            //migrationBuilder.AlterColumn<TimeOnly>(
            //    name: "ValidFromHour",
            //    table: "PassPeriods",
            //    type: "time",
            //    nullable: false,
            //    comment: "Starting hour of pass period",
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldComment: "Starting hour of pass period");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ValidToHour",
                table: "PassPeriods",
                type: "int",
                nullable: false,
                comment: "Ending hour of pass period",
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldComment: "Ending hour of pass period");

            migrationBuilder.AlterColumn<int>(
                name: "ValidFromHour",
                table: "PassPeriods",
                type: "int",
                nullable: false,
                comment: "Starting hour of pass period",
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldComment: "Starting hour of pass period");

            migrationBuilder.AddColumn<Guid>(
                name: "PassTypeId",
                table: "Passes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key for pass type");

            migrationBuilder.CreateTable(
                name: "PassTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table"),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Discount of current pass type"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false, comment: "Name of pass type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassTypes", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Passes_PassTypeId",
                table: "Passes",
                column: "PassTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passes_PassTypes_PassTypeId",
                table: "Passes",
                column: "PassTypeId",
                principalTable: "PassTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
