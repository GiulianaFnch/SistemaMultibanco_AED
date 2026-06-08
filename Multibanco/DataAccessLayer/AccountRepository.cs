using Microsoft.Data.SqlClient;
using Multibanco.Models;

namespace Multibanco.DataAccessLayer
{
    public class AccountRepository
    {
        // Connection string para o LocalDB
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SistemaMultibancoDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // ---------- CONTAS ----------

        public BankAccount GetAccount(string accountNumber)
        {
            BankAccount account = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT IdConta, IdCliente, AccountNumber, PIN, Balance, HolderName, IsDefault FROM Contas WHERE AccountNumber = @AccNum";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccNum", accountNumber);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new BankAccount(
                                reader["AccountNumber"].ToString(),
                                reader["PIN"].ToString(),
                                Convert.ToDecimal(reader["Balance"]),
                                reader["HolderName"].ToString()
                            )
                            {
                                IdConta = Convert.ToInt32(reader["IdConta"]),
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                IsDefault = Convert.ToBoolean(reader["IsDefault"])
                            };
                        }
                    }
                }
            }
            return account;
        }

        public void UpdateAccount(BankAccount account)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Agora fazemos UPDATE real (Resolve Bug #19 do relatório)
                string query = "UPDATE Contas SET Balance = @Balance WHERE IdConta = @IdConta";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Balance", account.Balance);
                    cmd.Parameters.AddWithValue("@IdConta", account.IdConta);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ---------- MOVIMENTOS ----------

        public void RegistarMovimento(Movimento movimento)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // O SQL gera o IdMovimento automaticamente agora
                string query = "INSERT INTO Movimentos (IdConta, Data, Tipo, Valor, Descricao) VALUES (@IdConta, @Data, @Tipo, @Valor, @Descricao)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdConta", movimento.IdConta);
                    cmd.Parameters.AddWithValue("@Data", movimento.Data);
                    cmd.Parameters.AddWithValue("@Tipo", movimento.Tipo);
                    cmd.Parameters.AddWithValue("@Valor", movimento.Valor);
                    cmd.Parameters.AddWithValue("@Descricao", movimento.Descricao);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Movimento> GetMovimentos(int idConta)
        {
            var lista = new List<Movimento>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT IdMovimento, IdConta, Data, Tipo, Valor, Descricao FROM Movimentos WHERE IdConta = @IdConta ORDER BY Data DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdConta", idConta);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Movimento
                            {
                                IdMovimento = Convert.ToInt32(reader["IdMovimento"]),
                                IdConta = Convert.ToInt32(reader["IdConta"]),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Tipo = reader["Tipo"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"]),
                                Descricao = reader["Descricao"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Movimento> GetMovimentosByDateRange(int idConta, DateTime inicio, DateTime fim)
        {
            var lista = new List<Movimento>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT IdMovimento, IdConta, Data, Tipo, Valor, Descricao FROM Movimentos WHERE IdConta = @IdConta AND Data >= @Inicio AND Data < @Fim ORDER BY Data DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdConta", idConta);
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fim", fim.AddDays(1));
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Mesma lógica de extração do GetMovimentos acima
                            lista.Add(new Movimento
                            {
                                IdMovimento = Convert.ToInt32(reader["IdMovimento"]),
                                IdConta = Convert.ToInt32(reader["IdConta"]),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Tipo = reader["Tipo"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"]),
                                Descricao = reader["Descricao"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}