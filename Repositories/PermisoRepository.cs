using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;

namespace TaskFlow.Api.Repositories;
/// Implementación del repositorio para la entidad Permiso.
/// Se encarga de realizar las operaciones CRUD utilizando Entity Framework Core.
public class PermisoRepository : IPermisoRepository
{
    private readonly TaskFlowDbContext _context;
    
    /// Constructor del repositorio.
    /// Contexto de la base de datos.
    public PermisoRepository(TaskFlowDbContext context)
    {
        _context = context;
    }

    
    /// Obtiene todos los permisos registrados.  
    public async Task<IEnumerable<Permiso>> ObtenerTodosAsync()
    {
        return await _context.Permisos
            .AsNoTracking()
            .ToListAsync();
    }

    
    /// Obtiene un permiso por su identificador.   
    public async Task<Permiso?> ObtenerPorIdAsync(int id)
    {
        return await _context.Permisos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    
    /// Crea un nuevo permiso.
    public async Task<Permiso> CrearAsync(Permiso permiso)
    {
        await _context.Permisos.AddAsync(permiso);

        await _context.SaveChangesAsync();

        return permiso;
    }

    
    /// Actualiza un permiso existente.   
    public async Task ActualizarAsync(Permiso permiso)
    {
        _context.Permisos.Update(permiso);

        await _context.SaveChangesAsync();
    }

    
    /// Elimina un permiso existente.
    public async Task EliminarAsync(Permiso permiso)
    {
        _context.Permisos.Remove(permiso);

        await _context.SaveChangesAsync();
    }
}