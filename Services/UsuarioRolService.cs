using TaskFlow.Api.DTOs.UsuarioRol;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Interfaces.Repositories;
using TaskFlow.Api.Interfaces.Services;

namespace TaskFlow.Api.Services;

/// <summary>
/// Servicio encargado de la lógica de negocio para la relación
/// entre Usuarios y Roles.
/// </summary>
public class UsuarioRolService : IUsuarioRolService
{
    private readonly IUsuarioRolRepository _usuarioRolRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRolRepository _rolRepository;

    /// <summary>
    /// Constructor del servicio.
    /// </summary>
    public UsuarioRolService(
        IUsuarioRolRepository usuarioRolRepository,
        IUsuarioRepository usuarioRepository,
        IRolRepository rolRepository)
    {
        _usuarioRolRepository = usuarioRolRepository;
        _usuarioRepository = usuarioRepository;
        _rolRepository = rolRepository;
    }

    /// <summary>
    /// Obtiene todos los roles asignados a un usuario.
    /// </summary>
    public async Task<IEnumerable<UsuarioRolDto>> ObtenerPorUsuarioAsync(int usuarioId)
    {
        var relaciones = await _usuarioRolRepository.ObtenerPorUsuarioAsync(usuarioId);

        return relaciones.Select(ur => new UsuarioRolDto
        {
            UsuarioId = ur.UsuarioId,
            NombreUsuario = ur.Usuario.Nombre,
            RolId = ur.RolId,
            NombreRol = ur.Rol.Nombre
        });
    }

    /// <summary>
    /// Obtiene todos los usuarios asociados a un rol.
    /// </summary>
    public async Task<IEnumerable<UsuarioRolDto>> ObtenerPorRolAsync(int rolId)
    {
        var relaciones = await _usuarioRolRepository.ObtenerPorRolAsync(rolId);

        return relaciones.Select(ur => new UsuarioRolDto
        {
            UsuarioId = ur.UsuarioId,
            NombreUsuario = ur.Usuario.Nombre,
            RolId = ur.RolId,
            NombreRol = ur.Rol.Nombre
        });
    }

    /// <summary>
    /// Obtiene una relación específica entre un usuario y un rol.
    /// </summary>
    public async Task<UsuarioRolDto?> ObtenerAsync(int usuarioId, int rolId)
    {
        var relacion = await _usuarioRolRepository.ObtenerAsync(usuarioId, rolId);

        if (relacion is null)
            return null;

        return new UsuarioRolDto
        {
            UsuarioId = relacion.UsuarioId,
            NombreUsuario = relacion.Usuario.Nombre,
            RolId = relacion.RolId,
            NombreRol = relacion.Rol.Nombre
        };
    }

    /// <summary>
    /// Asigna un rol a un usuario.
    /// </summary>
    public async Task<UsuarioRolDto> CrearAsync(CreateUsuarioRolDto dto)
    {
        var usuario = await _usuarioRepository.ObtenerPorIdAsync(dto.UsuarioId);

        if (usuario is null)
            throw new Exception($"No existe un usuario con Id {dto.UsuarioId}");

        var rol = await _rolRepository.ObtenerPorIdAsync(dto.RolId);

        if (rol is null)
            throw new Exception($"No existe un rol con Id {dto.RolId}");

        var existe = await _usuarioRolRepository.ExisteAsync(dto.UsuarioId, dto.RolId);

        if (existe)
            throw new Exception("El usuario ya tiene asignado este rol.");

        var usuarioRol = new UsuarioRol
        {
            UsuarioId = dto.UsuarioId,
            RolId = dto.RolId
        };

        await _usuarioRolRepository.CrearAsync(usuarioRol);

        return new UsuarioRolDto
        {
            UsuarioId = usuario.Id,
            NombreUsuario = usuario.Nombre,
            RolId = rol.Id,
            NombreRol = rol.Nombre
        };
    }

    /// <summary>
    /// Elimina un rol asignado a un usuario.
    /// </summary>
    public async Task EliminarAsync(int usuarioId, int rolId)
    {
        var relacion = await _usuarioRolRepository.ObtenerAsync(usuarioId, rolId);

        if (relacion is null)
            throw new Exception("La relación entre el usuario y el rol no existe.");

        await _usuarioRolRepository.EliminarAsync(relacion);
    }
}