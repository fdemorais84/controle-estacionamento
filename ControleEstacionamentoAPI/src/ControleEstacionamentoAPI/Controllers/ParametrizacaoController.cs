using System;
using System.Threading.Tasks;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.Api.Controllers
{
    [Route("api/parametrizacao")]
    public class ParametrizacaoController : ControllerBase
    {
        private readonly IParametrizacaoAppService _parametrizacaoAppService;

        public ParametrizacaoController(IParametrizacaoAppService parametrizacaoAppService)
        {
            _parametrizacaoAppService = parametrizacaoAppService;
        }

        [HttpPost("salvar-parametros")]
        public async Task<IActionResult> CadastrarParametros([FromBody] ParametroViewModel dados)
        {
            if (await _parametrizacaoAppService.VerificarParametrosAtivo())
                return BadRequest("Já existem parâmetros ativos");

            try
            {
                await _parametrizacaoAppService.CadastrarParametros(dados);

                return Ok($"Novos parâmetros cadastrados! Valor Primeira Hora: {dados.ValorPrimeiraHora} / Valor Hora Adicional: {dados.ValorHoraAdicional}");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPut("desativar-parametros")]
        public async Task<IActionResult> DesativarParametro()
        {
            if (await _parametrizacaoAppService.VerificarParametrosAtivo() == true)
                return BadRequest("Não há parâmetro ativo no momento");

            try
            {
                var parametro = await _parametrizacaoAppService.BuscarParametro();

                await _parametrizacaoAppService.DesativarParametro(parametro);

                return Ok($"Parâmetro desativado!");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }        
    }
}
