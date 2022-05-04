using ControleEstacionamento.Data.Context;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Data.Repository
{
    public class ParametrizacaoRepository : IParametrizacaoRepository
    {
        protected readonly EstacionamentoDbContext Db;
        protected readonly DbSet<Parametro> DbSet;

        public ParametrizacaoRepository(EstacionamentoDbContext db)
        {
            Db = db;
            DbSet = db.Set<Parametro>();
        }

        public async Task<Parametro> Consultar()
        {
            return await Db.Parametros.AsNoTracking().SingleOrDefaultAsync(x => x.Ativo == true);
                  
        }

        public async Task Adicionar(Parametro dados)
        {
            DbSet.Add(dados);
            await SaveChanges();
        }

        public async Task Atualizar(Parametro dados)
        {
            DbSet.Update(dados);
            await SaveChanges();            
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
