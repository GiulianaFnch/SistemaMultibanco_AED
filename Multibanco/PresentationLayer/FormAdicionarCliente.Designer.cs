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
            lblNome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNome.ForeColor = SystemColors.ControlLightLight;
            lblNome.Location = new Point(92, 78);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(102, 37);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblNIF
            // 
            lblNIF.AutoSize = true;
            lblNIF.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNIF.ForeColor = SystemColors.ControlLightLight;
            lblNIF.Location = new Point(102, 152);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(68, 37);
            lblNIF.TabIndex = 1;
            lblNIF.Text = "NIF:";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSaldo.ForeColor = SystemColors.ControlLightLight;
            lblSaldo.Location = new Point(75, 326);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(186, 28);
            lblSaldo.TabIndex = 2;
            lblSaldo.Text = "Saldo Inicial: 100€";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 15F);
            txtNome.Location = new Point(229, 82);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(147, 34);
            txtNome.TabIndex = 3;
            // 
            // txtNIF
            // 
            txtNIF.Font = new Font("Segoe UI", 15F);
            txtNIF.Location = new Point(229, 156);
            txtNIF.Name = "txtNIF";
            txtNIF.Size = new Size(147, 34);
            txtNIF.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(607, 233);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 49);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Firebrick;
            btnCancelar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(607, 316);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 49);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAdicionarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
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