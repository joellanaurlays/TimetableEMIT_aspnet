namespace BackendCoursFlow.Services.Utilisateurs;

using Microsoft.EntityFrameworkCore;

using BackendCoursFlow.Donnees;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.EmploiDuTemps;

public class EtudiantService
{
    private readonly ApplicationDbContext _context;

    // Injection de dépendances pour l'accéder au BD
    public EtudiantService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer tous les étudiants avec ses relations
    public async Task<List<Etudiant>> GetAllEtudiantsAsync()
    {
        return await _context.Etudiants
            .Include(e => e.Filiere)
            .Include(e => e.Classe)
            .Include(e => e.Utilisateur)
            .ToListAsync();
    }

    // Récupérer un étudiant par son ID
    public async Task<Etudiant?> GetEtudiantByIdAsync(int id)
    {
        return await _context.Etudiants
            .Include(e => e.Filiere)
            .Include(e => e.Classe)
            .FirstOrDefaultAsync(e => e.IdEtudiant == id);
    }

    // Ajout
    public async Task CreateEtudiantAsync(Etudiant etudiant)
    {
        _context.Etudiants.Add(etudiant);
        await _context.SaveChangesAsync();
    }

    // Suppression
    public async Task DeleteEtudiantAsync(int id)
    {
        var etudiant = await _context.Etudiants.FindAsync(id);
        if (etudiant != null)
        {
            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();
        }
    }
}