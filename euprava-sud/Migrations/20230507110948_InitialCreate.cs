using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace euprava_sud.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    DokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URLDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.DokumentId);
                });

            migrationBuilder.CreateTable(
                name: "Opstine",
                columns: table => new
                {
                    OpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PTT = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstine", x => x.OpstinaId);
                });

            migrationBuilder.CreateTable(
                name: "Sudovi",
                columns: table => new
                {
                    SudId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sudovi", x => x.SudId);
                    table.ForeignKey(
                        name: "FK_Sudovi_Opstine_OpstinaId",
                        column: x => x.OpstinaId,
                        principalTable: "Opstine",
                        principalColumn: "OpstinaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gradjani",
                columns: table => new
                {
                    Jmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SudId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradjani", x => x.Jmbg);
                    table.ForeignKey(
                        name: "FK_Gradjani_Opstine_OpstinaId",
                        column: x => x.OpstinaId,
                        principalTable: "Opstine",
                        principalColumn: "OpstinaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gradjani_Sudovi_SudId",
                        column: x => x.SudId,
                        principalTable: "Sudovi",
                        principalColumn: "SudId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrekrsajnePrijave",
                columns: table => new
                {
                    PrekrsajnaPrijavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptuzeniJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrijavljenoOdJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SudijaJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prekrsaj = table.Column<int>(type: "int", nullable: false),
                    PrekrsajId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusPrekrsajnePrijave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrekrsajnePrijave", x => x.PrekrsajnaPrijavaId);
                    table.ForeignKey(
                        name: "FK_PrekrsajnePrijave_Gradjani_OptuzeniJmbg",
                        column: x => x.OptuzeniJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrekrsajnePrijave_Gradjani_PrijavljenoOdJmbg",
                        column: x => x.PrijavljenoOdJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrekrsajnePrijave_Gradjani_SudijaJmbg",
                        column: x => x.SudijaJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrekrsajnePrijave_Opstine_OpstinaId",
                        column: x => x.OpstinaId,
                        principalTable: "Opstine",
                        principalColumn: "OpstinaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdlukaSudijeDokumenti",
                columns: table => new
                {
                    DokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrekrsajnaPrijavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdlukaSudijeDokumenti", x => new { x.DokumentId, x.PrekrsajnaPrijavaId });
                    table.ForeignKey(
                        name: "FK_OdlukaSudijeDokumenti_Dokumenti_DokumentId",
                        column: x => x.DokumentId,
                        principalTable: "Dokumenti",
                        principalColumn: "DokumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdlukaSudijeDokumenti_PrekrsajnePrijave_PrekrsajnaPrijavaId",
                        column: x => x.PrekrsajnaPrijavaId,
                        principalTable: "PrekrsajnePrijave",
                        principalColumn: "PrekrsajnaPrijavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdlukaSudijeSvedoci",
                columns: table => new
                {
                    PrekrsajnaPrijavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SvedociJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdlukaSudijeSvedoci", x => new { x.PrekrsajnaPrijavaId, x.SvedociJmbg });
                    table.ForeignKey(
                        name: "FK_OdlukaSudijeSvedoci_Gradjani_SvedociJmbg",
                        column: x => x.SvedociJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdlukaSudijeSvedoci_PrekrsajnePrijave_PrekrsajnaPrijavaId",
                        column: x => x.PrekrsajnaPrijavaId,
                        principalTable: "PrekrsajnePrijave",
                        principalColumn: "PrekrsajnaPrijavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predmeti",
                columns: table => new
                {
                    PredmetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvokatJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PrekrsajnaPrijavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmeti", x => x.PredmetId);
                    table.ForeignKey(
                        name: "FK_Predmeti_Gradjani_AdvokatJmbg",
                        column: x => x.AdvokatJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Predmeti_PrekrsajnePrijave_PrekrsajnaPrijavaId",
                        column: x => x.PrekrsajnaPrijavaId,
                        principalTable: "PrekrsajnePrijave",
                        principalColumn: "PrekrsajnaPrijavaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rocista",
                columns: table => new
                {
                    RocisteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdlukaSudije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRocista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredmetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SudijaJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SudId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IshodRocista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rocista", x => x.RocisteId);
                    table.ForeignKey(
                        name: "FK_Rocista_Gradjani_SudijaJmbg",
                        column: x => x.SudijaJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg");
                    table.ForeignKey(
                        name: "FK_Rocista_Predmeti_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetId");
                    table.ForeignKey(
                        name: "FK_Rocista_Sudovi_SudId",
                        column: x => x.SudId,
                        principalTable: "Sudovi",
                        principalColumn: "SudId");
                });

            migrationBuilder.CreateTable(
                name: "OdlukeSudija",
                columns: table => new
                {
                    OdlukaSudijeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OduzimanjeVozacke = table.Column<bool>(type: "bit", nullable: false),
                    OduzimanjeBodova = table.Column<int>(type: "int", nullable: false),
                    NovcanaKazna = table.Column<double>(type: "float", nullable: false),
                    Resenje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SudijaJmbg = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RocisteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PredmetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdlukeSudija", x => x.OdlukaSudijeId);
                    table.ForeignKey(
                        name: "FK_OdlukeSudija_Gradjani_SudijaJmbg",
                        column: x => x.SudijaJmbg,
                        principalTable: "Gradjani",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlukeSudija_Predmeti_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlukeSudija_Rocista_RocisteId",
                        column: x => x.RocisteId,
                        principalTable: "Rocista",
                        principalColumn: "RocisteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gradjani_Jmbg",
                table: "Gradjani",
                column: "Jmbg",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gradjani_OpstinaId",
                table: "Gradjani",
                column: "OpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gradjani_SudId",
                table: "Gradjani",
                column: "SudId");

            migrationBuilder.CreateIndex(
                name: "IX_OdlukaSudijeDokumenti_PrekrsajnaPrijavaId",
                table: "OdlukaSudijeDokumenti",
                column: "PrekrsajnaPrijavaId");

            migrationBuilder.CreateIndex(
                name: "IX_OdlukaSudijeSvedoci_SvedociJmbg",
                table: "OdlukaSudijeSvedoci",
                column: "SvedociJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_OdlukeSudija_PredmetId",
                table: "OdlukeSudija",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_OdlukeSudija_RocisteId",
                table: "OdlukeSudija",
                column: "RocisteId");

            migrationBuilder.CreateIndex(
                name: "IX_OdlukeSudija_SudijaJmbg",
                table: "OdlukeSudija",
                column: "SudijaJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_Opstine_PTT",
                table: "Opstine",
                column: "PTT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_AdvokatJmbg",
                table: "Predmeti",
                column: "AdvokatJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_PrekrsajnaPrijavaId",
                table: "Predmeti",
                column: "PrekrsajnaPrijavaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrekrsajnePrijave_OpstinaId",
                table: "PrekrsajnePrijave",
                column: "OpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrekrsajnePrijave_OptuzeniJmbg",
                table: "PrekrsajnePrijave",
                column: "OptuzeniJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_PrekrsajnePrijave_PrijavljenoOdJmbg",
                table: "PrekrsajnePrijave",
                column: "PrijavljenoOdJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_PrekrsajnePrijave_SudijaJmbg",
                table: "PrekrsajnePrijave",
                column: "SudijaJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_Rocista_PredmetId",
                table: "Rocista",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Rocista_SudId",
                table: "Rocista",
                column: "SudId");

            migrationBuilder.CreateIndex(
                name: "IX_Rocista_SudijaJmbg",
                table: "Rocista",
                column: "SudijaJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_Sudovi_OpstinaId",
                table: "Sudovi",
                column: "OpstinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdlukaSudijeDokumenti");

            migrationBuilder.DropTable(
                name: "OdlukaSudijeSvedoci");

            migrationBuilder.DropTable(
                name: "OdlukeSudija");

            migrationBuilder.DropTable(
                name: "Dokumenti");

            migrationBuilder.DropTable(
                name: "Rocista");

            migrationBuilder.DropTable(
                name: "Predmeti");

            migrationBuilder.DropTable(
                name: "PrekrsajnePrijave");

            migrationBuilder.DropTable(
                name: "Gradjani");

            migrationBuilder.DropTable(
                name: "Sudovi");

            migrationBuilder.DropTable(
                name: "Opstine");
        }
    }
}
