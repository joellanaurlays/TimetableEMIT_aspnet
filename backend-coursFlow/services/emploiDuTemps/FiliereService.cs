namespace BackendCoursFlow.Services.EmploiDuTemps;

using Microsoft.EntityFrameworkCore;

using BackendCoursFlow.Donnees;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.EmploiDuTemps;

public class FiliereService
{
    private readonly ApplicationDbContext _context;

    public FiliereService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer toutes les filières
    public async Task<List<Filiere>> GetAllFilieresAsync()
    {
        return await _context.Filieres.ToListAsync();
    }

    // Récupérer une filière avec ses classes 
    public async Task<Filiere?> GetFiliereWithClassesAsync(int id)
    {
        return await _context.Filieres
            .Include(f => f.Classes)
            .FirstOrDefaultAsync(f => f.IdFiliere == id);
    }

    // Ajout d'une filière
    public async Task CreateFiliereAsync(Filiere filiere)
    {
        _context.Filieres.Add(filiere);
        await _context.SaveChangesAsync();
    }

    // Mettre à jour une filière
    public async Task UpdateFiliereAsync(Filiere filiere)
    {
        _context.Entry(filiere).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // Suppression d'une filière
    public async Task DeleteFiliereAsync(int id)
    {
        var filiere = await _context.Filieres.FindAsync(id);
        if (filiere != null)
        {
            _context.Filieres.Remove(filiere);
            await _context.SaveChangesAsync();
        }
    }
}