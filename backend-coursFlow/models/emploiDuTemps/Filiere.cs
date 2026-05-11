namespace BackendCoursFlow.Models.EmploiDuTemps;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.Utilisateurs;

public class Filiere
{
    [Key]
    public int IdFiliere { get; set; }

    public required string Nom { get; set; }
    public required string Description { get; set; }

    // Navigation properties
    public virtual ICollection<Etudiant> Etudiants { get; set; } = new List<Etudiant>();
    public virtual ICollection<Classe> Classes { get; set; } = new List<Classe>();

    // Methodes
    public void AjouterFiliere() {  }
}