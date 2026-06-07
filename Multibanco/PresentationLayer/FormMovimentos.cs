using Multibanco.BusinessLogicLayer;
using Multibanco.Models;

namespace Multibanco.PresentationLayer
{
    // Formulário do Elemento 3: mostra a lista de movimentos de uma conta.
    // Recebe a conta atual e o serviço, tal como os outros formulários do projeto
    // (FormTransferencia, FormPagamentos, etc.), para manter o mesmo padrão.
    public partial class FormMovimentos : Form
    {
        private readonly BankAccount _contaAtual;
        private readonly AccountService _accountService;

        public FormMovimentos(BankAccount contaAtual, AccountService accountService)
        {
            InitializeComponent();
            _contaAtual = contaAtual;
            _accountService = accountService;

            // Cabeçalho com a informação da conta.
            lblConta.Text = $"Conta: {contaAtual.AccountNumber}  •  Titular: {contaAtual.HolderName}";
            lblSaldo.Text = $"Saldo atual: €{contaAtual.Balance:F2}";

            CriarColunas();         // prepara as colunas da tabela uma única vez
            MostrarTodosMovimentos(); // carrega todos os movimentos ao abrir
        }

        // Cria as colunas da tabela manualmente (em vez de gerar automaticamente),
        // para podermos controlar os títulos, larguras e o alinhamento.
        private void CriarColunas()
        {
            dgvMovimentos.Columns.Clear();
            dgvMovimentos.Columns.Add("colData", "Data");
            dgvMovimentos.Columns.Add("colTipo", "Tipo");
            dgvMovimentos.Columns.Add("colValor", "Valor");
            dgvMovimentos.Columns.Add("colDescricao", "Descrição");

            // A coluna do valor fica alinhada à direita (como é habitual em valores monetários).
            dgvMovimentos.Columns["colValor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Damos um peso maior à descrição para ocupar o espaço que sobra.
            dgvMovimentos.Columns["colData"].FillWeight      = 22;
            dgvMovimentos.Columns["colTipo"].FillWeight      = 22;
            dgvMovimentos.Columns["colValor"].FillWeight     = 16;
            dgvMovimentos.Columns["colDescricao"].FillWeight = 40;
        }

        // Vai buscar TODOS os movimentos da conta ao serviço e mostra-os na tabela.
        private void MostrarTodosMovimentos()
        {
            // O "!" indica que a conta autenticada tem sempre número (nunca é nulo aqui).
            var movimentos = _accountService.GetMovimentos(_contaAtual.AccountNumber!);
            PreencherTabela(movimentos);
        }

        // Recebe uma lista de movimentos e desenha-os na tabela, linha a linha.
        // Está separada para podermos reutilizar tanto na listagem completa
        // como (mais tarde) na pesquisa por datas.
        private void PreencherTabela(List<Movimento> movimentos)
        {
            dgvMovimentos.Rows.Clear();

            // Se não houver nada para mostrar, avisamos o utilizador e saímos.
            if (movimentos.Count == 0)
            {
                lblResumo.Text = "Sem movimentos para apresentar.";
                return;
            }

            foreach (var m in movimentos)
            {
                // Adiciona a linha com os dados formatados.
                int linha = dgvMovimentos.Rows.Add(
                    m.Data.ToString("dd/MM/yyyy HH:mm"),
                    m.Tipo,
                    $"€{m.Valor:F2}",
                    m.Descricao
                );

                // Verde para entradas (valor positivo) e vermelho para saídas (valor negativo),
                // para ser fácil distinguir o tipo de movimento num relance.
                dgvMovimentos.Rows[linha].Cells["colValor"].Style.ForeColor =
                    m.Valor >= 0 ? Color.DarkGreen : Color.DarkRed;
            }

            AtualizarResumo(movimentos);
        }

        // Calcula e mostra um pequeno resumo: nº de movimentos, total de entradas e de saídas.
        private void AtualizarResumo(List<Movimento> movimentos)
        {
            decimal entradas = movimentos.Where(m => m.Valor > 0).Sum(m => m.Valor);
            decimal saidas   = movimentos.Where(m => m.Valor < 0).Sum(m => m.Valor); // já é negativo

            lblResumo.Text =
                $"{movimentos.Count} movimento(s)   |   Entradas: €{entradas:F2}   |   Saídas: €{Math.Abs(saidas):F2}";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
