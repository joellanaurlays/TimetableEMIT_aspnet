namespace BackendCoursFlow.Models.Utilisateurs;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.EmploiDuTemps; 
using BackendCoursFlow.Models.Enums;

public class Etudiant : Utilisateur
{
    public int IdEtudiant { get; set; }

    public required string Matricule { get; set; }
    public required string Niveau { get; set; }
    public string? Groupe { get; set; }

    public int UtilisateurId { get; set; }
    public virtual Utilisateur Utilisateur { get; set; }

    public int IdFiliere { get; set; }
    public virtual Filiere Filiere { get; set; }

    // 1 Classe -> * Etudiants
    public int IdClasse { get; set; }
    public virtual Classe Classe { get; set; }

    public void ConsulterEDT() { }
}