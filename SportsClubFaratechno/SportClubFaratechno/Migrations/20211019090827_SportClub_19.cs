using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Session",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Session");
        }
    }
}
