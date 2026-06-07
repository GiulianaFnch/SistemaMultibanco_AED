namespace Multibanco.PresentationLayer
{
    partial class FormAdmin
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
            lblUtilizador = new Label();
            txtUtilizador = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            pnlAdmin = new Panel();
            btnAdicionarConta = new Button();
            btnSair = new Button();
            btnListarContas = new Button();
            btnEliminarCliente = new Button();
            btnAdicionarCliente = new Button();
            btnListarClientes = new Button();
            lblSibisMenu = new Label();
            pnlAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(261, 59);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(243, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administrador SIBS";
            // 
            // lblUtilizador
            // 
            lblUtilizador.AutoSize = true;
            lblUtilizador.Font = new Font("Segoe UI", 16F);
            lblUtilizador.Location = new Point(261, 144);
            lblUtilizador.Name = "lblUtilizador";
            lblUtilizador.Size = new Size(110, 30);
            lblUtilizador.TabIndex = 1;
            lblUtilizador.Text = "Utilizador:";
            // 
            // txtUtilizador
            // 
            txtUtilizador.Location = new Point(393, 151);
            txtUtilizador.Name = "txtUtilizador";
            txtUtilizador.Size = new Size(100, 23);
            txtUtilizador.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(393, 199);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 16F);
            lblPassword.Location = new Point(261, 199);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(103, 30);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.GradientActiveCaption;
            btnLogin.Font = new Font("Segoe UI", 20F);
            btnLogin.Location = new Point(278, 272);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(198, 64);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlAdmin
            // 
            pnlAdmin.BackColor = Color.DarkCyan;
            pnlAdmin.BorderStyle = BorderStyle.FixedSingle;
            pnlAdmin.Controls.Add(lblSibisMenu);
            pnlAdmin.Controls.Add(btnAdicionarConta);
            pnlAdmin.Controls.Add(btnSair);
            pnlAdmin.Controls.Add(btnListarContas);
            pnlAdmin.Controls.Add(btnEliminarCliente);
            pnlAdmin.Controls.Add(btnAdicionarCliente);
            pnlAdmin.Controls.Add(btnListarClientes);
            pnlAdmin.Location = new Point(-33, -4);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(836, 457);
            pnlAdmin.TabIndex = 6;
            pnlAdmin.Visible = false;
            // 
            // btnAdicionarConta
            // 
            btnAdicionarConta.BackColor = Color.DarkSeaGreen;
            btnAdicionarConta.FlatAppearance.BorderSize = 0;
            btnAdicionarConta.FlatStyle = FlatStyle.Flat;
            btnAdicionarConta.Font = new Font("Segoe UI", 15F);
            btnAdicionarConta.Location = new Point(273, 166);
            btnAdicionarConta.Name = "btnAdicionarConta";
            btnAdicionarConta.Size = new Size(146, 66);
            btnAdicionarConta.TabIndex = 5;
            btnAdicionarConta.Text = "Adicionar Conta";
            btnAdicionarConta.UseVisualStyleBackColor = false;
            btnAdicionarConta.Click += btnAdicionarConta_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.Firebrick;
            btnSair.FlatAppearance.BorderColor = Color.Red;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Segoe UI", 15F);
            btnSair.ForeColor = SystemColors.ControlLightLight;
            btnSair.Location = new Point(672, 329);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(118, 50);
            btnSair.TabIndex = 4;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click_1;
            // 
            // btnListarContas
            // 
            btnListarContas.BackColor = Color.DarkSeaGreen;
            btnListarContas.FlatAppearance.BorderSize = 0;
            btnListarContas.FlatStyle = FlatStyle.Flat;
            btnListarContas.Font = new Font("Segoe UI", 10F);
            btnListarContas.Location = new Point(293, 262);
            btnListarContas.Name = "btnListarContas";
            btnListarContas.Size = new Size(98, 42);
            btnListarContas.TabIndex = 3;
            btnListarContas.Text = "Listar Contas";
            btnListarContas.UseVisualStyleBackColor = false;
            btnListarContas.Click += btnListarContas_Click;
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.BackColor = Color.DarkSeaGreen;
            btnEliminarCliente.FlatAppearance.BorderSize = 0;
            btnEliminarCliente.FlatStyle = FlatStyle.Flat;
            btnEliminarCliente.Font = new Font("Segoe UI", 15F);
            btnEliminarCliente.Location = new Point(542, 202);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(146, 66);
            btnEliminarCliente.TabIndex = 2;
            btnEliminarCliente.Text = "Eliminar Cliente";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // btnAdicionarCliente
            // 
            btnAdicionarCliente.BackColor = Color.DarkSeaGreen;
            btnAdicionarCliente.FlatAppearance.BorderSize = 0;
            btnAdicionarCliente.FlatStyle = FlatStyle.Flat;
            btnAdicionarCliente.Font = new Font("Segoe UI", 15F);
            btnAdicionarCliente.ForeColor = Color.Black;
            btnAdicionarCliente.Location = new Point(91, 166);
            btnAdicionarCliente.Name = "btnAdicionarCliente";
            btnAdicionarCliente.Size = new Size(146, 66);
            btnAdicionarCliente.TabIndex = 1;
            btnAdicionarCliente.Text = "Adicionar Cliente";
            btnAdicionarCliente.UseVisualStyleBackColor = false;
            btnAdicionarCliente.Click += btnAdicionarCliente_Click;
            // 
            // btnListarClientes
            // 
            btnListarClientes.BackColor = Color.DarkSeaGreen;
            btnListarClientes.FlatAppearance.BorderColor = Color.White;
            btnListarClientes.FlatAppearance.BorderSize = 0;
            btnListarClientes.FlatStyle = FlatStyle.Flat;
            btnListarClientes.Font = new Font("Segoe UI", 10F);
            btnListarClientes.Location = new Point(111, 262);
            btnListarClientes.Name = "btnListarClientes";
            btnListarClientes.Size = new Size(110, 42);
            btnListarClientes.TabIndex = 0;
            btnListarClientes.Text = "Listar Clientes";
            btnListarClientes.UseVisualStyleBackColor = false;
            btnListarClientes.Click += btnListarClientes_Click;
            // 
            // lblSibisMenu
            // 
            lblSibisMenu.AutoSize = true;
            lblSibisMenu.Font = new Font("Sans Serif Collection", 29.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSibisMenu.ForeColor = SystemColors.ControlText;
            lblSibisMenu.Location = new Point(192, 26);
            lblSibisMenu.Name = "lblSibisMenu";
            lblSibisMenu.Size = new Size(434, 136);
            lblSibisMenu.TabIndex = 6;
            lblSibisMenu.Text = "Administrador SIBS";
            lblSibisMenu.Click += lblSibisMenu_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlAdmin);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUtilizador);
            Controls.Add(lblUtilizador);
            Controls.Add(lblTitulo);
            Name = "FormAdmin";
            Text = "FormAdmin";
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUtilizador;
        private TextBox txtUtilizador;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Panel pnlAdmin;
        private Button btnSair;
        private Button btnListarContas;
        private Button btnEliminarCliente;
        private Button btnAdicionarCliente;
        private Button btnListarClientes;
        private Button btnAdicionarConta;
        private Label lblSibisMenu;
    }
}