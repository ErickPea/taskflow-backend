using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.DTOs.UsuarioRol;

/// <summary>
/// DTO utilizado para asignar un rol a un usuario.
/// </summary>
public class CreateUsuarioRolDto
{
    /// <summary>
    /// Identificador del usuario.
    /// </summary>
    [Required(ErrorMessage = "El usuario es obligatorio.")]
    public int UsuarioId { get; set; }

    /// <summary>
    /// Identificador del rol.
    /// </summary>
    [Required(ErrorMessage = "El rol es obligatorio.")]
    public int RolId { get; set; }
}