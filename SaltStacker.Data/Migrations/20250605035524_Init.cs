﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaltStacker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "settings");

            migrationBuilder.EnsureSchema(
                name: "nutrition");

            migrationBuilder.EnsureSchema(
                name: "operation");

            migrationBuilder.CreateTable(
                name: "ApplicationSettings",
                schema: "settings",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ChangeDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettings", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETUTCDATE()"),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsSystem = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
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
                name: "Countries",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Permalink = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    EmptyDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ProfitMargin = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Permalink = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCookingCategories",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCookingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverheadCosts",
                schema: "operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverheadCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Permalink = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sign = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ConversionFactor = table.Column<double>(type: "float", nullable: true),
                    HasCustomConversionFactor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Provinces",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "settings",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodAttachments",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    UploadDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodAttachments_Foods_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "nutrition",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RecipeDetails = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    RecipeType = table.Column<int>(type: "int", nullable: false),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    PackagingTime = table.Column<int>(type: "int", nullable: false),
                    MainMenu = table.Column<bool>(type: "bit", nullable: false),
                    DefaultInCategory = table.Column<bool>(type: "bit", nullable: false),
                    IsOption = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CalculateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowNoAppleCider = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AllowNoPepper = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AllowNoSalt = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AllowNoSalmonSkin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HeatingInstruction = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsRoutine = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Orderable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTwoStepCooking = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RecipeSize = table.Column<int>(type: "int", nullable: false),
                    PersonalChefId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_PersonalChefId",
                        column: x => x.PersonalChefId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "nutrition",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientSubCategories",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Permalink = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IngredientCategoryId = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IngredientSubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientSubCategories_IngredientCategories_IngredientCategoryId",
                        column: x => x.IngredientCategoryId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientSubCategories_IngredientSubCategories_IngredientSubCategoryId",
                        column: x => x.IngredientSubCategoryId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageAttachments",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    UploadDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageAttachments_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "nutrition",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageGroups",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageGroups_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "nutrition",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    OrderPeriod = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CookingCategoryId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientCookingCategories_CookingCategoryId",
                        column: x => x.CookingCategoryId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientCookingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "nutrition",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "settings",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customizations",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Changes = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    TotalFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    TransFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    SaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Cholesterol = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    DietaryFiber = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Sugars = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Sudium = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Iron = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    VitaminA = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    VitaminC = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Zinc = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    CalculateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customizations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customizations_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDiets",
                schema: "nutrition",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDiets", x => new { x.RecipeId, x.DietId });
                    table.ForeignKey(
                        name: "FK_RecipeDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalSchema: "nutrition",
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeDiets_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeOverheadCosts",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    OverheadCostId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeOverheadCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeOverheadCosts_OverheadCosts_OverheadCostId",
                        column: x => x.OverheadCostId,
                        principalSchema: "operation",
                        principalTable: "OverheadCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeOverheadCosts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeOwners",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeOwners_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTags",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "nutrition",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageGroupItems",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageGroupItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageGroupItems_PackageGroups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "nutrition",
                        principalTable: "PackageGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageGroupItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTypes",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 1m),
                    MixDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pchef = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NeedsPrep = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientTypes_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "nutrition",
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "settings",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTypeAllergenAlerts",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    AllergenAlert = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypeAllergenAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientTypeAllergenAlerts_IngredientTypes_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTypeSubCategories",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    IngredientSubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypeSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientTypeSubCategories_IngredientSubCategories_IngredientSubCategoryId",
                        column: x => x.IngredientSubCategoryId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientTypeSubCategories_IngredientTypes_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTypeUnits",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ConversionFactor = table.Column<double>(type: "float", nullable: true),
                    PriceOperator = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    PriceFactor = table.Column<double>(type: "float", nullable: false),
                    IsPercent = table.Column<bool>(type: "bit", nullable: false),
                    AmountOperator = table.Column<string>(type: "char(1)", maxLength: 1, nullable: true),
                    AmountFactor = table.Column<double>(type: "float", nullable: true),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cholesterol = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DietaryFiber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sugars = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sudium = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Iron = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Zinc = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypeUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientTypeUnits_IngredientTypes_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientTypeUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "nutrition",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientTypeUnits",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAddOn = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDressing = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IngredientTypeUnitId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientTypeUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientTypeUnits_IngredientTypeUnits_IngredientTypeUnitId",
                        column: x => x.IngredientTypeUnitId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientTypeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientTypeUnits_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "nutrition",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientTypeAmounts",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeIngredientTypeUnitId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcessFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientTypeAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientTypeAmounts_RecipeIngredientTypeUnits_RecipeIngredientTypeUnitId",
                        column: x => x.RecipeIngredientTypeUnitId,
                        principalSchema: "nutrition",
                        principalTable: "RecipeIngredientTypeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientTypeSubstitutes",
                schema: "nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeIngredientTypeUnitId = table.Column<int>(type: "int", nullable: false),
                    IngredientTypeUnitId = table.Column<int>(type: "int", nullable: false),
                    ProcessFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientTypeSubstitutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientTypeSubstitutes_IngredientTypeUnits_IngredientTypeUnitId",
                        column: x => x.IngredientTypeUnitId,
                        principalSchema: "nutrition",
                        principalTable: "IngredientTypeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientTypeSubstitutes_RecipeIngredientTypeUnits_RecipeIngredientTypeUnitId",
                        column: x => x.RecipeIngredientTypeUnitId,
                        principalSchema: "nutrition",
                        principalTable: "RecipeIngredientTypeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsSystem", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "634fce1a-f3e0-4512-86ab-628adb4999f1", null, "AspNetRole", true, "User", "USER" },
                    { "72c2c695-2efd-4fcf-b083-dcb1f47fa314", null, "AspNetRole", true, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsBlocked", "IsSystem", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "011b406e-94e4-480f-b0e3-d7ac50db372c", 0, "4c159afc-539f-4d73-b997-d23eea86b75c", "AspNetUser", null, false, false, true, false, null, "Admin", null, null, "AQAAAAIAAYagAAAAEI0CynVzbtPbQD3eAMJft/5fjCYJbXaectUfMaDSh85aoH6XqLGQsyhEUMH6xP76Ng==", null, false, null, null, "081c6cd0-07fb-457f-9e8e-92cea0fd4cae", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "72c2c695-2efd-4fcf-b083-dcb1f47fa314", "011b406e-94e4-480f-b0e3-d7ac50db372c" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSettings_Key",
                schema: "settings",
                table: "ApplicationSettings",
                column: "Key");

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
                name: "IX_Cities_ProvinceId",
                schema: "settings",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_RecipeId",
                schema: "nutrition",
                table: "Customizations",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UserId",
                schema: "nutrition",
                table: "Customizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAttachments_FoodId",
                schema: "nutrition",
                table: "FoodAttachments",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Title",
                schema: "nutrition",
                table: "Foods",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CookingCategoryId",
                schema: "nutrition",
                table: "Ingredients",
                column: "CookingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UnitId",
                schema: "nutrition",
                table: "Ingredients",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSubCategories_IngredientCategoryId",
                schema: "nutrition",
                table: "IngredientSubCategories",
                column: "IngredientCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSubCategories_IngredientSubCategoryId",
                schema: "nutrition",
                table: "IngredientSubCategories",
                column: "IngredientSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypeAllergenAlerts_IngredientTypeId",
                schema: "nutrition",
                table: "IngredientTypeAllergenAlerts",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypes_IngredientId",
                schema: "nutrition",
                table: "IngredientTypes",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypeSubCategories_IngredientSubCategoryId",
                schema: "nutrition",
                table: "IngredientTypeSubCategories",
                column: "IngredientSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypeSubCategories_IngredientTypeId",
                schema: "nutrition",
                table: "IngredientTypeSubCategories",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypeUnits_IngredientTypeId",
                schema: "nutrition",
                table: "IngredientTypeUnits",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypeUnits_UnitId",
                schema: "nutrition",
                table: "IngredientTypeUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAttachments_PackageId",
                schema: "nutrition",
                table: "PackageAttachments",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageGroupItems_GroupId",
                schema: "nutrition",
                table: "PackageGroupItems",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageGroupItems_RecipeId",
                schema: "nutrition",
                table: "PackageGroupItems",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageGroups_PackageId",
                schema: "nutrition",
                table: "PackageGroups",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                schema: "settings",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDiets_DietId",
                schema: "nutrition",
                table: "RecipeDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientTypeAmounts_RecipeIngredientTypeUnitId",
                schema: "nutrition",
                table: "RecipeIngredientTypeAmounts",
                column: "RecipeIngredientTypeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientTypeSubstitutes_IngredientTypeUnitId",
                schema: "nutrition",
                table: "RecipeIngredientTypeSubstitutes",
                column: "IngredientTypeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientTypeSubstitutes_RecipeIngredientTypeUnitId",
                schema: "nutrition",
                table: "RecipeIngredientTypeSubstitutes",
                column: "RecipeIngredientTypeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientTypeUnits_IngredientTypeUnitId",
                schema: "nutrition",
                table: "RecipeIngredientTypeUnits",
                column: "IngredientTypeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientTypeUnits_RecipeId",
                schema: "nutrition",
                table: "RecipeIngredientTypeUnits",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeOverheadCosts_OverheadCostId",
                schema: "nutrition",
                table: "RecipeOverheadCosts",
                column: "OverheadCostId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeOverheadCosts_RecipeId",
                schema: "nutrition",
                table: "RecipeOverheadCosts",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeOwners_RecipeId",
                schema: "nutrition",
                table: "RecipeOwners",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeOwners_UserId",
                schema: "nutrition",
                table: "RecipeOwners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_FoodId",
                schema: "nutrition",
                table: "Recipes",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PersonalChefId",
                schema: "nutrition",
                table: "Recipes",
                column: "PersonalChefId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_RecipeId",
                schema: "nutrition",
                table: "RecipeTags",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_TagId",
                schema: "nutrition",
                table: "RecipeTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_CityId",
                schema: "settings",
                table: "Zones",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationSettings",
                schema: "settings");

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
                name: "Customizations",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "FoodAttachments",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "IngredientTypeAllergenAlerts",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "IngredientTypeSubCategories",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "PackageAttachments",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "PackageGroupItems",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeDiets",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeIngredientTypeAmounts",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeIngredientTypeSubstitutes",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeOverheadCosts",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeOwners",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeTags",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "IngredientSubCategories",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "PackageGroups",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Diets",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "RecipeIngredientTypeUnits",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "OverheadCosts",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "IngredientCategories",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Packages",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "IngredientTypeUnits",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "IngredientTypes",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Foods",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "IngredientCookingCategories",
                schema: "nutrition");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "nutrition");
        }
    }
}
