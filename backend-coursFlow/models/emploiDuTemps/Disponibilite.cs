using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Disponibilite
{
    [Key]
    public int IdDispo { get; set; }
    public JourSemaine Jour { get; set; }
    public TimeSpan HeureDebut { get; set; }
    public TimeSpan HeureFin { get; set; }
    public TypeDisponibilite Type { get; set; }

    [ForeignKey("Professeur")]
    public int ProfesseurId { get; set; }
    public virtual Professeur Professeur { get; set; }

    public void AjouterDisponibilite() { }
    public void ModifierDisponibilite() { }
    public void SupprimerDisponibilite() { }
}