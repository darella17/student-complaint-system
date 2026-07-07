using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDoubleConfirmation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Complaints");

            migrationBuilder.AddColumn<bool>(
                name: "AdminResolved",
                table: "Complaints",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StudentConfirmed",
                table: "Complaints",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminResolved",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "StudentConfirmed",
                table: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
