namespace TaskFlow.Api.Entities;

public class Rol
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

     public DateTime FechaRegistro { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public ICollection<UsuarioRol> UsuariosRoles { get; set; } = new List<UsuarioRol>();

    public ICollection<RolPermiso> RolesPermisos { get; set; } = new List<RolPermiso>();
}