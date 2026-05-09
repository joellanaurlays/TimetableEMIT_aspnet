namespace BackendCoursFlow.Models.Pedagogies;

public class Matiere
{
    public int IdMatiere { get; set; }
    public required string Code { get; set; }
    public required string Nom { get; set; }
    public string? Description { get; set; }
    public int Credit { get; set; }
    
    public ICollection<Cours> Cours { get; set; } = new List<Cours>();
    public ICollection<Prerequis> Prerequis { get; set; } = new List<Prerequis>();
    
    public void AjouterMatiere()
    {
        // Logique pour ajouter une matière
    }

    public void ModifierMatiere()
    {
        // Logique pour modifier une matière
    }
}


