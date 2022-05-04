using ControleEstacionamento.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstacionamento.Data.Context
{
    public class EstacionamentoDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<ParametroGratuidade> ParametrosGratuidade { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    
    }
}
