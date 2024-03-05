using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste
    {
        [Fact]
        public void VeiculoTesteAcelerar()
        {
            //Arrange
            var veiculoTeste = new Veiculo();
            //Act
            veiculoTeste.Acelerar(20);
            //Assert
            Assert.Equal(100, veiculoTeste.VelocidadeAtual);
        
        }

    }
   
}
