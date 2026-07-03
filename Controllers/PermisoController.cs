using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.Permiso;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

/// Controlador encargado de gestionar las operaciones relacionadas con los permisos.
[ApiController]
[Route("api/[controller]")]
public class PermisoController : ControllerBase
{
    private readonly IPermisoService _permisoService;

    /// Constructor del controlador.
    /// <param name="permisoService">
    /// Servicio encargado de la lógica de negocio de los permisos.
    public PermisoController(IPermisoService permisoService)
    {
        _permisoService = permisoService;
    }


    /// Obtiene todos los permisos registrados.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PermisoDto>>> ObtenerTodos()
    {
        var permisos = await _permisoService.ObtenerTodosAsync();

        return Ok(permisos);
    }


    /// Obtiene un permiso por su identificador.
    /// <param name="id">
    /// Identificador del permiso.
    [HttpGet("{id}")]
    public async Task<ActionResult<PermisoDto>> ObtenerPorId(int id)
    {
        var permiso = await _permisoService.ObtenerPorIdAsync(id);

        if (permiso is null)
        {
            return NotFound();
        }

        return Ok(permiso);
    }


    /// Crea un nuevo permiso.
    /// <param name="createPermisoDto">
    /// Datos necesarios para crear el permiso.
    [HttpPost]
    public async Task<ActionResult<PermisoDto>> Crear(CreatePermisoDto createPermisoDto)
    {
        var permiso = await _permisoService.CrearAsync(createPermisoDto);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = permiso.Id },
            permiso);
    }


    /// Elimina un permiso por su identificador.
    /// <param name="id">
    /// Identificador del permiso.
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _permisoService.EliminarAsync(id);

        return NoContent();
    }
}