namespace BackendCoursFlow.Controllers.EmploiDuTemps;

using Microsoft.AspNetCore.Mvc;
using BackendCoursFlow.Models.EmploiDuTemps;
using BackendCoursFlow.Services.EmploiDuTemps;

[ApiController]
[Route("api/[controller]")]
public class FiliereController : ControllerBase
{
    private readonly FiliereService _filiereService;

    public FiliereController(FiliereService filiereService)
    {
        _filiereService = filiereService;
    }

    // GET all
    [HttpGet]
    public async Task<ActionResult<List<Filiere>>> GetAll()
    {
        var filieres = await _filiereService.GetAllFilieresAsync();
        return Ok(filieres);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<ActionResult<Filiere>> GetById(int id)
    {
        var filiere = await _filiereService.GetFiliereWithClassesAsync(id);

        if (filiere == null)
        {
            return NotFound($"La filière avec l'ID {id} n'a pas été trouvée.");
        }

        return Ok(filiere);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Filiere filiere)
    {
        await _filiereService.CreateFiliereAsync(filiere);
        return CreatedAtAction(nameof(GetById), new { id = filiere.IdFiliere }, filiere);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Filiere filiere)
    {
        if (id != filiere.IdFiliere)
        {
            return BadRequest("L'ID dans l'URL ne correspond pas à l'ID de l'objet.");
        }

        await _filiereService.UpdateFiliereAsync(filiere);
        return NoContent(); // Réponse standard 204 pour une mise à jour réussie
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _filiereService.DeleteFiliereAsync(id);
        return NoContent();
    }
}