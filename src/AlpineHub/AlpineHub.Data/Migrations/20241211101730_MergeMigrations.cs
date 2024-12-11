using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class MergeMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "First name of user"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Last name of user"),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Birthdate of user"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiftTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of lift type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassAgeGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of age group"),
                    MinAge = table.Column<int>(type: "int", nullable: false, comment: "Min age of client"),
                    MaxAge = table.Column<int>(type: "int", nullable: false, comment: "Max age of client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassAgeGroups", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Slopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the slope"),
                    Length = table.Column<int>(type: "int", nullable: false, comment: "Length of the slope in meters"),
                    UpperPointAltitude = table.Column<int>(type: "int", nullable: false, comment: "Elevation at upmost point of the slope"),
                    LowerPointAltitude = table.Column<int>(type: "int", nullable: false, comment: "Elevation at lowest point of the slope"),
                    Difficulty = table.Column<int>(type: "int", nullable: false, comment: "Slope difficulty enum"),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false, comment: "Flag indicating if slope is open"),
                    SlopeCondition = table.Column<int>(type: "int", nullable: false, comment: "Slope condition enum"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete flag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResortManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key for ResortManager"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for user relation(1-1)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResortManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResortManagers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Lifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "Name of ski lift"),
                    Length = table.Column<int>(type: "int", nullable: false, comment: "Length of ski lift in meters"),
                    VerticalAscend = table.Column<int>(type: "int", nullable: false, comment: "Vertical ascend of lift in meters"),
                    CapacityPerHour = table.Column<int>(type: "int", nullable: false, comment: "Max number of people per hour"),
                    AverageAscendTime = table.Column<int>(type: "int", nullable: false, comment: "Average ascend time in minutes"),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false, comment: "Number of seats of lift"),
                    OpenningTime = table.Column<TimeOnly>(type: "time", nullable: false, comment: "Openning hour of lift"),
                    ClosingTime = table.Column<TimeOnly>(type: "time", nullable: false, comment: "Closing hour of lift"),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false, comment: "Lift status flag"),
                    LiftTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for lift type relation"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete flag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lifts_LiftTypes_LiftTypeId",
                        column: x => x.LiftTypeId,
                        principalTable: "LiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key of table"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false, comment: "Name of pass"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "Description of pass"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Pass price. Pass type discount is automatically deduced"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Flag for soft deletion"),
                    PassAgeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for pass age group"),
                    PassPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for pass period")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passes_PassAgeGroups_PassAgeGroupId",
                        column: x => x.PassAgeGroupId,
                        principalTable: "PassAgeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passes_PassPeriods_PassPeriodId",
                        column: x => x.PassPeriodId,
                        principalTable: "PassPeriods",
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
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for cart"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PassId",
                table: "CartItems",
                column: "PassId");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_LiftTypeId",
                table: "Lifts",
                column: "LiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Passes_PassAgeGroupId",
                table: "Passes",
                column: "PassAgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Passes_PassPeriodId",
                table: "Passes",
                column: "PassPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ResortManagers_ApplicationUserId",
                table: "ResortManagers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_UserId",
                table: "UserCarts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Lifts");

            migrationBuilder.DropTable(
                name: "ResortManagers");

            migrationBuilder.DropTable(
                name: "Slopes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "UserCarts");

            migrationBuilder.DropTable(
                name: "LiftTypes");

            migrationBuilder.DropTable(
                name: "PassAgeGroups");

            migrationBuilder.DropTable(
                name: "PassPeriods");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
