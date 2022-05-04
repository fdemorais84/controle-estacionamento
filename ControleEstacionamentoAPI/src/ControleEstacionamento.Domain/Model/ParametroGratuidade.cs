using System;

namespace ControleEstacionamento.Domain.Model
{
    public class ParametroGratuidade : Entity
    { 
        public string DiaSemana { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Encerramento { get; set; }
    }
}
