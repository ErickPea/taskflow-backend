using TaskFlow.Api.DTOs.RolPermiso;

namespace TaskFlow.Api.Interfaces.Services;

/// Define las operaciones de negocio para la gestión
/// de las relaciones entre Roles y Permisos.
public interface IRolPermisoService
{
  
    /// Obtiene todos los permisos asignados a un rol.
    /// <param name="rolId">
    /// Identificador del rol.
    Task<IEnumerable<RolPermisoDto>> ObtenerPorRolAsync(int rolId);

    /// Obtiene todos los roles asociados a un permiso.
    /// <param name="permisoId">
    /// Identificador del permiso.
    Task<IEnumerable<RolPermisoDto>> ObtenerPorPermisoAsync(int permisoId);
  
    /// Obtiene una relación específica entre un rol y un permiso.
    /// <param name="rolId">
    /// Identificador del rol.
    /// <param name="permisoId">
    /// Identificador del permiso.
    Task<RolPermisoDto?> ObtenerAsync(int rolId, int permisoId);
  
    /// Asigna un permiso a un rol.
    /// <param name="createRolPermisoDto">
    /// Datos necesarios para crear la relación.
    Task<RolPermisoDto> CrearAsync(CreateRolPermisoDto createRolPermisoDto);
  
    /// Elimina la relación entre un rol y un permiso.
    /// <param name="rolId">
    /// Identificador del rol.
    /// <param name="permisoId">
    /// Identificador del permiso.
    Task EliminarAsync(int rolId, int permisoId);
}