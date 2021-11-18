using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Session",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Session");
        }
    }
}
