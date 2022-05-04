using ControleEstacionamento.Api.Controllers;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Tests.Factory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ControleEstacionamento.Tests.Controllers
{
    public class HistoricoControllerTests
    {
        private readonly Mock<IHistoricoAppService> mockService;
        public HistoricoController controller;

        public HistoricoControllerTests()
        {
            mockService = new Mock<IHistoricoAppService>();
            controller = new HistoricoController(mockService.Object);
        }

        [Fact]
        public async Task HistoricoPorCondutor_Sucesso()
        {
            //Arrange
            var cpf = HistoricoFactory.GerarCpfConsulta();

            //Act
            var listaHistoricoCondutor = await controller.HistoricoPorCondutor(cpf);

            var statusCode = (listaHistoricoCondutor as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(listaHistoricoCondutor);
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task HistoricoPorVeiculo_Sucesso()
        {
            //Arrange
            var placa = HistoricoFactory.GerarPlacaConsulta();

            //Act
            var listaHistoricoVeiculo = await controller.HistoricoPorVeiculo(placa);

            var statusCode = (listaHistoricoVeiculo as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(listaHistoricoVeiculo);
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task HistoricoVeiculosEmAberto_Sucesso()
        {
            //Act
            var listaHistoricoEmAberto = await controller.HistoricoVeiculosEmAberto();

            var statusCode = (listaHistoricoEmAberto as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(listaHistoricoEmAberto);
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task HistoricoPorData_Sucesso()
        {
            //Arrange
            var data = HistoricoFactory.GerarDataConsulta();

            //Act
            var listaHistoricoPorData = await controller.HistoricoPorData(data);

            var statusCode = (listaHistoricoPorData as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(listaHistoricoPorData);
            Assert.Equal(200, statusCode);
        }
    }
}
