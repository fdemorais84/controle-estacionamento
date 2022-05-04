using ControleEstacionamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstacionamento.Tests.Factory
{
    public class ParametroFactory
    {
        public static ParametroViewModel GerarParametros()
        {
            return new ParametroViewModel
            { 
                ValorPrimeiraHora = 1,
                ValorHoraAdicional = 2,
                DataInicio = "01/01/2022",
                DataFim = "31/12/2022"
            };
        }
    }
}
