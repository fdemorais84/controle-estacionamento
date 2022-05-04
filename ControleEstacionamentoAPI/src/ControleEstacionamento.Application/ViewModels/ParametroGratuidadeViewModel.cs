using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleEstacionamento.Application.ViewModels
{
    public class ParametroGratuidadeViewModel
    {
        [Required]
        public string DiaSemana { get; set; }
        [Required]
        public string Inicio { get; set; }
        [Required]
        public string Encerramento { get; set; }
    }
}
