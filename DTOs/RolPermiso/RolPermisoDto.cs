namespace TaskFlow.Api.DTOs.RolPermiso;

/// DTO utilizado para mostrar la relación entre un rol y un permiso.
public class RolPermisoDto
{

    /// Identificador del rol.
    public int RolId { get; set; }

    /// Nombre del rol.
    public string NombreRol { get; set; } = string.Empty;

    /// Identificador del permiso.
    public int PermisoId { get; set; }

    /// Nombre del permiso.
    public string NombrePermiso { get; set; } = string.Empty;
}