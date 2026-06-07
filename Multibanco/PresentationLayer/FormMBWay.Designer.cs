namespace Multibanco.PresentationLayer
{
    // Parte visual do formulário MBWay (Elemento 3 - extra).
    // Tem duas zonas: "Ativar MBWay" e "Enviar dinheiro".
    partial class FormMBWay
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;            // barra de título
        private Label lblSaldo;             // saldo disponível
        private Label lblEstado;            // estado do MBWay (ativo / não ativo)

        // Zona "Ativar MBWay"
        private Label lblTelefoneLabel;     // "Número de telemóvel:"
        private TextBox txtTelefone;        // telemóvel a associar
        private Button btnAtivar;           // ativa o MBWay

        // Zona "Enviar dinheiro"
        private Label lblEnviarTitulo;      // subtítulo "Enviar dinheiro"
        private Label lblDestinoLabel;      // "Telemóvel de destino:"
        private TextBox txtTelefoneDestino; // telemóvel de quem recebe
        private Label lblValorLabel;        // "Valor (€):"
        private TextBox txtValor;           // valor a enviar
        private Button btnEnviar;           // envia o dinheiro

        private Label lblMensagem;          // mensagens de erro/sucesso
        private Button btnFechar;           // fecha o formulário

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo          = new Label();
            lblSaldo           = new Label();
            lblEstado          = new Label();
            lblTelefoneLabel   = new Label();
            txtTelefone        = new TextBox();
            btnAtivar          = new Button();
            lblEnviarTitulo    = new Label();
            lblDestinoLabel    = new Label();
            txtTelefoneDestino = new TextBox();
            lblValorLabel      = new Label();
            txtValor           = new TextBox();
            btnEnviar          = new Button();
            lblMensagem        = new Label();
            btnFechar          = new Button();
            SuspendLayout();

            // lblTitulo
            lblTitulo.BackColor = Color.MediumVioletRed;
            lblTitulo.Dock      = DockStyle.Top;
            lblTitulo.Font      = new Font("Arial", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Size      = new Size(460, 50);
            lblTitulo.Text      = "📱  MBWAY";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblSaldo
            lblSaldo.Font      = new Font("Arial", 11F);
            lblSaldo.ForeColor = Color.DarkGreen;
            lblSaldo.Location  = new Point(20, 60);
            lblSaldo.Size      = new Size(420, 22);

            // lblEstado
            lblEstado.Font      = new Font("Arial", 10F, FontStyle.Bold);
            lblEstado.Location  = new Point(20, 88);
            lblEstado.Size      = new Size(420, 22);

            // lblTelefoneLabel
            lblTelefoneLabel.Font     = new Font("Arial", 10F);
            lblTelefoneLabel.Location = new Point(20, 120);
            lblTelefoneLabel.Size     = new Size(200, 20);
            lblTelefoneLabel.Text     = "Número de telemóvel:";

            // txtTelefone
            txtTelefone.Font     = new Font("Arial", 12F);
            txtTelefone.Location = new Point(20, 143);
            txtTelefone.MaxLength = 9;
            txtTelefone.Size     = new Size(190, 27);

            // btnAtivar
            btnAtivar.BackColor            = Color.MediumVioletRed;
            btnAtivar.Cursor               = Cursors.Hand;
            btnAtivar.Font                 = new Font("Arial", 10F, FontStyle.Bold);
            btnAtivar.ForeColor            = Color.White;
            btnAtivar.Location             = new Point(225, 142);
            btnAtivar.Size                 = new Size(200, 30);
            btnAtivar.Text                 = "Ativar MBWay";
            btnAtivar.UseVisualStyleBackColor = false;
            btnAtivar.Click               += btnAtivar_Click;

            // lblEnviarTitulo (separa a zona de envio)
            lblEnviarTitulo.BackColor = Color.Gainsboro;
            lblEnviarTitulo.Font      = new Font("Arial", 11F, FontStyle.Bold);
            lblEnviarTitulo.Location  = new Point(20, 190);
            lblEnviarTitulo.Size      = new Size(405, 26);
            lblEnviarTitulo.Text      = "  Enviar dinheiro";
            lblEnviarTitulo.TextAlign = ContentAlignment.MiddleLeft;

            // lblDestinoLabel
            lblDestinoLabel.Font     = new Font("Arial", 10F);
            lblDestinoLabel.Location = new Point(20, 228);
            lblDestinoLabel.Size     = new Size(200, 20);
            lblDestinoLabel.Text     = "Telemóvel de destino:";

            // txtTelefoneDestino
            txtTelefoneDestino.Font      = new Font("Arial", 12F);
            txtTelefoneDestino.Location  = new Point(20, 251);
            txtTelefoneDestino.MaxLength = 9;
            txtTelefoneDestino.Size      = new Size(190, 27);

            // lblValorLabel
            lblValorLabel.Font     = new Font("Arial", 10F);
            lblValorLabel.Location = new Point(20, 290);
            lblValorLabel.Size     = new Size(200, 20);
            lblValorLabel.Text     = "Valor a enviar (€):";

            // txtValor
            txtValor.Font     = new Font("Arial", 12F);
            txtValor.Location = new Point(20, 313);
            txtValor.Size     = new Size(190, 27);

            // btnEnviar
            btnEnviar.BackColor            = Color.DarkGreen;
            btnEnviar.Cursor               = Cursors.Hand;
            btnEnviar.Font                 = new Font("Arial", 12F, FontStyle.Bold);
            btnEnviar.ForeColor            = Color.White;
            btnEnviar.Location             = new Point(20, 358);
            btnEnviar.Size                 = new Size(200, 44);
            btnEnviar.Text                 = "💸  Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click               += btnEnviar_Click;

            // lblMensagem
            lblMensagem.Font      = new Font("Arial", 10F);
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location  = new Point(20, 415);
            lblMensagem.Size      = new Size(420, 40);

            // btnFechar
            btnFechar.BackColor            = Color.DarkRed;
            btnFechar.Cursor               = Cursors.Hand;
            btnFechar.Font                 = new Font("Arial", 11F, FontStyle.Bold);
            btnFechar.ForeColor            = Color.White;
            btnFechar.Location             = new Point(285, 460);
            btnFechar.Size                 = new Size(140, 40);
            btnFechar.Text                 = "✖  FECHAR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click               += btnFechar_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.WhiteSmoke;
            ClientSize          = new Size(460, 515);
            Controls.Add(lblTitulo);
            Controls.Add(lblSaldo);
            Controls.Add(lblEstado);
            Controls.Add(lblTelefoneLabel);
            Controls.Add(txtTelefone);
            Controls.Add(btnAtivar);
            Controls.Add(lblEnviarTitulo);
            Controls.Add(lblDestinoLabel);
            Controls.Add(txtTelefoneDestino);
            Controls.Add(lblValorLabel);
            Controls.Add(txtValor);
            Controls.Add(btnEnviar);
            Controls.Add(lblMensagem);
            Controls.Add(btnFechar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "FormMBWay";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "MBWay";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
