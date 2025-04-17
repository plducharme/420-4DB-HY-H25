using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstFluentAPI.Migrations
{
    /// <inheritdoc />
    public partial class DBinitiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Générique")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musiciens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musiciens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnneeDeSortie = table.Column<int>(type: "int", nullable: false, defaultValue: 1970),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicienGroupe",
                columns: table => new
                {
                    GroupesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusiciensId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicienGroupe", x => new { x.GroupesId, x.MusiciensId });
                    table.ForeignKey(
                        name: "FK_MusicienGroupe_Groupes_GroupesId",
                        column: x => x.GroupesId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicienGroupe_Musiciens_MusiciensId",
                        column: x => x.MusiciensId,
                        principalSchema: "dbo",
                        principalTable: "Musiciens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GroupeId",
                schema: "dbo",
                table: "Albums",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicienGroupe_MusiciensId",
                table: "MusicienGroupe",
                column: "MusiciensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MusicienGroupe");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Musiciens",
                schema: "dbo");
        }
    }
}
