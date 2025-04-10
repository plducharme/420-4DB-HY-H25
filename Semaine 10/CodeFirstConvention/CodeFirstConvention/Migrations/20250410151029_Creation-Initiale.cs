using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstConvention.Migrations
{
    /// <inheritdoc />
    public partial class CreationInitiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    PaysId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.PaysId);
                });

            migrationBuilder.CreateTable(
                name: "Fabricants",
                columns: table => new
                {
                    FabricantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    AnneeCreation = table.Column<int>(type: "INTEGER", nullable: true),
                    PaysId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricants", x => x.FabricantId);
                    table.ForeignKey(
                        name: "FK_Fabricants_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "PaysId");
                });

            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FabricantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Modele = table.Column<string>(type: "TEXT", nullable: false),
                    Annee = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automobiles_Fabricants_FabricantId",
                        column: x => x.FabricantId,
                        principalTable: "Fabricants",
                        principalColumn: "FabricantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_FabricantId",
                table: "Automobiles",
                column: "FabricantId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricants_PaysId",
                table: "Fabricants",
                column: "PaysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.DropTable(
                name: "Fabricants");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
