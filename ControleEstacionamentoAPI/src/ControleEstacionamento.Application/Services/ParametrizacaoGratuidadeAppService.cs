using AutoMapper;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Services
{
    public class ParametrizacaoGratuidadeAppService : IParametrizacaoGratuidadeAppService
    {
        private readonly IParametrizacaoGratuidadeRepository _parametrizacaoGratuidadeRepository;
        private readonly IMapper _mapper;

        public ParametrizacaoGratuidadeAppService(IParametrizacaoGratuidadeRepository parametrizacaoGratuidadeRepository, 
                                                  IMapper mapper)
        {
            _parametrizacaoGratuidadeRepository = parametrizacaoGratuidadeRepository;
            _mapper = mapper;
        }        

        public async Task CadastrarParametros(ParametroGratuidadeViewModel dados)
        {
            dados = FormatarDiaSemana(dados);
            await _parametrizacaoGratuidadeRepository.Adicionar(_mapper.Map<ParametroGratuidade>(dados));
        }

        public async Task<IEnumerable<ParametroGratuidade>> ListarParametros()
        {
            return _parametrizacaoGratuidadeRepository.Consultar();
        }

        #region PRIVATE AREA
        private ParametroGratuidadeViewModel FormatarDiaSemana(ParametroGratuidadeViewModel dados)
        {
            switch (dados.DiaSemana)
            {
                case "Domingo":
                    dados.DiaSemana = "Sunday";
                    break;
                case "Segunda":
                    dados.DiaSemana = "Monday";
                    break;
                case "Terça":
                    dados.DiaSemana = "Tuesday";
                    break;
                case "Quarta":
                    dados.DiaSemana = "Wednesday";
                    break;
                case "Quinta":
                    dados.DiaSemana = "Thursday";
                    break;
                case "Sexta":
                    dados.DiaSemana = "Friday";
                    break;
                case "Sabado":
                    dados.DiaSemana = "Saturday";
                    break;
                default:
                    throw new ArgumentException("O dia da semana informado não existe");
            }
            return dados;
        }
        #endregion
    }
}
