using Multibanco.Models;

namespace Multibanco.DataAccessLayer
{
    public class AccountRepository
    {
        // Simulando a Base de Dados (Giuliana vai substituir por SQL Server)
        private static List<BankAccount> accounts = new List<BankAccount>
        {
            new BankAccount("123456789", "1234", 5000, "João Silva")   { IdConta = 1, IdCliente = 1, IsDefault = true },
            new BankAccount("987654321", "5678", 2500, "Maria Santos") { IdConta = 2, IdCliente = 2, IsDefault = true },
            new BankAccount("555666777", "0000", 10000, "Pedro Oliveira") { IdConta = 3, IdCliente = 3, IsDefault = true }
        };

        private static List<Movimento> movimentos = new List<Movimento>();
        private static int nextMovimentoId = 1;

        // ---------- Contas ----------

        public BankAccount GetAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void UpdateAccount(BankAccount account)
        {
            var existing = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
            if (existing != null)
            {
                existing.Balance = account.Balance;
            }
        }

        // ---------- Movimentos ----------

        public void RegistarMovimento(Movimento movimento)
        {
            movimento.IdMovimento = nextMovimentoId++;
            movimentos.Add(movimento);
        }

        public List<Movimento> GetMovimentos(int idConta)
        {
            return movimentos
                .Where(m => m.IdConta == idConta)
                .OrderByDescending(m => m.Data)
                .ToList();
        }

        public List<Movimento> GetMovimentosByDateRange(int idConta, DateTime inicio, DateTime fim)
        {
            return movimentos
                .Where(m => m.IdConta == idConta && m.Data >= inicio && m.Data < fim.AddDays(1))
                .OrderByDescending(m => m.Data)
                .ToList();
        }
    }
}
