using Multibanco.BusinessLogicLayer;
using Multibanco.Models;

namespace Multibanco.PresentationLayer
{
    public partial class FormEmprestimo : Form
    {
        private readonly BankAccount _contaAtual;
        private readonly AccountService _accountService;

        public FormEmprestimo(BankAccount contaAtual, AccountService accountService)
        {
            InitializeComponent();
            _contaAtual = contaAtual;
            _accountService = accountService;
            lblSaldoAtual.Text = $"Saldo Atual: €{contaAtual.Balance:F2}";
        }

        // Recalcula a simulação sempre que o montante ou prazo mudam
        private void AtualizarSimulacao()
        {
            if (cmbPrazo.SelectedIndex < 0) return;

            if (!decimal.TryParse(
                    txtMontante.Text.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal montante) || montante <= 0)
            {
                LimparSimulacao();
                return;
            }

            int     prazo     = int.Parse(cmbPrazo.SelectedItem!.ToString()!.Split(' ')[0]);
            decimal taxaAnual = _accountService.CalcularTaxaJuro(prazo);
            decimal prestacao = _accountService.CalcularPrestacao(montante, prazo);
            decimal total     = prestacao * prazo;
            decimal juros     = total - montante;

            lblTaxaJuro.Text   = $"Taxa de Juro: {taxaAnual:F1}% ao ano";
            lblPrestacao.Text  = $"Prestação Mensal: €{prestacao:F2}";
            lblTotalPagar.Text = $"Total a Pagar: €{total:F2}";
            lblTotalJuros.Text = $"Total de Juros: €{juros:F2}";
        }

        private void LimparSimulacao()
        {
            lblTaxaJuro.Text   = "Taxa de Juro: ---";
            lblPrestacao.Text  = "Prestação Mensal: ---";
            lblTotalPagar.Text = "Total a Pagar: ---";
            lblTotalJuros.Text = "Total de Juros: ---";
        }

        private void txtMontante_TextChanged(object sender, EventArgs e)
        {
            AtualizarSimulacao();
        }

        private void cmbPrazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarSimulacao();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;

            if (!decimal.TryParse(
                    txtMontante.Text.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal montante) || montante <= 0)
            {
                lblMensagem.Text = "❌ Montante inválido.";
                return;
            }

            int     prazo     = int.Parse(cmbPrazo.SelectedItem!.ToString()!.Split(' ')[0]);
            decimal taxaAnual = _accountService.CalcularTaxaJuro(prazo);
            decimal prestacao = _accountService.CalcularPrestacao(montante, prazo);

            DialogResult confirmacao = MessageBox.Show(
                $"Confirmar pedido de empréstimo?\n\n" +
                $"Montante:         €{montante:F2}\n" +
                $"Prazo:               {prazo} meses\n" +
                $"Taxa de Juro:    {taxaAnual:F1}% ao ano\n" +
                $"Prestação Mensal: €{prestacao:F2}",
                "Confirmar Empréstimo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes) return;

            bool sucesso = _accountService.SolicitarEmprestimo(
                _contaAtual.AccountNumber, montante, prazo,
                out string erro, out decimal prestacaoFinal);

            if (sucesso)
            {
                _contaAtual.Balance += montante;
                MessageBox.Show(
                    $"✅ Empréstimo aprovado!\n\n" +
                    $"Montante creditado: €{montante:F2}\n" +
                    $"Prestação mensal:   €{prestacaoFinal:F2}\n" +
                    $"Novo saldo:         €{_contaAtual.Balance:F2}",
                    "Empréstimo Aprovado",
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
