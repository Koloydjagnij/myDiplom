using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievement",
                columns: table => new
                {
                    id_achievement = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_achievement = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievement", x => x.id_achievement);
                });

            migrationBuilder.CreateTable(
                name: "AppConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "document",
                columns: table => new
                {
                    id_document = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_document = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document", x => x.id_document);
                });

            migrationBuilder.CreateTable(
                name: "education_type",
                columns: table => new
                {
                    id_education_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_education_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_type", x => x.id_education_type);
                });

            migrationBuilder.CreateTable(
                name: "entrance_exams",
                columns: table => new
                {
                    id_entrance_exam = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_entrance_exam = table.Column<string>(nullable: false),
                    necessarily = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrance_exams", x => x.id_entrance_exam);
                });

            migrationBuilder.CreateTable(
                name: "fact_of_prosecution",
                columns: table => new
                {
                    id_fact_of_prosecution = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_fact_of_prosecution = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fact_of_prosecution", x => x.id_fact_of_prosecution);
                });

            migrationBuilder.CreateTable(
                name: "family_type",
                columns: table => new
                {
                    id_family_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_family_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_family_type", x => x.id_family_type);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id_group = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountEnrolleeInGroup = table.Column<int>(nullable: false),
                    group_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id_group);
                });

            migrationBuilder.CreateTable(
                name: "marital_status",
                columns: table => new
                {
                    id_marital_status = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_marital_status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marital_status", x => x.id_marital_status);
                });

            migrationBuilder.CreateTable(
                name: "military_district",
                columns: table => new
                {
                    id_military_district = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_military_district = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_military_district", x => x.id_military_district);
                });

            migrationBuilder.CreateTable(
                name: "military_rank",
                columns: table => new
                {
                    id_military_rank = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_military_rank = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_military_rank", x => x.id_military_rank);
                });

            migrationBuilder.CreateTable(
                name: "military_service_category",
                columns: table => new
                {
                    id_category_ms = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_category_ms = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_military_service_category", x => x.id_category_ms);
                });

            migrationBuilder.CreateTable(
                name: "nationality",
                columns: table => new
                {
                    id_nationality = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_nationality = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationality", x => x.id_nationality);
                });

            migrationBuilder.CreateTable(
                name: "parent_type",
                columns: table => new
                {
                    id_parent_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_parent_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parent_type", x => x.id_parent_type);
                });

            migrationBuilder.CreateTable(
                name: "Pochta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActDate = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Autonom = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    City1 = table.Column<string>(nullable: true),
                    Index = table.Column<string>(nullable: true),
                    IndexOld = table.Column<string>(nullable: true),
                    OPSName = table.Column<string>(nullable: true),
                    OPSSubm = table.Column<string>(nullable: true),
                    OPSType = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pochta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "preemptive_right",
                columns: table => new
                {
                    id_preemptive_right = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_preemptive_right = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preemptive_right", x => x.id_preemptive_right);
                });

            migrationBuilder.CreateTable(
                name: "reason_for_deduction",
                columns: table => new
                {
                    id_reason_for_deduction = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_reason_for_deduction = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reason_for_deduction", x => x.id_reason_for_deduction);
                });

            migrationBuilder.CreateTable(
                name: "sex",
                columns: table => new
                {
                    id_sex = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_sex = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sex", x => x.id_sex);
                });

            migrationBuilder.CreateTable(
                name: "social_background",
                columns: table => new
                {
                    id_social_background = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_social_background = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_background", x => x.id_social_background);
                });

            migrationBuilder.CreateTable(
                name: "social_status",
                columns: table => new
                {
                    id_social_status = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_social_status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_status", x => x.id_social_status);
                });

            migrationBuilder.CreateTable(
                name: "speciality",
                columns: table => new
                {
                    id_speciality = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountAbiturToSpeciality = table.Column<int>(nullable: false),
                    name_speciality = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speciality", x => x.id_speciality);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id_subject = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_subject = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.id_subject);
                });

            migrationBuilder.CreateTable(
                name: "test_type",
                columns: table => new
                {
                    id_test_type = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_test_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_type", x => x.id_test_type);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    id_region = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_military_district = table.Column<int>(nullable: false),
                    name_region = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.id_region);
                    table.ForeignKey(
                        name: "r_60",
                        column: x => x.id_military_district,
                        principalTable: "military_district",
                        principalColumn: "id_military_district",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exam_for_speciality",
                columns: table => new
                {
                    IdExamForSpeciality = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_entrance_exam = table.Column<int>(nullable: false),
                    id_speciality = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam_for_speciality", x => x.IdExamForSpeciality);
                    table.ForeignKey(
                        name: "r_73",
                        column: x => x.id_entrance_exam,
                        principalTable: "entrance_exams",
                        principalColumn: "id_entrance_exam",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_74",
                        column: x => x.id_speciality,
                        principalTable: "speciality",
                        principalColumn: "id_speciality",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id_area = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_region = table.Column<int>(nullable: false),
                    name_area = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id_area);
                    table.ForeignKey(
                        name: "r_59",
                        column: x => x.id_region,
                        principalTable: "region",
                        principalColumn: "id_region",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id_town = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_area = table.Column<int>(nullable: false),
                    name_city = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id_town);
                    table.ForeignKey(
                        name: "r_58",
                        column: x => x.id_area,
                        principalTable: "area",
                        principalColumn: "id_area",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "military_unit",
                columns: table => new
                {
                    id_military_unit = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_area = table.Column<int>(nullable: false),
                    name_military_unit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_military_unit", x => x.id_military_unit);
                    table.ForeignKey(
                        name: "r_61",
                        column: x => x.id_area,
                        principalTable: "area",
                        principalColumn: "id_area",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "educational_institution",
                columns: table => new
                {
                    id_educational_institution = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_town = table.Column<int>(nullable: false),
                    name_educational_institution = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educational_institution", x => x.id_educational_institution);
                    table.ForeignKey(
                        name: "r_55",
                        column: x => x.id_town,
                        principalTable: "city",
                        principalColumn: "id_town",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "military_office",
                columns: table => new
                {
                    id_military_office = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_town = table.Column<int>(nullable: false),
                    military_district = table.Column<string>(nullable: true),
                    name_military_office = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_military_office", x => x.id_military_office);
                    table.ForeignKey(
                        name: "r_53",
                        column: x => x.id_town,
                        principalTable: "city",
                        principalColumn: "id_town",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "parent",
                columns: table => new
                {
                    id_parent = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_city = table.Column<int>(nullable: false),
                    id_fact_of_prosecution = table.Column<int>(nullable: false),
                    id_parent_type = table.Column<int>(nullable: false),
                    id_sex = table.Column<int>(nullable: false),
                    id_social_status = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    patronymic = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parent", x => x.id_parent);
                    table.ForeignKey(
                        name: "r_50",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id_town",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_66",
                        column: x => x.id_fact_of_prosecution,
                        principalTable: "fact_of_prosecution",
                        principalColumn: "id_fact_of_prosecution",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_4",
                        column: x => x.id_parent_type,
                        principalTable: "parent_type",
                        principalColumn: "id_parent_type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_48",
                        column: x => x.id_sex,
                        principalTable: "sex",
                        principalColumn: "id_sex",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_49",
                        column: x => x.id_social_status,
                        principalTable: "social_status",
                        principalColumn: "id_social_status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "enrollee",
                columns: table => new
                {
                    id_enrollee = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AddressLine = table.Column<string>(nullable: true),
                    admit_ssgt = table.Column<int>(nullable: true),
                    arrival_date = table.Column<DateTime>(type: "date", nullable: true),
                    card_ppo = table.Column<int>(nullable: true),
                    children = table.Column<int>(nullable: true),
                    CreatedTo = table.Column<DateTime>(nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    date_of_deduction = table.Column<DateTime>(type: "date", nullable: true),
                    grade_point_AVG = table.Column<float>(nullable: false),
                    IdArea = table.Column<int>(nullable: false),
                    id_category_ms = table.Column<int>(nullable: false),
                    id_current_spec = table.Column<int>(nullable: false),
                    id_education_type = table.Column<int>(nullable: false),
                    id_educational_institution = table.Column<int>(nullable: false),
                    id_fact_of_prosecution = table.Column<int>(nullable: false),
                    id_first_spec = table.Column<int>(nullable: false),
                    id_group = table.Column<int>(nullable: false),
                    id_marital_status = table.Column<int>(nullable: false),
                    id_military_office = table.Column<string>(nullable: true),
                    id_military_rank = table.Column<int>(nullable: false),
                    id_military_unit = table.Column<string>(nullable: true),
                    id_nationality = table.Column<int>(nullable: false),
                    id_preemptive_right = table.Column<int>(nullable: false),
                    id_reason_for_deduction = table.Column<int>(nullable: false),
                    IdRegion = table.Column<int>(nullable: false),
                    id_reserve_spec = table.Column<int>(nullable: false),
                    id_second_spec = table.Column<int>(nullable: false),
                    id_sex = table.Column<int>(nullable: false),
                    id_social_background = table.Column<int>(nullable: false),
                    id_third_spec = table.Column<int>(nullable: false),
                    id_town = table.Column<int>(nullable: false),
                    inteernational_passport = table.Column<bool>(nullable: true),
                    live_in_camp = table.Column<bool>(nullable: true),
                    MilitaryOfficeIdMilitaryOffice = table.Column<int>(nullable: true),
                    MilitaryUnitIdMilitaryUnit = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    notes_educational_institution = table.Column<string>(nullable: true),
                    num_of_personal_file = table.Column<string>(nullable: true),
                    other_notes = table.Column<string>(nullable: true),
                    passport_issue_date = table.Column<DateTime>(type: "date", nullable: true),
                    passport_issued_by = table.Column<string>(nullable: true),
                    passport_number = table.Column<int>(nullable: true),
                    passport_series = table.Column<int>(nullable: true),
                    passport_unit_code = table.Column<string>(nullable: true),
                    patronymic = table.Column<string>(nullable: false),
                    personal_number_ms = table.Column<string>(nullable: true),
                    place_of_birth = table.Column<string>(nullable: false),
                    stock_position_ms = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: false),
                    year_of_ending_education = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollee", x => x.id_enrollee);
                    table.ForeignKey(
                        name: "r_81",
                        column: x => x.id_category_ms,
                        principalTable: "military_service_category",
                        principalColumn: "id_category_ms",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_speciality_id_current_spec",
                        column: x => x.id_current_spec,
                        principalTable: "speciality",
                        principalColumn: "id_speciality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_68",
                        column: x => x.id_education_type,
                        principalTable: "education_type",
                        principalColumn: "id_education_type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_67",
                        column: x => x.id_educational_institution,
                        principalTable: "educational_institution",
                        principalColumn: "id_educational_institution",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_65",
                        column: x => x.id_fact_of_prosecution,
                        principalTable: "fact_of_prosecution",
                        principalColumn: "id_fact_of_prosecution",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_speciality_id_first_spec",
                        column: x => x.id_first_spec,
                        principalTable: "speciality",
                        principalColumn: "id_speciality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "enrolleesGroup",
                        column: x => x.id_group,
                        principalTable: "Groups",
                        principalColumn: "id_group",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_9",
                        column: x => x.id_marital_status,
                        principalTable: "marital_status",
                        principalColumn: "id_marital_status",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_80",
                        column: x => x.id_military_rank,
                        principalTable: "military_rank",
                        principalColumn: "id_military_rank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_10",
                        column: x => x.id_nationality,
                        principalTable: "nationality",
                        principalColumn: "id_nationality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_16",
                        column: x => x.id_preemptive_right,
                        principalTable: "preemptive_right",
                        principalColumn: "id_preemptive_right",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_31",
                        column: x => x.id_reason_for_deduction,
                        principalTable: "reason_for_deduction",
                        principalColumn: "id_reason_for_deduction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_speciality_id_reserve_spec",
                        column: x => x.id_reserve_spec,
                        principalTable: "speciality",
                        principalColumn: "id_speciality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_speciality_id_second_spec",
                        column: x => x.id_second_spec,
                        principalTable: "speciality",
                        principalColumn: "id_speciality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_8",
                        column: x => x.id_sex,
                        principalTable: "sex",
                        principalColumn: "id_sex",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_6",
                        column: x => x.id_social_background,
                        principalTable: "social_background",
                        principalColumn: "id_social_background",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_speciality_id_third_spec",
                        column: x => x.id_third_spec,
                        principalTable: "speciality",
                        principalColumn: "id_speciality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_52",
                        column: x => x.id_town,
                        principalTable: "city",
                        principalColumn: "id_town",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_military_office_MilitaryOfficeIdMilitaryOffice",
                        column: x => x.MilitaryOfficeIdMilitaryOffice,
                        principalTable: "military_office",
                        principalColumn: "id_military_office",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollee_military_unit_MilitaryUnitIdMilitaryUnit",
                        column: x => x.MilitaryUnitIdMilitaryUnit,
                        principalTable: "military_unit",
                        principalColumn: "id_military_unit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "application_to_speciality",
                columns: table => new
                {
                    IdApplicationToSpeciality = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date_of_passing_exam = table.Column<DateTime>(type: "date", nullable: true),
                    exam_mark = table.Column<int>(nullable: true),
                    groupe = table.Column<string>(nullable: true),
                    id_enrollee = table.Column<int>(nullable: false),
                    id_entrance_exam = table.Column<int>(nullable: false),
                    id_speciality = table.Column<int>(nullable: false),
                    id_test_type = table.Column<int>(nullable: false),
                    priority_number = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_to_speciality", x => x.IdApplicationToSpeciality);
                    table.ForeignKey(
                        name: "r_41",
                        column: x => x.id_enrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_77",
                        column: x => x.id_entrance_exam,
                        principalTable: "exam_for_speciality",
                        principalColumn: "IdExamForSpeciality",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_78",
                        column: x => x.id_test_type,
                        principalTable: "test_type",
                        principalColumn: "id_test_type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "change_history",
                columns: table => new
                {
                    id_change_history = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    changeBy = table.Column<string>(nullable: true),
                    date_time = table.Column<DateTime>(nullable: false),
                    EnrolleeIdEnrollee = table.Column<int>(nullable: true),
                    field_name = table.Column<string>(nullable: true),
                    new_value = table.Column<string>(nullable: true),
                    old_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_change_history", x => x.id_change_history);
                    table.ForeignKey(
                        name: "FK_change_history_enrollee_EnrolleeIdEnrollee",
                        column: x => x.EnrolleeIdEnrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFile",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    File = table.Column<byte[]>(nullable: true),
                    id_enrollee = table.Column<int>(nullable: false),
                    NameFile = table.Column<string>(nullable: true),
                    TypeFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFile", x => x.id);
                    table.ForeignKey(
                        name: "EnrolleesDocuments",
                        column: x => x.id_enrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "enrollee_achievement",
                columns: table => new
                {
                    IdEnrolleeAchievement = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_achievement = table.Column<int>(nullable: false),
                    id_enrollee = table.Column<int>(nullable: false),
                    priority = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollee_achievement", x => x.IdEnrolleeAchievement);
                    table.ForeignKey(
                        name: "r_64",
                        column: x => x.id_achievement,
                        principalTable: "achievement",
                        principalColumn: "id_achievement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_63",
                        column: x => x.id_enrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "enrollee_documents",
                columns: table => new
                {
                    IdEnrolleeDocument = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_document = table.Column<int>(nullable: false),
                    id_enrollee = table.Column<int>(nullable: false),
                    load_date = table.Column<DateTime>(type: "date", nullable: true),
                    presence_in_personal_file = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollee_documents", x => x.IdEnrolleeDocument);
                    table.ForeignKey(
                        name: "r_72",
                        column: x => x.id_document,
                        principalTable: "document",
                        principalColumn: "id_document",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_71",
                        column: x => x.id_enrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "family",
                columns: table => new
                {
                    IdFamily = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_enrollee = table.Column<int>(nullable: false),
                    id_family_type = table.Column<int>(nullable: false),
                    id_parent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_family", x => x.IdFamily);
                    table.ForeignKey(
                        name: "r_45",
                        column: x => x.id_enrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_1",
                        column: x => x.id_family_type,
                        principalTable: "family_type",
                        principalColumn: "id_family_type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_3",
                        column: x => x.id_parent,
                        principalTable: "parent",
                        principalColumn: "id_parent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subject_mark",
                columns: table => new
                {
                    id_subject_mark = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_enrollee = table.Column<int>(nullable: false),
                    id_subject = table.Column<int>(nullable: false),
                    mark = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_mark", x => x.id_subject_mark);
                    table.ForeignKey(
                        name: "r_70",
                        column: x => x.id_enrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "r_35",
                        column: x => x.id_subject,
                        principalTable: "subject",
                        principalColumn: "id_subject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_application_to_speciality_id_enrollee",
                table: "application_to_speciality",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_application_to_speciality_id_entrance_exam",
                table: "application_to_speciality",
                column: "id_entrance_exam");

            migrationBuilder.CreateIndex(
                name: "IX_application_to_speciality_id_test_type",
                table: "application_to_speciality",
                column: "id_test_type");

            migrationBuilder.CreateIndex(
                name: "IX_area_id_region",
                table: "area",
                column: "id_region");

            migrationBuilder.CreateIndex(
                name: "IX_area_name_area_id_region",
                table: "area",
                columns: new[] { "name_area", "id_region" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_change_history_EnrolleeIdEnrollee",
                table: "change_history",
                column: "EnrolleeIdEnrollee");

            migrationBuilder.CreateIndex(
                name: "IX_city_id_area",
                table: "city",
                column: "id_area");

            migrationBuilder.CreateIndex(
                name: "IX_city_name_city_id_area",
                table: "city",
                columns: new[] { "name_city", "id_area" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFile_id_enrollee",
                table: "DocumentFile",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_educational_institution_id_town",
                table: "educational_institution",
                column: "id_town");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_category_ms",
                table: "enrollee",
                column: "id_category_ms");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_current_spec",
                table: "enrollee",
                column: "id_current_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_education_type",
                table: "enrollee",
                column: "id_education_type");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_educational_institution",
                table: "enrollee",
                column: "id_educational_institution");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_fact_of_prosecution",
                table: "enrollee",
                column: "id_fact_of_prosecution");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_first_spec",
                table: "enrollee",
                column: "id_first_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_group",
                table: "enrollee",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_marital_status",
                table: "enrollee",
                column: "id_marital_status");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_military_rank",
                table: "enrollee",
                column: "id_military_rank");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_nationality",
                table: "enrollee",
                column: "id_nationality");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_preemptive_right",
                table: "enrollee",
                column: "id_preemptive_right");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_reason_for_deduction",
                table: "enrollee",
                column: "id_reason_for_deduction");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_reserve_spec",
                table: "enrollee",
                column: "id_reserve_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_second_spec",
                table: "enrollee",
                column: "id_second_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_sex",
                table: "enrollee",
                column: "id_sex");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_social_background",
                table: "enrollee",
                column: "id_social_background");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_third_spec",
                table: "enrollee",
                column: "id_third_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_town",
                table: "enrollee",
                column: "id_town");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_MilitaryOfficeIdMilitaryOffice",
                table: "enrollee",
                column: "MilitaryOfficeIdMilitaryOffice");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_MilitaryUnitIdMilitaryUnit",
                table: "enrollee",
                column: "MilitaryUnitIdMilitaryUnit");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_achievement_id_achievement",
                table: "enrollee_achievement",
                column: "id_achievement");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_achievement_id_enrollee",
                table: "enrollee_achievement",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_documents_id_document",
                table: "enrollee_documents",
                column: "id_document");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_documents_id_enrollee",
                table: "enrollee_documents",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_exam_for_speciality_id_entrance_exam",
                table: "exam_for_speciality",
                column: "id_entrance_exam");

            migrationBuilder.CreateIndex(
                name: "IX_exam_for_speciality_id_speciality",
                table: "exam_for_speciality",
                column: "id_speciality");

            migrationBuilder.CreateIndex(
                name: "IX_family_id_enrollee",
                table: "family",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_family_id_family_type",
                table: "family",
                column: "id_family_type");

            migrationBuilder.CreateIndex(
                name: "IX_family_id_parent",
                table: "family",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "IX_military_office_id_town",
                table: "military_office",
                column: "id_town");

            migrationBuilder.CreateIndex(
                name: "IX_military_unit_id_area",
                table: "military_unit",
                column: "id_area");

            migrationBuilder.CreateIndex(
                name: "IX_parent_id_city",
                table: "parent",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_parent_id_fact_of_prosecution",
                table: "parent",
                column: "id_fact_of_prosecution");

            migrationBuilder.CreateIndex(
                name: "IX_parent_id_parent_type",
                table: "parent",
                column: "id_parent_type");

            migrationBuilder.CreateIndex(
                name: "IX_parent_id_sex",
                table: "parent",
                column: "id_sex");

            migrationBuilder.CreateIndex(
                name: "IX_parent_id_social_status",
                table: "parent",
                column: "id_social_status");

            migrationBuilder.CreateIndex(
                name: "IX_region_id_military_district",
                table: "region",
                column: "id_military_district");

            migrationBuilder.CreateIndex(
                name: "IX_region_name_region_id_military_district",
                table: "region",
                columns: new[] { "name_region", "id_military_district" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_mark_id_enrollee",
                table: "subject_mark",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_subject_mark_id_subject",
                table: "subject_mark",
                column: "id_subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfig");

            migrationBuilder.DropTable(
                name: "application_to_speciality");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "change_history");

            migrationBuilder.DropTable(
                name: "DocumentFile");

            migrationBuilder.DropTable(
                name: "enrollee_achievement");

            migrationBuilder.DropTable(
                name: "enrollee_documents");

            migrationBuilder.DropTable(
                name: "family");

            migrationBuilder.DropTable(
                name: "Pochta");

            migrationBuilder.DropTable(
                name: "subject_mark");

            migrationBuilder.DropTable(
                name: "exam_for_speciality");

            migrationBuilder.DropTable(
                name: "test_type");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "achievement");

            migrationBuilder.DropTable(
                name: "document");

            migrationBuilder.DropTable(
                name: "family_type");

            migrationBuilder.DropTable(
                name: "parent");

            migrationBuilder.DropTable(
                name: "enrollee");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "entrance_exams");

            migrationBuilder.DropTable(
                name: "parent_type");

            migrationBuilder.DropTable(
                name: "social_status");

            migrationBuilder.DropTable(
                name: "military_service_category");

            migrationBuilder.DropTable(
                name: "speciality");

            migrationBuilder.DropTable(
                name: "education_type");

            migrationBuilder.DropTable(
                name: "educational_institution");

            migrationBuilder.DropTable(
                name: "fact_of_prosecution");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "marital_status");

            migrationBuilder.DropTable(
                name: "military_rank");

            migrationBuilder.DropTable(
                name: "nationality");

            migrationBuilder.DropTable(
                name: "preemptive_right");

            migrationBuilder.DropTable(
                name: "reason_for_deduction");

            migrationBuilder.DropTable(
                name: "sex");

            migrationBuilder.DropTable(
                name: "social_background");

            migrationBuilder.DropTable(
                name: "military_office");

            migrationBuilder.DropTable(
                name: "military_unit");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "military_district");
        }
    }
}
