using ControleEstacionamento.Api.Controllers;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Tests.Factory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ControleEstacionamento.Tests.Controllers
{
    public class EstacionamentoControllerTests
    {
        private readonly Mock<IEstacionamentoAppService> mockService;
        private readonly Mock<IParametrizacaoAppService> mockServiceParam;
        public EstacionamentoController controller;

        public EstacionamentoControllerTests()
        {
            mockService = new Mock<IEstacionamentoAppService>();
            mockServiceParam = new Mock<IParametrizacaoAppService>();
            controller = new EstacionamentoController(mockService.Object, mockServiceParam.Object);
        }

        [Fact]
        public async Task Entrada_Sucesso()
        {
            //Arrange
            var dadosEntrada = EstacionamentoFactory.GerarDadosEntrada();

            //Act
            var ticketEntrada = await controller.Entrada(dadosEntrada);

            var statusCode = (ticketEntrada as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(ticketEntrada);
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task Saida_Sucesso()
        {
            //Arrange
            var dadosSaida = EstacionamentoFactory.GerarDadosSaida();

            //Act
            var ticketSaida = await controller.Saida(dadosSaida);

            var statusCode = (ticketSaida as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(ticketSaida);
            Assert.Equal(200, statusCode);
        }
    }
}
