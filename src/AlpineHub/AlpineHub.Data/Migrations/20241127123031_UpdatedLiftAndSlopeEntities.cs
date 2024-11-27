using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedLiftAndSlopeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastRideFromBottomStationTime",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "LastRideFromTopStationTime",
                table: "Lifts");

            migrationBuilder.AddColumn<int>(
                name: "LowerPointAltitude",
                table: "Slopes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Elevation at lowest point of the slope");

            migrationBuilder.AddColumn<int>(
                name: "UpperPointAltitude",
                table: "Slopes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Elevation at upmost point of the slope");

            migrationBuilder.AddColumn<int>(
                name: "CapacityPerHour",
                table: "Lifts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Max number of people per hour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowerPointAltitude",
                table: "Slopes");

            migrationBuilder.DropColumn(
                name: "UpperPointAltitude",
                table: "Slopes");

            migrationBuilder.DropColumn(
                name: "CapacityPerHour",
                table: "Lifts");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "LastRideFromBottomStationTime",
                table: "Lifts",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                comment: "Last time to ride lift from bottom station");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "LastRideFromTopStationTime",
                table: "Lifts",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                comment: "Last time to ride lift from top station");
        }
    }
}
