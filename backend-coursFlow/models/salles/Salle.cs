namespace BackendCoursFlow.Models.Salles;

public class Salle
{
    public int IdSalle { get; set; }
    public required string Nom { get; set; }
    public required string Batiment { get; set; }
    public int Capacite { get; set; }
    public required TypeSalleEnum Type { get; set; }
    
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

