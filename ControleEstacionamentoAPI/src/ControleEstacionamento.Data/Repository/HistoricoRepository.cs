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
    public class HistoricoRepository : IHistoricoRepository
    {
        protected readonly EstacionamentoDbContext Db;
        protected readonly DbSet<Ticket> DbSet;

        public HistoricoRepository(EstacionamentoDbContext db)
        {
            Db = db;
            DbSet = db.Set<Ticket>();
        }

        public async Task<IEnumerable<Ticket>> ListarVeiculo(string placa)
        {
            return await Db.Tickets.Where(x => x.Placa == placa).ToListAsync();

        }

        public async Task<IEnumerable<Ticket>> ListarCondutor(string cpf)
        {
            return await Db.Tickets.Where(x => x.Cpf == cpf).ToListAsync();

        }

        public async Task<IEnumerable<Ticket>> ListarVeiculosEmAberto()
        {
            return await Db.Tickets.Where(x => x.Ativo == true).ToListAsync();

        }

        public async Task<IEnumerable<Ticket>> ListarPorData(string data)
        {
            return await Db.Tickets.Where(x => x.Entrada.Date.Equals(Convert.ToDateTime(data).Date)).ToListAsync();

        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
