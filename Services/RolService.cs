using TaskFlow.Api.DTOs.Rol;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Services;

public class RolService: IRolService
{
    private readonly IRolRepository _rolRepository;

    public RolService(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task<IEnumerable<RolDto>> ObtenerTodosAsync()
    {
        var rol  = await _rolRepository.ObtenerTodosAsync();

        return rol.Select(rol => new RolDto
        {
            
            Id= rol.Id,
            Nombre= rol.Nombre,
            Descripcion=rol.Descripcion
        });
        
    }

    public async Task<RolDto?> ObtenerPorIdAsync(int id)
    {
        var rol = await _rolRepository.ObtenerPorIdAsync(id);

        if (rol is null)
            return null;

        return new RolDto
        {
            Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion,
            
        };
    }

    public async Task<RolDto> CrearAsync(CreateRolDto createRolDto)
    {
        
        var rol = new Rol
        {
            Nombre = createRolDto.Nombre,
            Descripcion = createRolDto.Descripcion,

            // Temporalmente almacenamos el texto plano.
            // Más adelante utilizaremos BCrypt.
            FechaRegistro = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _rolRepository.CrearAsync(rol);

        return new RolDto
        {
            Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion,
            
        };
    }

    /// Elimina un usuario por Id.
    /// <param name="id">
    /// Identificador del usuario.
    public async Task EliminarAsync(int id)
    {
        var rol = await _rolRepository
            .ObtenerPorIdAsync(id);

        if (rol is null)
        {
            throw new Exception(
                $"No existe un usuario con Id {id}");
        }

        await _rolRepository.EliminarAsync(rol);
        
    }
}