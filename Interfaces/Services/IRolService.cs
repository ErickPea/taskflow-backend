using TaskFlow.Api.DTOs.Rol;

namespace TaskFlow.Api.Interfaces.Services;

public interface IRolService
{
    Task<IEnumerable<RolDto>> ObtenerTodosAsync();

    Task<RolDto?> ObtenerPorIdAsync(int id);

    Task<RolDto> CrearAsync(CreateRolDto createRolDto);

    Task EliminarAsync(int id);
}