using TaskFlow.Api.DTOs.Permiso;

namespace TaskFlow.Api.Interfaces.Services;

public interface IPermisoService
{
    Task<IEnumerable<PermisoDto>> ObtenerTodosAsync();

    Task<PermisoDto?> ObtenerPorIdAsync(int id);

    Task<PermisoDto> CrearAsync(CreatePermisoDto createPermisoDto);

    Task EliminarAsync(int id);
}