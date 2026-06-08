using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Multibanco.BusinessLogicLayer;

namespace Multibanco.Tests
{
    public class AccountServiceTests
    {
        [Theory] // Theory permite testar com vários dados de entrada
        [InlineData(12, 4.5)] // 12 meses -> Taxa de 4.5
        [InlineData(24, 5.5)] // 24 meses -> Taxa de 5.5
        [InlineData(30, 6.5)] // 30 meses -> Taxa de 6.5
        [InlineData(60, 8.5)] // 60 meses -> Taxa de 8.5
        public void CalcularTaxaJuro_RetornaTaxaCorreta(int meses, decimal taxaEsperada)
        {
            // Arrange
            var service = new AccountService();

            // Act
            decimal taxaCalculada = service.CalcularTaxaJuro(meses);

            // Assert
            Assert.Equal(taxaEsperada, taxaCalculada);
        }

        [Fact]
        public void RealizarLevantamento_ComSaldoSuficiente_RetornaTrueEAtualizaSaldo()
        {
            // Arrange
            var service = new AccountService();
            var conta = service.GetAccount("987654321"); // Maria Santos
            decimal saldoInicial = conta.Balance;

            // Act: Tentar levantar 50 euros
            bool sucesso = service.RealizarLevantamento("987654321", 50, out string erro);

            // Assert
            Assert.True(sucesso); // Tem de ter sucesso
            Assert.Empty(erro);   // Não pode haver mensagem de erro

            var contaAtualizada = service.GetAccount("987654321");
            Assert.Equal(saldoInicial - 50, contaAtualizada.Balance); // O saldo tem de descer 50 euros

            // Cleanup: Repor o dinheiro da Maria
            service.RealizarDeposito("987654321", 50);
        }

        [Fact]
        public void RealizarLevantamento_SemSaldoSuficiente_RetornaFalse()
        {
            // Arrange
            var service = new AccountService();

            // Act: Tentar levantar um milhão de euros (ela não tem este dinheiro)
            bool sucesso = service.RealizarLevantamento("987654321", 1000000, out string erro);

            // Assert
            Assert.False(sucesso); // Tem de falhar
            Assert.Equal("Saldo insuficiente!", erro); // A mensagem de erro tem de ser exatamente esta
        }

    }
}