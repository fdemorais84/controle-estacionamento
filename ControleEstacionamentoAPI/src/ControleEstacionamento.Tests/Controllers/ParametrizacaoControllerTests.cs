using ControleEstacionamento.Api.Controllers;
using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Tests.Factory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControleEstacionamento.Tests.Controllers
{
    public class ParametrizacaoControllerTests
    {
        private readonly Mock<IParametrizacaoAppService> mockService;
        public ParametrizacaoController controller;

        public ParametrizacaoControllerTests()
        {
            mockService = new Mock<IParametrizacaoAppService>();
            controller = new ParametrizacaoController(mockService.Object);
        }

        [Fact]
        public async Task CadastrarParametros_Sucesso()
        {
            //Arrange
            var parametros = ParametroFactory.GerarParametros();

            //Act
            var parametrosCadastrados = await controller.CadastrarParametros(parametros);

            var statusCode = (parametrosCadastrados as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(parametrosCadastrados);
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task DesativarParametro_Sucesso()
        {
            //Act
            var parametrosDesativados = await controller.DesativarParametro();

            var statusCode = (parametrosDesativados as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(parametrosDesativados);
            Assert.Equal(200, statusCode);
        }
    }
}
