using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Entities;

namespace TesteBitzen.INFRA.Data.DataMapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Email).HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Senha).HasMaxLength(10).HasColumnType("varchar(10)");
            builder.HasMany(x => x.Veiculos)
                .WithOne(v => v.Usuario)
                .HasForeignKey(v => v.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
