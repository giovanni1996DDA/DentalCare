namespace UI.NonProfessional.FormsPacientes
{
    partial class CreatePacienteForm
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
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            txtFechaNac = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtNroDoc = new MaterialSkin.Controls.MaterialTextBox();
            cbxTipoDoc = new MaterialSkin.Controls.MaterialComboBox();
            txtApellido = new MaterialSkin.Controls.MaterialTextBox();
            txtNombre = new MaterialSkin.Controls.MaterialTextBox();
            groupBox2 = new GroupBox();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtTelefono = new MaterialSkin.Controls.MaterialTextBox();
            txtDireccion = new MaterialSkin.Controls.MaterialTextBox();
            groupBox3 = new GroupBox();
            cbxObraSocial = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            txtCtaCte = new MaterialSkin.Controls.MaterialTextBox();
            btnCreate = new MaterialSkin.Controls.MaterialButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(txtFechaNac);
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(materialLabel3);
            groupBox1.Controls.Add(materialLabel2);
            groupBox1.Controls.Add(materialLabel1);
            groupBox1.Controls.Add(txtNroDoc);
            groupBox1.Controls.Add(cbxTipoDoc);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 352);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos personales";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(31, 297);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(129, 19);
            materialLabel5.TabIndex = 9;
            materialLabel5.Text = "Fecha Nacimiento";
            // 
            // txtFechaNac
            // 
            txtFechaNac.AnimateReadOnly = false;
            txtFechaNac.BorderStyle = BorderStyle.None;
            txtFechaNac.Depth = 0;
            txtFechaNac.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFechaNac.LeadingIcon = null;
            txtFechaNac.Location = new Point(197, 266);
            txtFechaNac.MaxLength = 50;
            txtFechaNac.MouseState = MaterialSkin.MouseState.OUT;
            txtFechaNac.Multiline = false;
            txtFechaNac.Name = "txtFechaNac";
            txtFechaNac.Size = new Size(256, 50);
            txtFechaNac.TabIndex = 8;
            txtFechaNac.Text = "";
            txtFechaNac.TrailingIcon = null;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(31, 241);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(143, 19);
            materialLabel4.TabIndex = 7;
            materialLabel4.Text = "Numero Documento";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(31, 185);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(140, 19);
            materialLabel3.TabIndex = 6;
            materialLabel3.Text = "Tipo de Documento";
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
            // txtNroDoc
            // 
            txtNroDoc.AnimateReadOnly = false;
            txtNroDoc.BorderStyle = BorderStyle.None;
            txtNroDoc.Depth = 0;
            txtNroDoc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNroDoc.LeadingIcon = null;
            txtNroDoc.Location = new Point(197, 210);
            txtNroDoc.MaxLength = 50;
            txtNroDoc.MouseState = MaterialSkin.MouseState.OUT;
            txtNroDoc.Multiline = false;
            txtNroDoc.Name = "txtNroDoc";
            txtNroDoc.Size = new Size(256, 50);
            txtNroDoc.TabIndex = 3;
            txtNroDoc.Text = "";
            txtNroDoc.TrailingIcon = null;
            // 
            // cbxTipoDoc
            // 
            cbxTipoDoc.AutoResize = false;
            cbxTipoDoc.BackColor = Color.FromArgb(255, 255, 255);
            cbxTipoDoc.Depth = 0;
            cbxTipoDoc.DrawMode = DrawMode.OwnerDrawVariable;
            cbxTipoDoc.DropDownHeight = 174;
            cbxTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoDoc.DropDownWidth = 121;
            cbxTipoDoc.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxTipoDoc.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxTipoDoc.FormattingEnabled = true;
            cbxTipoDoc.IntegralHeight = false;
            cbxTipoDoc.ItemHeight = 43;
            cbxTipoDoc.Location = new Point(197, 155);
            cbxTipoDoc.MaxDropDownItems = 4;
            cbxTipoDoc.MouseState = MaterialSkin.MouseState.OUT;
            cbxTipoDoc.Name = "cbxTipoDoc";
            cbxTipoDoc.Size = new Size(256, 49);
            cbxTipoDoc.StartIndex = 0;
            cbxTipoDoc.TabIndex = 2;
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
            txtApellido.TabIndex = 1;
            txtApellido.Text = "";
            txtApellido.TrailingIcon = null;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(materialLabel7);
            groupBox2.Controls.Add(materialLabel9);
            groupBox2.Controls.Add(materialLabel10);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Controls.Add(txtDireccion);
            groupBox2.Font = new Font("Segoe UI", 14F);
            groupBox2.Location = new Point(498, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(480, 237);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de contacto";
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(29, 185);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(41, 19);
            materialLabel7.TabIndex = 7;
            materialLabel7.Text = "Email";
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(29, 130);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(64, 19);
            materialLabel9.TabIndex = 5;
            materialLabel9.Text = "Teléfono";
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(29, 74);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(67, 19);
            materialLabel10.TabIndex = 4;
            materialLabel10.Text = "Dirección";
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(197, 154);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(256, 50);
            txtEmail.TabIndex = 3;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtTelefono
            // 
            txtTelefono.AnimateReadOnly = false;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Depth = 0;
            txtTelefono.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefono.LeadingIcon = null;
            txtTelefono.Location = new Point(197, 98);
            txtTelefono.MaxLength = 50;
            txtTelefono.MouseState = MaterialSkin.MouseState.OUT;
            txtTelefono.Multiline = false;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(256, 50);
            txtTelefono.TabIndex = 1;
            txtTelefono.Text = "";
            txtTelefono.TrailingIcon = null;
            // 
            // txtDireccion
            // 
            txtDireccion.AnimateReadOnly = false;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Depth = 0;
            txtDireccion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDireccion.LeadingIcon = null;
            txtDireccion.Location = new Point(197, 43);
            txtDireccion.MaxLength = 50;
            txtDireccion.MouseState = MaterialSkin.MouseState.OUT;
            txtDireccion.Multiline = false;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(256, 50);
            txtDireccion.TabIndex = 0;
            txtDireccion.Text = "";
            txtDireccion.TrailingIcon = null;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbxObraSocial);
            groupBox3.Controls.Add(materialLabel8);
            groupBox3.Controls.Add(materialLabel11);
            groupBox3.Controls.Add(txtCtaCte);
            groupBox3.Font = new Font("Segoe UI", 14F);
            groupBox3.Location = new Point(12, 370);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(480, 173);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Otros Datos";
            // 
            // cbxObraSocial
            // 
            cbxObraSocial.AutoResize = false;
            cbxObraSocial.BackColor = Color.FromArgb(255, 255, 255);
            cbxObraSocial.Depth = 0;
            cbxObraSocial.DrawMode = DrawMode.OwnerDrawVariable;
            cbxObraSocial.DropDownHeight = 174;
            cbxObraSocial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxObraSocial.DropDownWidth = 121;
            cbxObraSocial.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxObraSocial.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxObraSocial.FormattingEnabled = true;
            cbxObraSocial.IntegralHeight = false;
            cbxObraSocial.ItemHeight = 43;
            cbxObraSocial.Location = new Point(197, 44);
            cbxObraSocial.MaxDropDownItems = 4;
            cbxObraSocial.MouseState = MaterialSkin.MouseState.OUT;
            cbxObraSocial.Name = "cbxObraSocial";
            cbxObraSocial.Size = new Size(256, 49);
            cbxObraSocial.StartIndex = 0;
            cbxObraSocial.TabIndex = 10;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(29, 130);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(118, 19);
            materialLabel8.TabIndex = 5;
            materialLabel8.Text = "Cuenta Corriente";
            // 
            // materialLabel11
            // 
            materialLabel11.AutoSize = true;
            materialLabel11.Depth = 0;
            materialLabel11.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel11.Location = new Point(29, 74);
            materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel11.Name = "materialLabel11";
            materialLabel11.Size = new Size(83, 19);
            materialLabel11.TabIndex = 4;
            materialLabel11.Text = "Obra Social";
            // 
            // txtCtaCte
            // 
            txtCtaCte.AnimateReadOnly = true;
            txtCtaCte.BorderStyle = BorderStyle.None;
            txtCtaCte.Depth = 0;
            txtCtaCte.Enabled = false;
            txtCtaCte.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCtaCte.LeadingIcon = null;
            txtCtaCte.Location = new Point(197, 99);
            txtCtaCte.MaxLength = 50;
            txtCtaCte.MouseState = MaterialSkin.MouseState.OUT;
            txtCtaCte.Multiline = false;
            txtCtaCte.Name = "txtCtaCte";
            txtCtaCte.Size = new Size(256, 50);
            txtCtaCte.TabIndex = 1;
            txtCtaCte.Text = "";
            txtCtaCte.TrailingIcon = null;
            // 
            // btnCreate
            // 
            btnCreate.AutoSize = false;
            btnCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCreate.Depth = 0;
            btnCreate.HighEmphasis = true;
            btnCreate.Icon = null;
            btnCreate.Location = new Point(13, 552);
            btnCreate.Margin = new Padding(4, 6, 4, 6);
            btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnCreate.Name = "btnCreate";
            btnCreate.NoAccentTextColor = Color.Empty;
            btnCreate.Size = new Size(256, 50);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Crear";
            btnCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCreate.UseAccentColor = false;
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // CreatePacienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 730);
            Controls.Add(btnCreate);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreatePacienteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CreatePacienteForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtNroDoc;
        private MaterialSkin.Controls.MaterialComboBox cbxTipoDoc;
        private MaterialSkin.Controls.MaterialTextBox txtApellido;
        private MaterialSkin.Controls.MaterialTextBox txtNombre;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox txtFechaNac;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtTelefono;
        private MaterialSkin.Controls.MaterialTextBox txtDireccion;
        private GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialTextBox txtCtaCte;
        private MaterialSkin.Controls.MaterialComboBox cbxObraSocial;
        private MaterialSkin.Controls.MaterialButton btnCreate;
    }
}