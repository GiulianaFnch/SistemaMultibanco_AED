using Multibanco.BusinessLogicLayer;
using Multibanco.Models;

namespace Multibanco.PresentationLayer
{
    // Formulário MBWay (Elemento 3 - funcionalidade extra).
    // Permite ativar o MBWay (associar um telemóvel à conta) e enviar dinheiro
    // para o telemóvel de outra pessoa que também tenha MBWay.
    public partial class FormMBWay : Form
    {
        private readonly BankAccount _contaAtual;
        private readonly MBWayService _mbwayService;

        // Mantemos o mesmo padrão de construtor dos outros formulários (conta + serviço).
        // O AccountService não é usado diretamente aqui, mas é recebido por coerência
        // com o resto do projeto; o MBWay tem o seu próprio serviço.
        public FormMBWay(BankAccount contaAtual, AccountService accountService)
        {
            InitializeComponent();
            _contaAtual = contaAtual;
            _mbwayService = new MBWayService();

            AtualizarEcra();
        }

        // Atualiza o saldo, o estado do MBWay e ativa/desativa os campos conforme o caso.
        private void AtualizarEcra()
        {
            lblSaldo.Text = $"Saldo disponível: €{_contaAtual.Balance:F2}";

            bool ativo = _mbwayService.TemMBWayAtivo(_contaAtual.AccountNumber!);

            if (ativo)
            {
                string telefone = _mbwayService.TelefoneAssociado(_contaAtual.AccountNumber!)!;
                lblEstado.ForeColor = Color.DarkGreen;
                lblEstado.Text = $"✅ MBWay ativo no número {telefone}";

                // Já está ativo: não deixa ativar outra vez, mas deixa enviar dinheiro.
                txtTelefone.Text    = telefone;
                txtTelefone.Enabled = false;
                btnAtivar.Enabled   = false;
                DefinirEnvioAtivo(true);
            }
            else
            {
                lblEstado.ForeColor = Color.DarkRed;
                lblEstado.Text = "MBWay não ativo. Ative para poder enviar dinheiro.";

                // Sem MBWay ativo não se pode enviar dinheiro.
                txtTelefone.Enabled = true;
                btnAtivar.Enabled   = true;
                DefinirEnvioAtivo(false);
            }
        }

        // Liga/desliga os campos da zona "Enviar dinheiro".
        private void DefinirEnvioAtivo(bool ativo)
        {
            txtTelefoneDestino.Enabled = ativo;
            txtValor.Enabled           = ativo;
            btnEnviar.Enabled          = ativo;
        }

        // Ativa o MBWay com o número introduzido.
        private void btnAtivar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;

            bool sucesso = _mbwayService.AtivarMBWay(
                _contaAtual.AccountNumber!, txtTelefone.Text, out string erro);

            if (sucesso)
            {
                MessageBox.Show(
                    $"✅ MBWay ativado no número {txtTelefone.Text.Trim()}!",
                    "MBWay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarEcra();
            }
            else
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = $"❌ {erro}";
            }
        }

        // Envia dinheiro para o telemóvel de destino.
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtTelefoneDestino.Text))
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = "❌ Introduza o telemóvel de destino.";
                return;
            }

            // Aceita vírgula ou ponto como separador decimal (ex.: 12,50 ou 12.50).
            if (!decimal.TryParse(
                    txtValor.Text.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal valor) || valor <= 0)
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = "❌ Valor inválido. Introduza um número positivo.";
                return;
            }

            bool sucesso = _mbwayService.EnviarDinheiro(
                _contaAtual.AccountNumber!, txtTelefoneDestino.Text, valor, out string erro);

            if (sucesso)
            {
                MessageBox.Show(
                    $"✅ Enviados €{valor:F2} via MBWay para {txtTelefoneDestino.Text.Trim()}!",
                    "MBWay", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // O saldo de _contaAtual já foi atualizado pelo serviço (mesma instância
                // de conta partilhada). Limpamos os campos e atualizamos o ecrã.
                txtTelefoneDestino.Clear();
                txtValor.Clear();
                AtualizarEcra();
            }
            else
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = $"❌ {erro}";
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
