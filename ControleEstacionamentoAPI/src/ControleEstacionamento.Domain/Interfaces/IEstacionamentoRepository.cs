using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Domain.Interfaces
{
    public interface IEstacionamentoRepository
    {
        Task<Ticket> Consultar(string placa);
        Task<List<Ticket>> ConsultarPorCpf(string cpf);
        Task Adicionar(Ticket dados);
        Task Atualizar(Ticket dados);
        Task MarcarDesconto(List<Ticket> list);
    }
}
