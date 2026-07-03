using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Interfaces.Repositories;

public interface IUsuarioRepository
{
    //Trae todos los usuarios. esto equivale a un SELECT*FROM Usuarios;
    Task<IEnumerable<Usuario>> ObtenerTodosAsync();
    //Busca un usuario específico por id. esto equivale en sql:  SELECT * FROM Usuarios WHERE Id = 1
    Task<Usuario?> ObtenerPorIdAsync(int id);

    //Muy útil para: Login ,Registro ,Validaciones
    Task<Usuario?> ObtenerPorEmailAsync(string email);
    //Guarda un nuevo usuario.
    Task<Usuario> CrearAsync(Usuario usuario);
    //Modifica un usuario existente
    Task ActualizarAsync(Usuario usuario);
    //Sirve para eliminar
    Task EliminarAsync(Usuario usuario);
    //Sirve para validar: si el correo existe
    Task<bool> ExisteEmailAsync(string email);
}