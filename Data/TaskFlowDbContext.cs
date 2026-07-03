using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Data;

/// <summary>
/// Contexto principal de la base de datos de la aplicación TaskFlow.
/// 
/// Esta clase actúa como puente entre las entidades del sistema y la base de datos.
/// Entity Framework Core utiliza este contexto para realizar operaciones CRUD
/// (Crear, Leer, Actualizar y Eliminar) sobre las tablas configuradas.
/// </summary>
public class TaskFlowDbContext : DbContext
{
    /// <summary>
    /// Inicializa una nueva instancia del contexto de base de datos.
    /// </summary>
    /// <param name="options">
    /// Opciones de configuración del contexto, como la cadena de conexión
    /// y el proveedor de base de datos (SQL Server, PostgreSQL, etc.).
    /// </param>
    public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Tabla de usuarios del sistema.
    /// Permite gestionar la información de las personas que acceden a la aplicación.
    /// </summary>
    public DbSet<Usuario> Usuarios { get; set; }

    /// <summary>
    /// Tabla de roles.
    /// Define los diferentes perfiles de acceso disponibles en el sistema.
    /// </summary>
    public DbSet<Rol> Roles { get; set; }

    /// <summary>
    /// Tabla de permisos.
    /// Contiene las acciones o funcionalidades que pueden ser asignadas a un rol.
    /// </summary>
    public DbSet<Permiso> Permisos { get; set; }

    /// <summary>
    /// Tabla intermedia que relaciona usuarios con roles.
    /// Representa una relación de muchos a muchos entre Usuario y Rol.
    /// </summary>
    public DbSet<UsuarioRol> UsuariosRoles { get; set; }

    /// <summary>
    /// Tabla intermedia que relaciona roles con permisos.
    /// Representa una relación de muchos a muchos entre Rol y Permiso.
    /// </summary>
    public DbSet<RolPermiso> RolesPermisos { get; set; }
    //
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(TaskFlowDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
}
}