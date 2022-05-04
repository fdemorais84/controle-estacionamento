using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleEstacionamento.Domain.Model
{
    public class Parametro : Entity
    {
        public decimal ValorPrimeiraHora { get; set; }
        public decimal ValorHoraAdicional { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativo { get; set; }
    }
}
