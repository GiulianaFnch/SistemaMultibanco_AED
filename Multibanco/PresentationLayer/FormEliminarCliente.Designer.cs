namespace Multibanco.PresentationLayer
{
    partial class FormEliminarCliente
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
            lblID = new Label();
            btnCancelar = new Button();
            btnEliminar = new Button();
            txtID = new TextBox();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(269, 60);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(203, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Eliminar Cliente";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 16F);
            lblID.Location = new Point(47, 150);
            lblID.Name = "lblID";
            lblID.Size = new Size(144, 30);
            lblID.TabIndex = 1;
            lblID.Text = "ID do Cliente:";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 16F);
            btnCancelar.Location = new Point(605, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(151, 56);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 16F);
            btnEliminar.Location = new Point(40, 322);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(151, 56);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // txtID
            // 
            txtID.Location = new Point(210, 157);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 4;
            // 
            // FormEliminarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtID);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Controls.Add(lblID);
            Controls.Add(lblTitulo);
            Name = "FormEliminarCliente";
            Text = "FormEliminarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblID;
        private Button btnCancelar;
        private Button btnEliminar;
        private TextBox txtID;
    }
}