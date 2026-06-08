using Xunit;
using Multibanco.DataAccessLayer;
using Multibanco.Models;

namespace Multibanco.Tests
{
    public class AccountRepositoryTests
    {
        [Fact] // O [Fact] diz ao Visual Studio que isto é um teste
        public void GetAccount_ContaExistente_RetornaContaCorreta()
        {
            // 1. Arrange (Preparar o teste)
            var repo = new AccountRepository();
            string numeroContaTeste = "123456789"; // A conta do João Silva

            // 2. Act (Agir / Executar o método que queremos testar)
            var conta = repo.GetAccount(numeroContaTeste);

            // 3. Assert (Verificar se o resultado é o esperado)
            Assert.NotNull(conta); // Garante que não vem nulo
            Assert.Equal("123456789", conta.AccountNumber); // Garante que o número está certo
            Assert.Equal("João Silva", conta.HolderName); // Garante que foi à BD ler o nome certo
        }

        [Fact]
        public void GetAccount_ContaNaoExistente_RetornaNull()
        {
            // Arrange
            var repo = new AccountRepository();

            // Act
            var conta = repo.GetAccount("000000000"); // Uma conta inventada

            // Assert
            Assert.Null(conta); // Como não existe no SQL, tem de retornar nulo
        }
        [Fact]
        public void UpdateAccount_AtualizaSaldoNaBaseDeDados()
        {
            // Arrange
            var repo = new AccountRepository();
            var conta = repo.GetAccount("123456789"); // Conta do João Silva
            decimal saldoOriginal = conta.Balance;
            decimal valorRetirar = 100.00m;

            // Act: Tirar 100 euros e mandar o SQL atualizar
            conta.Balance -= valorRetirar;
            repo.UpdateAccount(conta);

            // Assert: Voltar a ler a conta do SQL e ver se o saldo realmente desceu
            var contaAtualizada = repo.GetAccount("123456789");
            Assert.Equal(saldoOriginal - valorRetirar, contaAtualizada.Balance);

            // Cleanup: Devolver os 100 euros ao João para não estragar futuros testes!
            contaAtualizada.Balance = saldoOriginal;
            repo.UpdateAccount(contaAtualizada);
        }

        [Fact]
        public void RegistarMovimento_InsereMovimentoNoSQL()
        {
            // Arrange
            var repo = new AccountRepository();
            var conta = repo.GetAccount("123456789");
            var novoMovimento = new Movimento
            {
                IdConta = conta.IdConta,
                Data = DateTime.Now,
                Tipo = "Teste",
                Valor = 50.0m,
                Descricao = "Teste de Integração " + Guid.NewGuid().ToString() // Garante que a descrição é única
            };

            // Act
            repo.RegistarMovimento(novoMovimento);

            // Assert: Pedir os movimentos da conta e verificar se o nosso teste lá está
            var movimentosDoJoao = repo.GetMovimentos(conta.IdConta);
            Assert.Contains(movimentosDoJoao, m => m.Descricao == novoMovimento.Descricao);
        }
    }
}