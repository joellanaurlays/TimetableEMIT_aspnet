namespace BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.Matiere;
public class Cours
{
    public int IdCours { get; set; }
    public required string AnneeUniversitaire { get; set; }
    public required string Semestre { get; set; }
    public int Duree { get; set; }
    public int VolumeHoraire { get; set; }

    public required Matiere Matiere { get; set; }
    public required Matiere Matiere { get; set; }
    public required Professeur Professeur { get; set; }
    public required Classe Classe { get; set; }
    public required Salle Salle { get; set; }
    public required EmploiDuTemps EmploiDuTemps { get; set; }
    
    public void EffecterCours()
    {
        // Logique pour effecter un cours
    }
}