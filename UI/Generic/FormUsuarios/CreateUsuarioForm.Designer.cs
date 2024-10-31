namespace UI.Generic.FormUsuarios
{
    partial class CreateUsuarioForm
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
            groupBox1 = new GroupBox();
            lblContrasena = new MaterialSkin.Controls.MaterialLabel();
            lblUser = new MaterialSkin.Controls.MaterialLabel();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            txtUsuario = new MaterialSkin.Controls.MaterialTextBox();
            groupBox2 = new GroupBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            btnRemoveEspecialidad = new MaterialSkin.Controls.MaterialButton();
            btnAddEspecialidad = new MaterialSkin.Controls.MaterialButton();
            dgvEspecialidades = new DataGridView();
            txtApellido = new MaterialSkin.Controls.MaterialTextBox();
            lblEmail = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtNombre = new MaterialSkin.Controls.MaterialTextBox();
            dgvRoles = new DataGridView();
            btnRemoveRole = new MaterialSkin.Controls.MaterialButton();
            btnAddRole = new MaterialSkin.Controls.MaterialButton();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            dgvPermisos = new DataGridView();
            btnRemovePermiso = new MaterialSkin.Controls.MaterialButton();
            btnAddPermiso = new MaterialSkin.Controls.MaterialButton();
            btnCreate = new MaterialSkin.Controls.MaterialButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermisos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblContrasena);
            groupBox1.Controls.Add(lblUser);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 177);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos personales";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Depth = 0;
            lblContrasena.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContrasena.Location = new Point(29, 130);
            lblContrasena.MouseState = MaterialSkin.MouseState.HOVER;
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(82, 19);
            lblContrasena.TabIndex = 5;
            lblContrasena.Text = "Contraseña";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Depth = 0;
            lblUser.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUser.Location = new Point(29, 74);
            lblUser.MouseState = MaterialSkin.MouseState.HOVER;
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(55, 19);
            lblUser.TabIndex = 4;
            lblUser.Text = "Usuario";
            // 
            // txtPassword
            // 
            txtPassword.AnimateReadOnly = false;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F);
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(197, 99);
            txtPassword.MaxLength = 50;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Password = true;
            txtPassword.Size = new Size(256, 50);
            txtPassword.TabIndex = 1;
            txtPassword.TabStop = false;
            txtPassword.Text = "********************";
            txtPassword.TrailingIcon = null;
            // 
            // txtUsuario
            // 
            txtUsuario.AnimateReadOnly = false;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Depth = 0;
            txtUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsuario.LeadingIcon = null;
            txtUsuario.Location = new Point(197, 43);
            txtUsuario.MaxLength = 50;
            txtUsuario.MouseState = MaterialSkin.MouseState.OUT;
            txtUsuario.Multiline = false;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(256, 50);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "";
            txtUsuario.TrailingIcon = null;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(materialLabel3);
            groupBox2.Controls.Add(btnRemoveEspecialidad);
            groupBox2.Controls.Add(btnAddEspecialidad);
            groupBox2.Controls.Add(dgvEspecialidades);
            groupBox2.Controls.Add(txtApellido);
            groupBox2.Controls.Add(lblEmail);
            groupBox2.Controls.Add(materialLabel2);
            groupBox2.Controls.Add(materialLabel1);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Font = new Font("Segoe UI", 14F);
            groupBox2.Location = new Point(12, 195);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(480, 448);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos personales";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(31, 223);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(91, 19);
            materialLabel3.TabIndex = 31;
            materialLabel3.Text = "Especialidad";
            // 
            // btnRemoveEspecialidad
            // 
            btnRemoveEspecialidad.AutoSize = false;
            btnRemoveEspecialidad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveEspecialidad.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemoveEspecialidad.Depth = 0;
            btnRemoveEspecialidad.HighEmphasis = true;
            btnRemoveEspecialidad.Icon = null;
            btnRemoveEspecialidad.Location = new Point(296, 382);
            btnRemoveEspecialidad.Margin = new Padding(4, 6, 4, 6);
            btnRemoveEspecialidad.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemoveEspecialidad.Name = "btnRemoveEspecialidad";
            btnRemoveEspecialidad.NoAccentTextColor = Color.Empty;
            btnRemoveEspecialidad.Size = new Size(157, 36);
            btnRemoveEspecialidad.TabIndex = 30;
            btnRemoveEspecialidad.Text = "Eliminar";
            btnRemoveEspecialidad.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemoveEspecialidad.UseAccentColor = false;
            btnRemoveEspecialidad.UseVisualStyleBackColor = true;
            // 
            // btnAddEspecialidad
            // 
            btnAddEspecialidad.AutoSize = false;
            btnAddEspecialidad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddEspecialidad.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddEspecialidad.Depth = 0;
            btnAddEspecialidad.HighEmphasis = true;
            btnAddEspecialidad.Icon = null;
            btnAddEspecialidad.Location = new Point(131, 382);
            btnAddEspecialidad.Margin = new Padding(4, 6, 4, 6);
            btnAddEspecialidad.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddEspecialidad.Name = "btnAddEspecialidad";
            btnAddEspecialidad.NoAccentTextColor = Color.Empty;
            btnAddEspecialidad.Size = new Size(157, 36);
            btnAddEspecialidad.TabIndex = 29;
            btnAddEspecialidad.Text = "Agregar";
            btnAddEspecialidad.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddEspecialidad.UseAccentColor = false;
            btnAddEspecialidad.UseVisualStyleBackColor = true;
            // 
            // dgvEspecialidades
            // 
            dgvEspecialidades.AllowUserToAddRows = false;
            dgvEspecialidades.AllowUserToDeleteRows = false;
            dgvEspecialidades.AllowUserToOrderColumns = true;
            dgvEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEspecialidades.Location = new Point(29, 245);
            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.ReadOnly = true;
            dgvEspecialidades.Size = new Size(424, 128);
            dgvEspecialidades.TabIndex = 28;
            // 
            // txtApellido
            // 
            txtApellido.AnimateReadOnly = false;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Depth = 0;
            txtApellido.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtApellido.LeadingIcon = null;
            txtApellido.Location = new Point(197, 99);
            txtApellido.MaxLength = 50;
            txtApellido.MouseState = MaterialSkin.MouseState.OUT;
            txtApellido.Multiline = false;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(256, 50);
            txtApellido.TabIndex = 8;
            txtApellido.Text = "";
            txtApellido.TrailingIcon = null;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Depth = 0;
            lblEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEmail.Location = new Point(31, 185);
            lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(29, 130);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(58, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Apellido";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(29, 74);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(57, 19);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "Nombre";
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(197, 155);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(256, 50);
            txtEmail.TabIndex = 3;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtNombre
            // 
            txtNombre.AnimateReadOnly = false;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Depth = 0;
            txtNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombre.LeadingIcon = null;
            txtNombre.Location = new Point(197, 43);
            txtNombre.MaxLength = 50;
            txtNombre.MouseState = MaterialSkin.MouseState.OUT;
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(256, 50);
            txtNombre.TabIndex = 0;
            txtNombre.Text = "";
            txtNombre.TrailingIcon = null;
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AllowUserToOrderColumns = true;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Location = new Point(10, 31);
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.Size = new Size(464, 200);
            dgvRoles.TabIndex = 27;
            // 
            // btnRemoveRole
            // 
            btnRemoveRole.AutoSize = false;
            btnRemoveRole.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveRole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemoveRole.Depth = 0;
            btnRemoveRole.HighEmphasis = true;
            btnRemoveRole.Icon = null;
            btnRemoveRole.Location = new Point(316, 240);
            btnRemoveRole.Margin = new Padding(4, 6, 4, 6);
            btnRemoveRole.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemoveRole.Name = "btnRemoveRole";
            btnRemoveRole.NoAccentTextColor = Color.Empty;
            btnRemoveRole.Size = new Size(157, 36);
            btnRemoveRole.TabIndex = 26;
            btnRemoveRole.Text = "Eliminar";
            btnRemoveRole.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemoveRole.UseAccentColor = false;
            btnRemoveRole.UseVisualStyleBackColor = true;
            // 
            // btnAddRole
            // 
            btnAddRole.AutoSize = false;
            btnAddRole.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddRole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddRole.Depth = 0;
            btnAddRole.HighEmphasis = true;
            btnAddRole.Icon = null;
            btnAddRole.Location = new Point(151, 240);
            btnAddRole.Margin = new Padding(4, 6, 4, 6);
            btnAddRole.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddRole.Name = "btnAddRole";
            btnAddRole.NoAccentTextColor = Color.Empty;
            btnAddRole.Size = new Size(157, 36);
            btnAddRole.TabIndex = 25;
            btnAddRole.Text = "Agregar";
            btnAddRole.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddRole.UseAccentColor = false;
            btnAddRole.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvRoles);
            groupBox3.Controls.Add(btnRemoveRole);
            groupBox3.Controls.Add(btnAddRole);
            groupBox3.Font = new Font("Segoe UI", 14F);
            groupBox3.Location = new Point(498, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(480, 290);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Roles";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvPermisos);
            groupBox4.Controls.Add(btnRemovePermiso);
            groupBox4.Controls.Add(btnAddPermiso);
            groupBox4.Font = new Font("Segoe UI", 14F);
            groupBox4.Location = new Point(498, 308);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(480, 290);
            groupBox4.TabIndex = 28;
            groupBox4.TabStop = false;
            groupBox4.Text = "Permisos";
            // 
            // dgvPermisos
            // 
            dgvPermisos.AllowUserToAddRows = false;
            dgvPermisos.AllowUserToDeleteRows = false;
            dgvPermisos.AllowUserToOrderColumns = true;
            dgvPermisos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermisos.Location = new Point(10, 31);
            dgvPermisos.Name = "dgvPermisos";
            dgvPermisos.ReadOnly = true;
            dgvPermisos.Size = new Size(464, 200);
            dgvPermisos.TabIndex = 27;
            // 
            // btnRemovePermiso
            // 
            btnRemovePermiso.AutoSize = false;
            btnRemovePermiso.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemovePermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemovePermiso.Depth = 0;
            btnRemovePermiso.HighEmphasis = true;
            btnRemovePermiso.Icon = null;
            btnRemovePermiso.Location = new Point(316, 240);
            btnRemovePermiso.Margin = new Padding(4, 6, 4, 6);
            btnRemovePermiso.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemovePermiso.Name = "btnRemovePermiso";
            btnRemovePermiso.NoAccentTextColor = Color.Empty;
            btnRemovePermiso.Size = new Size(157, 36);
            btnRemovePermiso.TabIndex = 26;
            btnRemovePermiso.Text = "Eliminar";
            btnRemovePermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemovePermiso.UseAccentColor = false;
            btnRemovePermiso.UseVisualStyleBackColor = true;
            // 
            // btnAddPermiso
            // 
            btnAddPermiso.AutoSize = false;
            btnAddPermiso.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddPermiso.Depth = 0;
            btnAddPermiso.HighEmphasis = true;
            btnAddPermiso.Icon = null;
            btnAddPermiso.Location = new Point(151, 240);
            btnAddPermiso.Margin = new Padding(4, 6, 4, 6);
            btnAddPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddPermiso.Name = "btnAddPermiso";
            btnAddPermiso.NoAccentTextColor = Color.Empty;
            btnAddPermiso.Size = new Size(157, 36);
            btnAddPermiso.TabIndex = 25;
            btnAddPermiso.Text = "Agregar";
            btnAddPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddPermiso.UseAccentColor = false;
            btnAddPermiso.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.AutoSize = false;
            btnCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCreate.Depth = 0;
            btnCreate.HighEmphasis = true;
            btnCreate.Icon = null;
            btnCreate.Location = new Point(821, 607);
            btnCreate.Margin = new Padding(4, 6, 4, 6);
            btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnCreate.Name = "btnCreate";
            btnCreate.NoAccentTextColor = Color.Empty;
            btnCreate.Size = new Size(157, 36);
            btnCreate.TabIndex = 29;
            btnCreate.Text = "Crear";
            btnCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCreate.UseAccentColor = false;
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // CreateUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 730);
            Controls.Add(btnCreate);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateUsuarioForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPermisos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel lblContrasena;
        private MaterialSkin.Controls.MaterialLabel lblUser;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialTextBox txtUsuario;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel lblEspecialidad;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialComboBox cbxEspecialidad;
        private MaterialSkin.Controls.MaterialTextBox txtNombre;
        private MaterialSkin.Controls.MaterialTextBox txtApellido;
        private DataGridView dgvRoles;
        private MaterialSkin.Controls.MaterialButton btnRemoveRole;
        private MaterialSkin.Controls.MaterialButton btnAddRole;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private DataGridView dgvPermisos;
        private MaterialSkin.Controls.MaterialButton btnRemovePermiso;
        private MaterialSkin.Controls.MaterialButton btnAddPermiso;
        private MaterialSkin.Controls.MaterialButton btnCreate;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btnRemoveEspecialidad;
        private MaterialSkin.Controls.MaterialButton btnAddEspecialidad;
        private DataGridView dgvEspecialidades;
    }
}