using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstacionamento.Domain.Model
{
    public class Ticket : Entity
    {        
        [Required(ErrorMessage = "Os dados da placa é obrigatório", AllowEmptyStrings = false)]
        public string Placa { get; set; }
        public string Cpf { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public bool Desconto { get; set; }
    }
}
