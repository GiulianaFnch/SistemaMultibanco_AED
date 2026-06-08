using Microsoft.Data.SqlClient;
using Multibanco.Models;
using System.Collections.Generic;

namespace Multibanco.DataAccessLayer
{
    public class ClienteRepository
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SistemaMultibancoDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Cliente> ObterTodosClientes()
        {
            var listaClientes = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT IdCliente, Nome, NIF FROM Clientes";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaClientes.Add(new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Nome = reader["Nome"].ToString(),
                                NIF = reader["NIF"].ToString()
                            });
                        }
                    }
                }
            }
            return listaClientes;
        }
    }
}