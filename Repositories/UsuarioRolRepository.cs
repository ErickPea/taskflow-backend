using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;

namespace TaskFlow.Api.Repositories;

/// <summary>
/// Implementación del repositorio para administrar
/// la relación entre Usuarios y Roles.
/// </summary>
public class UsuarioRolRepository : IUsuarioRolRepository
{
    private readonly TaskFlowDbContext _context;

    /// <summary>
    /// Constructor del repositorio.
    /// </summary>
    /// <param name="context">
    /// Contexto de la base de datos.
    /// </param>
    public UsuarioRolRepository(TaskFlowDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtiene todos los roles asignados a un usuario.
    /// </summary>
    public async Task<IEnumerable<UsuarioRol>> ObtenerPorUsuarioAsync(int usuarioId)
    {
        return await _context.UsuariosRoles
            .Include(ur => ur.Usuario)
            .Include(ur => ur.Rol)
            .Where(ur => ur.UsuarioId == usuarioId)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene todos los usuarios asociados a un rol.
    /// </summary>
    public async Task<IEnumerable<UsuarioRol>> ObtenerPorRolAsync(int rolId)
    {
        return await _context.UsuariosRoles
            .Include(ur => ur.Usuario)
            .Include(ur => ur.Rol)
            .Where(ur => ur.RolId == rolId)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene una relación específica entre un usuario y un rol.
    /// </summary>
    public async Task<UsuarioRol?> ObtenerAsync(int usuarioId, int rolId)
    {
        return await _context.UsuariosRoles
            .Include(ur => ur.Usuario)
            .Include(ur => ur.Rol)
            .AsNoTracking()
            .FirstOrDefaultAsync(ur =>
                ur.UsuarioId == usuarioId &&
                ur.RolId == rolId);
    }

    /// <summary>
    /// Asigna un rol a un usuario.
    /// </summary>
    public async Task<UsuarioRol> CrearAsync(UsuarioRol usuarioRol)
    {
        await _context.UsuariosRoles.AddAsync(usuarioRol);

        await _context.SaveChangesAsync();

        return usuarioRol;
    }

    /// <summary>
    /// Elimina la relación entre un usuario y un rol.
    /// </summary>
    public async Task EliminarAsync(UsuarioRol usuarioRol)
    {
        _context.UsuariosRoles.Remove(usuarioRol);

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Verifica si la relación entre un usuario y un rol ya existe.
    /// </summary>
    public async Task<bool> ExisteAsync(int usuarioId, int rolId)
    {
        return await _context.UsuariosRoles.AnyAsync(ur =>
            ur.UsuarioId == usuarioId &&
            ur.RolId == rolId);
    }
}