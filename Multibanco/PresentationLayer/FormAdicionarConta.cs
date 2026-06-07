namespace Multibanco.PresentationLayer
{
    public partial class FormAdicionarConta : Form
    {
        private Label lblTitulo;
        private Label lblIdCliente;
        private Label lblNumeroConta;
        private Label lblPin;
        private TextBox txtIdCliente;
        private TextBox txtNumeroConta;
        private TextBox txtPin;
        private Button btnCriar;
        private Button btnCancelar;

        public FormAdicionarConta()
        {
            InitializeComponent();
            CriarElementos();
        }

        private void CriarElementos()
        {
            lblTitulo = new Label();
            lblTitulo.Text = "Criar Nova Conta";
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.Location = new Point(250, 20);
            lblTitulo.AutoSize = true;
            this.Controls.Add(lblTitulo);

            lblIdCliente = new Label();
            lblIdCliente.Text = "ID do Cliente:";
            lblIdCliente.Location = new Point(150, 90);
            lblIdCliente.AutoSize = true;
            this.Controls.Add(lblIdCliente);

            txtIdCliente = new TextBox();
            txtIdCliente.Location = new Point(320, 87);
            txtIdCliente.Size = new Size(200, 25);
            this.Controls.Add(txtIdCliente);

            lblNumeroConta = new Label();
            lblNumeroConta.Text = "Número da Conta:";
            lblNumeroConta.Location = new Point(150, 140);
            lblNumeroConta.AutoSize = true;
            this.Controls.Add(lblNumeroConta);

            txtNumeroConta = new TextBox();
            txtNumeroConta.Location = new Point(320, 137);
            txtNumeroConta.Size = new Size(200, 25);
            this.Controls.Add(txtNumeroConta);

            lblPin = new Label();
            lblPin.Text = "PIN:";
            lblPin.Location = new Point(150, 190);
            lblPin.AutoSize = true;
            this.Controls.Add(lblPin);

            txtPin = new TextBox();
            txtPin.Location = new Point(320, 187);
            txtPin.Size = new Size(200, 25);
            txtPin.PasswordChar = '*';
            this.Controls.Add(txtPin);

            btnCriar = new Button();
            btnCriar.Text = "Criar Conta";
            btnCriar.Location = new Point(220, 260);
            btnCriar.Size = new Size(120, 40);
            btnCriar.Click += btnCriar_Click;
            this.Controls.Add(btnCriar);

            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(370, 260);
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.Click += btnCancelar_Click;
            this.Controls.Add(btnCancelar);

            this.Text = "Criar Nova Conta";
            this.ClientSize = new Size(700, 350);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                MessageBox.Show("Por favor insira o ID do cliente!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroConta.Text))
            {
                MessageBox.Show("Por favor insira o número da conta!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPin.Text) || txtPin.Text.Length != 4)
            {
                MessageBox.Show("O PIN deve ter 4 dígitos!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"Criar conta:\nCliente ID: {txtIdCliente.Text}\nNúmero: {txtNumeroConta.Text}\nSaldo inicial: 100€\n\nConfirma?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Conta criada com sucesso! Saldo inicial de 100€.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}