namespace BackendCoursFlow.Donnees;

using Microsoft.EntityFrameworkCore;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.Salles;
using BackendCoursFlow.Models.EmploiDuTemps;
using BackendCoursFlow.Models.Enums;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // --- Tables principales basées sur ton diagramme ---

    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Etudiant> Etudiants { get; set; }
    public DbSet<Professeur> Professeurs { get; set; }
    public DbSet<Responsable> Responsables { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public DbSet<Filiere> Filieres { get; set; }
    public DbSet<Classe> Classes { get; set; }
    public DbSet<Matiere> Matieres { get; set; }
    public DbSet<Cours> Cours { get; set; }
    public DbSet<Salle> Salles { get; set; }
    public DbSet<Disponibilite> Disponibilites { get; set; }
    public DbSet<EmploiDuTemps> EmploisDuTemps { get; set; }
    public DbSet<Prerequis> Prerequis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CONFIG DES HERITAGES
        // Comme Etudiant, Professeur, Admin héritent de Utilisateur
        modelBuilder.Entity<Etudiant>().ToTable("Etudiants");
        modelBuilder.Entity<Professeur>().ToTable("Professeurs");
        modelBuilder.Entity<Responsable>().ToTable("Responsables");
        modelBuilder.Entity<Admin>().ToTable("Admins");

        // CONFIG DES RELATIONS SPECIFIQUES

        // Relation Matière - Cours (1..* : une matière peut avoir plusieurs cours)
        modelBuilder.Entity<Cours>()
            .HasOne(c => c.Matiere)
            .WithMany(m => m.Cours)
            .HasForeignKey(c => c.IdMatiere);

        // Relation Classe - Cours (1..* : une classe a plusieurs cours)
        modelBuilder.Entity<Cours>()
            .HasOne(c => c.Classe)
            .WithMany(cl => cl.Cours)
            .HasForeignKey(c => c.IdClasse);

        // Relation Professeur - Disponibilité (1..* : un prof a plusieurs dispos)
        modelBuilder.Entity<Disponibilite>()
            .HasOne(d => d.Professeur)
            .WithMany(p => p.Disponibilites)
            .HasForeignKey(d => d.IdProf);

        // Relation Professeur - Cours (1..* : un prof donne plusieurs cours)
        modelBuilder.Entity<Cours>()
            .HasOne(c => c.Professeur)
            .WithMany(p => p.Cours)
            .HasForeignKey(c => c.IdProf);

        // Relation Salle - Cours (1..* : une salle accueille plusieurs cours)
        modelBuilder.Entity<Cours>()
            .HasOne(c => c.Salle)
            .WithMany(s => s.Cours)
            .HasForeignKey(c => c.IdSalle);

        // Relation Filière - Classe (1..* : une filière contient plusieurs classes)
        modelBuilder.Entity<Classe>()
            .HasOne(c => c.Filiere)
            .WithMany(f => f.Classes)
            .HasForeignKey(c => c.IdFiliere);

        // Gestion des Enums pour PostgreSQL
        // PostgreSQL peut stocker les Enums comme des chaînes ou des types ENUM natifs.
        modelBuilder.Entity<Utilisateur>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Disponibilite>()
            .Property(d => d.Jour)
            .HasConversion<string>();

        modelBuilder.Entity<Prerequis>(entity =>
        {
            entity.HasKey(p => p.Id);

            // Relation avec la matière principale
            entity.HasOne(p => p.Matiere)
                .WithMany(m => m.Prerequis)
                .HasForeignKey(p => p.IdMatiere)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation avec la matière qui sert de prérequis
            entity.HasOne(p => p.MatierePrerequis)
                .WithMany() 
                .HasForeignKey(p => p.IdMatierePrerequis)
                .OnDelete(DeleteBehavior.Restrict);
            // Note : Restrict est important pour éviter les cycles de suppression en cascade
        });
    }
}