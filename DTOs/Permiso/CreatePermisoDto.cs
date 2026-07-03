using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.DTOs.Permiso;

/// <summary>
/// DTO utilizado para crear un nuevo permiso.
/// </summary>
public class CreatePermisoDto
{
    /// <summary>
    /// Nombre del permiso.
    /// </summary>
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del permiso.
    /// </summary>
    [MaxLength(250)]
    public string Descripcion { get; set; } = string.Empty;
}