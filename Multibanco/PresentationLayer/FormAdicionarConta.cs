using Multibanco.BusinessLogicLayer;

namespace Multibanco.PresentationLayer
{
    public partial class FormAdicionarConta : Form
    {
        private Label lblTitulo, lblIdCliente, lblNumeroConta, lblPin;
        private TextBox txtIdCliente, txtNumeroConta, txtPin;
        private Button btnCriar, btnCancelar;
        private readonly ClienteService _service = new ClienteService();

        public FormAdicionarConta()
        {
            InitializeComponent();
            CriarElementos();
        }

        private void CriarElementos()
        {
            lblTitulo = new Label { Text = "Criar Nova Conta", Font = new Font("Segoe UI", 18F), Location = new Point(250, 20), AutoSize = true };
            this.Controls.Add(lblTitulo);

            lblIdCliente = new Label { Text = "ID do Cliente:", Location = new Point(150, 90), AutoSize = true };
            this.Controls.Add(lblIdCliente);
            txtIdCliente = new TextBox { Location = new Point(320, 87), Size = new Size(200, 25) };
            this.Controls.Add(txtIdCliente);

            lblNumeroConta = new Label { Text = "Número da Conta:", Location = new Point(150, 140), AutoSize = true };
            this.Controls.Add(lblNumeroConta);
            txtNumeroConta = new TextBox { Location = new Point(320, 137), Size = new Size(200, 25) };
            this.Controls.Add(txtNumeroConta);

            lblPin = new Label { Text = "PIN:", Location = new Point(150, 190), AutoSize = true };
            this.Controls.Add(lblPin);
            txtPin = new TextBox { Location = new Point(320, 187), Size = new Size(200, 25), PasswordChar = '*' };
            this.Controls.Add(txtPin);

            btnCriar = new Button { Text = "Criar Conta", Location = new Point(220, 260), Size = new Size(120, 40) };
            btnCriar.Click += btnCriar_Click;
            this.Controls.Add(btnCriar);

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(370, 260), Size = new Size(120, 40) };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancelar);

            this.Text = "Criar Nova Conta";
            this.ClientSize = new Size(700, 350);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdCliente.Text, out int id)) { MessageBox.Show("ID inválido!"); return; }
            if (string.IsNullOrWhiteSpace(txtNumeroConta.Text)) { MessageBox.Show("Insira o número!"); return; }
            if (txtPin.Text.Length != 4) { MessageBox.Show("PIN deve ter 4 dígitos!"); return; }

            if (MessageBox.Show($"Criar conta para cliente {id}\nNúmero: {txtNumeroConta.Text}\nSaldo: 100€\n\nConfirma?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _service.AdicionarConta(id, txtNumeroConta.Text, txtPin.Text);
                    MessageBox.Show("Conta criada com sucesso!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            }
        }
    }
}