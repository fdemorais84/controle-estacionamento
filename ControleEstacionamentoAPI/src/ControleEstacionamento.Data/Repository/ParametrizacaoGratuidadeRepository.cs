using ControleEstacionamento.Data.Context;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Data.Repository
{
    public class ParametrizacaoGratuidadeRepository : IParametrizacaoGratuidadeRepository
    {
        protected readonly EstacionamentoDbContext Db;
        protected readonly DbSet<ParametroGratuidade> DbSet;

        public ParametrizacaoGratuidadeRepository(EstacionamentoDbContext db)
        {
            Db = db;
            DbSet = db.Set<ParametroGratuidade>();
        }

        public List<ParametroGratuidade> Consultar()
        {
            return Db.ParametrosGratuidade.ToList();
        }

        public async Task Adicionar(ParametroGratuidade dados)
        {
            DbSet.Add(dados);
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
