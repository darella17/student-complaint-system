using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MatricNumber",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "MatricNumber",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Complaints");
        }
    }
}
