using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.Usuario;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

/// Controlador encargado de gestionar las operaciones
/// relacionadas con los usuarios del sistema.

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    /// Constructor del controlador.
    /// Recibe el servicio mediante Inyección de Dependencias.
    /// <param name="usuarioService">
    /// Servicio encargado de la lógica de negocio de usuarios.
    
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    /// Obtiene todos los usuarios registrados.
    /// Lista de usuarios.
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> ObtenerTodos()
    {
        var usuarios = await _usuarioService.ObtenerTodosAsync();

        return Ok(usuarios);
    }
    
    /// Obtiene un usuario por su identificador.
    /// <param name="id">
    /// Id del usuario.
    /// Usuario encontrado.
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> ObtenerPorId(int id)
    {
        var usuario = await _usuarioService.ObtenerPorIdAsync(id);

        if (usuario is null)
        {
            return NotFound(
                $"No existe un usuario con Id {id}");
        }

        return Ok(usuario);
    }

    
    /// Registra un nuevo usuario en el sistema.
    /// <param name="createUsuarioDto">
    /// Información del usuario a registrar.
    /// Usuario creado.
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsuarioDto>> Crear(
        CreateUsuarioDto createUsuarioDto)
    {
        var usuario = await _usuarioService
            .CrearAsync(createUsuarioDto);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = usuario.Id },
            usuario);
    }

   
    /// Elimina un usuario existente.
    /// <param name="id">
    /// Id del usuario a eliminar.
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _usuarioService.EliminarAsync(id);

        return NoContent();
    }
}