using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        [Fact(Skip ="Teste repetido")]
        public void ValidaFaturamentoDeSomenteUmVeiculoPatio()
        {
            //Arrange
           var estacionamentTest = new Patio();
           var operador = new Operador();
           var veiculo = new Veiculo();
           estacionamentTest.OperadorPatio = operador;
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

        [Theory(DisplayName ="Conjunto de teste")]
        [InlineData("NomeTeste", "CorTeste", "def-5678", "marcaTeste")]
        [InlineData("NomeTeste2", "CorTeste2", "def-9101", "marcaTeste2")]
        [InlineData("NomeTeste", "CorTeste", "def-1213", "marcaTeste3")]

        public void ConjuntoTesteFaturamento(string proprietario, string cor, string placa, string marca )
        {
            var estacionamentTest = new Patio();
            var operador = new Operador();
            var veiculo = new Veiculo();
            estacionamentTest.OperadorPatio = operador;
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor= cor;
            veiculo.Placa = placa;
            veiculo.Modelo = marca;

            estacionamentTest.RegistrarEntradaVeiculo(veiculo);
            estacionamentTest.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act

            double faturamento = estacionamentTest.TotalFaturado();

            //Assert

            Assert.Equal(2, faturamento);

        }


        // public class DadosVeiculo : IEnumerable<object[]>
        // {
        //     public IEnumerable<object[]> GetEnumerator()
        //     {
        //         yield return new object[] 
        //         {
        //             new Veiculo
        //             {
        //                 Proprietario = "NomeTeste",
        //                 Cor = "azul",
        //                 Placa = "asd-6845",
        //                 Modelo = "gol"
        //             }   
        //         };
                
        //     }
        //     IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => GetEnumerator();
        // } Erro de implementação

        public class DadosVeiculo : TheoryData<Veiculo>
        {
            public DadosVeiculo()
            {
                Add(
                    new Veiculo
                    {
                        Proprietario = "NomeTeste",
                        Cor = "azul",
                        Placa = "asd-6845",
                        Modelo = "gol"
                  } 
                );
                Add(
                    new Veiculo
                    {
                        Proprietario = "NomeTeste2",
                        Cor = "branco",
                        Placa = "asd-8545",
                        Modelo = "fusca"
                  }
                );
            }
        }

        [Theory(DisplayName ="ClassDataTest" )]
        [Trait("Teste", "ClassDataTest")]
        [ClassData(typeof(DadosVeiculo))]
        public void ClassDataTestFaturamento(Veiculo veiculoTeste )
        {
            var estacionamentTest = new Patio();
            var operador = new Operador();
            estacionamentTest.OperadorPatio = operador;
            veiculoTeste.Tipo = TipoVeiculo.Automovel;
            

            estacionamentTest.RegistrarEntradaVeiculo(veiculoTeste);
            estacionamentTest.RegistrarSaidaVeiculo(veiculoTeste.Placa);

            //Act

            double faturamento = estacionamentTest.TotalFaturado();

            //Assert

            Assert.Equal(2, faturamento);

        }

        public class DadosAlteraVeiculo : TheoryData<List<Veiculo>>
        {
            public DadosAlteraVeiculo()
            {
                Add(
                    new List<Veiculo>
                    {
                        new Veiculo
                        {
                            Proprietario = "NomeTeste",
                            Cor = "azul",
                            Placa = "asd-6845",
                            Modelo = "gol"
                        },
                        new Veiculo
                        {
                            Proprietario = "NomeAlterado",
                            Cor = "verde",
                            Placa = "asd-6845",
                            Modelo = "uno"

                        }

                    }
                );
            }
        }

        [Theory(DisplayName ="AlterarTest" )]
        [ClassData(typeof(DadosAlteraVeiculo))]
        public void AlteraVeiculoTest(List<Veiculo> veiculos )
        {
            var estacionamentTest = new Patio();
            var operador = new Operador();
            estacionamentTest.OperadorPatio = operador;
            Veiculo veiculoAtual = veiculos[0];
            veiculoAtual.Tipo = TipoVeiculo.Automovel;
            estacionamentTest.RegistrarEntradaVeiculo(veiculoAtual);

            Veiculo veiculoNovo = veiculos[1];
            veiculoNovo.Tipo = TipoVeiculo.Automovel;
            


            //Act

            Veiculo alterado = estacionamentTest.AlteraDadosVeiculo(veiculoNovo);

            //Assert

            Assert.Equal(alterado.Cor, veiculoNovo.Cor);

        }
    }
}
