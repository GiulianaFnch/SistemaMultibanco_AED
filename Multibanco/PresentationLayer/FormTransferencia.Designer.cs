namespace Multibanco.PresentationLayer
{
    partial class FormTransferencia
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblContaOrigem;
        private Label lblSaldoAtual;
        private Label lblContaDestinoLabel;
        private TextBox txtContaDestino;
        private Label lblValorLabel;
        private TextBox txtValor;
        private Label lblMensagem;
        private Button btnConfirmar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo          = new Label();
            lblContaOrigem     = new Label();
            lblSaldoAtual      = new Label();
            lblContaDestinoLabel = new Label();
            txtContaDestino    = new TextBox();
            lblValorLabel      = new Label();
            txtValor           = new TextBox();
            lblMensagem        = new Label();
            btnConfirmar       = new Button();
            btnCancelar        = new Button();
            SuspendLayout();

            // lblTitulo
            lblTitulo.BackColor = Color.DarkBlue;
            lblTitulo.Dock      = DockStyle.Top;
            lblTitulo.Font      = new Font("Arial", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Size      = new Size(450, 50);
            lblTitulo.Text      = "🔄  TRANSFERÊNCIA ENTRE CONTAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblContaOrigem
            lblContaOrigem.Font      = new Font("Arial", 11F, FontStyle.Bold);
            lblContaOrigem.ForeColor = Color.DarkBlue;
            lblContaOrigem.Location  = new Point(30, 65);
            lblContaOrigem.Size      = new Size(390, 22);

            // lblSaldoAtual
            lblSaldoAtual.Font      = new Font("Arial", 11F);
            lblSaldoAtual.ForeColor = Color.DarkGreen;
            lblSaldoAtual.Location  = new Point(30, 92);
            lblSaldoAtual.Size      = new Size(390, 22);

            // lblContaDestinoLabel
            lblContaDestinoLabel.Font     = new Font("Arial", 11F);
            lblContaDestinoLabel.Location = new Point(30, 135);
            lblContaDestinoLabel.Size     = new Size(260, 22);
            lblContaDestinoLabel.Text     = "Número da Conta de Destino:";

            // txtContaDestino
            txtContaDestino.Font     = new Font("Arial", 13F);
            txtContaDestino.Location = new Point(30, 160);
            txtContaDestino.Size     = new Size(260, 29);

            // lblValorLabel
            lblValorLabel.Font     = new Font("Arial", 11F);
            lblValorLabel.Location = new Point(30, 205);
            lblValorLabel.Size     = new Size(200, 22);
            lblValorLabel.Text     = "Valor a Transferir (€):";

            // txtValor
            txtValor.Font     = new Font("Arial", 13F);
            txtValor.Location = new Point(30, 230);
            txtValor.Size     = new Size(160, 29);

            // btnConfirmar
            btnConfirmar.BackColor            = Color.DarkGreen;
            btnConfirmar.Cursor               = Cursors.Hand;
            btnConfirmar.Font                 = new Font("Arial", 12F, FontStyle.Bold);
            btnConfirmar.ForeColor            = Color.White;
            btnConfirmar.Location             = new Point(30, 290);
            btnConfirmar.Size                 = new Size(180, 44);
            btnConfirmar.Text                 = "✔  CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click               += btnConfirmar_Click;

            // btnCancelar
            btnCancelar.BackColor            = Color.DarkRed;
            btnCancelar.Cursor               = Cursors.Hand;
            btnCancelar.Font                 = new Font("Arial", 12F, FontStyle.Bold);
            btnCancelar.ForeColor            = Color.White;
            btnCancelar.Location             = new Point(230, 290);
            btnCancelar.Size                 = new Size(180, 44);
            btnCancelar.Text                 = "✖  CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click               += btnCancelar_Click;

            // lblMensagem
            lblMensagem.AutoSize = false;
            lblMensagem.Font     = new Font("Arial", 10F);
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location = new Point(30, 350);
            lblMensagem.Size     = new Size(390, 40);

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.WhiteSmoke;
            ClientSize          = new Size(450, 410);
            Controls.Add(lblTitulo);
            Controls.Add(lblContaOrigem);
            Controls.Add(lblSaldoAtual);
            Controls.Add(lblContaDestinoLabel);
            Controls.Add(txtContaDestino);
            Controls.Add(lblValorLabel);
            Controls.Add(txtValor);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Controls.Add(lblMensagem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "FormTransferencia";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "Transferência";
            ResumeLayout(false);
        }
    }
}
