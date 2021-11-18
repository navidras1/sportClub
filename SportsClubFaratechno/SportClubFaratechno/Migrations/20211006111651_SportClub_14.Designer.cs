﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportClubFaratechno.Models.SportClubFaratechnoDB;

namespace SportClubFaratechno.Migrations
{
    [DbContext(typeof(SportClubFaratechnoDBContext))]
    [Migration("20211006111651_SportClub_14")]
    partial class SportClub_14
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.Access", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebApiAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.AppRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandlineNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.BuffetDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BuffetId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BuffetItem")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuffetDetail");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.Cabinet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CabinetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CabinetType")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsEngaged")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cabinet");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.DetailType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MasterId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DetailType");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.MasterType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MasterType");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.RoleAccess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccessId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleAccess");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SalonBuffet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BuffetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descripiton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SalonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalonBuffet");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SalonCabinet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CabinetId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SalonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalonCabinet");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SalonEquipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsFreeToUse")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<long?>("SalonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SalonEquipment");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SalonSport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desctiption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SalonCabinetPrioraty")
                        .HasColumnType("bit");

                    b.Property<long?>("SalonTypeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SportTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalonSport");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SalonSportSessionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SalonSportId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalonSportSessionType");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.Session", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AtAprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<int?>("NumberOfSessions")
                        .HasColumnType("int");

                    b.Property<long?>("SessionType")
                        .HasColumnType("bigint");

                    b.Property<bool?>("Sex")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.Property<long?>("State")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Test")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SessionDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SessionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("State")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SessionDetail");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SessionUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SessionUser");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SessionUserExtraDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("SessionUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserExtraDetailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SessionUserExtraDetail");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.SessionUserTraffic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EntranceDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntranceDatetimeShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExitDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExitDatetimeShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SessionUserTraffic");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("TrnSource")
                        .HasColumnType("bigint");

                    b.Property<long?>("TrnType")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.UserAccess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccessId")
                        .HasColumnType("bigint");

                    b.Property<bool>("HasAccess")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserAccess");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.UserCabinet", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CabinetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserCabinet");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.UserEquimentUsage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SalonEquipmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("TimeOfUsage")
                        .HasColumnType("time");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserEquimentUsage");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.UserExtraDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserExtraDetail");
                });

            modelBuilder.Entity("SportClubFaratechno.Models.SportClubFaratechnoDB.UserExtraInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionDateShamsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserExtraInfo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("SportClubFaratechno.Models.SportClubFaratechnoDB.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("SportClubFaratechno.Models.SportClubFaratechnoDB.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("SportClubFaratechno.Models.SportClubFaratechnoDB.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("SportClubFaratechno.Models.SportClubFaratechnoDB.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportClubFaratechno.Models.SportClubFaratechnoDB.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("SportClubFaratechno.Models.SportClubFaratechnoDB.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
