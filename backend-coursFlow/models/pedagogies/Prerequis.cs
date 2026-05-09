namespace BackendCoursFlow.Models.Pedagogies;

public class Prerequis
{
    public int Id { get; set; }
    public int IdMatiere { get; set; }
    public int IdMatierePrerequis { get; set; }

    public Matiere Matiere { get; set; } = null!;

    public Matiere MatierePrerequis { get; set; } = null!;
}
