using TaskFlow.Api.DTOs.RolPermiso;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Services;

/// Servicio encargado de la lógica de negocio de las relaciones
/// entre Roles y Permisos.
public class RolPermisoService : IRolPermisoService
{
    private readonly IRolPermisoRepository _rolPermisoRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IPermisoRepository _permisoRepository;

   
    /// Constructor del servicio.
    public RolPermisoService(
        IRolPermisoRepository rolPermisoRepository,
        IRolRepository rolRepository,
        IPermisoRepository permisoRepository)
    {
        _rolPermisoRepository = rolPermisoRepository;
        _rolRepository = rolRepository;
        _permisoRepository = permisoRepository;
    }

   
    /// Obtiene todos los permisos asignados a un rol.
    public async Task<IEnumerable<RolPermisoDto>> ObtenerPorRolAsync(int rolId)
    {
        var relaciones = await _rolPermisoRepository.ObtenerPorRolAsync(rolId);

        return relaciones.Select(rp => new RolPermisoDto
        {
            RolId = rp.RolId,
            NombreRol = rp.Rol.Nombre,
            PermisoId = rp.PermisoId,
            NombrePermiso = rp.Permiso.Nombre
        });
    }

   
    /// Obtiene todos los roles asociados a un permiso.
    public async Task<IEnumerable<RolPermisoDto>> ObtenerPorPermisoAsync(int permisoId)
    {
        var relaciones = await _rolPermisoRepository.ObtenerPorPermisoAsync(permisoId);

        return relaciones.Select(rp => new RolPermisoDto
        {
            RolId = rp.RolId,
            NombreRol = rp.Rol.Nombre,
            PermisoId = rp.PermisoId,
            NombrePermiso = rp.Permiso.Nombre
        });
    }

   
    /// Obtiene una relación específica.
    public async Task<RolPermisoDto?> ObtenerAsync(int rolId, int permisoId)
    {
        var relacion = await _rolPermisoRepository.ObtenerAsync(rolId, permisoId);

        if (relacion is null)
            return null;

        return new RolPermisoDto
        {
            RolId = relacion.RolId,
            NombreRol = relacion.Rol.Nombre,
            PermisoId = relacion.PermisoId,
            NombrePermiso = relacion.Permiso.Nombre
        };
    }

   
    /// Asigna un permiso a un rol.
    public async Task<RolPermisoDto> CrearAsync(CreateRolPermisoDto dto)
    {
        var rol = await _rolRepository.ObtenerPorIdAsync(dto.RolId);

        if (rol is null)
        {
            throw new Exception($"No existe un rol con Id {dto.RolId}");
        }

        var permiso = await _permisoRepository.ObtenerPorIdAsync(dto.PermisoId);

        if (permiso is null)
        {
            throw new Exception($"No existe un permiso con Id {dto.PermisoId}");
        }

        var existe = await _rolPermisoRepository.ExisteAsync(dto.RolId, dto.PermisoId);

        if (existe)
        {
            throw new Exception("El permiso ya está asignado a este rol.");
        }

        var rolPermiso = new RolPermiso
        {
            RolId = dto.RolId,
            PermisoId = dto.PermisoId
        };

        await _rolPermisoRepository.CrearAsync(rolPermiso);

        return new RolPermisoDto
        {
            RolId = rol.Id,
            NombreRol = rol.Nombre,
            PermisoId = permiso.Id,
            NombrePermiso = permiso.Nombre
        };
    }

   
    /// Elimina la relación entre un rol y un permiso.
    public async Task EliminarAsync(int rolId, int permisoId)
    {
        var relacion = await _rolPermisoRepository.ObtenerAsync(rolId, permisoId);

        if (relacion is null)
        {
            throw new Exception("La relación entre el rol y el permiso no existe.");
        }

        await _rolPermisoRepository.EliminarAsync(relacion);
    }
}