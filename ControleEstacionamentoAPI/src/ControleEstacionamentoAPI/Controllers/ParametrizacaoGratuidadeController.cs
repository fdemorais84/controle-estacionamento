using System;
using System.Threading.Tasks;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamento.Api.Controllers
{
    [Route("api/parametrizacao-gratuidade")]
    public class ParametrizacaoGratuidadeController : ControllerBase
    {
        private readonly IParametrizacaoGratuidadeAppService _parametrizacaoGratuidadeAppService;

        public ParametrizacaoGratuidadeController(IParametrizacaoGratuidadeAppService parametrizacaoGratuidadeAppService)
        {
            _parametrizacaoGratuidadeAppService = parametrizacaoGratuidadeAppService;
        }

        [HttpPost("salvar-parametros")]
        public async Task<IActionResult> CadastrarParametros([FromBody] ParametroGratuidadeViewModel dados)
        {
            try
            {
                await _parametrizacaoGratuidadeAppService.CadastrarParametros(dados);

                return Ok($"Novos parâmetros de gratuidade cadastrados!");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("buscar-parametros")]
        public async Task<IActionResult> ListarParametros()
        {
            try
            {
                return Ok(await _parametrizacaoGratuidadeAppService.ListarParametros());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
