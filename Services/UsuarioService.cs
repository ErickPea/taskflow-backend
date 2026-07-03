using TaskFlow.Api.DTOs.Usuario;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Services;

/// Servicio encargado de gestionar la lógica de negocio relacionada con usuarios.
/// Responsabilidades:
/// - Validar reglas de negocio.
/// - Transformar DTOs en Entidades.
/// - Transformar Entidades en DTOs.
/// - Coordinar la comunicación con los repositorios.
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    /// Constructor del servicio.
    /// Recibe el repositorio mediante Inyección de Dependencias.
    /// <param name="usuarioRepository">
    /// Repositorio encargado del acceso a datos de usuarios.

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    /// Obtiene todos los usuarios registrados.
    /// Lista de usuarios convertidos a DTO.
  
    public async Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync()
    {
        var usuarios = await _usuarioRepository.ObtenerTodosAsync();

        return usuarios.Select(usuario => new UsuarioDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            Activo = usuario.Activo
        });
    }
    /// Obtiene un usuario por su identificador.
    /// <param name="id">Id del usuario.</param>
    /// Usuario encontrado o null si no existe.
  
    public async Task<UsuarioDto?> ObtenerPorIdAsync(int id)
    {
        var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

        if (usuario is null)
            return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            Activo = usuario.Activo
        };
    }

    /// Crea un nuevo usuario.
    /// <param name="createUsuarioDto">
    /// Información enviada desde el cliente.
    /// Usuario creado.
    /// <exception cref="Exception">
    /// Se lanza si el correo ya existe.
    public async Task<UsuarioDto> CrearAsync(CreateUsuarioDto createUsuarioDto)
    {
        var existeEmail = await _usuarioRepository
            .ExisteEmailAsync(createUsuarioDto.Email);

        if (existeEmail)
        {
            throw new Exception(
                "Ya existe un usuario registrado con ese correo.");
        }

        var usuario = new Usuario
        {
            Nombre = createUsuarioDto.Nombre,
            Apellido = createUsuarioDto.Apellido,
            Email = createUsuarioDto.Email,

            // Temporalmente almacenamos el texto plano.
            // Más adelante utilizaremos BCrypt.
            PasswordHash = createUsuarioDto.Password,

            Activo = true,

            FechaRegistro = DateTime.UtcNow,

            CreatedAt = DateTime.UtcNow
        };

        await _usuarioRepository.CrearAsync(usuario);

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            Activo = usuario.Activo
        };
    }

    /// Elimina un usuario por Id.
    /// <param name="id">
    /// Identificador del usuario.
    public async Task EliminarAsync(int id)
    {
        var usuario = await _usuarioRepository
            .ObtenerPorIdAsync(id);

        if (usuario is null)
        {
            throw new Exception(
                $"No existe un usuario con Id {id}");
        }

        await _usuarioRepository.EliminarAsync(usuario);
    }
}