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
    public class ClienteRepository : IClienteRepository
    {
        protected readonly EstacionamentoDbContext Db;
        protected readonly DbSet<Cliente> DbSet;

        public ClienteRepository(EstacionamentoDbContext db)
        {
            Db = db;
            DbSet = db.Set<Cliente>();
        }

        public async Task<Cliente> Consultar(string cpf)
        {
            return await Db.Clientes.Where(x => x.Cpf.Contains(cpf))
                                    .Where(x => x.Quantidade <= 2)
                                    .FirstOrDefaultAsync();
        }

        public async Task Adicionar(Cliente cliente)
        {
            DbSet.Add(cliente);
            await SaveChanges();
        }

        public async Task Atualizar(Cliente cliente)
        {
            DbSet.Update(cliente);
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
