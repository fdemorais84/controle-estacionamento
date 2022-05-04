using ControleEstacionamento.Data.Context;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstacionamento.Data.Repository
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        protected readonly EstacionamentoDbContext Db;
        protected readonly DbSet<Ticket> DbSet;

        public EstacionamentoRepository(EstacionamentoDbContext db)
        {
            Db = db;
            DbSet = db.Set<Ticket>();
        }

        public async Task<Ticket> Consultar(string placa)
        {
            return await Db.Tickets.Where(x => x.Ativo == true)
                                   .Where(x => x.Placa == placa)
                                   .FirstOrDefaultAsync();

        }

        public async Task<List<Ticket>> ConsultarPorCpf(string cpf)
        {
            return await Db.Tickets.Where(x => x.Ativo == false)
                                   .Where(x => x.Desconto != true)
                                   .Where(x => x.Cpf == cpf)
                                   .ToListAsync();

        }

        public async Task Adicionar(Ticket dados)
        {
            DbSet.Add(dados);
            await SaveChanges();
        }

        public async Task MarcarDesconto(List<Ticket> list)
        {
            DbSet.AddRange(list);
            await SaveChanges();
        }

        public async Task Atualizar(Ticket dados)
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
