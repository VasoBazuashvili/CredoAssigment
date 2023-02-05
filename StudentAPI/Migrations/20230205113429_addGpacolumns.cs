using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class addGpacolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GPA",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Students");
        }
    }
}
