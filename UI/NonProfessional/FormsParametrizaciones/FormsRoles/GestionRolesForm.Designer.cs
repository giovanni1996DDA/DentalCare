namespace UI.NonProfessional.FormsParametrizaciones.FormsRoles
{
    partial class GestionRolesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionRolesForm));
            lblRol = new MaterialSkin.Controls.MaterialLabel();
            dgvRol = new DataGridView();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            btnSearch = new MaterialSkin.Controls.MaterialButton();
            lblDestalle = new MaterialSkin.Controls.MaterialLabel();
            btnAgregar = new MaterialSkin.Controls.MaterialButton();
            btnEliminar = new MaterialSkin.Controls.MaterialButton();
            txtRol = new MaterialSkin.Controls.MaterialTextBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            dgvPermiso = new DataGridView();
            txtDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            lblDescripcion = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dgvRol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPermiso).BeginInit();
            SuspendLayout();
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Depth = 0;
            lblRol.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRol.Location = new Point(12, 9);
            lblRol.MouseState = MaterialSkin.MouseState.HOVER;
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 19);
            lblRol.TabIndex = 0;
            lblRol.Text = "Rol";
            // 
            // dgvRol
            // 
            dgvRol.AllowUserToAddRows = false;
            dgvRol.AllowUserToDeleteRows = false;
            dgvRol.AllowUserToOrderColumns = true;
            dgvRol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRol.Location = new Point(12, 195);
            dgvRol.Name = "dgvRol";
            dgvRol.ReadOnly = true;
            dgvRol.Size = new Size(476, 307);
            dgvRol.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.AutoSize = false;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.Enabled = false;
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(848, 556);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(157, 36);
            btnSave.TabIndex = 5;
            btnSave.Text = "Guardar";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = false;
            btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearch.BackgroundImage = (Image)resources.GetObject("btnSearch.BackgroundImage");
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearch.Depth = 0;
            btnSearch.HighEmphasis = true;
            btnSearch.Icon = (Image)resources.GetObject("btnSearch.Icon");
            btnSearch.Location = new Point(466, 31);
            btnSearch.Margin = new Padding(4, 6, 4, 6);
            btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearch.Name = "btnSearch";
            btnSearch.NoAccentTextColor = Color.Empty;
            btnSearch.Size = new Size(50, 50);
            btnSearch.TabIndex = 6;
            btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearch.UseAccentColor = false;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblDestalle
            // 
            lblDestalle.AutoSize = true;
            lblDestalle.Depth = 0;
            lblDestalle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDestalle.Location = new Point(11, 173);
            lblDestalle.MouseState = MaterialSkin.MouseState.HOVER;
            lblDestalle.Name = "lblDestalle";
            lblDestalle.Size = new Size(78, 19);
            lblDestalle.TabIndex = 7;
            lblDestalle.Text = "Roles hijos";
            // 
            // btnAgregar
            // 
            btnAgregar.AutoSize = false;
            btnAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAgregar.Depth = 0;
            btnAgregar.Enabled = false;
            btnAgregar.HighEmphasis = true;
            btnAgregar.Icon = null;
            btnAgregar.Location = new Point(166, 511);
            btnAgregar.Margin = new Padding(4, 6, 4, 6);
            btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAgregar.Name = "btnAgregar";
            btnAgregar.NoAccentTextColor = Color.Empty;
            btnAgregar.Size = new Size(157, 36);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAgregar.UseAccentColor = false;
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.AutoSize = false;
            btnEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEliminar.Depth = 0;
            btnEliminar.Enabled = false;
            btnEliminar.HighEmphasis = true;
            btnEliminar.Icon = null;
            btnEliminar.Location = new Point(331, 511);
            btnEliminar.Margin = new Padding(4, 6, 4, 6);
            btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.NoAccentTextColor = Color.Empty;
            btnEliminar.Size = new Size(157, 36);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEliminar.UseAccentColor = false;
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // txtRol
            // 
            txtRol.AnimateReadOnly = false;
            txtRol.BorderStyle = BorderStyle.None;
            txtRol.Depth = 0;
            txtRol.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRol.LeadingIcon = null;
            txtRol.Location = new Point(12, 31);
            txtRol.MaxLength = 50;
            txtRol.MouseState = MaterialSkin.MouseState.OUT;
            txtRol.Multiline = false;
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(447, 50);
            txtRol.TabIndex = 13;
            txtRol.Text = "";
            txtRol.TrailingIcon = null;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.Enabled = false;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(848, 511);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(157, 36);
            materialButton1.TabIndex = 18;
            materialButton1.Text = "Eliminar";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            materialButton2.AutoSize = false;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.Enabled = false;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(683, 511);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(157, 36);
            materialButton2.TabIndex = 17;
            materialButton2.Text = "Agregar";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(529, 173);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(67, 19);
            materialLabel1.TabIndex = 16;
            materialLabel1.Text = "Permisos";
            // 
            // dgvPermiso
            // 
            dgvPermiso.AllowUserToAddRows = false;
            dgvPermiso.AllowUserToDeleteRows = false;
            dgvPermiso.AllowUserToOrderColumns = true;
            dgvPermiso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermiso.Location = new Point(529, 195);
            dgvPermiso.Name = "dgvPermiso";
            dgvPermiso.ReadOnly = true;
            dgvPermiso.Size = new Size(476, 307);
            dgvPermiso.TabIndex = 19;
            // 
            // txtDescripcion
            // 
            txtDescripcion.AnimateReadOnly = false;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Depth = 0;
            txtDescripcion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDescripcion.LeadingIcon = null;
            txtDescripcion.Location = new Point(12, 106);
            txtDescripcion.MaxLength = 50;
            txtDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            txtDescripcion.Multiline = false;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(447, 50);
            txtDescripcion.TabIndex = 21;
            txtDescripcion.Text = "";
            txtDescripcion.TrailingIcon = null;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Depth = 0;
            lblDescripcion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDescripcion.Location = new Point(11, 84);
            lblDescripcion.MouseState = MaterialSkin.MouseState.HOVER;
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(84, 19);
            lblDescripcion.TabIndex = 20;
            lblDescripcion.Text = "Descripcion";
            // 
            // GestionRolesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 600);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(dgvPermiso);
            Controls.Add(materialButton1);
            Controls.Add(materialButton2);
            Controls.Add(materialLabel1);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(txtRol);
            Controls.Add(lblDestalle);
            Controls.Add(btnSave);
            Controls.Add(btnSearch);
            Controls.Add(dgvRol);
            Controls.Add(lblRol);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GestionRolesForm";
            Text = "GestionRolesForm";
            ((System.ComponentModel.ISupportInitialize)dgvRol).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPermiso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblRol;
        private DataGridView dgvRol;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnSearch;
        private MaterialSkin.Controls.MaterialLabel lblDestalle;
        private MaterialSkin.Controls.MaterialButton btnAgregar;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
        private MaterialSkin.Controls.MaterialTextBox txtRol;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private DataGridView dgvPermiso;
        private MaterialSkin.Controls.MaterialTextBox txtDescripcion;
        private MaterialSkin.Controls.MaterialLabel lblDescripcion;
    }
}