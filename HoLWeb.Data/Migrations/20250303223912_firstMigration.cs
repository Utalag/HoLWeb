﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HoLWeb.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Atribut = table.Column<int>(type: "int", nullable: false),
                    RangeLow = table.Column<int>(type: "int", nullable: false),
                    RangeHigh = table.Column<int>(type: "int", nullable: false),
                    NumberOfDice = table.Column<int>(type: "int", nullable: false),
                    @class = table.Column<string>(name: "class", type: "nvarchar(21)", maxLength: 21, nullable: false),
                    PrimarAtribut = table.Column<int>(type: "int", nullable: true),
                    AttributePoints = table.Column<int>(type: "int", nullable: true),
                    DiceRoll = table.Column<int>(type: "int", nullable: true),
                    AtributValue = table.Column<int>(type: "int", nullable: true),
                    Bonus = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correction = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    HpRangeMin = table.Column<int>(type: "int", nullable: false),
                    HpRangeMax = table.Column<int>(type: "int", nullable: false),
                    WizardMana = table.Column<int>(type: "int", nullable: false),
                    HasWizardMana = table.Column<bool>(type: "bit", nullable: false),
                    RengerMana = table.Column<int>(type: "int", nullable: false),
                    HasRengerMana = table.Column<bool>(type: "bit", nullable: false),
                    AlchemiMana = table.Column<int>(type: "int", nullable: false),
                    HasAlchemiMana = table.Column<bool>(type: "bit", nullable: false),
                    SpecialdMana = table.Column<int>(type: "int", nullable: false),
                    HasSpecialdMana = table.Column<bool>(type: "bit", nullable: false),
                    ProfiPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Worlds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorldDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfMagicInTheWorld = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaceSize = table.Column<int>(type: "int", nullable: false),
                    Mobility = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialAbilitiesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightMin = table.Column<int>(type: "int", nullable: false),
                    WeightMax = table.Column<int>(type: "int", nullable: false),
                    BodyHeightMin = table.Column<int>(type: "int", nullable: false),
                    BodyHeightMax = table.Column<int>(type: "int", nullable: false),
                    StrengthStatId = table.Column<int>(type: "int", nullable: true),
                    AgilityStatId = table.Column<int>(type: "int", nullable: true),
                    ConstitutionStatId = table.Column<int>(type: "int", nullable: true),
                    IntelligenceStatId = table.Column<int>(type: "int", nullable: true),
                    CharismaStatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agility_Race",
                        column: x => x.AgilityStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Charisma_Race",
                        column: x => x.CharismaStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Constitution_Race",
                        column: x => x.ConstitutionStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Intelligence_Race",
                        column: x => x.IntelligenceStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Strength_Race",
                        column: x => x.StrengthStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Naratives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarrativeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NarrativeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Era = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naratives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naratives_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceWorld",
                columns: table => new
                {
                    RacesId = table.Column<int>(type: "int", nullable: false),
                    WorldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceWorld", x => new { x.RacesId, x.WorldsId });
                    table.ForeignKey(
                        name: "FK_RaceWorld_Races_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceWorld_Worlds_WorldsId",
                        column: x => x.WorldsId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profipoints = table.Column<int>(type: "int", nullable: false),
                    Visage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NarrativeId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    StrengthStatId = table.Column<int>(type: "int", nullable: false),
                    AgilityStatId = table.Column<int>(type: "int", nullable: false),
                    ConstitutionStatId = table.Column<int>(type: "int", nullable: false),
                    IntelligenceStatId = table.Column<int>(type: "int", nullable: false),
                    CharismaStatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agility_Character",
                        column: x => x.AgilityStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Naratives_NarrativeId",
                        column: x => x.NarrativeId,
                        principalTable: "Naratives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Charisma",
                        column: x => x.CharismaStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Constitution_Character",
                        column: x => x.ConstitutionStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Intelligence_Character",
                        column: x => x.IntelligenceStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Strength_Character",
                        column: x => x.StrengthStatId,
                        principalTable: "AttributeStats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NarrativeProfessionModul",
                columns: table => new
                {
                    NarrativesId = table.Column<int>(type: "int", nullable: false),
                    ProfessionModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarrativeProfessionModul", x => new { x.NarrativesId, x.ProfessionModulesId });
                    table.ForeignKey(
                        name: "FK_NarrativeProfessionModul_Naratives_NarrativesId",
                        column: x => x.NarrativesId,
                        principalTable: "Naratives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarrativeProfessionModul_Professions_ProfessionModulesId",
                        column: x => x.ProfessionModulesId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnowledgeGroup = table.Column<int>(type: "int", nullable: false),
                    SkillClass = table.Column<int>(type: "int", nullable: false),
                    ProfessionClass = table.Column<int>(type: "int", nullable: false),
                    DependencySkillId = table.Column<int>(type: "int", nullable: false),
                    DependencySkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseProfessionPoint = table.Column<int>(type: "int", nullable: false),
                    BaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatetByUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionSkill_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThumbnailImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    ScaleImage = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patchname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    @class = table.Column<string>(name: "class", type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    NarrativeId = table.Column<int>(type: "int", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    WorldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThumbnailImages_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThumbnailImages_Naratives_NarrativeId",
                        column: x => x.NarrativeId,
                        principalTable: "Naratives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThumbnailImages_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThumbnailImages_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalTable: "Worlds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BindTable_Advanced_ProfessionSkill",
                columns: table => new
                {
                    AdvancedSkillsId = table.Column<int>(type: "int", nullable: false),
                    ProfessionModul1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BindTable_Advanced_ProfessionSkill", x => new { x.AdvancedSkillsId, x.ProfessionModul1Id });
                    table.ForeignKey(
                        name: "FK_BindTable_Advanced_ProfessionSkill_ProfessionSkill_AdvancedSkillsId",
                        column: x => x.AdvancedSkillsId,
                        principalTable: "ProfessionSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BindTable_Advanced_ProfessionSkill_Professions_ProfessionModul1Id",
                        column: x => x.ProfessionModul1Id,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BindTable_Beginner_ProfessionSkill",
                columns: table => new
                {
                    BeginnerSkillsId = table.Column<int>(type: "int", nullable: false),
                    ProfessionModulId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BindTable_Beginner_ProfessionSkill", x => new { x.BeginnerSkillsId, x.ProfessionModulId });
                    table.ForeignKey(
                        name: "FK_BindTable_Beginner_ProfessionSkill_ProfessionSkill_BeginnerSkillsId",
                        column: x => x.BeginnerSkillsId,
                        principalTable: "ProfessionSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BindTable_Beginner_ProfessionSkill_Professions_ProfessionModulId",
                        column: x => x.ProfessionModulId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BindTable_Expert_ProfessionSkill",
                columns: table => new
                {
                    ExpertSkillsId = table.Column<int>(type: "int", nullable: false),
                    ProfessionModul2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BindTable_Expert_ProfessionSkill", x => new { x.ExpertSkillsId, x.ProfessionModul2Id });
                    table.ForeignKey(
                        name: "FK_BindTable_Expert_ProfessionSkill_ProfessionSkill_ExpertSkillsId",
                        column: x => x.ExpertSkillsId,
                        principalTable: "ProfessionSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BindTable_Expert_ProfessionSkill_Professions_ProfessionModul2Id",
                        column: x => x.ProfessionModul2Id,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    InternalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillSumPrice = table.Column<int>(type: "int", nullable: false),
                    ProfessionClass = table.Column<int>(type: "int", nullable: false),
                    LevelGroup = table.Column<int>(type: "int", nullable: false),
                    ProfessionSkillId = table.Column<int>(type: "int", nullable: false),
                    ProfessionSkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_type = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    MaxHealingPoints = table.Column<int>(type: "int", nullable: true),
                    SpeedOfHealing = table.Column<int>(type: "int", nullable: true),
                    Initiative = table.Column<int>(type: "int", nullable: true),
                    InitiativeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryWeapon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificSkill_ProfessionSkill_ProfessionSkillId",
                        column: x => x.ProfessionSkillId,
                        principalTable: "ProfessionSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AttributeStats",
                columns: new[] { "Id", "Atribut", "Correction", "Name", "NumberOfDice", "RangeHigh", "RangeLow", "class" },
                values: new object[,]
                {
                    { 1, 0, -5, "Hobbit", 1, 8, 3, "race" },
                    { 2, 1, 2, "Hobbit", 1, 16, 11, "race" },
                    { 3, 2, 0, "Hobbit", 1, 13, 8, "race" },
                    { 4, 3, -2, "Hobbit", 1, 15, 10, "race" },
                    { 5, 4, 3, "Hobbit", 2, 18, 8, "race" },
                    { 6, 0, -3, "Gnom", 1, 10, 5, "race" },
                    { 7, 1, 1, "Gnom", 1, 15, 10, "race" },
                    { 8, 2, 1, "Gnom", 1, 15, 10, "race" },
                    { 9, 3, -2, "Gnom", 1, 14, 9, "race" },
                    { 10, 4, 0, "Gnom", 1, 12, 7, "race" },
                    { 11, 0, 1, "Dwarf", 1, 12, 7, "race" },
                    { 12, 1, -2, "Dwarf", 1, 12, 7, "race" },
                    { 13, 2, 3, "Dwarf", 1, 17, 12, "race" },
                    { 14, 3, -3, "Dwarf", 1, 13, 8, "race" },
                    { 15, 4, -2, "Dwarf", 1, 12, 7, "race" },
                    { 16, 0, 0, "Human", 1, 11, 6, "race" },
                    { 17, 1, 1, "Human", 1, 15, 10, "race" },
                    { 18, 2, -4, "Human", 1, 11, 6, "race" },
                    { 19, 3, 2, "Human", 1, 17, 12, "race" },
                    { 20, 4, 2, "Human", 2, 18, 8, "race" },
                    { 21, 0, 0, "Elf", 2, 16, 6, "race" },
                    { 22, 1, 0, "Elf", 1, 14, 9, "race" },
                    { 23, 2, 0, "Elf", 1, 14, 9, "race" },
                    { 24, 3, 0, "Elf", 1, 15, 10, "race" },
                    { 25, 4, 0, "Elf", 3, 17, 2, "race" },
                    { 26, 0, 1, "Barbar", 1, 15, 10, "race" },
                    { 27, 1, -1, "Barbar", 1, 13, 8, "race" },
                    { 28, 2, 1, "Barbar", 1, 16, 11, "race" },
                    { 29, 3, 0, "Barbar", 1, 11, 6, "race" },
                    { 30, 4, -2, "Barbar", 3, 16, 1, "race" },
                    { 31, 0, 3, "Kroll", 1, 16, 11, "race" },
                    { 32, 1, -4, "Kroll", 1, 10, 5, "race" },
                    { 33, 2, 3, "Kroll", 1, 18, 13, "race" },
                    { 34, 3, -6, "Kroll", 1, 7, 2, "race" },
                    { 35, 4, -5, "Kroll", 2, 11, 1, "race" }
                });

            migrationBuilder.InsertData(
                table: "AttributeStats",
                columns: new[] { "Id", "Atribut", "AtributValue", "AttributePoints", "Author", "Bonus", "DiceRoll", "Name", "NumberOfDice", "PrimarAtribut", "RangeHigh", "RangeLow", "class" },
                values: new object[,]
                {
                    { 36, 0, 6, 30, "", -2, 4, "Pokusňák", 1, 0, 8, 3, "character" },
                    { 37, 1, 13, 55, "", 1, 4, "Pokusňák", 1, 0, 16, 11, "character" },
                    { 38, 2, 11, 40, "", 0, 4, "Pokusňák", 1, 0, 13, 8, "character" },
                    { 39, 3, 13, 50, "", 1, 4, "Pokusňák", 1, 0, 15, 10, "character" },
                    { 40, 4, 14, 40, "", 1, 8, "Pokusňák", 2, 0, 18, 8, "character" }
                });

            migrationBuilder.InsertData(
                table: "ProfessionSkill",
                columns: new[] { "Id", "BaseDescription", "BaseProfessionPoint", "CharacterId", "CreatetByUserName", "DependencySkillId", "DependencySkillName", "KnowledgeGroup", "ProfessionClass", "SkillClass", "SkillName" },
                values: new object[,]
                {
                    { 1, "", 1, null, "Admin", 0, "", 0, 0, 8, "Sum range 23-24" },
                    { 2, "", 2, null, "Admin", 0, "", 0, 0, 8, "Sum range 25" },
                    { 3, "", 3, null, "Admin", 0, "", 0, 0, 8, "Sum range 26" },
                    { 4, "", 4, null, "Admin", 0, "", 0, 0, 8, "Sum range 27-28" },
                    { 5, "", 1, null, "Admin", 0, "", 0, 0, 7, "Životy 1k6" },
                    { 6, "", 2, null, "Admin", 0, "", 0, 0, 7, "Životy 1k6+1" },
                    { 7, "", 3, null, "Admin", 0, "", 0, 0, 7, "Životy 1k6+2" },
                    { 8, "", 4, null, "Admin", 0, "", 0, 0, 7, "Životy 1k10" },
                    { 9, "", 2, null, "Admin", 0, "", 0, 1, 0, "Léčba vlastních zranění II" },
                    { 10, "", 1, null, "Admin", 0, "", 0, 1, 0, "Odhad soupeře" },
                    { 11, "", 1, null, "Admin", 0, "", 0, 1, 0, "Odhad zbraně" },
                    { 12, "", 1, null, "Admin", 0, "", 0, 1, 0, "Poznání artefaktu" },
                    { 13, "", 2, null, "Admin", 0, "", 0, 1, 0, "Přesnost" },
                    { 14, "", 1, null, "Admin", 0, "", 0, 1, 0, "Sehranost" },
                    { 15, "", 4, null, "Admin", 0, "", 0, 1, 0, "Vícenásobné útoky" },
                    { 16, "", 1, null, "Admin", 0, "", 0, 1, 0, "Zastrašení" },
                    { 17, "", 1, null, "Admin", 0, "", 0, 8, 2, "Boj se zvýřaty" },
                    { 18, "", 2, null, "Admin", 0, "", 0, 8, 2, "Stopování" },
                    { 19, "", 2, null, "Admin", 0, "", 0, 8, 1, "Hraničářská mana" },
                    { 20, "", 3, null, "Admin", 12, "", 0, 8, 1, "Kouzla" },
                    { 21, "", 4, null, "Admin", 0, "", 0, 8, 1, "Mymosmysloví schopnosti" },
                    { 22, "", 2, null, "Admin", 12, "", 0, 8, 1, "Zmámení" },
                    { 23, "", 2, null, "Admin", 0, "", 0, 8, 2, "Pes" },
                    { 24, "", 1, null, "Admin", 0, "", 0, 11, 3, "Odolnost proti jedům" },
                    { 25, "", 1, null, "Admin", 0, "", 0, 11, 3, "Lučba a magenergie" },
                    { 26, "", 3, null, "Admin", 17, "", 0, 11, 3, "Lektvary" },
                    { 27, "", 1, null, "Admin", 17, "", 0, 11, 3, "Svitky" },
                    { 28, "", 1, null, "Admin", 17, "", 0, 11, 3, "Ostatní" },
                    { 29, "", 1, null, "Admin", 17, "", 0, 11, 3, "Zbraně" },
                    { 30, "", 1, null, "Admin", 17, "", 0, 11, 3, "Prsteny" },
                    { 31, "", 3, null, "Admin", 17, "", 0, 11, 3, "Jedy" },
                    { 32, "", 3, null, "Admin", 17, "", 0, 11, 3, "Výbušniny" },
                    { 33, "", 2, null, "Admin", 26, "", 0, 5, 1, "Kouzelnický přítel" },
                    { 34, "", 4, null, "Admin", 0, "", 0, 5, 1, "Kouzelnická magenergie" },
                    { 35, "", 2, null, "Admin", 26, "", 0, 5, 1, "Časoprostorová magie" },
                    { 36, "", 1, null, "Admin", 26, "", 0, 5, 1, "Energetická útočná magie" },
                    { 37, "", 1, null, "Admin", 26, "", 0, 5, 1, "Energetická obranná magie" },
                    { 38, "", 1, null, "Admin", 26, "", 0, 5, 1, "Materiální magie" },
                    { 39, "", 1, null, "Admin", 26, "", 0, 5, 1, "Vitální magie" },
                    { 40, "", 1, null, "Admin", 26, "", 0, 5, 1, "Psychická magie" },
                    { 41, "", 1, null, "Admin", 26, "", 0, 5, 1, "Poznávací magie" },
                    { 42, "", 1, null, "Admin", 26, "", 0, 5, 1, "Iluzivní magie" },
                    { 43, "", 2, null, "Admin", 0, "", 0, 14, 6, "Převleky" },
                    { 44, "", 1, null, "Admin", 0, "", 0, 14, 6, "Zisk důvěry" },
                    { 45, "", 1, null, "Admin", 0, "", 0, 14, 6, "Objevení mechanismu" },
                    { 46, "", 1, null, "Admin", 0, "", 0, 14, 6, "Objevení objektu" },
                    { 47, "", 2, null, "Admin", 0, "", 0, 14, 6, "Šplh po zdech" },
                    { 48, "", 1, null, "Admin", 0, "", 0, 14, 6, "Skok z výšky" },
                    { 49, "", 1, null, "Admin", 0, "", 0, 14, 6, "Tichý pohyb" },
                    { 50, "", 1, null, "Admin", 0, "", 0, 14, 6, "Schování se ve stínu" },
                    { 51, "", 1, null, "Admin", 0, "", 0, 14, 6, "Vybírání kapes" },
                    { 52, "", 1, null, "Admin", 0, "", 0, 14, 6, "Otevření objetu" },
                    { 53, "", 1, null, "Admin", 0, "", 0, 14, 6, "Zneškodnění mechanismu" },
                    { 54, "", 3, null, "Admin", 0, "", 0, 14, 0, "Probodnutí ze zálohy" },
                    { 55, "", 1, null, "Admin", 0, "", 0, 18, 0, "Léčba vlastních zranění I" },
                    { 56, "", 4, null, "Admin", 0, "", 0, 18, 0, "Vícenásobné útoky ve střelbě" },
                    { 57, "", 1, null, "Admin", 0, "", 0, 18, 0, "Zrak" },
                    { 58, "", 1, null, "Admin", 0, "", 0, 18, 0, "Odhad střelných zbraní" },
                    { 59, "", 1, null, "Admin", 0, "", 0, 18, 0, "Odhad soupeře" },
                    { 60, "", 5, null, "Admin", 0, "", 0, 18, 5, "Výroba šípů" },
                    { 61, "", 1, null, "Admin", 0, "", 0, 18, 0, "Krok a střelba" }
                });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "AlchemiMana", "Description", "HasAlchemiMana", "HasRengerMana", "HasSpecialdMana", "HasWizardMana", "HpRangeMax", "HpRangeMin", "Level", "Name", "ProfiPoints", "RengerMana", "SpecialdMana", "WizardMana" },
                values: new object[,]
                {
                    { 1, 0, "Zkušený bojovník, který se specializuje na zbraně a bojovou taktiku. Je fyzicky zdatný a často nosí těžké brnění. Válečníci vedou své spojence do bitvy a používají svou sílu a odvahu k ochraně ostatních. Jsou loajální a čestní, připravení postavit se jakékoli hrozbě.", false, false, false, false, 10, 1, 1, "Válečník", 0, 0, 0, 0 },
                    { 2, 0, "Mistr magie, ovládající sílu živlů a starodávných kouzel. Často se věnuje studiu mystických textů a hledá tajemství ukrytá ve stínech. Kouzelníci jsou schopni léčit, klamat nepřátele nebo vytvářet ničivá kouzla. Jsou intelektuálně založení a často se spoléhají na svou moudrost a znalosti.", false, false, false, true, 6, 1, 1, "Kouzelník", 0, 0, 0, 7 },
                    { 3, 9, "Vědec a badatel, který míchá elixíry a hledá tajemství transmutace. Alchymisté jsou známí svou schopností vytvářet léčivé lektvary, výbušniny a různé magické substance. Jejich práce často hraničí s tajemnem a někteří se snaží najít kámen mudrců. Je to povolání plné experimentů a objevů.", true, false, false, false, 8, 1, 1, "Alchymista", 0, 0, 0, 0 },
                    { 4, 0, "Mistr lukostřelby a lovec, který se specializuje na střelbu z dálky. Lučištníci jsou rychlí a obratní, schopní zasáhnout nepřítele z velké vzdálenosti. Používají luky, kuše a střelné zbraně k ochraně svých spojenců a lovu zvěře. Jsou často samotáři a preferují život v divočině.", false, false, false, false, 8, 1, 1, "Lučištník", 0, 0, 0, 0 },
                    { 5, 0, "Mistr lstí a skrytých operací, který se specializuje na krádeže a infiltraci. Je rychlý, tichý a vysoce obratný, což mu umožňuje snadno unikat nepřátelům. Zloději využívají své dovednosti k získávání informací a cenností. Jsou inteligentní a vynalézaví, často pracující ve stínu.", false, false, false, false, 6, 1, 1, "Zloděj", 0, 0, 0, 0 },
                    { 6, 0, "Mistr přežití v divočině, který často slouží jako stopař a strážce. Má hluboké znalosti o přírodě a umí se pohybovat nepozorovaně. Hraničáři bývají vynikající lučištníci a lovci, kteří využívají svých dovedností k ochraně říše před nebezpečím. Spojují fyzickou zdatnost s bystrým instinktem.", false, true, false, false, 7, 1, 1, "Hraničář", 0, 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Worlds",
                columns: new[] { "Id", "AmountOfMagicInTheWorld", "WorldDescription", "WorldName" },
                values: new object[,]
                {
                    { 1, 100, "Svět plný magie a kouzel, kde se můžete setkat s draky, elfy, trpaslíky a dalšími bytostmi.", "Fantasy svět" },
                    { 2, 25, "Svět, který prošel apokalypsou a kde se lidstvo snaží přežít v nepřátelském prostředí.", "Postapo" },
                    { 3, 0, "Svět, který známe, kde neexistuje magie a kouzla.", "Reálný svět" }
                });

            migrationBuilder.InsertData(
                table: "Naratives",
                columns: new[] { "Id", "Era", "NarrativeDescription", "NarrativeName", "WorldId", "Year" },
                values: new object[,]
                {
                    { 1, "Císaře C-Chou", "Příběh ve vzdálené číně", "Čína", 1, 679 },
                    { 2, "III", "Boje v Persii", "Řecko", 1, 679 },
                    { 3, "XXI", "podle Pc hry", "Warhammer", 2, 3754 }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "AgilityStatId", "BodyHeightMax", "BodyHeightMin", "CharismaStatId", "ConstitutionStatId", "IntelligenceStatId", "Mobility", "RaceDescription", "RaceName", "RaceSize", "SpecialAbilities", "SpecialAbilitiesDescription", "StrengthStatId", "WeightMax", "WeightMin" },
                values: new object[,]
                {
                    { 1, 2, 120, 70, 5, 3, 4, 10, "Hobiti jsou malým, veselým nárůdkem. Jsou ještě menší než trpaslíci, chlupatí a jaksi \"dobrácky kulaťoučcí\". Žijí zpravidla v úrodných údolích, kde si ve stráních budují komfortní nory a doupata. Rozhodně nejsou nijak zvlášť silní, ale zato jsou velmi obratní a povětšinou inteligentní. Dobrodružství příliš nevyhledávají, protože mají rádi pohodlí, dobré jídlo a silné piti. Jestliže se však jednou přece jen vydají na cesty, patří k těm nejlepším zlodějům, jaké si jen dovedeš představit. Hobiti mají také zvláštní psychickou schopnost, díky které dokážou \"vycítit\" na dálku většinu živých tvorů. Této zvláštní vlastnosti říkají mezi sebou \"čich\", a přestože jejich pohodlnickým životem již dosti zakrněla, dokážou díky ní lokalizovat živou bytost, dokonce i když je od nich oddělena například železnou stěnou. Přestože hobiti nejsou zbabělí, jen neradi přistupují na boj tváří v tvář a raději používají své kuše než těžké meče nebo halapartny.", "Hobbit", 0, "Čich", "Tato schopnost mu umožňuje vycítit přítomnost většiny živých tvorů což zdaleka neznamená všechny tvory, například na kostlivce je hobitův čich krátký), není ale schopen vycítit různé plísně, houby a jiné rostliny ani běžné tvory velikosti A0 (respektive byl by schopen je cítit, ale nevnímá je, asi jako člověk obvykle nevnímá mravence v trávě, ačkoliv je schopen je vidět). Největší vzdálenost, na jakou to je schopen dokázat, je 12 sáhů. Tato vzdálenost se zkracuje o 1 sáh za každých 30 coulů dřeva, 10 coulů kamene nebo 1 coul kovu. Hobit není schopen určit, o jakého tvora se jedná, ani jak je přesně daleko, ale pozná, do jaké třídy velikosti patří. Hobit má neurčitý pocit cizí přítomnosti. Hobit nemůže svou zvláštní schopnost používat, pokud spí. V bdělém stavu se na ni nemusí soustředit, ale nebude-li svému okolí věnovat dostatečnou pozornost, může mu něco uniknout. Hobita při používání čichu neruší přítomnost ostatních členů družiny.", 1, 60, 40 },
                    { 2, 7, 130, 90, 10, 8, 9, 9, "Gnómové jsou zvláštní rasou, o které se ví téměř jistě, že vznikla kdysi v dávných dobách splynutím části plemene trpaslíků s hobity. Podobně jako hobiti také gnómové jsou velmi obratní a poměrně chytří. Po trpaslících zase zdědili jejich nezdolnost a z části také lásku ke zlatu a drahým kamenům. Žijí v horách i v nížinách, ale nemilují podzemí, a proto si staví drobné kamenné domy, většinou daleko od velkých měst a obchodních cest. Přestože jen málokterý z nich se stane dobrým bojovníkem, dokážou v boji velmi dobře zacházet jak se sekerou, tak i s kuší. Mnoho z nich také nachází potěšení v různém bylinkářství a alchymii, ale stejně tak dobře se mohou uplatnit třeba jako zloději.", "Gnom", 0, "", "", 6, 75, 50 },
                    { 3, 12, 140, 110, 15, 13, 14, 8, "Trpaslíci jsou jednou z nejznámějších člověku podobných ras. Jsou menší, podsadití, zocelení dlouhými věky strávenými v nehostinných pustinách. Jejich větrem ošlehané tváře snad vždy zdobí hnědé až černé vousy, které jim však, stejně jako vlasy, poměrně záhy šedivějí. Sídlí v horách, zpravidla daleko od civilizace. Díky infravidění vidí v omezené míře i ve tmě, a proto mohou pod zemí budovat rozsáhlé skalní komplexy šachet, jeskyní a sálů, kde těží drahé kameny, stříbro a především svoje milované zlato. Trpaslíci většinou postrádají jakýkoliv smysl pro humor, jsou vždy vážní a někdy až příliš sebejistí. Dané slovo dodrží, zejména kyne-li jim z toho nějaká výhoda. Jejich nejoblíbenější zbraní je válečná sekera. V boji jsou nesmírně stateční a jen neradi ustupují z prohrané bitvy. Brání-li trpaslík svoji hroudu zlata, neustoupí ani před rozvztekleným, vyhladovělým ohnivým drakem.", "Trpaslík", 0, "Infravidění", "Infravidění má dosah 20 sáhů a neproniká žádným materiálem, kterým by neproniklo obyčejné světlo. Ve slunečním světle (nebo ve světle stejné intenzity vyvolaném kouzlem) je infravidění nepoužitelné. Infravidění rovněž není použitelné za mlhy (a to ani ve tmě), podobně jako normální zrak. Pod vodou je infravidění použitelné, ale nikoli skrz vodní hladinu, která infrazáření podobně jako světlo a zvuk láme a všelijak zkresluje. Infravidění je schopnost vidět teplo. I v naprosté tmě trpaslík zřetelně uvidí každého živého tvora s teplou krví - skřeta i zatoulaného psa- jako jasně červenou skvrnu. Hady, červy a jiné studenokrevné živočichy trpaslík neuvidí, pokud se nebude dívat velmi pozorně. Infraviděním rovněž nelze zpozorovat některé nestvůry magické podstaty, jež nevydávají teplo (například kostlivce). lnfraviděním zpravidla nelze určovat ani tvar místností, ani jejich obsah. Výjimkou mohou být věci, které jsou studenější nebo teplejší než okolí. Například jezírko studené vody trpaslík uvidí jako tmavě modrou skvrnu, nedávno vyhaslé ohniště jako tmavě červenou. Trpaslík se nemusí na infravidění soustřeďovat. V situaci, kdy mu nebude stačit obyčejný zrak, začne automaticky infravidění využívat. I když tobě se takové zobrazení může zdát nejasné a nepochopitelné, trpaslík, který ho má jako vrozenou schopnost, se v něm poměrně dobře vyzná. Přechod od normálního vidění k infra vidění lze přirovnat k překrývání fotografií. Jakmile v šeru trpaslík přestává vidět skutečné barvy, začíná vnímat infrabarvy.", 11, 100, 55 },
                    { 4, 17, 180, 145, 20, 18, 19, 12, "Elfové jsou známou rasou, žijící zpravidla hluboko v lesích nebo odlehlých údolích a roklinách. Jsou menší než lidé a zdaleka ne tak robustní. Pro své většinou plavé vlasy a jemné rysy obličeje jsou pokládáni za velmi krásné až poněkud změkčilé. Protože jsou velmi inteligentní, jen neradi bojují avšak jsou-li k boji donuceni, mohou být nebezpečnými soupeři. Díky své obratnosti dovedou dobře zacházet zejména s lukem a se střelnými zbraněmi vůbec. Největší potěšeni jim však činí studium a učení se kouzlům, a proto z jejich řad vzešlo již mnoho známých kouzelníků. Také milují krásné věci, ale od trpaslíků (které mimochodem nemají příliš v lásce) se liší především tím, že krásu hned nepřepočítávají na zlaťáky. Elfové jsou vesměs velmi čestní a spravedliví a nikdy se mezi nimi nevyskytují jedinci, pro které by zlo bylo přirozenou podstatou jejich osobnosti.", "Elf", 1, "Dlouhověkost", "", 16, 85, 50 },
                    { 5, 22, 210, 165, 25, 23, 24, 11, "Lidé jsou snad nejrozšířenější rasou, žijící jak v oblastech hor, tak i ve stepích, lesích a tundrách. Budují rozsáhlá sídla, ať už města či vesnice, která zpravidla leží na velkých obchodních křižovatkách. Lidé jsou velmi houževnatí, nacházejí uplatnění v celé škále povoláni. Většina z nich se zabývá především zemědělstvím a řemeslnou výrobou, ale najdete mezi nimi i zdatné lovce a zkušené dobrodruhy všeho druhu.", "Člověk", 1, "", "", 21, 115, 65 },
                    { 6, 27, 220, 175, 30, 28, 29, 12, "Barbaři jsou v podstatě lidé, ale jejich po staletí trvající odloučení od skutečné lidské civilizace způsobilo, že barbar zpravidla není tak inteligentní jako člověk, avšak je silnější a mnohem odolnější. Tyto vlastnosti jej také předurčují k tomu, aby se stal dobrým válečníkem.", "Barbar", 1, "", "", 26, 140, 75 },
                    { 7, 32, 245, 180, 35, 33, 34, 11, "Krollové sídlí v horách, tundrách a vůbec v prostředí velmi tvrdém a nehostinném. Dospělý kroll může měřit hodně přes dva metry a zjevem může vzdáleně (velmi vzdáleně) připomínat pračlověka, i když jeho kůže je spíše zrohovatělá než chlupatá. Bezpečně je však poznáte podle jejich nezaměnitelných uší, jimž vděčí za svůj neobvyklý sluch. Krollové jsou silnější než obyčejní lidé, ale také poněkud neohrabaní a zejména o poznání hloupější. Žijí obvykle v nevelkých kmenech, které mezi sebou neustále válčí. V těchto bojích se velmi zdokonalili, a proto nyní patří k nejobávanějším bojovníkům a z jejich kyjů a palcátů jde vskutku příslovečný strach. Po svých divokých předcích kromě jiného podědili také vrozený \"ultrasluch\", který jim umožňuje do jisté míry \"vidět\" (podobně jako netopýrům) i za úplné tmy nebo mlhy. Pokud jde o jejich původ, je možné, že vznikli kdysi dávno spojením skřeta s poloobrem. To by také vysvětlovalo, proč se mezi nimi téměř nikdy nevyskytují jedinci preferující výhradně dobro.", "Kroll", 2, "Ultrasluch", "Jeho zvláštní schopnost se nazývá ultrasluch a připomíná sonar netopýrů. Kroll je schopen vysílat Lidským uchem nezachytitelné zvukové vlnění, které se odráží od zkoumaného předmětu a vrací se zpět ke krollovi. Podle toho, jak odražené vlnění vypadá, je kroll schopen určit vzdálenost a tvar předmětu. Ultrasluch je použitelný v mlze, dokonce i pod vodou (ale ne skrz vodní hladinu, na ní se zvuk láme, odráží a všelijak zkresluje). Krollův ultrasluch má dosah 50 sáhů. To znamená, že kroll je schopen postřehnout jakýkoliv předmět nebo jakéhokoliv hmotného tvora, který je blíž než 50 sáhů a není zastíněn nějakým jiným předmětem nebo tvorem. Bude také schopen zhruba určit jeho vzdálenost a velikost. Kroll nepozná, o jakého tvora jde, ale pozná například, kolik má nohou apod. S předměty v jeskyni a jejím vybavením to je podobné. Krollův ultrasluch je v podstatě stále ještě sluchem, a proto závisí na hluku, který krolla obklopuje. Kroll nemůže používat ultrasluch v prostředí, které je hlučnější než obyčejný lidský hovor. Kroll svůj ultrasluch nepoužívá automaticky. Chce-li tuto svou zvláštní schopnost použít, musí o tom říct Pánovi jeskyně. Prozkoumávání ultrasluchem je stejně rychlé jako pohled. Prostor, který by kroll očima přehlédl během jednoho kola, je schopen za stejnou dobu prozkoumat i ultrasluchem. Kroll je schopen díky svému ultrasluchu vnímat i netopýry (a delfíny a jiné tvory, vybavené sonarem), není ovšem schopen se s nimi nijak dorozumět ani s nimi komunikovat. Tyto cizí signály krollův ultrasluch neruší, není-li jich příliš mnoho. Například uprostřed hejna netopýrů kroll svoji zvláštní schopnost může použít jen stěží.", 31, 200, 100 }
                });

            migrationBuilder.InsertData(
                table: "SpecificSkill",
                columns: new[] { "Id", "InternalName", "Level", "LevelGroup", "MaxHealingPoints", "ProfessionClass", "ProfessionSkillId", "ProfessionSkillName", "SkillSumPrice", "Skill_type", "SpecificDescription", "SpeedOfHealing" },
                values: new object[,]
                {
                    { 1, "Healing", 2, 3, 2, 1, 1, "", 20, "healing", "Postava si může vyléčit 2 Hp za 1 směnu, maximálně 2 Hp za den.", 2 },
                    { 2, "Healing", 3, 3, 4, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 4 Hp za den.", 3 },
                    { 3, "Healing", 4, 3, 6, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 6 Hp za den.", 3 },
                    { 4, "Healing", 5, 3, 8, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 8 Hp za den.", 3 },
                    { 5, "Healing", 6, 3, 10, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 10 Hp za den.", 3 },
                    { 6, "Healing", 7, 3, 12, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 12 Hp za den.", 3 },
                    { 7, "Healing", 8, 3, 14, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 14 Hp za den.", 3 },
                    { 8, "Healing", 9, 3, 16, 1, 1, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 16 Hp za den.", 3 },
                    { 9, "Healing", 15, 3, 16, 1, 1, "", 20, "healing", "Postava si může vyléčit 4 Hp za 1 směnu, maximálně 16 Hp za den.", 4 },
                    { 10, "Healing", 16, 3, 16, 1, 1, "", 20, "healing", "Postava si může vyléčit 4 Hp za 1 směnu, maximálně 16 Hp za den.", 4 },
                    { 11, "Healing", 25, 3, 16, 1, 1, "", 20, "healing", "Postava si může vyléčit 5 Hp za 1 směnu, maximálně 16 Hp za den.", 5 },
                    { 12, "Healing", 35, 3, 16, 1, 1, "", 20, "healing", "Postava si může vyléčit 6 Hp za 1 směnu, maximálně 16 Hp za den.", 6 },
                    { 13, "Healing", 2, 3, 1, 18, 16, "", 20, "healing", "Postava si může vyléčit 1 Hp za 1 směnu, maximálně 1 Hp za den.", 1 },
                    { 14, "Healing", 3, 3, 2, 18, 16, "", 20, "healing", "Postava si může vyléčit 2 Hp za 1 směnu, maximálně 2 Hp za den.", 2 },
                    { 15, "Healing", 4, 3, 3, 18, 16, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 3 Hp za den.", 3 },
                    { 16, "Healing", 5, 3, 4, 18, 16, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 4 Hp za den.", 3 },
                    { 17, "Healing", 6, 1, 5, 18, 16, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 5 Hp za den.", 3 },
                    { 18, "Healing", 7, 3, 6, 18, 16, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 6 Hp za den.", 3 },
                    { 19, "Healing", 8, 3, 7, 18, 16, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 7 Hp za den.", 3 },
                    { 20, "Healing", 6, 3, 8, 18, 16, "", 20, "healing", "Postava si může vyléčit 3 Hp za 1 směnu, maximálně 8 Hp za den.", 3 }
                });

            migrationBuilder.InsertData(
                table: "SpecificSkill",
                columns: new[] { "Id", "CategoryWeapon", "Initiative", "InitiativeText", "InternalName", "Level", "LevelGroup", "ProfessionClass", "ProfessionSkillId", "ProfessionSkillName", "SkillSumPrice", "Skill_type", "SpecificDescription" },
                values: new object[,]
                {
                    { 21, 3, 3, "3/2", "MultipleAttack", 5, 0, 1, 7, "", 20, "multiple_attack", "Postava může zaútočit 2x v prvním kole a v dalším kole 1x" },
                    { 22, 1, 6, "2/1", "MultipleAttack", 10, 1, 4, 7, "", 20, "multiple_attack", "Postava může zaútočit 2x v každém kole" },
                    { 23, 3, 6, "2/1", "MultipleAttack", 15, 1, 4, 7, "", 20, "multiple_attack", "Postava může zaútočit 2x v každém kole" },
                    { 24, 1, 9, "5/2", "MultipleAttack", 16, 2, 4, 7, "", 20, "multiple_attack", "Postava může zaútočit 5x v prvním kole a v dalším kole 2x" },
                    { 25, 1, 12, "3/1", "MultipleAttack", 27, 2, 4, 7, "", 20, "multiple_attack", "Postava může zaútočit 3x v každém kole" },
                    { 26, 3, 9, "5/2", "MultipleAttack", 28, 2, 4, 7, "", 20, "multiple_attack", "Postava může zaútočit 5x v prvním kole a v dalším kole 2x" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AgilityStatId", "CharismaStatId", "ConstitutionStatId", "Description", "IntelligenceStatId", "Mobility", "Name", "NarrativeId", "Profipoints", "RaceId", "StrengthStatId", "Visage" },
                values: new object[] { 1, 37, 40, 38, "Lorem Ypsum", 39, "[11,0]", "Tester", 1, 20, 1, 36, "[12,0]" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BindTable_Advanced_ProfessionSkill_ProfessionModul1Id",
                table: "BindTable_Advanced_ProfessionSkill",
                column: "ProfessionModul1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BindTable_Beginner_ProfessionSkill_ProfessionModulId",
                table: "BindTable_Beginner_ProfessionSkill",
                column: "ProfessionModulId");

            migrationBuilder.CreateIndex(
                name: "IX_BindTable_Expert_ProfessionSkill_ProfessionModul2Id",
                table: "BindTable_Expert_ProfessionSkill",
                column: "ProfessionModul2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AgilityStatId",
                table: "Characters",
                column: "AgilityStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ConstitutionStatId",
                table: "Characters",
                column: "ConstitutionStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharismaStatId",
                table: "Characters",
                column: "CharismaStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IntelligenceStatId",
                table: "Characters",
                column: "IntelligenceStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_NarrativeId",
                table: "Characters",
                column: "NarrativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StrengthStatId",
                table: "Characters",
                column: "StrengthStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Naratives_WorldId",
                table: "Naratives",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_NarrativeProfessionModul_ProfessionModulesId",
                table: "NarrativeProfessionModul",
                column: "ProfessionModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionSkill_CharacterId",
                table: "ProfessionSkill",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_AgilityStatId",
                table: "Races",
                column: "AgilityStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ConstitutionStatId",
                table: "Races",
                column: "ConstitutionStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_CharismaStatId",
                table: "Races",
                column: "CharismaStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_IntelligenceStatId",
                table: "Races",
                column: "IntelligenceStatId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_StrengthStatId",
                table: "Races",
                column: "StrengthStatId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceWorld_WorldsId",
                table: "RaceWorld",
                column: "WorldsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificSkill_ProfessionSkillId",
                table: "SpecificSkill",
                column: "ProfessionSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailImages_CharacterId",
                table: "ThumbnailImages",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailImages_NarrativeId",
                table: "ThumbnailImages",
                column: "NarrativeId",
                unique: true,
                filter: "[NarrativeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailImages_RaceId",
                table: "ThumbnailImages",
                column: "RaceId",
                unique: true,
                filter: "[RaceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailImages_WorldId",
                table: "ThumbnailImages",
                column: "WorldId",
                unique: true,
                filter: "[WorldId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BindTable_Advanced_ProfessionSkill");

            migrationBuilder.DropTable(
                name: "BindTable_Beginner_ProfessionSkill");

            migrationBuilder.DropTable(
                name: "BindTable_Expert_ProfessionSkill");

            migrationBuilder.DropTable(
                name: "NarrativeProfessionModul");

            migrationBuilder.DropTable(
                name: "RaceWorld");

            migrationBuilder.DropTable(
                name: "SpecificSkill");

            migrationBuilder.DropTable(
                name: "ThumbnailImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "ProfessionSkill");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "AttributeStats");

            migrationBuilder.DropTable(
                name: "Naratives");

            migrationBuilder.DropTable(
                name: "Worlds");
        }
    }
}
