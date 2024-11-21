namespace UI.Generic.FormsParametrizaciones.FormsRoles
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
            btnAddRole = new MaterialSkin.Controls.MaterialButton();
            btnRemoveRole = new MaterialSkin.Controls.MaterialButton();
            txtRol = new MaterialSkin.Controls.MaterialTextBox();
            btnRemovePermiso = new MaterialSkin.Controls.MaterialButton();
            btnAddPermiso = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            dgvPermiso = new DataGridView();
            txtDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            lblDescripcion = new MaterialSkin.Controls.MaterialLabel();
            btnDelete = new MaterialSkin.Controls.MaterialButton();
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
            // btnAddRole
            // 
            btnAddRole.AutoSize = false;
            btnAddRole.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddRole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddRole.Depth = 0;
            btnAddRole.Enabled = false;
            btnAddRole.HighEmphasis = true;
            btnAddRole.Icon = null;
            btnAddRole.Location = new Point(166, 511);
            btnAddRole.Margin = new Padding(4, 6, 4, 6);
            btnAddRole.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddRole.Name = "btnAddRole";
            btnAddRole.NoAccentTextColor = Color.Empty;
            btnAddRole.Size = new Size(157, 36);
            btnAddRole.TabIndex = 8;
            btnAddRole.Text = "Agregar";
            btnAddRole.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddRole.UseAccentColor = false;
            btnAddRole.UseVisualStyleBackColor = true;
            // 
            // btnRemoveRole
            // 
            btnRemoveRole.AutoSize = false;
            btnRemoveRole.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveRole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemoveRole.Depth = 0;
            btnRemoveRole.Enabled = false;
            btnRemoveRole.HighEmphasis = true;
            btnRemoveRole.Icon = null;
            btnRemoveRole.Location = new Point(331, 511);
            btnRemoveRole.Margin = new Padding(4, 6, 4, 6);
            btnRemoveRole.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemoveRole.Name = "btnRemoveRole";
            btnRemoveRole.NoAccentTextColor = Color.Empty;
            btnRemoveRole.Size = new Size(157, 36);
            btnRemoveRole.TabIndex = 9;
            btnRemoveRole.Text = "Eliminar";
            btnRemoveRole.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemoveRole.UseAccentColor = false;
            btnRemoveRole.UseVisualStyleBackColor = true;
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
            // btnRemovePermiso
            // 
            btnRemovePermiso.AutoSize = false;
            btnRemovePermiso.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemovePermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemovePermiso.Depth = 0;
            btnRemovePermiso.Enabled = false;
            btnRemovePermiso.HighEmphasis = true;
            btnRemovePermiso.Icon = null;
            btnRemovePermiso.Location = new Point(848, 511);
            btnRemovePermiso.Margin = new Padding(4, 6, 4, 6);
            btnRemovePermiso.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemovePermiso.Name = "btnRemovePermiso";
            btnRemovePermiso.NoAccentTextColor = Color.Empty;
            btnRemovePermiso.Size = new Size(157, 36);
            btnRemovePermiso.TabIndex = 18;
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
            btnAddPermiso.Enabled = false;
            btnAddPermiso.HighEmphasis = true;
            btnAddPermiso.Icon = null;
            btnAddPermiso.Location = new Point(683, 511);
            btnAddPermiso.Margin = new Padding(4, 6, 4, 6);
            btnAddPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddPermiso.Name = "btnAddPermiso";
            btnAddPermiso.NoAccentTextColor = Color.Empty;
            btnAddPermiso.Size = new Size(157, 36);
            btnAddPermiso.TabIndex = 17;
            btnAddPermiso.Text = "Agregar";
            btnAddPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddPermiso.UseAccentColor = false;
            btnAddPermiso.UseVisualStyleBackColor = true;
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
            txtDescripcion.Enabled = false;
            txtDescripcion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
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
            // btnDelete
            // 
            btnDelete.AutoSize = false;
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDelete.Depth = 0;
            btnDelete.HighEmphasis = true;
            btnDelete.Icon = (Image)resources.GetObject("btnDelete.Icon");
            btnDelete.Location = new Point(524, 31);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            btnDelete.Name = "btnDelete";
            btnDelete.NoAccentTextColor = Color.Empty;
            btnDelete.Size = new Size(50, 50);
            btnDelete.TabIndex = 22;
            btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDelete.UseAccentColor = false;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // GestionRolesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 600);
            Controls.Add(btnDelete);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(dgvPermiso);
            Controls.Add(btnRemovePermiso);
            Controls.Add(btnAddPermiso);
            Controls.Add(materialLabel1);
            Controls.Add(btnRemoveRole);
            Controls.Add(btnAddRole);
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
        private MaterialSkin.Controls.MaterialButton btnAddRole;
        private MaterialSkin.Controls.MaterialButton btnRemoveRole;
        private MaterialSkin.Controls.MaterialTextBox txtRol;
        private MaterialSkin.Controls.MaterialButton btnRemovePermiso;
        private MaterialSkin.Controls.MaterialButton btnAddPermiso;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private DataGridView dgvPermiso;
        private MaterialSkin.Controls.MaterialTextBox txtDescripcion;
        private MaterialSkin.Controls.MaterialLabel lblDescripcion;
        private MaterialSkin.Controls.MaterialButton btnDelete;
    }
}