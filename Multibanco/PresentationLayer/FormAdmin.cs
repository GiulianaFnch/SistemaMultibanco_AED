namespace Multibanco.PresentationLayer
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUtilizador.Text == "sibs" && txtPassword.Text == "sibs")
            {
                MessageBox.Show("Bem-vindo, Administrador SIBS!",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Esconde o login e mostra o painel
                lblUtilizador.Visible = false;
                lblPassword.Visible = false;
                txtUtilizador.Visible = false;
                txtPassword.Visible = false;
                btnLogin.Visible = false;
                lblTitulo.Visible = false;
                pnlAdmin.Visible = true;
            }
            else
            {
                MessageBox.Show("Utilizador ou password incorretos!",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Clear();
            }
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            FormListarClientes formListar = new FormListarClientes();
            formListar.Show();
        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            FormAdicionarCliente formAdicionar = new FormAdicionarCliente();
            formAdicionar.Show();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            FormEliminarCliente formEliminar = new FormEliminarCliente();
            formEliminar.Show();
        }

        private void btnListarContas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade: Listar todas as contas.",
                "Listar Contas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListarClientes_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdicionarCliente_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminarCliente_Click_1(object sender, EventArgs e)
        {

        }

        private void btnListarContas_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {

        }
    }
}