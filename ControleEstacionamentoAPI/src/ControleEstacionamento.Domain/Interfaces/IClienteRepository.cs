using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Consultar(string cpf);
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
    }
}
