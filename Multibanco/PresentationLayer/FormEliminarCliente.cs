using Multibanco.BusinessLogicLayer;

namespace Multibanco.PresentationLayer
{
    public partial class FormEliminarCliente : Form
    {
        private readonly ClienteService _service = new ClienteService();

        public FormEliminarCliente() { InitializeComponent(); }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) { MessageBox.Show("Insira o ID!"); return; }
            if (!int.TryParse(txtID.Text, out int id)) { MessageBox.Show("ID tem de ser número!"); return; }

            if (MessageBox.Show($"Eliminar cliente ID {id}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (_service.EliminarCliente(id))
                    {
                        MessageBox.Show("Cliente eliminado!");
                        this.Close();
                    }
                    else MessageBox.Show("Não pode eliminar - cliente tem saldo!");
                }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) { this.Close(); }
        private void btnEliminar_Click_1(object sender, EventArgs e) { }
        private void btnCancelar_Click_1(object sender, EventArgs e) { }
        private void txtID_TextChanged(object sender, EventArgs e) { }
    }
}