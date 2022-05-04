using AutoMapper;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using ControleEstacionamento.Domain.Model.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Services
{
    public class EstacionamentoAppService : IEstacionamentoAppService
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IParametrizacaoGratuidadeRepository _parametrizacaoGratuidadeRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;



        public EstacionamentoAppService(IEstacionamentoRepository estacionamentoRepository, 
                                        IParametrizacaoGratuidadeRepository parametrizacaoGratuidadeRepository,
                                        IClienteRepository clienteRepository,
                                        IMapper mapper)
        {
            _estacionamentoRepository = estacionamentoRepository;
            _parametrizacaoGratuidadeRepository = parametrizacaoGratuidadeRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<bool> VerificarVeiculoEstacionado(TicketEntradaViewModel dados)
        {
            return await _estacionamentoRepository.Consultar(dados.Placa) != null ? true : false;             
        }

        public async Task<bool> VerificarVeiculoEstacionado(TicketSaidaViewModel dados)
        {
           return await _estacionamentoRepository.Consultar(dados.Placa) != null ? false : true;            
        }

        public async Task CadastrarVeiculo(TicketEntradaViewModel dados)
        {
            await _estacionamentoRepository.Adicionar(_mapper.Map<Ticket>(dados));            
        }

        public async Task<Ticket> BuscarDadosTicket(TicketSaidaViewModel dados)
        {
            var ticket = await _estacionamentoRepository.Consultar(dados.Placa);

            ticket.Cpf = dados.Cpf;

            return ticket;
        }

        public async Task PagarTicket(Ticket dados, Parametro regra)
        {
            dados.Saida = DateTime.Now;

            var valor = ValidarRegrasEstacionamento(dados, regra);

            await _estacionamentoRepository.Atualizar(valor.Result);
        }
        
        public async Task SomarHorasEstacionadas(string cpf)
        {
            var listaTicket = await _estacionamentoRepository.ConsultarPorCpf(cpf);

            if (SomarHoras(listaTicket)) 
            {
                await MarcarDesconto(listaTicket);
                await SalvarDesconto(cpf);
            }
        }

        public bool VerificarCpf(TicketSaidaViewModel dados)
        {
            return ValidacaoCpf.Validar(dados.Cpf);
        }

        public bool VerificarPlaca(string placa)
        {
            return ValidacaoPlaca.Validar(placa);
        }

        #region PRIVATE AREA
        private async Task SalvarDesconto(string cpf)
        {
            Cliente cliente = new Cliente(cpf, DateTime.Now, 1);
            await _clienteRepository.Adicionar(cliente);
        }

        private async Task MarcarDesconto(List<Ticket> list)
        {
            foreach (var item in list)
            {
                item.Desconto = true;
            }
            await _estacionamentoRepository.MarcarDesconto(list);
        }

        private bool SomarHoras(List<Ticket> list)
        {
            TimeSpan horas;
            foreach (var item in list)
            {
                horas += item.Entrada.Subtract(item.Saida);                
            }

            return horas.Hours >= 10 ? true : false;
        }

        private async Task SalvarSegundoDesconto(Cliente cliente)
        {
            cliente.Quantidade = 2;
            await _clienteRepository.Atualizar(cliente);
        }

        private async Task<Ticket> ValidarRegrasEstacionamento(Ticket dados, Parametro regra)
        {            
            if (ValidarGratuidade(dados))            
                return ValorGratuidade(dados);

            var cliente = ValidarDesconto(dados);
            if (cliente.Result != null)
            {
                await SalvarSegundoDesconto(cliente.Result);
                return ValorDesconto(dados, regra);
            }                

            return CalcularValor(dados, regra); 
        }

        private Ticket ValorGratuidade(Ticket dados)
        {
            dados.Valor = 0;
            dados.Ativo = false;
            return dados;
        }

        private Ticket ValorDesconto(Ticket dados, Parametro regra)
        {
            var ticket = CalcularValor(dados, regra);
            ticket.Valor = ticket.Valor / 2;
            return ticket;
        }

        private async Task<Cliente> ValidarDesconto(Ticket dados)
        {
            return await _clienteRepository.Consultar(dados.Cpf);                    
        }

        private bool ValidarGratuidade(Ticket dados)
        {
            var regraGratuidade = _parametrizacaoGratuidadeRepository.Consultar();
            
            if (dados.Entrada.Day == DateTime.Now.Day)
            {
                foreach (var item in regraGratuidade)
                {
                    if (item.DiaSemana.Equals(dados.Entrada.DayOfWeek.ToString()))
                        if (dados.Entrada.Hour >= item.Inicio.Hour && dados.Saida.Hour <= item.Encerramento.Hour)
                            if (dados.Entrada.Minute >= item.Inicio.Minute && dados.Saida.Minute <= item.Encerramento.Minute)
                                return true;
                }
            }       

            return false;
        }

        private Ticket CalcularValor(Ticket dados, Parametro regra)
        {
            TimeSpan valor = dados.Saida.Subtract(dados.Entrada);
            dados.Ativo = false;
            if (valor.TotalMinutes <= 30)
            {
                dados.Valor = regra.ValorPrimeiraHora / 2;                
                return dados;
            }
            else if (valor.Minutes <= 10 && valor.Hours == 1)
            {
                dados.Valor = regra.ValorPrimeiraHora;
                return dados;
            }            
            else if (valor.Minutes > 10 && valor.Hours >= 1)
            {
                dados.Valor = regra.ValorPrimeiraHora + (regra.ValorHoraAdicional * (valor.Hours + 1));
                return dados;
            }
            else 
            {
                dados.Valor = regra.ValorPrimeiraHora + (regra.ValorHoraAdicional * (valor.Hours));
                return dados;
            }
        }
        #endregion
    }
}
