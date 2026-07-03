using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.Rol;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

/// Controlador encargado de gestionar las operaciones relacionadas con los roles.
[ApiController]
[Route("api/[controller]")]
public class RolController : ControllerBase
{
    private readonly IRolService _rolService;
    /// Constructor del controlador.
    /// <param name="rolService">
    /// Servicio encargado de la lógica de negocio de los roles.
    public RolController(IRolService rolService)
    {
        _rolService = rolService;
    }

    /// Obtiene todos los roles registrados.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RolDto>>> ObtenerTodos()
    {
        var roles = await _rolService.ObtenerTodosAsync();

        return Ok(roles);
    }

    /// Obtiene un rol por su identificador.
    /// <param name="id">
    /// Identificador del rol.
    [HttpGet("{id}")]
    public async Task<ActionResult<RolDto>> ObtenerPorId(int id)
    {
        var rol = await _rolService.ObtenerPorIdAsync(id);

        if (rol is null)
        {
            return NotFound();
        }

        return Ok(rol);
    }

    /// Crea un nuevo rol.
    /// <param name="createRolDto">
    /// Datos necesarios para crear el rol.
    [HttpPost]
    public async Task<ActionResult<RolDto>> Crear(CreateRolDto createRolDto)
    {
        var rol = await _rolService.CrearAsync(createRolDto);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = rol.Id },
            rol);
    }

    /// Elimina un rol por su identificador.
    /// <param name="id">
    /// Identificador del rol.
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _rolService.EliminarAsync(id);

        return NoContent();
    }
}