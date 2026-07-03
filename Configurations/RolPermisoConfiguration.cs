using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Configurations;

public class RolPermisoConfiguration : IEntityTypeConfiguration<RolPermiso>
{
    public void Configure(EntityTypeBuilder<RolPermiso> builder)
    {
        builder.ToTable("RolesPermisos");

        builder.HasKey(x => new
        {
            x.RolId,
            x.PermisoId
        });

        builder.HasOne(x => x.Rol)
            .WithMany(x => x.RolesPermisos)
            .HasForeignKey(x => x.RolId);

        builder.HasOne(x => x.Permiso)
            .WithMany(x => x.RolesPermisos)
            .HasForeignKey(x => x.PermisoId);
    }
}