using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeBirthdateNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                comment: "Birthdate of user",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Birthdate of user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Birthdate of user",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Birthdate of user");
        }
    }
}
