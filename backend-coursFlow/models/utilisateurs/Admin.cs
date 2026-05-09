namespace  BackendCoursFlow.Utilisateurs.Models;

public class Admin : Utilisateur
{
    public int IdAdmin { get; set; }
    public Admin()
    {
        Role = RoleEnum.ADMIN;
    }
}
    