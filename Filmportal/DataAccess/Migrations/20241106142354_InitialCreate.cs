using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agelimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agelimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resources_to_view",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    MainUrl = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources_to_view", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    HashPassword = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    nameForeign = table.Column<string>(type: "text", nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persons_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TitleForeign = table.Column<string>(type: "text", nullable: false),
                    Slogan = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AgeLimitId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_films_agelimits_AgeLimitId",
                        column: x => x.AgeLimitId,
                        principalTable: "agelimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "film_resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_film_resource_films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_resource_resources_to_view_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "resources_to_view",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "films_actors",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "integer", nullable: false),
                    FilmsOfActorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films_actors", x => new { x.ActorsId, x.FilmsOfActorId });
                    table.ForeignKey(
                        name: "FK_films_actors_films_FilmsOfActorId",
                        column: x => x.FilmsOfActorId,
                        principalTable: "films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_actors_persons_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "films_countries",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "integer", nullable: false),
                    FilmsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films_countries", x => new { x.CountriesId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_films_countries_countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_countries_films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "films_directors",
                columns: table => new
                {
                    DirectorsId = table.Column<int>(type: "integer", nullable: false),
                    FilmsOfDirectorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films_directors", x => new { x.DirectorsId, x.FilmsOfDirectorId });
                    table.ForeignKey(
                        name: "FK_films_directors_films_FilmsOfDirectorId",
                        column: x => x.FilmsOfDirectorId,
                        principalTable: "films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_directors_persons_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "films_genres",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films_genres", x => new { x.FilmsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_films_genres_films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_genres_genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_film_resource_FilmId",
                table: "film_resource",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_film_resource_ResourceId",
                table: "film_resource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_films_AgeLimitId",
                table: "films",
                column: "AgeLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_films_CreatorId",
                table: "films",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_films_actors_FilmsOfActorId",
                table: "films_actors",
                column: "FilmsOfActorId");

            migrationBuilder.CreateIndex(
                name: "IX_films_countries_FilmsId",
                table: "films_countries",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_films_directors_FilmsOfDirectorId",
                table: "films_directors",
                column: "FilmsOfDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_films_genres_GenresId",
                table: "films_genres",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_CountryId",
                table: "persons",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "film_resource");

            migrationBuilder.DropTable(
                name: "films_actors");

            migrationBuilder.DropTable(
                name: "films_countries");

            migrationBuilder.DropTable(
                name: "films_directors");

            migrationBuilder.DropTable(
                name: "films_genres");

            migrationBuilder.DropTable(
                name: "resources_to_view");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "films");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "agelimits");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
