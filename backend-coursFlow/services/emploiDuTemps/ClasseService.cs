namespace BackendCoursFlow.Services.EmploiDuTemps;

using Microsoft.EntityFrameworkCore;

using BackendCoursFlow.Donnees;       
using BackendCoursFlow.Models.Pedagogies;   
using BackendCoursFlow.Models.EmploiDuTemps;

public class ClasseService
{
    private readonly ApplicationDbContext _context;

    public ClasseService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer toutes les classes avec filière
    public async Task<List<Classe>> GetAllClassesAsync()
    {
        return await _context.Classes
            .Include(c => c.Filiere)
            .ToListAsync();
    }

    // Récupérer une classe avec son EDT (cours)
    public async Task<Classe?> GetClasseWithCoursAsync(int id)
    {
        return await _context.Classes
            .Include(c => c.Filiere)
            .Include(c => c.Cours)
                .ThenInclude(cours => cours.Matiere) // cours
            .Include(c => c.Cours)
                .ThenInclude(cours => cours.Professeur) // prof
            .FirstOrDefaultAsync(c => c.IdClasse == id);
    }

    // Récupérer toutes les classes d'une filière 
    public async Task<List<Classe>> GetClassesByFiliereAsync(int filiereId)
    {
        return await _context.Classes
            .Where(c => c.IdFiliere == filiereId)
            .ToListAsync();
    }

    // Ajout
    public async Task CreateClasseAsync(Classe classe)
    {
        _context.Classes.Add(classe);
        await _context.SaveChangesAsync();
    }

    // Suppression
    public async Task DeleteClasseAsync(int id)
    {
        var classe = await _context.Classes.FindAsync(id);
        if (classe != null)
        {
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }
    }
}