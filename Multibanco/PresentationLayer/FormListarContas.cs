using Multibanco.BusinessLogicLayer;

namespace Multibanco.PresentationLayer
{
    public partial class FormListarContas : Form
    {
        private DataGridView dgvContas;
        private Button btnFechar;
        private Label lblTitulo;
        private readonly ClienteService _service = new ClienteService();

        public FormListarContas()
        {
            InitializeComponent();
            CriarElementos();
            CarregarContas();
        }

        private void CriarElementos()
        {
            lblTitulo = new Label { Text = "Lista de Contas", Font = new Font("Segoe UI", 20F), Location = new Point(287, 20), AutoSize = true };
            this.Controls.Add(lblTitulo);

            dgvContas = new DataGridView { Location = new Point(50, 80), Size = new Size(700, 280), ReadOnly = true, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            this.Controls.Add(dgvContas);

            btnFechar = new Button { Text = "Fechar", Location = new Point(630, 380), Size = new Size(120, 40) };
            btnFechar.Click += (s, e) => this.Close();
            this.Controls.Add(btnFechar);

            this.Text = "Lista de Contas";
            this.ClientSize = new Size(800, 450);
        }

        private void CarregarContas()
        {
            dgvContas.Columns.Clear();
            dgvContas.Columns.Add("Id", "ID");
            dgvContas.Columns.Add("Numero", "Número");
            dgvContas.Columns.Add("Titular", "Titular");
            dgvContas.Columns.Add("Saldo", "Saldo");
            dgvContas.Columns.Add("Default", "Principal");

            try
            {
                foreach (var c in _service.ObterTodasContas())
                    dgvContas.Rows.Add(c.IdConta, c.AccountNumber, c.HolderName, c.Balance.ToString("F2") + "€", c.IsDefault ? "Sim" : "Não");
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnFechar_Click(object sender, EventArgs e) { this.Close(); }
    }
}