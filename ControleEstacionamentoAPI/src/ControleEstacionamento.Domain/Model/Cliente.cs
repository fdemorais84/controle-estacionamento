using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleEstacionamento.Domain.Model
{
    public class Cliente : Entity
    {   
        public Cliente(int quantidade)
        {            
            Quantidade = quantidade;
        }

        public Cliente(string cpf, DateTime data, int quantidade)
        {
            Cpf = cpf;
            DataDesconto = data;
            Quantidade = quantidade;
        }

        public string Cpf { get; set; }
        public DateTime DataDesconto { get; set; }
        public int Quantidade { get; set; }
    }
}
