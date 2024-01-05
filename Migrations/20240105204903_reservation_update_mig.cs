using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareerBootcamp_Exam1.Migrations
{
    public partial class reservation_update_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckIn",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CheckOut",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Reservations");
        }
    }
}
