using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Etudiant
{
    [Key]
    public int IdEtudiant { get; set; }

    public required string Matricule { get; set; }
    public required string Niveau { get; set; }
    public string? Groupe { get; set; }

    [ForeignKey("Utilisateur")]
    public int UtilisateurId { get; set; }
    public virtual Utilisateur Utilisateur { get; set; }

    [ForeignKey("Filiere")]
    public int IdFiliere { get; set; }
    public virtual Filiere Filiere { get; set; }

    // 1 Classe -> * Etudiants
    [ForeignKey("Classe")]
    public int IdClasse { get; set; }
    public virtual Classe Classe { get; set; }

    protected void ConsulterEDT() { }
}