using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Model;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Interfaces
{
    public interface IEstacionamentoAppService
    {
        Task<bool> VerificarVeiculoEstacionado(TicketEntradaViewModel dados);
        Task<bool> VerificarVeiculoEstacionado(TicketSaidaViewModel dados);
        bool VerificarCpf(TicketSaidaViewModel dados);
        Task CadastrarVeiculo(TicketEntradaViewModel dados);
        Task<Ticket> BuscarDadosTicket(TicketSaidaViewModel dados);
        Task PagarTicket(Ticket dados, Parametro regra);
        Task SomarHorasEstacionadas(string cpf);
        bool VerificarPlaca(string placa);
    }
}
