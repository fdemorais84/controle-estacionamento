using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Interfaces
{
    public interface IHistoricoAppService
    {
        Task<bool> VerificarVeiculo(string placa);
        bool VerificarCpf(string cpf);
        Task<IEnumerable<Ticket>> ListarHistoricoCondutor(string cpf);
        Task<IEnumerable<Ticket>> ListarHistoricoVeiculo(string placa);
        Task<IEnumerable<Ticket>> ListarHistoricoVeiculosEmAberto();
        Task<IEnumerable<Ticket>> ListarHistoricoPorData(string data);
    }
}
