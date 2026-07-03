using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.DTOs.RolPermiso;

/// DTO utilizado para asignar un permiso a un rol.
public class CreateRolPermisoDto
{
   
    /// Identificador del rol.
    [Required(ErrorMessage = "El rol es obligatorio.")]
    public int RolId { get; set; }
   
    /// Identificador del permiso.
    [Required(ErrorMessage = "El permiso es obligatorio.")]
    public int PermisoId { get; set; }
}