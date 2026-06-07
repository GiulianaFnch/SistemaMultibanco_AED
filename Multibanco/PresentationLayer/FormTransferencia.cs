using Multibanco.BusinessLogicLayer;
using Multibanco.Models;

namespace Multibanco.PresentationLayer
{
    public partial class FormTransferencia : Form
    {
        private readonly BankAccount _contaAtual;
        private readonly AccountService _accountService;

        // Após fechar, Form1 pode ler estas propriedades para atualizar o saldo local
        public bool Sucesso { get; private set; }
        public decimal ValorTransferido { get; private set; }

        public FormTransferencia(BankAccount contaAtual, AccountService accountService)
        {
            InitializeComponent();
            _contaAtual = contaAtual;
            _accountService = accountService;
            lblContaOrigem.Text = $"Conta de Origem: {contaAtual.AccountNumber}";
            lblSaldoAtual.Text = $"Saldo Disponível: €{contaAtual.Balance:F2}";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtContaDestino.Text))
            {
                lblMensagem.Text = "❌ Introduza o número da conta de destino.";
                return;
            }

            if (!decimal.TryParse(
                    txtValor.Text.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal valor) || valor <= 0)
            {
                lblMensagem.Text = "❌ Valor inválido. Introduza um número positivo.";
                return;
            }

            bool sucesso = _accountService.RealizarTransferencia(
                _contaAtual.AccountNumber,
                txtContaDestino.Text.Trim(),
                valor,
                out string erro
            );

            if (sucesso)
            {
                ValorTransferido = valor;
                Sucesso = true;
                _contaAtual.Balance -= valor;
                MessageBox.Show(
                    $"✅ Transferência de €{valor:F2} realizada com sucesso!\nConta de destino: {txtContaDestino.Text.Trim()}",
                    "Transferência Concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Close();
            }
            else
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = $"❌ {erro}";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
