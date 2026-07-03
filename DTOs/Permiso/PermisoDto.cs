namespace TaskFlow.Api.DTOs.Permiso;

/// <summary>
/// DTO utilizado para mostrar la información de un permiso.
/// </summary>
public class PermisoDto
{
    /// <summary>
    /// Identificador del permiso.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del permiso.
    /// </summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del permiso.
    /// </summary>
    public string Descripcion { get; set; } = string.Empty;
}