using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Interfaces.Repositories;

/// Define las operaciones de acceso a datos para la entidad Permiso.
public interface IPermisoRepository
{
    /// Obtiene todos los permisos registrados.
    Task<IEnumerable<Permiso>> ObtenerTodosAsync();

    /// Obtiene un permiso por su identificador.
    /// <param name="id">Identificador del permiso.</param>
    Task<Permiso?> ObtenerPorIdAsync(int id);

    /// Crea un nuevo permiso.
    /// <param name="permiso">Entidad a registrar.</param>
    Task<Permiso> CrearAsync(Permiso permiso);


    /// Actualiza un permiso existente. 
    /// <param name="permiso">Entidad a actualizar.</param>
    Task ActualizarAsync(Permiso permiso);


    /// Elimina un permiso existente. 
    /// <param name="permiso">Entidad a eliminar.</param>
    Task EliminarAsync(Permiso permiso);
}