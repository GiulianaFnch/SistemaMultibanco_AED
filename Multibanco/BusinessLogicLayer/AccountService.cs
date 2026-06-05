using Multibanco.Models;
using Multibanco.DataAccessLayer;

namespace Multibanco.BusinessLogicLayer
{
    public class AccountService
    {
        private AccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository();
        }

        // Regra de Negócio 1: Validação de Login
        public BankAccount Login(string accountNumber, string pin)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account != null && account.PIN == pin)
            {
                return account; // Login com sucesso
            }
            return null; // Falha no login
        }

        // Regra de Negócio 2: Levantamento (Verifica saldo)
        public bool RealizarLevantamento(string accountNumber, decimal valor, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            var account = _repository.GetAccount(accountNumber);

            if (account == null)
            {
                mensagemErro = "Conta não encontrada.";
                return false;
            }

            if (account.Balance < valor)
            {
                mensagemErro = "Saldo insuficiente!";
                return false;
            }

            // Se passou nas regras, altera o saldo e manda a Camada de Dados gravar
            account.Balance -= valor;
            _repository.UpdateAccount(account);
            return true;
        }

        // Regra de Negócio 3: Depósito
        public void RealizarDeposito(string accountNumber, decimal valor)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account != null)
            {
                account.Balance += valor;
                _repository.UpdateAccount(account);
            }
        }
    }
}