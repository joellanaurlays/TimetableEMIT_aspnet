namespace  BackendCoursFlow.Models.Utilisateurs;

using BackendCoursFlow.Models.Enums;

public class Admin : Utilisateur
{
    public int IdAdmin { get; set; }
    public Admin()
    {
        Role = Role.ADMIN;
    }
}
    