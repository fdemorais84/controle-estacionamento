using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Interfaces
{
    public interface IParametrizacaoGratuidadeAppService
    {
        Task CadastrarParametros(ParametroGratuidadeViewModel dados);
        Task<IEnumerable<ParametroGratuidade>> ListarParametros();
    }
}
