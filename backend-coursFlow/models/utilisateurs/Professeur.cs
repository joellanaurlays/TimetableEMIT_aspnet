using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Professeur
{
    [Key]
    public int IdProf { get; set; }

    public required string Grade { get; set; }
    public required string Specialite { get; set; }

    [ForeignKey("Utilisateur")]
    public int UtilisateurId { get; set; }
    public virtual Utilisateur Utilisateur { get; set; }

    // Relations
    public virtual ICollection<Cours> Cours { get; set; } = new List<Cours>();
    public virtual ICollection<Disponibilite> Disponibilites { get; set; } = new List<Disponibilite>();

    protected void AjouterDisponibilite() { }
    protected void ConsulterEDT() { }
}