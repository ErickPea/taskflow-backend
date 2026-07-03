using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Configurations;

public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRol>
{
    public void Configure(EntityTypeBuilder<UsuarioRol> builder)
    {
        builder.ToTable("UsuariosRoles");

        builder.HasKey(x => new
        {
            x.UsuarioId,
            x.RolId
        });

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuariosRoles)
            .HasForeignKey(x => x.UsuarioId);

        builder.HasOne(x => x.Rol)
            .WithMany(x => x.UsuariosRoles)
            .HasForeignKey(x => x.RolId);
    }
}