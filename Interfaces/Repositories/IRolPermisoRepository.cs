using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Interfaces.Repositories;

/// Define las operaciones para administrar la relación entre Roles y Permisos.
public interface IRolPermisoRepository
{

    /// Obtiene todos los permisos asignados a un rol.
    /// <param name="rolId">
    /// Identificador del rol.
    Task<IEnumerable<RolPermiso>> ObtenerPorRolAsync(int rolId);

    /// Obtiene todos los roles asociados a un permiso.
    /// <param name="permisoId">
    /// Identificador del permiso.
    Task<IEnumerable<RolPermiso>> ObtenerPorPermisoAsync(int permisoId);

    /// Obtiene una relación específica entre un rol y un permiso.
    /// <param name="rolId">
    /// Identificador del rol.
    /// <param name="permisoId">
    /// Identificador del permiso.
    Task<RolPermiso?> ObtenerAsync(int rolId, int permisoId);

    /// Asigna un permiso a un rol.
    /// <param name="rolPermiso">
    /// Relación a registrar.
    Task<RolPermiso> CrearAsync(RolPermiso rolPermiso);

    /// Elimina un permiso de un rol.
    /// <param name="rolPermiso">
    /// Relación a eliminar.
    Task EliminarAsync(RolPermiso rolPermiso);

    /// Verifica si una relación ya existe.
    Task<bool> ExisteAsync(int rolId, int permisoId);
}