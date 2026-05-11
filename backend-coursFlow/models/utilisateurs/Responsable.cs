namespace BackendCoursFlow.Models.Utilisateurs;

using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.EmploiDuTemps;
using BackendCoursFlow.Models.Enums;

public class Responsable : Utilisateur
{
   public int IdResp { get; set; }

   public Responsable()
    {
        Role = Role.RESPONSABLE;
    }
    
    public void AjouterClasse(Classe classe)
    {
        // Logique pour ajouter une classe
    }
}