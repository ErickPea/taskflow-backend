using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.RolPermiso;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

/// Controlador encargado de gestionar las relaciones entre Roles y Permisos.
[ApiController]
[Route("api/[controller]")]
public class RolPermisoController : ControllerBase
{
    private readonly IRolPermisoService _rolPermisoService;
   
    /// Constructor del controlador.
    public RolPermisoController(IRolPermisoService rolPermisoService)
    {
        _rolPermisoService = rolPermisoService;
    }
   
    /// Obtiene todos los permisos asignados a un rol.
    /// <param name="rolId">Identificador del rol.</param>
    [HttpGet("rol/{rolId}")]
    public async Task<ActionResult<IEnumerable<RolPermisoDto>>> ObtenerPorRol(int rolId)
    {
        var relaciones = await _rolPermisoService.ObtenerPorRolAsync(rolId);

        return Ok(relaciones);
    }

    /// Obtiene todos los roles asociados a un permiso.
    /// <param name="permisoId">Identificador del permiso.</param>
    [HttpGet("permiso/{permisoId}")]
    public async Task<ActionResult<IEnumerable<RolPermisoDto>>> ObtenerPorPermiso(int permisoId)
    {
        var relaciones = await _rolPermisoService.ObtenerPorPermisoAsync(permisoId);

        return Ok(relaciones);
    }

    /// Obtiene una relación específica entre un rol y un permiso.
    /// <param name="rolId">Identificador del rol.</param>
    /// <param name="permisoId">Identificador del permiso.</param>
    [HttpGet("{rolId}/{permisoId}")]
    public async Task<ActionResult<RolPermisoDto>> Obtener(int rolId, int permisoId)
    {
        var relacion = await _rolPermisoService.ObtenerAsync(rolId, permisoId);

        if (relacion is null)
        {
            return NotFound();
        }

        return Ok(relacion);
    }
   
    /// Asigna un permiso a un rol.
    /// <param name="createRolPermisoDto">
    /// Datos necesarios para crear la relación.
    [HttpPost]
    public async Task<ActionResult<RolPermisoDto>> Crear(CreateRolPermisoDto createRolPermisoDto)
    {
        var relacion = await _rolPermisoService.CrearAsync(createRolPermisoDto);

        return CreatedAtAction(
            nameof(Obtener),
            new
            {
                rolId = relacion.RolId,
                permisoId = relacion.PermisoId
            },
            relacion);
    }

    /// Elimina la relación entre un rol y un permiso.
    /// <param name="rolId">Identificador del rol.</param>
    /// <param name="permisoId">Identificador del permiso.</param>
    [HttpDelete("{rolId}/{permisoId}")]
    public async Task<IActionResult> Eliminar(int rolId, int permisoId)
    {
        await _rolPermisoService.EliminarAsync(rolId, permisoId);

        return NoContent();
    }
}