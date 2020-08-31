using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TesteBitzen.DOMAIN.Entities;

namespace TesteBitzen.INFRA.Data.DataMapping
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Marca).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Modelo).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Ano).HasColumnType("smallint");
            builder.Property(x => x.Placa).HasMaxLength(8).HasColumnType("varchar(8)");
            builder.Property(x => x.Combustivel).HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.QuilometragemCadastro).HasColumnType("integer");
            builder.Property(x => x.QuilometragemRodada).HasColumnType("integer");
            builder.Property(x => x.Foto).HasMaxLength(255).HasColumnType("varchar(255)");
            builder.Property(x => x.UsuarioId).IsRequired();

            builder.HasMany(x => x.Abastecimentos)
                .WithOne(v => v.Veiculo)
                .HasForeignKey(v => v.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
