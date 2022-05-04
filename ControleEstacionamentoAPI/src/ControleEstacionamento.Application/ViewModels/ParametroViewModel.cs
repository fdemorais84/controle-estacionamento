using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleEstacionamento.Application.ViewModels
{
    public class ParametroViewModel
    {
        [Required]
        public decimal ValorPrimeiraHora { get; set; }
        [Required]
        public decimal ValorHoraAdicional { get; set; }
        [Required]
        public string DataInicio { get; set; }
        [Required]
        public string DataFim { get; set; }
    }
}
