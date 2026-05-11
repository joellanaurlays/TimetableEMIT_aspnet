namespace BackendCoursFlow.Models.Pedagogies;

using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Models.EmploiDuTemps;
using BackendCoursFlow.Models.Salles;
using System.ComponentModel.DataAnnotations;

public class Cours
{
    [Key]
    public int IdCours { get; set; }
    public required string AnneeUniversitaire { get; set; }
    public required string Semestre { get; set; }
    public int Duree { get; set; }
    public int VolumeHoraire { get; set; }

    // Clés étrangères explicites pour le DbContext
    public int IdMatiere { get; set; }
    public int IdProf { get; set; }
    public int IdClasse { get; set; }
    public int IdSalle { get; set; }

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