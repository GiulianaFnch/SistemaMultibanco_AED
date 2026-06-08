using Multibanco.Models;
using Multibanco.DataAccessLayer;

namespace Multibanco.BusinessLogicLayer
{
    public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository();
        }

        // --- Autenticação ---

        public BankAccount Login(string accountNumber, string pin)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account != null && account.PIN == pin)
                return account;
            return null;
        }

        // --- Operações Básicas ---

        public BankAccount GetAccount(string accountNumber)
        {
            // O Serviço pede ao Repositório para ir buscar a conta ao SQL
            return _repository.GetAccount(accountNumber);
        }

        public bool RealizarLevantamento(string accountNumber, decimal valor, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            var account = _repository.GetAccount(accountNumber);

            if (account == null) { mensagemErro = "Conta não encontrada."; return false; }
            if (account.Balance < valor) { mensagemErro = "Saldo insuficiente!"; return false; }

            account.Balance -= valor;
            _repository.UpdateAccount(account);
            _repository.RegistarMovimento(new Movimento
            {
                IdConta = account.IdConta,
                Data = DateTime.Now,
                Tipo = "Levantamento",
                Valor = -valor,
                Descricao = $"Levantamento de €{valor:F2}"
            });
            return true;
        }

        public void RealizarDeposito(string accountNumber, decimal valor)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account == null) return;

            account.Balance += valor;
            _repository.UpdateAccount(account);
            _repository.RegistarMovimento(new Movimento
            {
                IdConta = account.IdConta,
                Data = DateTime.Now,
                Tipo = "Depósito",
                Valor = valor,
                Descricao = $"Depósito de €{valor:F2}"
            });
        }

        // --- Transferência entre Contas ---

        public bool RealizarTransferencia(string contaOrigem, string contaDestino, decimal valor, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            var origem = _repository.GetAccount(contaOrigem);
            var destino = _repository.GetAccount(contaDestino);

            if (origem == null) { mensagemErro = "Conta de origem não encontrada."; return false; }
            if (destino == null) { mensagemErro = "Conta de destino não encontrada."; return false; }
            if (contaOrigem == contaDestino) { mensagemErro = "Não pode transferir para a mesma conta."; return false; }
            if (origem.Balance < valor) { mensagemErro = "Saldo insuficiente para a transferência!"; return false; }

            origem.Balance -= valor;
            destino.Balance += valor;
            _repository.UpdateAccount(origem);
            _repository.UpdateAccount(destino);

            _repository.RegistarMovimento(new Movimento
            {
                IdConta = origem.IdConta,
                Data = DateTime.Now,
                Tipo = "Transferência Enviada",
                Valor = -valor,
                Descricao = $"Transferência para conta {contaDestino}"
            });
            _repository.RegistarMovimento(new Movimento
            {
                IdConta = destino.IdConta,
                Data = DateTime.Now,
                Tipo = "Transferência Recebida",
                Valor = valor,
                Descricao = $"Transferência de conta {contaOrigem}"
            });

            return true;
        }

        // --- Pagamentos Pré-definidos ---

        public bool RealizarPagamento(string accountNumber, string servico, string referencia, decimal valor, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            var account = _repository.GetAccount(accountNumber);

            if (account == null) { mensagemErro = "Conta não encontrada."; return false; }
            if (valor <= 0) { mensagemErro = "O valor do pagamento tem de ser positivo."; return false; }
            if (account.Balance < valor) { mensagemErro = "Saldo insuficiente para este pagamento!"; return false; }

            account.Balance -= valor;
            _repository.UpdateAccount(account);
            _repository.RegistarMovimento(new Movimento
            {
                IdConta = account.IdConta,
                Data = DateTime.Now,
                Tipo = "Pagamento",
                Valor = -valor,
                Descricao = $"Pagamento {servico} - Ref: {referencia}"
            });
            return true;
        }

        // --- Empréstimos ---

        public bool SolicitarEmprestimo(string accountNumber, decimal montante, int prazoMeses,
            out string mensagemErro, out decimal prestacaoMensal)
        {
            mensagemErro = string.Empty;
            prestacaoMensal = 0;

            var account = _repository.GetAccount(accountNumber);
            if (account == null) { mensagemErro = "Conta não encontrada."; return false; }
            if (montante < 500 || montante > 50000)
            {
                mensagemErro = "O montante deve estar entre €500 e €50.000.";
                return false;
            }

            prestacaoMensal = CalcularPrestacao(montante, prazoMeses);
            decimal taxaAnual = CalcularTaxaJuro(prazoMeses);

            account.Balance += montante;
            _repository.UpdateAccount(account);
            _repository.RegistarMovimento(new Movimento
            {
                IdConta = account.IdConta,
                Data = DateTime.Now,
                Tipo = "Empréstimo",
                Valor = montante,
                Descricao = $"Empréstimo €{montante:F2} - {prazoMeses} meses a {taxaAnual:F1}%/ano"
            });
            return true;
        }

        public decimal CalcularTaxaJuro(int prazoMeses)
        {
            return prazoMeses switch
            {
                <= 12 => 4.5m,
                <= 24 => 5.5m,
                <= 36 => 6.5m,
                <= 48 => 7.5m,
                _ => 8.5m
            };
        }

        public decimal CalcularPrestacao(decimal montante, int prazoMeses)
        {
            decimal taxaMensal = CalcularTaxaJuro(prazoMeses) / 12 / 100;
            decimal fator = (decimal)Math.Pow((double)(1 + taxaMensal), prazoMeses);
            return montante * (taxaMensal * fator) / (fator - 1);
        }

        // --- Movimentos (para Elemento 3 usar) ---

        public List<Movimento> GetMovimentos(string accountNumber)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account == null) return new List<Movimento>();
            return _repository.GetMovimentos(account.IdConta);
        }

        public List<Movimento> GetMovimentosByDateRange(string accountNumber, DateTime inicio, DateTime fim)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account == null) return new List<Movimento>();
            return _repository.GetMovimentosByDateRange(account.IdConta, inicio, fim);
        }
    }
}
