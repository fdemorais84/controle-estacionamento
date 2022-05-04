using System;
using System.Threading.Tasks;
using ControleEstacionamento.Api.Extensions;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.Api.Controllers
{
    [Route("api/historico")]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoAppService _historicoAppService;

        public HistoricoController(IHistoricoAppService historicoAppService)
        {
            _historicoAppService = historicoAppService;
        }

        [HttpGet("condutor/{cpf}")]
        public async Task<IActionResult> HistoricoPorCondutor(string cpf)
        {
            if (_historicoAppService.VerificarCpf(ExtensionMethods.StringFormat(cpf)))
                return BadRequest("CPF inválido");

            try
            {
                return Ok(await _historicoAppService.ListarHistoricoCondutor(ExtensionMethods.StringFormat(cpf)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("veiculo/{placa}")]
        public async Task<IActionResult> HistoricoPorVeiculo(string placa)
        {
            if (await _historicoAppService.VerificarVeiculo(ExtensionMethods.StringFormat(placa).ToUpper()))
                return BadRequest("Placa não encontrada em nosso estacionamento");

            try
            {
                return Ok(await _historicoAppService.ListarHistoricoVeiculo(ExtensionMethods.StringFormat(placa).ToUpper()));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("em-aberto")]
        public async Task<IActionResult> HistoricoVeiculosEmAberto()
        {            
            try
            {
                return Ok(await _historicoAppService.ListarHistoricoVeiculosEmAberto());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("data")]
        public async Task<IActionResult> HistoricoPorData(HistoricoViewModel dados)
        {  
            try
            {
                return Ok(await _historicoAppService.ListarHistoricoPorData(dados.data));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
