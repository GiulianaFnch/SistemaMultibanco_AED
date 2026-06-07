using Multibanco.BusinessLogicLayer; // Importar a Lógica
using Multibanco.Models;
using Multibanco.PresentationLayer;

namespace Multibanco
{
    public partial class Form1 : Form
    {
        private BankAccount currentAccount;
        private string operacaoAtual;
        private AccountService _accountService; // Instanciar o serviço

        public Form1()
        {
            InitializeComponent();
            ConfigurarEventos();
            _accountService = new AccountService(); // Inicializar
        }

        private void ConfigurarEventos()
        {
            btnLogin.Click += BtnLogin_Click;
            btnConsultarSaldo.Click += BtnConsultarSaldo_Click;
            btnLevantamento.Click += BtnLevantamento_Click;
            btnDeposito.Click += BtnDeposito_Click;
            btnTransferencia.Click += BtnTransferencia_Click;
            btnSair.Click += BtnSair_Click;
            btnConfirmarOperacao.Click += BtnConfirmarOperacao_Click;
            btnCancelarOperacao.Click += BtnCancelarOperacao_Click;

            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccount.Text) || string.IsNullOrWhiteSpace(txtPin.Text))
            {
                MessageBox.Show("Por favor, preencha os campos obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAccount = _accountService.Login(txtAccount.Text, txtPin.Text);

            if (currentAccount != null)
            {
                MostrarMenu();
            }
            else
            {
                MessageBox.Show("Número de conta ou PIN incorretos!", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCamposLogin();
            }
        }

        private void MostrarMenu()
        {
            pnlLogin.Visible = false;
            pnlOperacao.Visible = false;
            pnlMenu.Visible = true;
            lblWelcome.Text = $"Bem-vindo, {currentAccount.HolderName}!";
            operacaoAtual = null;
        }

        private void BtnConsultarSaldo_Click(object sender, EventArgs e)
        {
            currentAccount = _accountService.Login(currentAccount.AccountNumber, currentAccount.PIN);
            MessageBox.Show($"Seu saldo atual é: €{currentAccount.Balance:F2}", "Saldo da Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLevantamento_Click(object sender, EventArgs e)
        {
            operacaoAtual = "Levantamento";
            MostrarTelaOperacao("💵 LEVANTAMENTO", "Digite o valor a levantar (€):");
        }

        private void BtnDeposito_Click(object sender, EventArgs e)
        {
            operacaoAtual = "Deposito";
            MostrarTelaOperacao("📥 DEPÓSITO", "Digite o valor a depositar (€):");
        }

        private void BtnTransferencia_Click(object sender, EventArgs e)
        {
            operacaoAtual = "Transferencia";
            MostrarTelaOperacao("🔄 TRANSFERÊNCIA", "Digite o valor a transferir (€):");
        }

        private void MostrarTelaOperacao(string titulo, string label)
        {
            pnlMenu.Visible = false;
            pnlLogin.Visible = false;
            pnlOperacao.Visible = true;
            lblOperacaoTitle.Text = titulo;
            lblOperacaoLabel.Text = label;
            txtOperacaoValor.Clear();
            lblMensagemOperacao.Text = "";
            txtOperacaoValor.Focus();
        }

        private void BtnConfirmarOperacao_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtOperacaoValor.Text, out decimal valor) || valor <= 0)
            {
                lblMensagemOperacao.Text = "❌ Valor inválido! Digite um número positivo.";
                return;
            }

            try
            {
                if (operacaoAtual == "Levantamento")
                {
                    // A Lógica de negócio decide se pode ou não levantar
                    bool sucesso = _accountService.RealizarLevantamento(currentAccount.AccountNumber, valor, out string erro);

                    if (sucesso)
                    {
                        // Atualizar a variável local para mostrar o novo saldo no ecrã
                        currentAccount.Balance -= valor;
                        lblMensagemOperacao.Text = $"✅ Levantamento de €{valor:F2} realizado com sucesso!";
                        System.Threading.Thread.Sleep(2000);
                        MostrarMenu();
                    }
                    else
                    {
                        lblMensagemOperacao.Text = $"❌ {erro} Saldo disponível: €{currentAccount.Balance:F2}";
                    }
                }
                else if (operacaoAtual == "Deposito")
                {
                    _accountService.RealizarDeposito(currentAccount.AccountNumber, valor);
                    currentAccount.Balance += valor;
                    lblMensagemOperacao.Text = $"✅ Depósito de €{valor:F2} realizado com sucesso!";
                    System.Threading.Thread.Sleep(2000);
                    MostrarMenu();
                }
                // (Fazer o mesmo conceito para a Transferência depois)
            }
            catch (Exception ex)
            {
                lblMensagemOperacao.Text = $"❌ Erro: {ex.Message}";
            }
        }

        private void BtnCancelarOperacao_Click(object sender, EventArgs e)
        {
            MostrarMenu();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                currentAccount = null;
                LimparCamposLogin();
                pnlMenu.Visible = false;
                pnlOperacao.Visible = false;
                pnlLogin.Visible = true;
            }
        }

        private void LimparCamposLogin()
        {
            txtAccount.Clear();
            txtPin.Clear();
            txtAccount.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && pnlMenu.Visible)
            {
                BtnSair_Click(null, null);
            }
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
        }
    }
}
