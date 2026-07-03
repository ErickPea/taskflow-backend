namespace TaskFlow.Api.Entities;

public class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    // Navigation Property
    public ICollection<UsuarioRol> UsuariosRoles { get; set; }
        = new List<UsuarioRol>();
}