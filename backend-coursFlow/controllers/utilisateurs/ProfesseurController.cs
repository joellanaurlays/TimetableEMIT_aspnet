namespace BackendCoursFlow.Controllers.Utilisateurs;

using Microsoft.AspNetCore.Mvc;
using BackendCoursFlow.Models.Utilisateurs;
using BackendCoursFlow.Services.Utilisateurs;


[ApiController]
[Route("api/[controller]")]
public class ProfesseurController : ControllerBase
{
    private readonly ProfesseurService _professeurService;

    public ProfesseurController(ProfesseurService professeurService)
    {
        _professeurService = professeurService;
    }

    // GET all
    [HttpGet]
    public async Task<ActionResult<List<Professeur>>> GetAll()
    {
        var professeurs = await _professeurService.GetAllProfesseursAsync();
        return Ok(professeurs);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<ActionResult<Professeur>> GetDetails(int id)
    {
        var professeur = await _professeurService.GetProfesseurDetailsAsync(id);

        if (professeur == null)
        {
            return NotFound(new { message = $"Le professeur avec l'ID {id} n'existe pas." });
        }

        return Ok(professeur);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Professeur professeur)
    {
        await _professeurService.CreateProfesseurAsync(professeur);
        return CreatedAtAction(nameof(GetDetails), new { id = professeur.IdProf }, professeur);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Professeur professeur)
    {
        if (id != professeur.IdProf)
        {
            return BadRequest("L'ID dans l'URL ne correspond pas à l'ID du professeur.");
        }

        await _professeurService.UpdateProfesseurAsync(professeur);
        return NoContent();
    }
}