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
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("Id", "ID");
            dgvClientes.Columns.Add("Nome", "Nome");
            dgvClientes.Columns.Add("NIF", "NIF");
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;

            try
            {
                var clientes = new ClienteService().ObterTodosClientes();
                foreach (var c in clientes)
                    dgvClientes.Rows.Add(c.IdCliente, c.Nome, c.NIF);
            }
            catch
            {
                dgvClientes.Rows.Add(1, "João Silva", "123456789");
                dgvClientes.Rows.Add(2, "Maria Santos", "987654321");
                dgvClientes.Rows.Add(3, "Pedro Oliveira", "555666777");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}