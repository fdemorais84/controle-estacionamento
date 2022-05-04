using ControleEstacionamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstacionamento.Tests.Factory
{
    public class EstacionamentoFactory
    {
        public static TicketEntradaViewModel GerarDadosEntrada()
        {
            return new TicketEntradaViewModel
            {
                Placa = "BBB-1234"
            };
        }

        public static TicketSaidaViewModel GerarDadosSaida()
        {
            return new TicketSaidaViewModel
            {
                Placa = "BBB-1234",
                Cpf = "92069398072"
            };
        }
    }
}
