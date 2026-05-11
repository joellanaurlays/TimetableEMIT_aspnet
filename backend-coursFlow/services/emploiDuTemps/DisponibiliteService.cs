namespace BackendCoursFlow.Services.EmploiDuTemps;

using Microsoft.EntityFrameworkCore;

using BackendCoursFlow.Donnees;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Models.Pedagogies;
using BackendCoursFlow.Models.EmploiDuTemps;

public class DisponibiliteService
{
    private readonly ApplicationDbContext _context;

    public DisponibiliteService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer toutes les disponibilités d'un professeur
    public async Task<List<Disponibilite>> GetByProfesseurAsync(int profId)
    {
        return await _context.Disponibilites
            .Where(d => d.IdProf == profId)
            .OrderBy(d => d.Jour)
            .ThenBy(d => d.HeureDebut)
            .ToListAsync();
    }

    // Ajout d'une disponibilité 
    public async Task<bool> CreateDisponibiliteAsync(Disponibilite dispo)
    {
        // Logique de vérification : est-ce que le prof a déjà un créneau qui chevauche avec celui-ci ?
        bool hasConflict = await _context.Disponibilites.AnyAsync(d =>
            d.IdProf == dispo.IdProf &&
            d.Jour == dispo.Jour &&
            ((dispo.HeureDebut >= d.HeureDebut && dispo.HeureDebut < d.HeureFin) ||
             (dispo.HeureFin > d.HeureDebut && dispo.HeureFin <= d.HeureFin)));

        if (hasConflict) return false;

        _context.Disponibilites.Add(dispo);
        await _context.SaveChangesAsync();
        return true;
    }

    // Suppression
    public async Task DeleteDisponibiliteAsync(int id)
    {
        var dispo = await _context.Disponibilites.FindAsync(id);
        if (dispo != null)
        {
            _context.Disponibilites.Remove(dispo);
            await _context.SaveChangesAsync();
        }
    }
}