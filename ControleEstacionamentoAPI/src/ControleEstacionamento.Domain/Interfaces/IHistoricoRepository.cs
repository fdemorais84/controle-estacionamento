using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Domain.Interfaces
{
    public interface IHistoricoRepository
    {
        Task<IEnumerable<Ticket>> ListarVeiculo(string placa);
        Task<IEnumerable<Ticket>> ListarCondutor(string cpf);
        Task<IEnumerable<Ticket>> ListarVeiculosEmAberto();
        Task<IEnumerable<Ticket>> ListarPorData(string data);
    }
}
