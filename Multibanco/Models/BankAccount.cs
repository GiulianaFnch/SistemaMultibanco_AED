namespace Multibanco.Models
{
    public class BankAccount
    {
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public bool IsDefault { get; set; }
        public string? AccountNumber { get; set; }
        public string? PIN { get; set; }
        public decimal Balance { get; set; }
        public string? HolderName { get; set; }

        public BankAccount(string? accountNumber, string? pin, decimal balance, string? holderName)
        {
            AccountNumber = accountNumber;
            PIN = pin;
            Balance = balance;
            HolderName = holderName;
        }
    }
}