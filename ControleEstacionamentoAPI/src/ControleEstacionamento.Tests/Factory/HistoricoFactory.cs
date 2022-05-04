using ControleEstacionamento.Application.ViewModels;

namespace ControleEstacionamento.Tests.Factory
{
    public class HistoricoFactory
    {
        public static HistoricoViewModel GerarDataConsulta()
        {
            return new HistoricoViewModel
            { data = "02/05/2022" };
        }

        public static string GerarPlacaConsulta()
        {
            var placa = "BBB-1234";
            return placa;
        }

        public static string GerarCpfConsulta()
        {
            var cpf = "92069398072";
            return cpf;
        }
    }
}
