namespace BackendCoursFlow.Services.Utilisateurs;

using Microsoft.EntityFrameworkCore;
using BackendCoursFlow.Donnees;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.EmploiDuTemps;

public class ProfesseurService
{
    private readonly ApplicationDbContext _context;

    public ProfesseurService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer tous les professeurs avec leurs infos de base (Utilisateur)
    public async Task<List<Professeur>> GetAllProfesseursAsync()
    {
        return await _context.Professeurs
            .Include(p => p.Utilisateur)
            .ToListAsync();
    }

    // Récupérer un professeur avec disponibilités, cours
    public async Task<Professeur?> GetProfesseurDetailsAsync(int id)
    {
        return await _context.Professeurs
            .Include(p => p.Utilisateur)
            .Include(p => p.Disponibilites)
            .Include(p => p.Cours)
                .ThenInclude(c => c.Matiere) // matiere demande
            .FirstOrDefaultAsync(p => p.IdProf == id);
    }

    // Ajout
    public async Task CreateProfesseurAsync(Professeur professeur)
    {
        _context.Professeurs.Add(professeur);
        await _context.SaveChangesAsync();
    }

    // Mis à jours spécialités ou grade
    public async Task UpdateProfesseurAsync(Professeur professeur)
    {
        _context.Entry(professeur).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}