namespace BackendCoursFlow.Models.Pedagogies;

using System.ComponentModel.DataAnnotations;
using BackendCoursFlow.Models.Enums;

public class EmploiDuTemps
{
    [Key]
    public int IdEmploi { get; set; }
    public required JourSemaine Jour { get; set; }
    public required TimeSpan HeureDebut { get; set; }
    public required TimeSpan HeureFin { get; set; }
    public required DateTime DateDebut { get; set; }
    public required DateTime DateFin { get; set; }
    
    public ICollection<Cours> Cours { get; set; } = new List<Cours>();

    public void GenererPDF()
    {
        // Logique pour générer un PDF
    }
    
    public void AfficherEmploi()
    {
        // Logique pour afficher l'emploi du temps
    }
}
    
    
    