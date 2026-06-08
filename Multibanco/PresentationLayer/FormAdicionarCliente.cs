using Multibanco.BusinessLogicLayer;

namespace Multibanco.PresentationLayer
{
    public partial class FormAdicionarCliente : Form
    {
        private readonly ClienteService _service = new ClienteService();

        public FormAdicionarCliente() { InitializeComponent(); }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { MessageBox.Show("Preencha o Nome!"); return; }
            if (string.IsNullOrWhiteSpace(txtNIF.Text)) { MessageBox.Show("Preencha o NIF!"); return; }

            if (MessageBox.Show($"Criar cliente:\nNome: {txtNome.Text}\nNIF: {txtNIF.Text}\nSaldo: 100€\n\nConfirma?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _service.AdicionarCliente(txtNome.Text, txtNIF.Text);
                    MessageBox.Show("Cliente criado com sucesso!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) { this.Close(); }
    }
}