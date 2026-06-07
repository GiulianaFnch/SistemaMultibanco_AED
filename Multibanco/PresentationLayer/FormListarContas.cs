namespace Multibanco.PresentationLayer
{
    public partial class FormListarContas : Form
    {
        private DataGridView dgvContas;
        private Button btnFechar;
        private Label lblTitulo;

        public FormListarContas()
        {
            InitializeComponent();
            CriarElementos();
            CarregarContas();
        }

        private void CriarElementos()
        {
            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Lista de Contas";
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(287, 20);
            lblTitulo.AutoSize = true;
            this.Controls.Add(lblTitulo);

            // Tabela
            dgvContas = new DataGridView();
            dgvContas.Location = new Point(50, 80);
            dgvContas.Size = new Size(700, 280);
            dgvContas.ReadOnly = true;
            dgvContas.AllowUserToAddRows = false;
            dgvContas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dgvContas);

            // Botão Fechar
            btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Location = new Point(630, 380);
            btnFechar.Size = new Size(120, 40);
            btnFechar.Click += btnFechar_Click;
            this.Controls.Add(btnFechar);

            this.Text = "Lista de Contas";
            this.ClientSize = new Size(800, 450);
        }

        private void CarregarContas()
        {
            dgvContas.Columns.Add("Id", "ID");
            dgvContas.Columns.Add("Numero", "Número da Conta");
            dgvContas.Columns.Add("Titular", "Titular");
            dgvContas.Columns.Add("Saldo", "Saldo");
            dgvContas.Columns.Add("Default", "Conta Principal");

            dgvContas.Rows.Add(1, "123456789", "João Silva", "5000€", "Sim");
            dgvContas.Rows.Add(2, "987654321", "Maria Santos", "2500€", "Sim");
            dgvContas.Rows.Add(3, "555666777", "Pedro Oliveira", "10000€", "Sim");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}