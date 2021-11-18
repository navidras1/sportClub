using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebApiAddress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccess",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccess", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "RoleAccess");
        }
    }
}
