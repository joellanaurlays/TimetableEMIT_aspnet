namespace BackendCoursFlow.Models.EmploiDuTemps;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.Utilisateurs;

public class Classe
{
    [Key]
    public int IdClasse { get; set; }

    public required string Nom { get; set; }
    public required string Niveau { get; set; }
    public required string Groupe { get; set; }

    [ForeignKey("Filiere")]
    public int IdFiliere { get; set; }
    public virtual Filiere Filiere { get; set; } = default!;

    // 1 Classe has * Cours
    public virtual ICollection<Cours> Cours { get; set; } = new List<Cours>();

    public void AjouterClasse() { }
}