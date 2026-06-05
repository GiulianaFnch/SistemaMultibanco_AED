using Multibanco.Models;

namespace Multibanco.DataAccessLayer
{
    public class AccountRepository
    {
        // Simulando a Base de Dados
        private static List<BankAccount> accounts = new List<BankAccount>
        {
            new BankAccount("123456789", "1234", 5000, "João Silva"),
            new BankAccount("987654321", "5678", 2500, "Maria Santos"),
            new BankAccount("555666777", "0000", 10000, "Pedro Oliveira")
        };

        public BankAccount GetAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void UpdateAccount(BankAccount account)
        {
            var existingAccount = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
            if (existingAccount != null)
            {
                existingAccount.Balance = account.Balance;
            }
        }
    }
}