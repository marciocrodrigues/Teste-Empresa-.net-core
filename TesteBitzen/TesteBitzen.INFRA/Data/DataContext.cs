using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.INFRA.Data.DataMapping;

namespace TesteBitzen.INFRA.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Abastecimento> Abastecimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new VeiculoMapping());
            modelBuilder.ApplyConfiguration(new AbastecimentoMapping());
        }
    }
}
