using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCartAndCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Number of passes"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total price of passes"),
                    PassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for pass"),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for cart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Passes_PassId",
                        column: x => x.PassId,
                        principalTable: "Passes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_UserCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "UserCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "AverageAscendTime", "CapacityPerHour", "ClosingTime", "IsDeleted", "IsOpen", "Length", "LiftTypeId", "Name", "NumberOfSeats", "OpenningTime", "VerticalAscend" },
                values: new object[,]
                {
                    { new Guid("21890091-755f-41a2-a8a5-475f937f9586"), 12, 1200, new TimeOnly(16, 0, 0), false, false, 1500, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Lakavator", 8, new TimeOnly(8, 45, 0), 400 },
                    { new Guid("54df2993-194d-4311-8abd-d1e25bae1a58"), 10, 1300, new TimeOnly(16, 30, 0), false, true, 1300, new Guid("dde8a2c0-a446-48b1-9da9-f3cb095b1662"), "Spring rider", 6, new TimeOnly(8, 30, 0), 300 },
                    { new Guid("d64d959f-b5aa-4143-9d14-828aa5f1a3c7"), 25, 2000, new TimeOnly(16, 30, 0), false, true, 2500, new Guid("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"), "Mountain Gondola", 8, new TimeOnly(8, 30, 0), 400 }
                });

            migrationBuilder.InsertData(
                table: "Passes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "PassAgeGroupId", "PassPeriodId", "Price", "ValidFromDate", "ValidToDate" },
                values: new object[,]
                {
                    { new Guid("908b799b-45a0-474f-85e1-3f35a9916eda"), null, false, "Allday adult pass", new Guid("a1371258-86d8-4ec2-9fbf-9b03a31cd548"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2a2c791-e3b9-4d43-af46-4c06a28fbe70"), null, false, "Allday student pass", new Guid("cae47722-1b8a-4578-b1c8-1f8b0412d7f1"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 40m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe62eca1-7671-4261-a2f9-5a01f59bd869"), null, false, "Allday child pass", new Guid("28700d0a-478e-476c-a2cb-cc56af2f7310"), new Guid("a91d8261-2dd1-4631-a379-ce4cff155371"), 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "Difficulty", "IsDeleted", "IsOpen", "Length", "LowerPointAltitude", "Name", "SlopeCondition", "UpperPointAltitude" },
                values: new object[,]
                {
                    { new Guid("5b03c0c8-f870-4433-95aa-74ea2cef3397"), 3, false, true, 2000, 1300, "Wolf ride", 0, 2200 },
                    { new Guid("712211ee-f66f-46ce-a65e-7a793840f835"), 0, false, true, 300, 1350, "Lerner's paradise", 1, 1450 },
                    { new Guid("9484bc1a-1230-4811-8ac9-a2e58bd59f3a"), 1, false, true, 800, 1800, "Rabbit's hole", 0, 2000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PassId",
                table: "CartItems",
                column: "PassId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_UserId",
                table: "UserCarts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "UserCarts");

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("21890091-755f-41a2-a8a5-475f937f9586"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("54df2993-194d-4311-8abd-d1e25bae1a58"));

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: new Guid("d64d959f-b5aa-4143-9d14-828aa5f1a3c7"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("908b799b-45a0-474f-85e1-3f35a9916eda"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("c2a2c791-e3b9-4d43-af46-4c06a28fbe70"));

            migrationBuilder.DeleteData(
                table: "Passes",
                keyColumn: "Id",
                keyValue: new Guid("fe62eca1-7671-4261-a2f9-5a01f59bd869"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("5b03c0c8-f870-4433-95aa-74ea2cef3397"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("712211ee-f66f-46ce-a65e-7a793840f835"));

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: new Guid("9484bc1a-1230-4811-8ac9-a2e58bd59f3a"));

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
    }
}
