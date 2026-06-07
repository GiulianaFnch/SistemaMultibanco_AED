namespace Multibanco.PresentationLayer
{
    partial class FormEmprestimo
    {
        private System.ComponentModel.IContainer components = null;

        private Label     lblTitulo;
        private Label     lblSaldoAtual;
        private Label     lblMontanteLabel;
        private TextBox   txtMontante;
        private Label     lblPrazoLabel;
        private ComboBox  cmbPrazo;
        private GroupBox  grpSimulacao;
        private Label     lblTaxaJuro;
        private Label     lblPrestacao;
        private Label     lblTotalPagar;
        private Label     lblTotalJuros;
        private Label     lblMensagem;
        private Button    btnSolicitar;
        private Button    btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo       = new Label();
            lblSaldoAtual   = new Label();
            lblMontanteLabel = new Label();
            txtMontante     = new TextBox();
            lblPrazoLabel   = new Label();
            cmbPrazo        = new ComboBox();
            grpSimulacao    = new GroupBox();
            lblTaxaJuro     = new Label();
            lblPrestacao    = new Label();
            lblTotalPagar   = new Label();
            lblTotalJuros   = new Label();
            lblMensagem     = new Label();
            btnSolicitar    = new Button();
            btnCancelar     = new Button();
            grpSimulacao.SuspendLayout();
            SuspendLayout();

            // lblTitulo
            lblTitulo.BackColor = Color.DarkBlue;
            lblTitulo.Dock      = DockStyle.Top;
            lblTitulo.Font      = new Font("Arial", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Size      = new Size(480, 50);
            lblTitulo.Text      = "🏦  PEDIDO DE EMPRÉSTIMO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblSaldoAtual
            lblSaldoAtual.Font      = new Font("Arial", 11F);
            lblSaldoAtual.ForeColor = Color.DarkGreen;
            lblSaldoAtual.Location  = new Point(20, 62);
            lblSaldoAtual.Size      = new Size(440, 22);

            // lblMontanteLabel
            lblMontanteLabel.Font     = new Font("Arial", 11F);
            lblMontanteLabel.Location = new Point(20, 100);
            lblMontanteLabel.Size     = new Size(320, 22);
            lblMontanteLabel.Text     = "Montante a Solicitar (€500 – €50.000):";

            // txtMontante
            txtMontante.Font         = new Font("Arial", 13F);
            txtMontante.Location     = new Point(20, 125);
            txtMontante.Size         = new Size(190, 29);
            txtMontante.TextChanged += txtMontante_TextChanged;

            // lblPrazoLabel
            lblPrazoLabel.Font     = new Font("Arial", 11F);
            lblPrazoLabel.Location = new Point(20, 170);
            lblPrazoLabel.Size     = new Size(160, 22);
            lblPrazoLabel.Text     = "Prazo (meses):";

            // cmbPrazo
            cmbPrazo.DropDownStyle          = ComboBoxStyle.DropDownList;
            cmbPrazo.Font                   = new Font("Arial", 12F);
            cmbPrazo.Location               = new Point(20, 195);
            cmbPrazo.Size                   = new Size(190, 30);
            cmbPrazo.Items.AddRange(new object[] { "12 meses", "24 meses", "36 meses", "48 meses", "60 meses" });
            cmbPrazo.SelectedIndex          = 0;
            cmbPrazo.SelectedIndexChanged  += cmbPrazo_SelectedIndexChanged;

            // grpSimulacao
            grpSimulacao.Font     = new Font("Arial", 10F, FontStyle.Bold);
            grpSimulacao.Location = new Point(20, 245);
            grpSimulacao.Size     = new Size(440, 130);
            grpSimulacao.Text     = "Simulação";
            grpSimulacao.Controls.Add(lblTaxaJuro);
            grpSimulacao.Controls.Add(lblPrestacao);
            grpSimulacao.Controls.Add(lblTotalPagar);
            grpSimulacao.Controls.Add(lblTotalJuros);

            // lblTaxaJuro
            lblTaxaJuro.Font     = new Font("Arial", 10F);
            lblTaxaJuro.Location = new Point(15, 25);
            lblTaxaJuro.Size     = new Size(220, 20);
            lblTaxaJuro.Text     = "Taxa de Juro: ---";

            // lblPrestacao
            lblPrestacao.Font      = new Font("Arial", 10F, FontStyle.Bold);
            lblPrestacao.ForeColor = Color.DarkBlue;
            lblPrestacao.Location  = new Point(15, 50);
            lblPrestacao.Size      = new Size(280, 20);
            lblPrestacao.Text      = "Prestação Mensal: ---";

            // lblTotalPagar
            lblTotalPagar.Font     = new Font("Arial", 10F);
            lblTotalPagar.Location = new Point(15, 75);
            lblTotalPagar.Size     = new Size(230, 20);
            lblTotalPagar.Text     = "Total a Pagar: ---";

            // lblTotalJuros
            lblTotalJuros.Font      = new Font("Arial", 10F);
            lblTotalJuros.ForeColor = Color.DarkRed;
            lblTotalJuros.Location  = new Point(15, 100);
            lblTotalJuros.Size      = new Size(230, 20);
            lblTotalJuros.Text      = "Total de Juros: ---";

            // btnSolicitar
            btnSolicitar.BackColor            = Color.DarkGreen;
            btnSolicitar.Cursor               = Cursors.Hand;
            btnSolicitar.Font                 = new Font("Arial", 12F, FontStyle.Bold);
            btnSolicitar.ForeColor            = Color.White;
            btnSolicitar.Location             = new Point(20, 400);
            btnSolicitar.Size                 = new Size(200, 44);
            btnSolicitar.Text                 = "✔  SOLICITAR";
            btnSolicitar.UseVisualStyleBackColor = false;
            btnSolicitar.Click               += btnSolicitar_Click;

            // btnCancelar
            btnCancelar.BackColor            = Color.DarkRed;
            btnCancelar.Cursor               = Cursors.Hand;
            btnCancelar.Font                 = new Font("Arial", 12F, FontStyle.Bold);
            btnCancelar.ForeColor            = Color.White;
            btnCancelar.Location             = new Point(250, 400);
            btnCancelar.Size                 = new Size(200, 44);
            btnCancelar.Text                 = "✖  CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click               += btnCancelar_Click;

            // lblMensagem
            lblMensagem.AutoSize  = false;
            lblMensagem.Font      = new Font("Arial", 10F);
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location  = new Point(20, 458);
            lblMensagem.Size      = new Size(440, 40);

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.WhiteSmoke;
            ClientSize          = new Size(480, 515);
            Controls.Add(lblTitulo);
            Controls.Add(lblSaldoAtual);
            Controls.Add(lblMontanteLabel);
            Controls.Add(txtMontante);
            Controls.Add(lblPrazoLabel);
            Controls.Add(cmbPrazo);
            Controls.Add(grpSimulacao);
            Controls.Add(btnSolicitar);
            Controls.Add(btnCancelar);
            Controls.Add(lblMensagem);
            grpSimulacao.ResumeLayout(false);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "FormEmprestimo";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "Pedido de Empréstimo";
            ResumeLayout(false);
        }
    }
}
