namespace Multibanco.PresentationLayer
{
    partial class FormListarClientes
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
            lblTitulo = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvClientes = new DataGridView();
            btnFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(286, 64);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(168, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Lista de Clientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 106);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(320, 124);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 2;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(153, 106);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(454, 197);
            dgvClientes.TabIndex = 3;
            //dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Segoe UI", 16F);
            btnFechar.Location = new Point(600, 339);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(164, 70);
            btnFechar.TabIndex = 4;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // FormListarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFechar);
            Controls.Add(dgvClientes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTitulo);
            Name = "FormListarClientes";
            Text = "FormListarClientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label2;
        private Label label3;
        private DataGridView dgvClientes;
        private Button btnFechar;
    }
}