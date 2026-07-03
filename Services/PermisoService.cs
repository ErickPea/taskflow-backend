using TaskFlow.Api.DTOs.Permiso;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Services;

/// Servicio encargado de la lógica de negocio de los permisos.
public class PermisoService : IPermisoService
{
    private readonly IPermisoRepository _permisoRepository;


    /// Constructor del servicio.
    public PermisoService(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }


    /// Obtiene todos los permisos.
    public async Task<IEnumerable<PermisoDto>> ObtenerTodosAsync()
    {
        var permisos = await _permisoRepository.ObtenerTodosAsync();

        return permisos.Select(permiso => new PermisoDto
        {
            Id = permiso.Id,
            Nombre = permiso.Nombre,
            Descripcion = permiso.Descripcion
        });
    }


    /// Obtiene un permiso por Id.
    public async Task<PermisoDto?> ObtenerPorIdAsync(int id)
    {
        var permiso = await _permisoRepository.ObtenerPorIdAsync(id);

        if (permiso is null)
            return null;

        return new PermisoDto
        {
            Id = permiso.Id,
            Nombre = permiso.Nombre,
            Descripcion = permiso.Descripcion
        };
    }


    /// Crea un nuevo permiso.
    public async Task<PermisoDto> CrearAsync(CreatePermisoDto createPermisoDto)
    {
        var permiso = new Permiso
        {
            Nombre = createPermisoDto.Nombre,
            Descripcion = createPermisoDto.Descripcion
        };

        await _permisoRepository.CrearAsync(permiso);

        return new PermisoDto
        {
            Id = permiso.Id,
            Nombre = permiso.Nombre,
            Descripcion = permiso.Descripcion
        };
    }


    /// Elimina un permiso por Id.
    public async Task EliminarAsync(int id)
    {
        var permiso = await _permisoRepository.ObtenerPorIdAsync(id);

        if (permiso is null)
        {
            throw new Exception($"No existe un permiso con Id {id}");
        }

        await _permisoRepository.EliminarAsync(permiso);
    }
}