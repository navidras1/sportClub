using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndDateShamsi",
                table: "Session",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartDateShamsi",
                table: "Session",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateShamsi",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "StartDateShamsi",
                table: "Session");
        }
    }
}
