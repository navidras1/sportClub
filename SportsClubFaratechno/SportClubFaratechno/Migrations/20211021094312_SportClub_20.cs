using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "SessionUserTraffic");

            migrationBuilder.AddColumn<long>(
                name: "SessionUserId",
                table: "SessionUserTraffic",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionUserId",
                table: "SessionUserTraffic");

            migrationBuilder.AddColumn<long>(
                name: "SessionId",
                table: "SessionUserTraffic",
                type: "bigint",
                nullable: true);
        }
    }
}
