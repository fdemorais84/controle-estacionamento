using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Application.Interfaces
{
    public interface IParametrizacaoAppService
    {
        Task<bool> VerificarParametrosAtivo();
        Task CadastrarParametros(ParametroViewModel dados);
        Task<Parametro> BuscarParametro();
        Task DesativarParametro(Parametro dados);
    }
}
