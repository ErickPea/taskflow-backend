using TaskFlow.Api.DTOs.UsuarioRol;

namespace TaskFlow.Api.Interfaces.Services;

/// <summary>
/// Define las operaciones de negocio para la gestión
/// de las relaciones entre Usuarios y Roles.
/// </summary>
public interface IUsuarioRolService
{
    /// <summary>
    /// Obtiene todos los roles asignados a un usuario.
    /// </summary>
    /// <param name="usuarioId">
    /// Identificador del usuario.
    /// </param>
    Task<IEnumerable<UsuarioRolDto>> ObtenerPorUsuarioAsync(int usuarioId);

    /// <summary>
    /// Obtiene todos los usuarios asociados a un rol.
    /// </summary>
    /// <param name="rolId">
    /// Identificador del rol.
    /// </param>
    Task<IEnumerable<UsuarioRolDto>> ObtenerPorRolAsync(int rolId);

    /// <summary>
    /// Obtiene una relación específica entre un usuario y un rol.
    /// </summary>
    /// <param name="usuarioId">
    /// Identificador del usuario.
    /// </param>
    /// <param name="rolId">
    /// Identificador del rol.
    /// </param>
    Task<UsuarioRolDto?> ObtenerAsync(int usuarioId, int rolId);

    /// <summary>
    /// Asigna un rol a un usuario.
    /// </summary>
    /// <param name="createUsuarioRolDto">
    /// Datos necesarios para crear la relación.
    /// </param>
    Task<UsuarioRolDto> CrearAsync(CreateUsuarioRolDto createUsuarioRolDto);

    /// <summary>
    /// Elimina la relación entre un usuario y un rol.
    /// </summary>
    /// <param name="usuarioId">
    /// Identificador del usuario.
    /// </param>
    /// <param name="rolId">
    /// Identificador del rol.
    /// </param>
    Task EliminarAsync(int usuarioId, int rolId);
}