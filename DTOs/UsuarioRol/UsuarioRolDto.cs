namespace TaskFlow.Api.DTOs.UsuarioRol;

/// <summary>
/// DTO utilizado para mostrar la relación entre un usuario y un rol.
/// </summary>
public class UsuarioRolDto
{
    /// <summary>
    /// Identificador del usuario.
    /// </summary>
    public int UsuarioId { get; set; }

    /// <summary>
    /// Nombre completo del usuario.
    /// </summary>
    public string NombreUsuario { get; set; } = string.Empty;

    /// <summary>
    /// Identificador del rol.
    /// </summary>
    public int RolId { get; set; }

    /// <summary>
    /// Nombre del rol.
    /// </summary>
    public string NombreRol { get; set; } = string.Empty;
}