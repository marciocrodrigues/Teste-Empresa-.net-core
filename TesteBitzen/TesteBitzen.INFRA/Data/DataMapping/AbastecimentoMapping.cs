using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TesteBitzen.DOMAIN.Entities;

namespace TesteBitzen.INFRA.Data.DataMapping
{
    public class AbastecimentoMapping : IEntityTypeConfiguration<Abastecimento>
    {
        public void Configure(EntityTypeBuilder<Abastecimento> builder)
        {
            builder.ToTable("Abastecimento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.KmAbastecimento).HasColumnType("integer");
            builder.Property(x => x.LitrosAbastecidos).HasColumnType("numeric(8,2)");
            builder.Property(x => x.ValorAbastecimento).HasColumnType("numeric(8,2)");
            builder.Property(x => x.MesAbastecimento).HasColumnType("smallint");
            builder.Property(x => x.DiaAbastecimento).HasColumnType("smallint");
            builder.Property(x => x.AnoAbastecimento).HasColumnType("smallint");
            builder.Property(x => x.PostoCombustivel).HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.TipoCombustivel).HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.VeiculoId).IsRequired();
        }
    }
}
