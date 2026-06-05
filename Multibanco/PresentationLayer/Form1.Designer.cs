namespace Multibanco
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles da interface
        private Label lblTitle;
        private Panel pnlLogin;
        private Panel pnlMenu;
        private Panel pnlOperacao;
        private TextBox txtAccount;
        private TextBox txtPin;
        private Button btnLogin;
        private Label lblWelcome;
        private Button btnConsultarSaldo;
        private Button btnLevantamento;
        private Button btnDeposito;
        private Button btnTransferencia;
        private Button btnSair;
        private Label lblOperacaoTitle;
        private Label lblOperacaoLabel;
        private TextBox txtOperacaoValor;
        private Button btnConfirmarOperacao;
        private Button btnCancelarOperacao;
        private Label lblMensagemOperacao;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlLogin = new Panel();
            lblAccount = new Label();
            txtAccount = new TextBox();
            lblPin = new Label();
            txtPin = new TextBox();
            btnLogin = new Button();
            lblInfo = new Label();
            pnlMenu = new Panel();
            lblWelcome = new Label();
            btnConsultarSaldo = new Button();
            btnLevantamento = new Button();
            btnDeposito = new Button();
            btnTransferencia = new Button();
            btnSair = new Button();
            pnlOperacao = new Panel();
            lblOperacaoTitle = new Label();
            lblOperacaoLabel = new Label();
            txtOperacaoValor = new TextBox();
            btnConfirmarOperacao = new Button();
            btnCancelarOperacao = new Button();
            lblMensagemOperacao = new Label();
            pnlLogin.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlOperacao.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.DarkBlue;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 60);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "🏦 MULTIBANCO";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.WhiteSmoke;
            pnlLogin.Controls.Add(lblAccount);
            pnlLogin.Controls.Add(txtAccount);
            pnlLogin.Controls.Add(lblPin);
            pnlLogin.Controls.Add(txtPin);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(lblInfo);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(0, 60);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(800, 540);
            pnlLogin.TabIndex = 0;
            pnlLogin.Paint += pnlLogin_Paint;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Font = new Font("Arial", 12F);
            lblAccount.Location = new Point(50, 80);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(135, 18);
            lblAccount.TabIndex = 0;
            lblAccount.Text = "Número de Conta:";
            // 
            // txtAccount
            // 
            txtAccount.Font = new Font("Arial", 14F);
            txtAccount.Location = new Point(50, 110);
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(300, 29);
            txtAccount.TabIndex = 1;
            // 
            // lblPin
            // 
            lblPin.AutoSize = true;
            lblPin.Font = new Font("Arial", 12F);
            lblPin.Location = new Point(50, 160);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(37, 18);
            lblPin.TabIndex = 2;
            lblPin.Text = "PIN:";
            // 
            // txtPin
            // 
            txtPin.Font = new Font("Arial", 14F);
            txtPin.Location = new Point(50, 190);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(300, 29);
            txtPin.TabIndex = 3;
            txtPin.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkGreen;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Arial", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 260);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ENTRAR";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Arial", 10F);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(400, 80);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(123, 64);
            lblInfo.TabIndex = 5;
            lblInfo.Text = "Contas de teste:\n123456789 / 1234\n987654321 / 5678\n555666777 / 0000";
            lblInfo.Click += lblInfo_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.WhiteSmoke;
            pnlMenu.Controls.Add(lblWelcome);
            pnlMenu.Controls.Add(btnConsultarSaldo);
            pnlMenu.Controls.Add(btnLevantamento);
            pnlMenu.Controls.Add(btnDeposito);
            pnlMenu.Controls.Add(btnTransferencia);
            pnlMenu.Controls.Add(btnSair);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 60);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(800, 540);
            pnlMenu.TabIndex = 1;
            pnlMenu.Visible = false;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 22);
            lblWelcome.TabIndex = 0;
            // 
            // btnConsultarSaldo
            // 
            btnConsultarSaldo.BackColor = Color.SteelBlue;
            btnConsultarSaldo.Cursor = Cursors.Hand;
            btnConsultarSaldo.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnConsultarSaldo.ForeColor = Color.White;
            btnConsultarSaldo.Location = new Point(50, 100);
            btnConsultarSaldo.Name = "btnConsultarSaldo";
            btnConsultarSaldo.Size = new Size(250, 50);
            btnConsultarSaldo.TabIndex = 1;
            btnConsultarSaldo.Text = "💰 CONSULTAR SALDO";
            btnConsultarSaldo.UseVisualStyleBackColor = false;
            // 
            // btnLevantamento
            // 
            btnLevantamento.BackColor = Color.DarkOrange;
            btnLevantamento.Cursor = Cursors.Hand;
            btnLevantamento.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnLevantamento.ForeColor = Color.White;
            btnLevantamento.Location = new Point(50, 160);
            btnLevantamento.Name = "btnLevantamento";
            btnLevantamento.Size = new Size(250, 50);
            btnLevantamento.TabIndex = 2;
            btnLevantamento.Text = "💵 LEVANTAMENTO";
            btnLevantamento.UseVisualStyleBackColor = false;
            // 
            // btnDeposito
            // 
            btnDeposito.BackColor = Color.Teal;
            btnDeposito.Cursor = Cursors.Hand;
            btnDeposito.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnDeposito.ForeColor = Color.White;
            btnDeposito.Location = new Point(50, 220);
            btnDeposito.Name = "btnDeposito";
            btnDeposito.Size = new Size(250, 50);
            btnDeposito.TabIndex = 3;
            btnDeposito.Text = "📥 DEPÓSITO";
            btnDeposito.UseVisualStyleBackColor = false;
            // 
            // btnTransferencia
            // 
            btnTransferencia.BackColor = Color.Purple;
            btnTransferencia.Cursor = Cursors.Hand;
            btnTransferencia.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnTransferencia.ForeColor = Color.White;
            btnTransferencia.Location = new Point(50, 280);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(250, 50);
            btnTransferencia.TabIndex = 4;
            btnTransferencia.Text = "🔄 TRANSFERÊNCIA";
            btnTransferencia.UseVisualStyleBackColor = false;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.DarkRed;
            btnSair.Cursor = Cursors.Hand;
            btnSair.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnSair.ForeColor = Color.White;
            btnSair.Location = new Point(50, 340);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(250, 50);
            btnSair.TabIndex = 5;
            btnSair.Text = "🚪 SAIR";
            btnSair.UseVisualStyleBackColor = false;
            // 
            // pnlOperacao
            // 
            pnlOperacao.BackColor = Color.WhiteSmoke;
            pnlOperacao.Controls.Add(lblOperacaoTitle);
            pnlOperacao.Controls.Add(lblOperacaoLabel);
            pnlOperacao.Controls.Add(txtOperacaoValor);
            pnlOperacao.Controls.Add(btnConfirmarOperacao);
            pnlOperacao.Controls.Add(btnCancelarOperacao);
            pnlOperacao.Controls.Add(lblMensagemOperacao);
            pnlOperacao.Dock = DockStyle.Fill;
            pnlOperacao.Location = new Point(0, 60);
            pnlOperacao.Name = "pnlOperacao";
            pnlOperacao.Size = new Size(800, 540);
            pnlOperacao.TabIndex = 2;
            pnlOperacao.Visible = false;
            // 
            // lblOperacaoTitle
            // 
            lblOperacaoTitle.AutoSize = true;
            lblOperacaoTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblOperacaoTitle.Location = new Point(30, 30);
            lblOperacaoTitle.Name = "lblOperacaoTitle";
            lblOperacaoTitle.Size = new Size(0, 22);
            lblOperacaoTitle.TabIndex = 0;
            // 
            // lblOperacaoLabel
            // 
            lblOperacaoLabel.AutoSize = true;
            lblOperacaoLabel.Font = new Font("Arial", 12F);
            lblOperacaoLabel.Location = new Point(50, 100);
            lblOperacaoLabel.Name = "lblOperacaoLabel";
            lblOperacaoLabel.Size = new Size(0, 18);
            lblOperacaoLabel.TabIndex = 1;
            // 
            // txtOperacaoValor
            // 
            txtOperacaoValor.Font = new Font("Arial", 14F);
            txtOperacaoValor.Location = new Point(50, 130);
            txtOperacaoValor.Name = "txtOperacaoValor";
            txtOperacaoValor.Size = new Size(200, 29);
            txtOperacaoValor.TabIndex = 2;
            // 
            // btnConfirmarOperacao
            // 
            btnConfirmarOperacao.BackColor = Color.DarkGreen;
            btnConfirmarOperacao.Cursor = Cursors.Hand;
            btnConfirmarOperacao.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnConfirmarOperacao.ForeColor = Color.White;
            btnConfirmarOperacao.Location = new Point(50, 200);
            btnConfirmarOperacao.Name = "btnConfirmarOperacao";
            btnConfirmarOperacao.Size = new Size(200, 40);
            btnConfirmarOperacao.TabIndex = 3;
            btnConfirmarOperacao.Text = "CONFIRMAR";
            btnConfirmarOperacao.UseVisualStyleBackColor = false;
            // 
            // btnCancelarOperacao
            // 
            btnCancelarOperacao.BackColor = Color.DarkRed;
            btnCancelarOperacao.Cursor = Cursors.Hand;
            btnCancelarOperacao.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnCancelarOperacao.ForeColor = Color.White;
            btnCancelarOperacao.Location = new Point(270, 200);
            btnCancelarOperacao.Name = "btnCancelarOperacao";
            btnCancelarOperacao.Size = new Size(200, 40);
            btnCancelarOperacao.TabIndex = 4;
            btnCancelarOperacao.Text = "CANCELAR";
            btnCancelarOperacao.UseVisualStyleBackColor = false;
            // 
            // lblMensagemOperacao
            // 
            lblMensagemOperacao.AutoSize = true;
            lblMensagemOperacao.Font = new Font("Arial", 11F);
            lblMensagemOperacao.Location = new Point(50, 280);
            lblMensagemOperacao.Name = "lblMensagemOperacao";
            lblMensagemOperacao.Size = new Size(0, 17);
            lblMensagemOperacao.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 600);
            Controls.Add(pnlLogin);
            Controls.Add(pnlMenu);
            Controls.Add(pnlOperacao);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Multibanco - Sistema ATM";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlOperacao.ResumeLayout(false);
            pnlOperacao.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblAccount;
        private Label lblPin;
        private Label lblInfo;
    }
}
