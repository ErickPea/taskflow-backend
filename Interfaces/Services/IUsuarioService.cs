using TaskFlow.Api.DTOs.Usuario;

namespace TaskFlow.Api.Interfaces.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync();

    Task<UsuarioDto?> ObtenerPorIdAsync(int id);

    Task<UsuarioDto> CrearAsync(CreateUsuarioDto createUsuarioDto);

    Task EliminarAsync(int id);
}