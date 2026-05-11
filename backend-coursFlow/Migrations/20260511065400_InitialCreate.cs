using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace coursFlow.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploisDuTemps",
                columns: table => new
                {
                    IdEmploi = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Jour = table.Column<int>(type: "integer", nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploisDuTemps", x => x.IdEmploi);
                });

            migrationBuilder.CreateTable(
                name: "Filieres",
                columns: table => new
                {
                    IdFiliere = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filieres", x => x.IdFiliere);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    IdMatiere = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Credit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.IdMatiere);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    IdSalle = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Batiment = table.Column<string>(type: "text", nullable: false),
                    Capacite = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.IdSalle);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    MotDePasse = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Niveau = table.Column<string>(type: "text", nullable: false),
                    Groupe = table.Column<string>(type: "text", nullable: false),
                    IdFiliere = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.IdClasse);
                    table.ForeignKey(
                        name: "FK_Classes_Filieres_IdFiliere",
                        column: x => x.IdFiliere,
                        principalTable: "Filieres",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prerequis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMatiere = table.Column<int>(type: "integer", nullable: false),
                    IdMatierePrerequis = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prerequis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prerequis_Matieres_IdMatiere",
                        column: x => x.IdMatiere,
                        principalTable: "Matieres",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prerequis_Matieres_IdMatierePrerequis",
                        column: x => x.IdMatierePrerequis,
                        principalTable: "Matieres",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IdAdmin = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Utilisateurs_Id",
                        column: x => x.Id,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IdProf = table.Column<int>(type: "integer", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: false),
                    Specialite = table.Column<string>(type: "text", nullable: false),
                    UtilisateurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professeurs_Utilisateurs_Id",
                        column: x => x.Id,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professeurs_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IdResp = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsables_Utilisateurs_Id",
                        column: x => x.Id,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IdEtudiant = table.Column<int>(type: "integer", nullable: false),
                    Matricule = table.Column<string>(type: "text", nullable: false),
                    Niveau = table.Column<string>(type: "text", nullable: false),
                    Groupe = table.Column<string>(type: "text", nullable: true),
                    UtilisateurId = table.Column<int>(type: "integer", nullable: false),
                    IdFiliere = table.Column<int>(type: "integer", nullable: false),
                    FiliereIdFiliere = table.Column<int>(type: "integer", nullable: false),
                    IdClasse = table.Column<int>(type: "integer", nullable: false),
                    ClasseIdClasse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_ClasseIdClasse",
                        column: x => x.ClasseIdClasse,
                        principalTable: "Classes",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etudiants_Filieres_FiliereIdFiliere",
                        column: x => x.FiliereIdFiliere,
                        principalTable: "Filieres",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etudiants_Utilisateurs_Id",
                        column: x => x.Id,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etudiants_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    IdCours = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnneeUniversitaire = table.Column<string>(type: "text", nullable: false),
                    Semestre = table.Column<string>(type: "text", nullable: false),
                    Duree = table.Column<int>(type: "integer", nullable: false),
                    VolumeHoraire = table.Column<int>(type: "integer", nullable: false),
                    IdMatiere = table.Column<int>(type: "integer", nullable: false),
                    IdProf = table.Column<int>(type: "integer", nullable: false),
                    IdClasse = table.Column<int>(type: "integer", nullable: false),
                    IdSalle = table.Column<int>(type: "integer", nullable: false),
                    EmploiDuTempsIdEmploi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.IdCours);
                    table.ForeignKey(
                        name: "FK_Cours_Classes_IdClasse",
                        column: x => x.IdClasse,
                        principalTable: "Classes",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_EmploisDuTemps_EmploiDuTempsIdEmploi",
                        column: x => x.EmploiDuTempsIdEmploi,
                        principalTable: "EmploisDuTemps",
                        principalColumn: "IdEmploi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_Matieres_IdMatiere",
                        column: x => x.IdMatiere,
                        principalTable: "Matieres",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_Professeurs_IdProf",
                        column: x => x.IdProf,
                        principalTable: "Professeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_Salles_IdSalle",
                        column: x => x.IdSalle,
                        principalTable: "Salles",
                        principalColumn: "IdSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilites",
                columns: table => new
                {
                    IdDispo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Jour = table.Column<string>(type: "text", nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IdProf = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilites", x => x.IdDispo);
                    table.ForeignKey(
                        name: "FK_Disponibilites_Professeurs_IdProf",
                        column: x => x.IdProf,
                        principalTable: "Professeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdFiliere",
                table: "Classes",
                column: "IdFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EmploiDuTempsIdEmploi",
                table: "Cours",
                column: "EmploiDuTempsIdEmploi");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_IdClasse",
                table: "Cours",
                column: "IdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_IdMatiere",
                table: "Cours",
                column: "IdMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_IdProf",
                table: "Cours",
                column: "IdProf");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_IdSalle",
                table: "Cours",
                column: "IdSalle");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilites_IdProf",
                table: "Disponibilites",
                column: "IdProf");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_ClasseIdClasse",
                table: "Etudiants",
                column: "ClasseIdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_FiliereIdFiliere",
                table: "Etudiants",
                column: "FiliereIdFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_UtilisateurId",
                table: "Etudiants",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequis_IdMatiere",
                table: "Prerequis",
                column: "IdMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequis_IdMatierePrerequis",
                table: "Prerequis",
                column: "IdMatierePrerequis");

            migrationBuilder.CreateIndex(
                name: "IX_Professeurs_UtilisateurId",
                table: "Professeurs",
                column: "UtilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Disponibilites");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Prerequis");

            migrationBuilder.DropTable(
                name: "Responsables");

            migrationBuilder.DropTable(
                name: "EmploisDuTemps");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Professeurs");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Filieres");
        }
    }
}
