namespace BackendCoursFlow.Models.Utilisateurs;

using BackendCoursFlow.Models.Enums;

public class Utilisateur
{
    public int Id { get; set; }
    public required string Nom { get; set; }
    public required string Prenom { get; set; }
    public required string Email { get; set; }
    public required string MotDePasse { get; set; }
    public required string Telephone { get; set; }
    public required Role Role { get; set; }  

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public bool SeConnecter()
    {
        // Logique de connexion
        return true;
    }
    
    public bool Deconnecter()
    {
        // Logique de déconnexion
        return true;
    }
}