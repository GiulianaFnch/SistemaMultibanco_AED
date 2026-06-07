namespace Multibanco.PresentationLayer
{
    // Parte "visual" do formulário de Movimentos (Elemento 3).
    // Aqui só se criam e posicionam os controlos. A lógica está em FormMovimentos.cs.
    partial class FormMovimentos
    {
        private System.ComponentModel.IContainer components = null;

        // --- Controlos do ecrã ---
        private Label lblTitulo;          // barra azul no topo
        private Label lblConta;           // mostra o número da conta
        private Label lblSaldo;           // mostra o saldo atual

        // Filtro por intervalo de datas
        private Label lblDe;              // texto "De:"
        private DateTimePicker dtpInicio; // data inicial do filtro
        private Label lblAte;             // texto "Até:"
        private DateTimePicker dtpFim;    // data final do filtro
        private Button btnPesquisar;      // aplica o filtro de datas
        private Button btnVerTodos;       // remove o filtro e mostra tudo

        private DataGridView dgvMovimentos; // tabela com os movimentos
        private Label lblResumo;            // resumo (entradas, saídas, total)
        private Button btnFechar;           // fecha o formulário

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo     = new Label();
            lblConta      = new Label();
            lblSaldo      = new Label();
            lblDe         = new Label();
            dtpInicio     = new DateTimePicker();
            lblAte        = new Label();
            dtpFim        = new DateTimePicker();
            btnPesquisar  = new Button();
            btnVerTodos   = new Button();
            dgvMovimentos = new DataGridView();
            lblResumo     = new Label();
            btnFechar     = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentos).BeginInit();
            SuspendLayout();

            // lblTitulo (barra de título azul, no mesmo estilo dos outros formulários)
            lblTitulo.BackColor = Color.DarkBlue;
            lblTitulo.Dock      = DockStyle.Top;
            lblTitulo.Font      = new Font("Arial", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Size      = new Size(720, 50);
            lblTitulo.Text      = "📄  MOVIMENTOS DA CONTA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblConta
            lblConta.Font      = new Font("Arial", 11F, FontStyle.Bold);
            lblConta.ForeColor = Color.DarkBlue;
            lblConta.Location  = new Point(20, 65);
            lblConta.Size      = new Size(400, 22);

            // lblSaldo
            lblSaldo.Font      = new Font("Arial", 11F);
            lblSaldo.ForeColor = Color.DarkGreen;
            lblSaldo.Location  = new Point(20, 90);
            lblSaldo.Size      = new Size(400, 22);

            // --- Linha de filtro por datas ---

            // lblDe
            lblDe.Font     = new Font("Arial", 10F);
            lblDe.Location = new Point(20, 124);
            lblDe.Size     = new Size(30, 20);
            lblDe.Text     = "De:";

            // dtpInicio (mostra só a data, sem horas)
            dtpInicio.Format   = DateTimePickerFormat.Short;
            dtpInicio.Font     = new Font("Arial", 10F);
            dtpInicio.Location = new Point(52, 120);
            dtpInicio.Size     = new Size(130, 25);

            // lblAte
            lblAte.Font     = new Font("Arial", 10F);
            lblAte.Location = new Point(195, 124);
            lblAte.Size     = new Size(35, 20);
            lblAte.Text     = "Até:";

            // dtpFim
            dtpFim.Format   = DateTimePickerFormat.Short;
            dtpFim.Font     = new Font("Arial", 10F);
            dtpFim.Location = new Point(232, 120);
            dtpFim.Size     = new Size(130, 25);

            // btnPesquisar
            btnPesquisar.BackColor            = Color.SteelBlue;
            btnPesquisar.Cursor               = Cursors.Hand;
            btnPesquisar.Font                 = new Font("Arial", 10F, FontStyle.Bold);
            btnPesquisar.ForeColor            = Color.White;
            btnPesquisar.Location             = new Point(375, 118);
            btnPesquisar.Size                 = new Size(140, 30);
            btnPesquisar.Text                 = "🔍 Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click               += btnPesquisar_Click;

            // btnVerTodos
            btnVerTodos.BackColor            = Color.Gray;
            btnVerTodos.Cursor               = Cursors.Hand;
            btnVerTodos.Font                 = new Font("Arial", 10F, FontStyle.Bold);
            btnVerTodos.ForeColor            = Color.White;
            btnVerTodos.Location             = new Point(525, 118);
            btnVerTodos.Size                 = new Size(120, 30);
            btnVerTodos.Text                 = "Ver todos";
            btnVerTodos.UseVisualStyleBackColor = false;
            btnVerTodos.Click               += btnVerTodos_Click;

            // dgvMovimentos (tabela só de leitura, seleciona a linha inteira)
            dgvMovimentos.AllowUserToAddRows    = false;
            dgvMovimentos.AllowUserToDeleteRows = false;
            dgvMovimentos.ReadOnly              = true;
            dgvMovimentos.RowHeadersVisible     = false;
            dgvMovimentos.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimentos.MultiSelect           = false;
            dgvMovimentos.BackgroundColor       = Color.White;
            dgvMovimentos.BorderStyle           = BorderStyle.FixedSingle;
            dgvMovimentos.Font                  = new Font("Arial", 10F);
            dgvMovimentos.Location              = new Point(20, 160);
            dgvMovimentos.Size                  = new Size(680, 350);
            dgvMovimentos.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMovimentos.ColumnHeadersDefaultCellStyle.Font      = new Font("Arial", 10F, FontStyle.Bold);
            dgvMovimentos.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvMovimentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMovimentos.EnableHeadersVisualStyles = false;

            // lblResumo (linha de totais por baixo da tabela)
            lblResumo.Font      = new Font("Arial", 10F, FontStyle.Bold);
            lblResumo.ForeColor = Color.Black;
            lblResumo.Location  = new Point(20, 520);
            lblResumo.Size      = new Size(680, 22);

            // btnFechar
            btnFechar.BackColor            = Color.DarkRed;
            btnFechar.Cursor               = Cursors.Hand;
            btnFechar.Font                 = new Font("Arial", 11F, FontStyle.Bold);
            btnFechar.ForeColor            = Color.White;
            btnFechar.Location             = new Point(560, 548);
            btnFechar.Size                 = new Size(140, 40);
            btnFechar.Text                 = "✖  FECHAR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click               += btnFechar_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.WhiteSmoke;
            ClientSize          = new Size(720, 600);
            Controls.Add(lblTitulo);
            Controls.Add(lblConta);
            Controls.Add(lblSaldo);
            Controls.Add(lblDe);
            Controls.Add(dtpInicio);
            Controls.Add(lblAte);
            Controls.Add(dtpFim);
            Controls.Add(btnPesquisar);
            Controls.Add(btnVerTodos);
            Controls.Add(dgvMovimentos);
            Controls.Add(lblResumo);
            Controls.Add(btnFechar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "FormMovimentos";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "Movimentos";
            ((System.ComponentModel.ISupportInitialize)dgvMovimentos).EndInit();
            ResumeLayout(false);
        }
    }
}
