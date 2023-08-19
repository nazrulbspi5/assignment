using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Web.Migrations
{
    /// <inheritdoc />
    public partial class addedManagerProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employees");
        }
    }
}
