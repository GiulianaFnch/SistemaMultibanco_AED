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
            lblTitulo.BackColor = Color.DarkCyan;
            lblTitulo.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(233, 42);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(272, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Eliminar Cliente";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblID.ForeColor = SystemColors.ControlLightLight;
            lblID.Location = new Point(200, 190);
            lblID.Name = "lblID";
            lblID.Size = new Size(153, 30);
            lblID.TabIndex = 1;
            lblID.Text = "ID do Cliente:";
            
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(605, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(151, 56);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.DarkGoldenrod;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnEliminar.ForeColor = SystemColors.ControlLightLight;
            btnEliminar.Location = new Point(40, 322);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(151, 56);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtID
            // 
            txtID.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            txtID.Location = new Point(359, 188);
            txtID.Name = "txtID";
            txtID.Size = new Size(146, 34);
            txtID.TabIndex = 4;
            txtID.TextChanged += txtID_TextChanged;
            // 
            // FormEliminarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
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