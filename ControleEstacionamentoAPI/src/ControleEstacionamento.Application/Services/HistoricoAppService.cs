using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using ControleEstacionamento.Domain.Model.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Services
{
    public class HistoricoAppService : IHistoricoAppService
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoAppService(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public async Task<bool> VerificarVeiculo(string placa)
        {
            return await _historicoRepository.ListarVeiculo(placa) != null ? false : true;  
        }

        public bool VerificarCpf(string cpf)
        {             
            return ValidacaoCpf.Validar(cpf);
        }

        public async Task<IEnumerable<Ticket>> ListarHistoricoCondutor(string cpf)
        {
            return await _historicoRepository.ListarCondutor(cpf);            
        }

        public async Task<IEnumerable<Ticket>> ListarHistoricoVeiculo(string placa)
        {
             return await _historicoRepository.ListarVeiculo(placa);  
        }

        public async Task<IEnumerable<Ticket>> ListarHistoricoVeiculosEmAberto()
        {
            return await _historicoRepository.ListarVeiculosEmAberto();
        }

        public async Task<IEnumerable<Ticket>> ListarHistoricoPorData(string data)
        {
            return await _historicoRepository.ListarPorData(data);
        }
    }
}
