namespace Multibanco.PresentationLayer
{
    public partial class FormEliminarCliente : Form
    {
        public FormEliminarCliente()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validação - campo não pode estar vazio
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Por favor insira o ID do cliente!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validação - tem de ser um número
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("O ID tem de ser um número!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Verificação de saldo (quando houver base de dados vai verificar aqui)
            // Por agora mostra mensagem de confirmação
            DialogResult resultado = MessageBox.Show(
                $"Tem a certeza que quer eliminar o cliente com ID {id}?\nEsta ação não pode ser desfeita!",
                "Confirmar Eliminação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Cliente eliminado com sucesso!",
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }
    }
}