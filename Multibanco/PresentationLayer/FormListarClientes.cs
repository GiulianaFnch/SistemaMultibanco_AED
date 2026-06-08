using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Multibanco.BusinessLogicLayer;
using Multibanco.Models;

namespace Multibanco.PresentationLayer
{
    public partial class FormListarClientes : Form
    {
        private readonly ClienteService _clienteService;

        public FormListarClientes()
        {
            InitializeComponent();
            _clienteService = new ClienteService(); // Inicia o serviço
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            // 1. Configurar as colunas (mantém-se igual)
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("Id", "ID");
            dgvClientes.Columns.Add("Nome", "Nome");
            dgvClientes.Columns.Add("NIF", "NIF");

            // Nota: Se quiser manter o "Saldo Inicial", ele deve vir da tabela Contas. 
            // Para simplificar agora, focamo-nos nos dados do cliente.

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;

            // 2. Ir buscar os dados reais à Base de Dados!
            try
            {
                List<Cliente> clientesBD = _clienteService.ObterTodosClientes();

                // 3. Preencher a tabela dinamicamente
                foreach (var cliente in clientesBD)
                {
                    dgvClientes.Rows.Add(cliente.IdCliente, cliente.Nome, cliente.NIF);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes da base de dados: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}