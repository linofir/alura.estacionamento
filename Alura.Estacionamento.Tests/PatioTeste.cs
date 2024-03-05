using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamentoDeSomenteUmVeiculoPatio()
        {
            //Arrange
           var estacionamentTest = new Patio();
           var veiculo = new Veiculo();
           veiculo.Proprietario = "LIno";
           veiculo.Tipo = TipoVeiculo.Automovel;
           veiculo.Cor= "Branco";
           veiculo.Placa = "abc-1234";
           veiculo.Modelo = "Gol";

           estacionamentTest.RegistrarEntradaVeiculo(veiculo);
           estacionamentTest.RegistrarSaidaVeiculo(veiculo.Placa);

           //Act

           double faturamento = estacionamentTest.TotalFaturado();

           //Assert

           Assert.Equal(2, faturamento);


        }

    }
}
