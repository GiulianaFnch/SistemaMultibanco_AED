using Microsoft.Data.SqlClient;
using Multibanco.Models;

namespace Multibanco.DataAccessLayer
{
    public class ClienteRepository
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SistemaMultibancoDB;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=1;";

        // Dados em memória para demo quando não há base de dados
        private static List<Cliente> _clientesDemo = new List<Cliente>
        {
            new Cliente { IdCliente = 1, Nome = "João Silva", NIF = "123456789" },
            new Cliente { IdCliente = 2, Nome = "Maria Santos", NIF = "987654321" },
            new Cliente { IdCliente = 3, Nome = "Pedro Oliveira", NIF = "555666777" }
        };

        private static List<BankAccount> _contasDemo = new List<BankAccount>
        {
            new BankAccount("123456789", "1234", 5000, "João Silva") { IdConta = 1, IdCliente = 1, IsDefault = true },
            new BankAccount("987654321", "5678", 2500, "Maria Santos") { IdConta = 2, IdCliente = 2, IsDefault = true },
            new BankAccount("555666777", "0000", 10000, "Pedro Oliveira") { IdConta = 3, IdCliente = 3, IsDefault = true }
        };

        public List<Cliente> ObterTodosClientes()
        {
            try
            {
                var lista = new List<Cliente>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT IdCliente, Nome, NIF FROM Clientes", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            lista.Add(new Cliente { IdCliente = Convert.ToInt32(reader["IdCliente"]), Nome = reader["Nome"].ToString(), NIF = reader["NIF"].ToString() });
                }
                return lista;
            }
            catch { return new List<Cliente>(_clientesDemo); }
        }

        public void AdicionarCliente(string nome, string nif)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Clientes (Nome, NIF) VALUES (@N, @NIF)", conn))
                    {
                        cmd.Parameters.AddWithValue("@N", nome);
                        cmd.Parameters.AddWithValue("@NIF", nif);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                int novoId = _clientesDemo.Count + 1;
                _clientesDemo.Add(new Cliente { IdCliente = novoId, Nome = nome, NIF = nif });
            }
        }

        public bool EliminarCliente(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var c = new SqlCommand("SELECT ISNULL(SUM(Balance),0) FROM Contas WHERE IdCliente=@I", conn))
                    {
                        c.Parameters.AddWithValue("@I", id);
                        if (Convert.ToDecimal(c.ExecuteScalar()) != 0) return false;
                    }
                    using (var c = new SqlCommand("DELETE FROM Contas WHERE IdCliente=@I", conn)) { c.Parameters.AddWithValue("@I", id); c.ExecuteNonQuery(); }
                    using (var c = new SqlCommand("DELETE FROM Clientes WHERE IdCliente=@I", conn)) { c.Parameters.AddWithValue("@I", id); c.ExecuteNonQuery(); }
                }
                return true;
            }
            catch
            {
                var cliente = _clientesDemo.FirstOrDefault(c => c.IdCliente == id);
                if (cliente != null) { _clientesDemo.Remove(cliente); return true; }
                return false;
            }
        }

        public List<BankAccount> ObterTodasContas()
        {
            try
            {
                var lista = new List<BankAccount>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT c.IdConta, c.IdCliente, c.AccountNumber, c.Balance, c.IsDefault, cl.Nome FROM Contas c INNER JOIN Clientes cl ON cl.IdCliente=c.IdCliente", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            lista.Add(new BankAccount(reader["AccountNumber"].ToString(), "", Convert.ToDecimal(reader["Balance"]), reader["Nome"].ToString()) { IdConta = Convert.ToInt32(reader["IdConta"]), IdCliente = Convert.ToInt32(reader["IdCliente"]), IsDefault = Convert.ToBoolean(reader["IsDefault"]) });
                }
                return lista;
            }
            catch { return new List<BankAccount>(_contasDemo); }
        }

        public void AdicionarConta(int idCliente, string num, string pin)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Contas (IdCliente, AccountNumber, PIN, Balance, HolderName, IsDefault) SELECT @I, @A, @P, 100, Nome, 0 FROM Clientes WHERE IdCliente=@I", conn))
                    {
                        cmd.Parameters.AddWithValue("@I", idCliente);
                        cmd.Parameters.AddWithValue("@A", num);
                        cmd.Parameters.AddWithValue("@P", pin);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                var titular = _clientesDemo.FirstOrDefault(c => c.IdCliente == idCliente);
                _contasDemo.Add(new BankAccount(num, pin, 100, titular?.Nome ?? "Cliente") { IdConta = _contasDemo.Count + 1, IdCliente = idCliente, IsDefault = false });
            }
        }
    }
}