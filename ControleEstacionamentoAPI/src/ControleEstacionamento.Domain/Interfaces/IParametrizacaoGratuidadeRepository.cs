using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Domain.Interfaces
{
    public interface IParametrizacaoGratuidadeRepository
    {
        Task Adicionar(ParametroGratuidade dados);
        List<ParametroGratuidade> Consultar();
    }
}
