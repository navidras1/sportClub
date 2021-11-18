using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalonSportSessionType");

            migrationBuilder.DropColumn(
                name: "SessionType",
                table: "Session");

            migrationBuilder.AddColumn<long>(
                name: "SalonSportId",
                table: "Session",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalonSportId",
                table: "Session");

            migrationBuilder.AddColumn<long>(
                name: "SessionType",
                table: "Session",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalonSportSessionType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalonSportId = table.Column<long>(type: "bigint", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubmissionDateShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonSportSessionType", x => x.Id);
                });
        }
    }
}
