namespace BackendCoursFlow.Models.Salles;

using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Salle
{
    [Key]
    public int IdSalle { get; set; }
    public required string Nom { get; set; }
    public required string Batiment { get; set; }
    public int Capacite { get; set; }
    public required TypeSalle Type { get; set; }
    
    public ICollection<Cours> Cours { get; set; } = new List<Cours>();
    
    public void AjouterSalle()
    {
        // Logique pour ajouter une salle
    }
    
    public void ModifierSalle()
    {
        // Logique pour modifier une salle
    }
}

