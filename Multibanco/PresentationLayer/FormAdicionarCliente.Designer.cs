namespace Multibanco.PresentationLayer
{
    partial class FormAdicionarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNome = new Label();
            lblNIF = new Label();
            lblSaldo = new Label();
            txtNome = new TextBox();
            txtNIF = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 15F);
            lblNome.Location = new Point(60, 82);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(70, 28);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblNIF
            // 
            lblNIF.AutoSize = true;
            lblNIF.Font = new Font("Segoe UI", 15F);
            lblNIF.Location = new Point(60, 156);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(46, 28);
            lblNIF.TabIndex = 1;
            lblNIF.Text = "NIF:";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 15F);
            lblSaldo.Location = new Point(51, 243);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(170, 28);
            lblSaldo.TabIndex = 2;
            lblSaldo.Text = "Saldo Inicial: 100€";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(147, 87);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 3;
            // 
            // txtNIF
            // 
            txtNIF.Location = new Point(147, 161);
            txtNIF.Name = "txtNIF";
            txtNIF.Size = new Size(100, 23);
            txtNIF.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 15F);
            btnGuardar.Location = new Point(483, 126);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 49);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 15F);
            btnCancelar.Location = new Point(483, 197);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 49);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAdicionarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 423);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNIF);
            Controls.Add(txtNome);
            Controls.Add(lblSaldo);
            Controls.Add(lblNIF);
            Controls.Add(lblNome);
            Name = "FormAdicionarCliente";
            Text = "FormAdicionarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblNIF;
        private Label lblSaldo;
        private TextBox txtNome;
        private TextBox txtNIF;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}