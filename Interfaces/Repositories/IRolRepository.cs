using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Interfaces.Repositories;

public interface IRolRepository
{
    
    Task<IEnumerable<Rol>> ObtenerTodosAsync();

    Task<Rol?> ObtenerPorIdAsync(int id);

    Task<Rol> CrearAsync(Rol rol);

    Task<Rol> ActualizarAsync(Rol rol);

    Task<Rol> EliminarAsync(Rol rol);

    
}