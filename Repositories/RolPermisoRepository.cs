using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;

namespace TaskFlow.Api.Repositories;

/// Implementación del repositorio para administrar la relación
/// entre Roles y Permisos.
public class RolPermisoRepository : IRolPermisoRepository
{
    private readonly TaskFlowDbContext _context;
    /// Constructor del repositorio.
    public RolPermisoRepository(TaskFlowDbContext context)
    {
        _context = context;
    }

    /// Obtiene todos los permisos asignados a un rol.
    public async Task<IEnumerable<RolPermiso>> ObtenerPorRolAsync(int rolId)
    {
        return await _context.RolesPermisos
            .Include(rp => rp.Rol)
            .Include(rp => rp.Permiso)
            .Where(rp => rp.RolId == rolId)
            .AsNoTracking()
            .ToListAsync();
    }


    /// Obtiene todos los roles asociados a un permiso. 
    public async Task<IEnumerable<RolPermiso>> ObtenerPorPermisoAsync(int permisoId)
    {
        return await _context.RolesPermisos
            .Include(rp => rp.Rol)
            .Include(rp => rp.Permiso)
            .Where(rp => rp.PermisoId == permisoId)
            .AsNoTracking()
            .ToListAsync();
    }


    /// Obtiene una relación específica entre un rol y un permiso.
    public async Task<RolPermiso?> ObtenerAsync(int rolId, int permisoId)
    {
        return await _context.RolesPermisos
            .Include(rp => rp.Rol)
            .Include(rp => rp.Permiso)
            .AsNoTracking()
            .FirstOrDefaultAsync(rp =>
                rp.RolId == rolId &&
                rp.PermisoId == permisoId);
    }


    /// Crea una nueva relación entre un rol y un permiso.
    public async Task<RolPermiso> CrearAsync(RolPermiso rolPermiso)
    {
        await _context.RolesPermisos.AddAsync(rolPermiso);

        await _context.SaveChangesAsync();

        return rolPermiso;
    }


    /// Elimina una relación entre un rol y un permiso.
    public async Task EliminarAsync(RolPermiso rolPermiso)
    {
        _context.RolesPermisos.Remove(rolPermiso);

        await _context.SaveChangesAsync();
    }

    /// Verifica si ya existe una relación entre un rol y un permiso.
    public async Task<bool> ExisteAsync(int rolId, int permisoId)
    {
        return await _context.RolesPermisos.AnyAsync(rp =>
            rp.RolId == rolId &&
            rp.PermisoId == permisoId);
    }
}