using Multibanco.BusinessLogicLayer;
using Multibanco.Models;

namespace Multibanco.PresentationLayer
{
    public partial class FormPagamentos : Form
    {
        private readonly BankAccount _contaAtual;
        private readonly AccountService _accountService;

        public FormPagamentos(BankAccount contaAtual, AccountService accountService)
        {
            InitializeComponent();
            _contaAtual = contaAtual;
            _accountService = accountService;
            lblSaldoAtual.Text = $"Saldo Disponível: €{contaAtual.Balance:F2}";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;

            if (cmbServico.SelectedIndex < 0)
            {
                lblMensagem.Text = "❌ Selecione um serviço.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReferencia.Text))
            {
                lblMensagem.Text = "❌ Introduza a referência do pagamento.";
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

            string servico     = cmbServico.SelectedItem!.ToString()!;
            string referencia  = txtReferencia.Text.Trim();

            DialogResult confirmacao = MessageBox.Show(
                $"Confirmar pagamento?\n\nServiço:     {servico}\nReferência: {referencia}\nValor:          €{valor:F2}",
                "Confirmar Pagamento",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes) return;

            bool sucesso = _accountService.RealizarPagamento(
                _contaAtual.AccountNumber, servico, referencia, valor, out string erro);

            if (sucesso)
            {
                _contaAtual.Balance -= valor;
                MessageBox.Show(
                    $"✅ Pagamento realizado com sucesso!\n{servico}\nValor: €{valor:F2}",
                    "Pagamento Concluído",
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
