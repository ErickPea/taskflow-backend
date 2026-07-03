using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.UsuarioRol;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

/// <summary>
/// Controlador encargado de gestionar la relación
/// entre Usuarios y Roles.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsuarioRolController : ControllerBase
{
    private readonly IUsuarioRolService _usuarioRolService;

    /// <summary>
    /// Constructor del controlador.
    /// </summary>
    public UsuarioRolController(IUsuarioRolService usuarioRolService)
    {
        _usuarioRolService = usuarioRolService;
    }

    /// <summary>
    /// Obtiene todos los roles asignados a un usuario.
    /// </summary>
    [HttpGet("usuario/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<UsuarioRolDto>>> ObtenerPorUsuario(int usuarioId)
    {
        var relaciones = await _usuarioRolService.ObtenerPorUsuarioAsync(usuarioId);

        return Ok(relaciones);
    }

    /// <summary>
    /// Obtiene todos los usuarios asociados a un rol.
    /// </summary>
    [HttpGet("rol/{rolId}")]
    public async Task<ActionResult<IEnumerable<UsuarioRolDto>>> ObtenerPorRol(int rolId)
    {
        var relaciones = await _usuarioRolService.ObtenerPorRolAsync(rolId);

        return Ok(relaciones);
    }

    /// <summary>
    /// Obtiene una relación específica entre un usuario y un rol.
    /// </summary>
    [HttpGet("{usuarioId}/{rolId}")]
    public async Task<ActionResult<UsuarioRolDto>> Obtener(int usuarioId, int rolId)
    {
        var relacion = await _usuarioRolService.ObtenerAsync(usuarioId, rolId);

        if (relacion is null)
            return NotFound();

        return Ok(relacion);
    }

    /// <summary>
    /// Asigna un rol a un usuario.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<UsuarioRolDto>> Crear(CreateUsuarioRolDto dto)
    {
        var relacion = await _usuarioRolService.CrearAsync(dto);

        return CreatedAtAction(
            nameof(Obtener),
            new
            {
                usuarioId = relacion.UsuarioId,
                rolId = relacion.RolId
            },
            relacion);
    }

    /// <summary>
    /// Elimina la relación entre un usuario y un rol.
    /// </summary>
    [HttpDelete("{usuarioId}/{rolId}")]
    public async Task<IActionResult> Eliminar(int usuarioId, int rolId)
    {
        await _usuarioRolService.EliminarAsync(usuarioId, rolId);

        return NoContent();
    }
}