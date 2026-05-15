namespace BackendCoursFlow.Controllers.Utilisateurs;

using Microsoft.AspNetCore.Mvc;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Services.Utilisateurs;


[ApiController]
[Route("api/[controller]")]
public class EtudiantController : ControllerBase
{
    private readonly EtudiantService _etudiantService;

    public EtudiantController(EtudiantService etudiantService)
    {
        _etudiantService = etudiantService;
    }

    // GET all
    [HttpGet]
    public async Task<ActionResult<List<Etudiant>>> GetAll()
    {
        var etudiants = await _etudiantService.GetAllEtudiantsAsync();
        return Ok(etudiants);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<ActionResult<Etudiant>> GetById(int id)
    {
        var etudiant = await _etudiantService.GetEtudiantByIdAsync(id);

        if (etudiant == null)
        {
            return NotFound(new { message = $"L'étudiant avec l'ID {id} n'a pas été trouvé." });
        }

        return Ok(etudiant);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Etudiant etudiant)
    {
        await _etudiantService.CreateEtudiantAsync(etudiant);

        return CreatedAtAction(nameof(GetById), new { id = etudiant.IdEtudiant }, etudiant);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _etudiantService.DeleteEtudiantAsync(id);
        return NoContent();
    }
}