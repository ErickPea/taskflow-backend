using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;

namespace TaskFlow.Api.Repositories;

public class RolRepository: IRolRepository
{
    private readonly TaskFlowDbContext _context;

    public RolRepository(TaskFlowDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rol>> ObtenerTodosAsync()
    {
        return await _context.Roles
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<Rol?> ObtenerPorIdAsync(int id){
      return await _context.Roles
      .AsNoTracking()
      .FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<Rol> CrearAsync(Rol rol)
    {
        await _context.Roles.AddAsync(rol);

        await _context.SaveChangesAsync();

        return rol;
    }

    public async Task<Rol> ActualizarAsync(Rol rol)
    {
        _context.Roles.Update(rol);

        await _context.SaveChangesAsync();

        return rol;
    }

    public async Task<Rol> EliminarAsync(Rol rol)
    {
        _context.Roles.Remove(rol);

        await _context.SaveChangesAsync();

        return rol;
    }
}