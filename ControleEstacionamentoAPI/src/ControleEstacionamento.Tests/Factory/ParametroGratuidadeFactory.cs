using ControleEstacionamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstacionamento.Tests.Factory
{
    public class ParametroGratuidadeFactory
    {
        public static ParametroGratuidadeViewModel GerarParametros()
        {
            return new ParametroGratuidadeViewModel
            {
                DiaSemana = "Saturday",
                Inicio = "11:00",
                Encerramento = "14:00"                
            };
        }
    }
}
