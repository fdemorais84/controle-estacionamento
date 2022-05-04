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
    public class ParametrizacaoGratuidadeControllerTests
    {
        private readonly Mock<IParametrizacaoGratuidadeAppService> mockService;
        public ParametrizacaoGratuidadeController controller;

        public ParametrizacaoGratuidadeControllerTests()
        {
            mockService = new Mock<IParametrizacaoGratuidadeAppService>();
            controller = new ParametrizacaoGratuidadeController(mockService.Object);
        }

        [Fact]
        public async Task CadastrarParametros_Sucesso()
        {
            //Arrange
            var parametros = ParametroGratuidadeFactory.GerarParametros();

            //Act
            var parametrosCadastrados = await controller.CadastrarParametros(parametros);

            var statusCode = (parametrosCadastrados as OkObjectResult).StatusCode;

            //Assert
            Assert.NotNull(parametrosCadastrados);
            Assert.Equal(200, statusCode);
        }
    }
}
