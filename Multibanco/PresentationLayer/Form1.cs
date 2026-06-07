using Multibanco.BusinessLogicLayer;
using Multibanco.DataAccessLayer;
using Multibanco.Models;
using Multibanco.PresentationLayer;

namespace Multibanco
{
    public partial class Form1 : Form
    {
        private BankAccount currentAccount;
        private string operacaoAtual;
        private AccountService _accountService;

        // Botões adicionados pelo Elemento 4 (criados via código para não alterar o Designer)
        private Button btnPagamentos;
        private Button btnEmprestimo;

        // Botão adicionado pelo Elemento 3 (mesmo método: criado via código)
        private Button btnMovimentos;

        public Form1()
        {
            InitializeComponent();
            _accountService = new AccountService();
            ConfigurarEventos();
            AdicionarBotoesExtras();
            AdicionarBotoesElemento3();

            // Carrega alguns movimentos de exemplo para a demonstração do extrato
            // (só corre uma vez; ver DadosDemo.cs). Quando o SQL estiver ligado, basta remover esta linha.
            DadosDemo.CarregarMovimentosExemplo();
        }

        private void ConfigurarEventos()
        {
            btnLogin.Click               += BtnLogin_Click;
            btnConsultarSaldo.Click      += BtnConsultarSaldo_Click;
            btnLevantamento.Click        += BtnLevantamento_Click;
            btnDeposito.Click            += BtnDeposito_Click;
            btnTransferencia.Click       += BtnTransferencia_Click;
            btnSair.Click                += BtnSair_Click;
            btnConfirmarOperacao.Click   += BtnConfirmarOperacao_Click;
            btnCancelarOperacao.Click    += BtnCancelarOperacao_Click;

            KeyPreview = true;
            KeyDown   += Form1_KeyDown;
        }

        // Adiciona os botões Pagamentos e Empréstimos ao pnlMenu sem alterar o Designer
        private void AdicionarBotoesExtras()
        {
            btnPagamentos = new Button
            {
                BackColor            = Color.DarkCyan,
                Cursor               = Cursors.Hand,
                Font                 = new Font("Arial", 12F, FontStyle.Bold),
                ForeColor            = Color.White,
                Location             = new Point(330, 100),
                Size                 = new Size(220, 50),
                Text                 = "💳 PAGAMENTOS",
                UseVisualStyleBackColor = false
            };
            btnPagamentos.Click += BtnPagamentos_Click;

            btnEmprestimo = new Button
            {
                BackColor            = Color.SaddleBrown,
                Cursor               = Cursors.Hand,
                Font                 = new Font("Arial", 12F, FontStyle.Bold),
                ForeColor            = Color.White,
                Location             = new Point(330, 160),
                Size                 = new Size(220, 50),
                Text                 = "🏦 EMPRÉSTIMOS",
                UseVisualStyleBackColor = false
            };
            btnEmprestimo.Click += BtnEmprestimo_Click;

            pnlMenu.Controls.Add(btnPagamentos);
            pnlMenu.Controls.Add(btnEmprestimo);
        }

        // Adiciona o botão "MOVIMENTOS" (Elemento 3) ao menu, também por código
        // para não mexer no Designer e evitar conflitos com o trabalho dos colegas.
        private void AdicionarBotoesElemento3()
        {
            btnMovimentos = new Button
            {
                BackColor               = Color.DarkSlateBlue,
                Cursor                  = Cursors.Hand,
                Font                    = new Font("Arial", 12F, FontStyle.Bold),
                ForeColor               = Color.White,
                Location                = new Point(330, 220),
                Size                    = new Size(220, 50),
                Text                    = "📄 MOVIMENTOS",
                UseVisualStyleBackColor = false
            };
            btnMovimentos.Click += BtnMovimentos_Click;

            pnlMenu.Controls.Add(btnMovimentos);
        }

        // Abre o extrato (FormMovimentos) com a conta atual.
        private void BtnMovimentos_Click(object sender, EventArgs e)
        {
            var form = new FormMovimentos(currentAccount, _accountService);
            form.ShowDialog(this);
        }

        // --- Login ---

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
            pnlLogin.Visible   = false;
            pnlOperacao.Visible = false;
            pnlMenu.Visible    = true;
            lblWelcome.Text    = $"Bem-vindo, {currentAccount.HolderName}!";
            operacaoAtual      = null;
        }

        // --- Operações do menu ---

        private void BtnConsultarSaldo_Click(object sender, EventArgs e)
        {
            currentAccount = _accountService.Login(currentAccount.AccountNumber, currentAccount.PIN);
            MessageBox.Show($"Saldo atual: €{currentAccount.Balance:F2}", "Saldo da Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // --- Transferência (Elemento 4) ---
        private void BtnTransferencia_Click(object sender, EventArgs e)
        {
            var form = new FormTransferencia(currentAccount, _accountService);
            form.ShowDialog(this);
        }

        // --- Pagamentos Pré-definidos (Elemento 4) ---
        private void BtnPagamentos_Click(object sender, EventArgs e)
        {
            var form = new FormPagamentos(currentAccount, _accountService);
            form.ShowDialog(this);
        }

        // --- Empréstimos (Elemento 4) ---
        private void BtnEmprestimo_Click(object sender, EventArgs e)
        {
            var form = new FormEmprestimo(currentAccount, _accountService);
            form.ShowDialog(this);
        }

        // --- Operações genéricas (Levantamento / Depósito) ---

        private void MostrarTelaOperacao(string titulo, string label)
        {
            pnlMenu.Visible     = false;
            pnlLogin.Visible    = false;
            pnlOperacao.Visible = true;
            lblOperacaoTitle.Text    = titulo;
            lblOperacaoLabel.Text    = label;
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
                    bool sucesso = _accountService.RealizarLevantamento(currentAccount.AccountNumber, valor, out string erro);
                    if (sucesso)
                    {
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

        // --- Sair ---

        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                currentAccount = null;
                LimparCamposLogin();
                pnlMenu.Visible     = false;
                pnlOperacao.Visible = false;
                pnlLogin.Visible    = true;
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
                BtnSair_Click(null, null);
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e) { }

        private void lblInfo_Click(object sender, EventArgs e) { }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
        }
    }
}
