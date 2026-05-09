namespace BackendCoursFlow.Models.Utilisateurs;

public class Responsable : Utilisateur
{
   public int IdResp { get; set; }

   public Responsable()
    {
        Role = RoleEnum.RESPONSABLE;
    }
    
    public void AjouterClasse(Classe classe)
    {
        // Logique pour ajouter une classe
    }
}