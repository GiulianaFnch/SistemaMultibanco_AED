namespace Multibanco.PresentationLayer
{
    partial class FormPagamentos
    {
        private System.ComponentModel.IContainer components = null;

        private Label    lblTitulo;
        private Label    lblSaldoAtual;
        private Label    lblServicoLabel;
        private ComboBox cmbServico;
        private Label    lblReferenciaLabel;
        private TextBox  txtReferencia;
        private Label    lblValorLabel;
        private TextBox  txtValor;
        private Label    lblMensagem;
        private Button   btnConfirmar;
        private Button   btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSaldoAtual = new Label();
            lblServicoLabel = new Label();
            cmbServico = new ComboBox();
            lblReferenciaLabel = new Label();
            txtReferencia = new TextBox();
            lblValorLabel = new Label();
            txtValor = new TextBox();
            lblMensagem = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.DarkBlue;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Arial", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(460, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "💳  PAGAMENTOS PRÉ-DEFINIDOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSaldoAtual
            // 
            lblSaldoAtual.Font = new Font("Arial", 11F);
            lblSaldoAtual.ForeColor = Color.DarkGreen;
            lblSaldoAtual.Location = new Point(30, 65);
            lblSaldoAtual.Name = "lblSaldoAtual";
            lblSaldoAtual.Size = new Size(400, 22);
            lblSaldoAtual.TabIndex = 1;
            // 
            // lblServicoLabel
            // 
            lblServicoLabel.Font = new Font("Arial", 11F);
            lblServicoLabel.Location = new Point(30, 100);
            lblServicoLabel.Name = "lblServicoLabel";
            lblServicoLabel.Size = new Size(100, 22);
            lblServicoLabel.TabIndex = 2;
            lblServicoLabel.Text = "Serviço:";
            // 
            // cmbServico
            // 
            cmbServico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServico.Font = new Font("Arial", 11F);
            cmbServico.Items.AddRange(new object[] { "Água (EPAL)", "Eletricidade (EDP)", "Gás (Galp)", "Telemóvel (MEO)", "Telemóvel (NOS)", "Telemóvel (Vodafone)", "Internet/TV (NOS)", "Internet/TV (MEO)", "Seguro (Fidelidade)" });
            cmbServico.Location = new Point(30, 125);
            cmbServico.Name = "cmbServico";
            cmbServico.Size = new Size(400, 25);
            cmbServico.TabIndex = 3;
            // 
            // lblReferenciaLabel
            // 
            lblReferenciaLabel.Font = new Font("Arial", 11F);
            lblReferenciaLabel.Location = new Point(30, 170);
            lblReferenciaLabel.Name = "lblReferenciaLabel";
            lblReferenciaLabel.Size = new Size(250, 22);
            lblReferenciaLabel.TabIndex = 4;
            lblReferenciaLabel.Text = "Referência / Nº de Cliente:";
            // 
            // txtReferencia
            // 
            txtReferencia.Font = new Font("Arial", 13F);
            txtReferencia.Location = new Point(30, 195);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(260, 27);
            txtReferencia.TabIndex = 5;
            // 
            // lblValorLabel
            // 
            lblValorLabel.Font = new Font("Arial", 11F);
            lblValorLabel.Location = new Point(30, 240);
            lblValorLabel.Name = "lblValorLabel";
            lblValorLabel.Size = new Size(180, 22);
            lblValorLabel.TabIndex = 6;
            lblValorLabel.Text = "Valor a Pagar (€):";
            // 
            // txtValor
            // 
            txtValor.Font = new Font("Arial", 13F);
            txtValor.Location = new Point(30, 265);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(160, 27);
            txtValor.TabIndex = 7;
            // 
            // lblMensagem
            // 
            lblMensagem.Font = new Font("Arial", 10F);
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location = new Point(30, 378);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(400, 40);
            lblMensagem.TabIndex = 10;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.DarkGreen;
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(30, 320);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(180, 44);
            btnConfirmar.TabIndex = 8;
            btnConfirmar.Text = "✔  PAGAR";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DarkRed;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(240, 320);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 44);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "✖  CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormPagamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(460, 435);
            Controls.Add(lblTitulo);
            Controls.Add(lblSaldoAtual);
            Controls.Add(lblServicoLabel);
            Controls.Add(cmbServico);
            Controls.Add(lblReferenciaLabel);
            Controls.Add(txtReferencia);
            Controls.Add(lblValorLabel);
            Controls.Add(txtValor);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Controls.Add(lblMensagem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPagamentos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pagamentos Pré-definidos";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
