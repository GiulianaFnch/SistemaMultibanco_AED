namespace Multibanco.PresentationLayer
{
    public partial class FormListarClientes : Form
    {
        public FormListarClientes()
        {
            InitializeComponent();
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            // Criar as colunas da tabela
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("Id", "ID");
            dgvClientes.Columns.Add("Nome", "Nome");
            dgvClientes.Columns.Add("NIF", "NIF");
            dgvClientes.Columns.Add("Saldo", "Saldo Inicial");

            // Dados de exemplo (depois virão da base de dados)
            dgvClientes.Rows.Add(1, "João Silva", "123456789", "100€");
            dgvClientes.Rows.Add(2, "Maria Santos", "987654321", "100€");
            dgvClientes.Rows.Add(3, "Pedro Oliveira", "555666777", "100€");

            // Estilo da tabela
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {

        }
    }
}