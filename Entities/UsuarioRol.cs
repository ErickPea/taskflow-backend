namespace TaskFlow.Api.Entities;

public class UsuarioRol
{
    public int UsuarioId { get; set; }

    public int RolId { get; set; }

    // Navigation Properties
    public Usuario Usuario { get; set; } = null!;

    public Rol Rol { get; set; } = null!;
}