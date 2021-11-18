using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportClubFaratechno.Migrations
{
    public partial class SportClub_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuffetDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuffetId = table.Column<long>(nullable: true),
                    BuffetItem = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabinet",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinetType = table.Column<long>(nullable: true),
                    CabinetName = table.Column<string>(nullable: true),
                    IsEngaged = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalonBuffet",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonId = table.Column<long>(nullable: true),
                    BuffetId = table.Column<long>(nullable: true),
                    Descripiton = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonBuffet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalonCabinet",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonId = table.Column<long>(nullable: true),
                    CabinetId = table.Column<long>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonCabinet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalonEquipment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonId = table.Column<long>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    IsFreeToUse = table.Column<bool>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalonSport",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonTypeId = table.Column<long>(nullable: true),
                    SportTypeId = table.Column<long>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true),
                    Desctiption = table.Column<string>(nullable: true),
                    SalonCabinetPrioraty = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonSport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalonSportSessionType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<long>(nullable: true),
                    SalonSportId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonSportSessionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionType = table.Column<long>(nullable: true),
                    NumberOfSessions = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    State = table.Column<long>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: true),
                    EndTime = table.Column<TimeSpan>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    AtAprice = table.Column<decimal>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true),
                    Sex = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<long>(nullable: true),
                    SessionDate = table.Column<DateTime>(nullable: true),
                    SessionDateShamsi = table.Column<string>(nullable: true),
                    State = table.Column<long>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    SessionId = table.Column<long>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionUserExtraDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionUserId = table.Column<long>(nullable: true),
                    UserExtraDetailId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUserExtraDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionUserTraffic",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<long>(nullable: true),
                    EntranceDatetime = table.Column<DateTime>(nullable: true),
                    EntranceDatetimeShamsi = table.Column<string>(nullable: true),
                    ExitDatetime = table.Column<DateTime>(nullable: true),
                    ExitDatetimeShamsi = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUserTraffic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    TrnType = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    TrnSource = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    HasAccess = table.Column<bool>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCabinet",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    CabinetId = table.Column<long>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCabinet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEquimentUsage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonEquipmentId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    TimeOfUsage = table.Column<TimeSpan>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEquimentUsage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserExtraInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: true),
                    SubmissionDateShamsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtraInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuffetDetail");

            migrationBuilder.DropTable(
                name: "Cabinet");

            migrationBuilder.DropTable(
                name: "SalonBuffet");

            migrationBuilder.DropTable(
                name: "SalonCabinet");

            migrationBuilder.DropTable(
                name: "SalonEquipment");

            migrationBuilder.DropTable(
                name: "SalonSport");

            migrationBuilder.DropTable(
                name: "SalonSportSessionType");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "SessionDetail");

            migrationBuilder.DropTable(
                name: "SessionUser");

            migrationBuilder.DropTable(
                name: "SessionUserExtraDetail");

            migrationBuilder.DropTable(
                name: "SessionUserTraffic");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserAccess");

            migrationBuilder.DropTable(
                name: "UserCabinet");

            migrationBuilder.DropTable(
                name: "UserEquimentUsage");

            migrationBuilder.DropTable(
                name: "UserExtraInfo");
        }
    }
}
