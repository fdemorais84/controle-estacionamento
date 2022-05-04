using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Domain.Interfaces
{
    public interface IParametrizacaoRepository
    {
        Task<Parametro> Consultar();
        Task Adicionar(Parametro dados);
        Task Atualizar(Parametro dados);
    }
}
