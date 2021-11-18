using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<long>(nullable: true),
                    DetailName = table.Column<string>(nullable: true),
                    DetailValue = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    TypeId = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailType");

            migrationBuilder.DropTable(
                name: "MasterType");
        }
    }
}
