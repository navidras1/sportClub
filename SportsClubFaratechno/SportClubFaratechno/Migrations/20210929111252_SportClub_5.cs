using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserExtraDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    DetailName = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtraDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExtraDetail");
        }
    }
}
