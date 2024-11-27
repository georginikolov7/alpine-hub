using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpineHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypeAddedLiftIsOpen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClosedHour",
                table: "Lifts",
                newName: "ClosingHour");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Lifts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Lift status flag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Lifts");

            migrationBuilder.RenameColumn(
                name: "ClosingHour",
                table: "Lifts",
                newName: "ClosedHour");
        }
    }
}
