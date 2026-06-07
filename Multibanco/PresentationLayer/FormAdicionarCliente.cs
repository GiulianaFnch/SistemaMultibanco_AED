namespace Multibanco.PresentationLayer
{
    public partial class FormAdicionarCliente : Form
    {
        public FormAdicionarCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validações - campos não podem estar vazios
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor preencha o Nome!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNIF.Text))
            {
                MessageBox.Show("Por favor preencha o NIF!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Confirmar criação do cliente
            DialogResult resultado = MessageBox.Show(
                $"Criar cliente:\nNome: {txtNome.Text}\nNIF: {txtNIF.Text}\nSaldo inicial: 100€\n\nConfirma?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Cliente criado com sucesso! Saldo inicial de 100€ atribuído.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}