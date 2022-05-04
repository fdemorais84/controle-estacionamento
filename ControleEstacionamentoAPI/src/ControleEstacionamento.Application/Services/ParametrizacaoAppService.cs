using AutoMapper;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Interfaces;
using ControleEstacionamento.Domain.Model;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Services
{
    public class ParametrizacaoAppService : IParametrizacaoAppService
    {
        private readonly IParametrizacaoRepository _parametrizacaoRepository;
        private readonly IParametrizacaoGratuidadeRepository _parametrizacaoGratuidadeRepository;
        private readonly IMapper _mapper;

        public ParametrizacaoAppService(IParametrizacaoRepository parametrizacaoRepository,
                                        IParametrizacaoGratuidadeRepository parametrizacaoGratuidadeRepository,
                                        IMapper mapper)
        {
            _parametrizacaoRepository = parametrizacaoRepository;
            _parametrizacaoGratuidadeRepository = parametrizacaoGratuidadeRepository;
            _mapper = mapper;
        }

        public async Task<bool> VerificarParametrosAtivo()
        {
            return await _parametrizacaoRepository.Consultar() != null ? true : false;            
        }

        public async Task CadastrarParametros(ParametroViewModel dados)
        {
            await _parametrizacaoRepository.Adicionar(_mapper.Map<Parametro>(dados));
        }

        public async Task<Parametro> BuscarParametro()
        {
            return await _parametrizacaoRepository.Consultar();            
        }

        public async Task DesativarParametro(Parametro dados)
        {            
            await _parametrizacaoRepository.Atualizar(RemoverFlag(dados));
        }

        public async Task CadastrarParametrosGratuidade(ParametroGratuidadeViewModel dados)
        {
            await _parametrizacaoGratuidadeRepository.Adicionar(_mapper.Map<ParametroGratuidade>(dados));
        }

        #region PRIVATE AREA

        public Parametro RemoverFlag(Parametro dados)
        {
            dados.Ativo = false;
            return dados;
        }

        #endregion
    }
}
