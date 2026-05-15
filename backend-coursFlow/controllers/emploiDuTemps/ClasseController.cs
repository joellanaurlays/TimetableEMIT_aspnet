namespace BackendCoursFlow.Controllers.EmploiDuTemps;

using Microsoft.AspNetCore.Mvc;
using BackendCoursFlow.Models.EmploiDuTemps;
using BackendCoursFlow.Services.EmploiDuTemps;

[ApiController]
[Route("api/[controller]")]
public class ClasseController : ControllerBase
{
	private readonly ClasseService _classeService;

	public ClasseController(ClasseService classeService)
	{
		_classeService = classeService;
	}

	// GET
	[HttpGet]
	public async Task<ActionResult<List<Classe>>> GetAll()
	{
		var classe = await _classeService.GetAllClassesAsync();
		return Ok(classe);
	}


	[HttpGet("{id}")]
	public async Task<ActionResult<Classe>> GetById(int id)
	{
		var classe = await _classeService.GetClasseWithCoursAsync(id);

		if(classe == null)
		{
			return NotFound($"La classe avec l'ID {id} n'existe pas.");
		}
		return Ok(classe);
	}

	[HttpGet("filiere/{filiereId}")]
	public async Task<ActionResult<List<Classe>>> GetByFiliere(int filiereId)
	{
		var classe = await _classeService.GetClassesByFiliereAsync(filiereId);
		return Ok(classe);
	}

	// POST
	[HttpPost]
	public async Task<IActionResult> Create(Classe classe)
	{
		await _classeService.CreateClasseAsync(classe);
		return CreatedAtAction(nameof(GetById), new { id = classe.IdClasse }, classe);
	}

	// DELETE
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _classeService.DeleteClasseAsync(id);
		return NoContent();
	}
}
