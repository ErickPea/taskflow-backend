using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Interfaces.Repositories;

/// <summary>
/// Define las operaciones para administrar la relación
/// entre Usuarios y Roles.
/// </summary>
public interface IUsuarioRolRepository
{
    /// <summary>
    /// Obtiene todos los roles asignados a un usuario.
    /// </summary>
    /// <param name="usuarioId">
    /// Identificador del usuario.
    /// </param>
    Task<IEnumerable<UsuarioRol>> ObtenerPorUsuarioAsync(int usuarioId);

    /// <summary>
    /// Obtiene todos los usuarios asociados a un rol.
    /// </summary>
    /// <param name="rolId">
    /// Identificador del rol.
    /// </param>
    Task<IEnumerable<UsuarioRol>> ObtenerPorRolAsync(int rolId);

    /// <summary>
    /// Obtiene una relación específica entre un usuario y un rol.
    /// </summary>
    /// <param name="usuarioId">
    /// Identificador del usuario.
    /// </param>
    /// <param name="rolId">
    /// Identificador del rol.
    /// </param>
    Task<UsuarioRol?> ObtenerAsync(int usuarioId, int rolId);

    /// <summary>
    /// Asigna un rol a un usuario.
    /// </summary>
    /// <param name="usuarioRol">
    /// Relación a registrar.
    /// </param>
    Task<UsuarioRol> CrearAsync(UsuarioRol usuarioRol);

    /// <summary>
    /// Elimina un rol asignado a un usuario.
    /// </summary>
    /// <param name="usuarioRol">
    /// Relación a eliminar.
    /// </param>
    Task EliminarAsync(UsuarioRol usuarioRol);

    /// <summary>
    /// Verifica si una relación entre un usuario y un rol ya existe.
    /// </summary>
    /// <param name="usuarioId">
    /// Identificador del usuario.
    /// </param>
    /// <param name="rolId">
    /// Identificador del rol.
    /// </param>
    Task<bool> ExisteAsync(int usuarioId, int rolId);
}