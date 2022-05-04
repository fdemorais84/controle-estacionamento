using System;
using System.Threading.Tasks;
using ControleEstacionamento.Api.Extensions;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.Api.Controllers
{
    [Route("api/estacionamento")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoAppService _estacionamentoAppService;
        private readonly IParametrizacaoAppService _parametrizacaoAppService;


        public EstacionamentoController(IEstacionamentoAppService estacionamentoAppService, 
                                        IParametrizacaoAppService parametrizacaoAppService)
        {
            _estacionamentoAppService = estacionamentoAppService;
            _parametrizacaoAppService = parametrizacaoAppService;
        }

        [HttpPost("entrada")]
        public async Task<IActionResult> Entrada([FromBody] TicketEntradaViewModel dados)
        {
            #region Formatar valores de entrada
            dados.Placa = !String.IsNullOrEmpty(dados.Placa) ? ExtensionMethods.StringFormat(dados.Placa).ToUpper() : null;
            #endregion

            if (await _estacionamentoAppService.VerificarVeiculoEstacionado(dados))
                return BadRequest("A placa ja consta em nosso estacionamento");

            if (_estacionamentoAppService.VerificarPlaca(dados.Placa))
                return BadRequest("A placa informada esta incorreta");

            try
            {
                await _estacionamentoAppService.CadastrarVeiculo(dados);

                return Ok($"Dados salvos com sucesso! Placa: {dados.Placa}");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPost("saida")]
        public async Task<IActionResult> Saida(TicketSaidaViewModel dados)
        {
            #region Formatar valores de entrada
            dados.Placa = !String.IsNullOrEmpty(dados.Placa) ? ExtensionMethods.StringFormat(dados.Placa).ToUpper() : null;
            dados.Cpf = !String.IsNullOrEmpty(dados.Cpf) ? ExtensionMethods.StringFormat(dados.Cpf) : null;
            #endregion

            if (await _estacionamentoAppService.VerificarVeiculoEstacionado(dados) == true || String.IsNullOrEmpty(dados.Placa))
                return BadRequest("Placa não encontrada em nosso estacionamento");

            if (_estacionamentoAppService.VerificarPlaca(dados.Placa))
                return BadRequest("A placa informada esta incorreta");

            if(!String.IsNullOrEmpty(dados.Cpf))
                if (_estacionamentoAppService.VerificarCpf(dados))
                    return BadRequest("CPF inválido");

            try
            {
                var ticket = await _estacionamentoAppService.BuscarDadosTicket(dados);

                var regraAtiva = await _parametrizacaoAppService.BuscarParametro();

                await _estacionamentoAppService.PagarTicket(ticket, regraAtiva);

                if(!String.IsNullOrEmpty(dados.Cpf))
                    await _estacionamentoAppService.SomarHorasEstacionadas(dados.Cpf);

                return Ok($"Ticket Pago! Placa: {dados.Placa}");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
