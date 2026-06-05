namespace Multibanco.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string PIN { get; set; }
        public decimal Balance { get; set; }
        public string HolderName { get; set; }

        public BankAccount(string accountNumber, string pin, decimal balance, string holderName)
        {
            AccountNumber = accountNumber;
            PIN = pin;
            Balance = balance;
            HolderName = holderName;
        }
    }
}