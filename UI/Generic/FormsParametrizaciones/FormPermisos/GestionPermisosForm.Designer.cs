namespace UI.Generic.FormsParametrizaciones.FormPermiso
{
    partial class GestionPermisosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionPermisosForm));
            btnDelete = new MaterialSkin.Controls.MaterialButton();
            txtNombre = new MaterialSkin.Controls.MaterialTextBox();
            lblNombre = new MaterialSkin.Controls.MaterialLabel();
            btnSearch = new MaterialSkin.Controls.MaterialButton();
            cbxModulo = new MaterialSkin.Controls.MaterialComboBox();
            lblModulo = new MaterialSkin.Controls.MaterialLabel();
            lblTipoPermiso = new MaterialSkin.Controls.MaterialLabel();
            cbxTipoPermiso = new MaterialSkin.Controls.MaterialComboBox();
            dgvScreens = new DataGridView();
            lblPantallas = new MaterialSkin.Controls.MaterialLabel();
            btnAddScreen = new MaterialSkin.Controls.MaterialButton();
            btnRemoveScreen = new MaterialSkin.Controls.MaterialButton();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dgvScreens).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = false;
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDelete.Depth = 0;
            btnDelete.Enabled = false;
            btnDelete.HighEmphasis = true;
            btnDelete.Icon = (Image)resources.GetObject("btnDelete.Icon");
            btnDelete.Location = new Point(524, 31);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            btnDelete.Name = "btnDelete";
            btnDelete.NoAccentTextColor = Color.Empty;
            btnDelete.Size = new Size(50, 50);
            btnDelete.TabIndex = 28;
            btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDelete.UseAccentColor = false;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.AnimateReadOnly = false;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Depth = 0;
            txtNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombre.LeadingIcon = null;
            txtNombre.Location = new Point(10, 31);
            txtNombre.MaxLength = 50;
            txtNombre.MouseState = MaterialSkin.MouseState.OUT;
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(447, 50);
            txtNombre.TabIndex = 27;
            txtNombre.Text = "";
            txtNombre.TrailingIcon = null;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Depth = 0;
            lblNombre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNombre.Location = new Point(10, 9);
            lblNombre.MouseState = MaterialSkin.MouseState.HOVER;
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 19);
            lblNombre.TabIndex = 26;
            lblNombre.Text = "Nombre";
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
            btnSearch.TabIndex = 24;
            btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearch.UseAccentColor = false;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // cbxModulo
            // 
            cbxModulo.AutoResize = false;
            cbxModulo.BackColor = Color.FromArgb(255, 255, 255);
            cbxModulo.Depth = 0;
            cbxModulo.DrawMode = DrawMode.OwnerDrawVariable;
            cbxModulo.DropDownHeight = 174;
            cbxModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxModulo.DropDownWidth = 121;
            cbxModulo.Enabled = false;
            cbxModulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxModulo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxModulo.FormattingEnabled = true;
            cbxModulo.IntegralHeight = false;
            cbxModulo.ItemHeight = 43;
            cbxModulo.Location = new Point(10, 106);
            cbxModulo.MaxDropDownItems = 4;
            cbxModulo.MouseState = MaterialSkin.MouseState.OUT;
            cbxModulo.Name = "cbxModulo";
            cbxModulo.Size = new Size(447, 49);
            cbxModulo.StartIndex = 0;
            cbxModulo.TabIndex = 29;
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Depth = 0;
            lblModulo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblModulo.Location = new Point(9, 84);
            lblModulo.MouseState = MaterialSkin.MouseState.HOVER;
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(55, 19);
            lblModulo.TabIndex = 30;
            lblModulo.Text = "Modulo";
            // 
            // lblTipoPermiso
            // 
            lblTipoPermiso.AutoSize = true;
            lblTipoPermiso.Depth = 0;
            lblTipoPermiso.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTipoPermiso.Location = new Point(10, 158);
            lblTipoPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            lblTipoPermiso.Name = "lblTipoPermiso";
            lblTipoPermiso.Size = new Size(115, 19);
            lblTipoPermiso.TabIndex = 32;
            lblTipoPermiso.Text = "Tipo de permiso";
            // 
            // cbxTipoPermiso
            // 
            cbxTipoPermiso.AutoResize = false;
            cbxTipoPermiso.BackColor = Color.FromArgb(255, 255, 255);
            cbxTipoPermiso.Depth = 0;
            cbxTipoPermiso.DrawMode = DrawMode.OwnerDrawVariable;
            cbxTipoPermiso.DropDownHeight = 174;
            cbxTipoPermiso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoPermiso.DropDownWidth = 121;
            cbxTipoPermiso.Enabled = false;
            cbxTipoPermiso.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxTipoPermiso.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxTipoPermiso.FormattingEnabled = true;
            cbxTipoPermiso.IntegralHeight = false;
            cbxTipoPermiso.ItemHeight = 43;
            cbxTipoPermiso.Location = new Point(9, 180);
            cbxTipoPermiso.MaxDropDownItems = 4;
            cbxTipoPermiso.MouseState = MaterialSkin.MouseState.OUT;
            cbxTipoPermiso.Name = "cbxTipoPermiso";
            cbxTipoPermiso.Size = new Size(447, 49);
            cbxTipoPermiso.StartIndex = 0;
            cbxTipoPermiso.TabIndex = 31;
            // 
            // dgvScreens
            // 
            dgvScreens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScreens.Location = new Point(8, 254);
            dgvScreens.Name = "dgvScreens";
            dgvScreens.Size = new Size(449, 199);
            dgvScreens.TabIndex = 33;
            // 
            // lblPantallas
            // 
            lblPantallas.AutoSize = true;
            lblPantallas.Depth = 0;
            lblPantallas.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPantallas.Location = new Point(9, 232);
            lblPantallas.MouseState = MaterialSkin.MouseState.HOVER;
            lblPantallas.Name = "lblPantallas";
            lblPantallas.Size = new Size(68, 19);
            lblPantallas.TabIndex = 34;
            lblPantallas.Text = "Pantallas";
            // 
            // btnAddScreen
            // 
            btnAddScreen.AutoSize = false;
            btnAddScreen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddScreen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddScreen.Depth = 0;
            btnAddScreen.Enabled = false;
            btnAddScreen.HighEmphasis = true;
            btnAddScreen.Icon = null;
            btnAddScreen.Location = new Point(134, 462);
            btnAddScreen.Margin = new Padding(4, 6, 4, 6);
            btnAddScreen.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddScreen.Name = "btnAddScreen";
            btnAddScreen.NoAccentTextColor = Color.Empty;
            btnAddScreen.Size = new Size(157, 36);
            btnAddScreen.TabIndex = 35;
            btnAddScreen.Text = "Agregar";
            btnAddScreen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddScreen.UseAccentColor = false;
            btnAddScreen.UseVisualStyleBackColor = true;
            // 
            // btnRemoveScreen
            // 
            btnRemoveScreen.AutoSize = false;
            btnRemoveScreen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveScreen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemoveScreen.Depth = 0;
            btnRemoveScreen.Enabled = false;
            btnRemoveScreen.HighEmphasis = true;
            btnRemoveScreen.Icon = null;
            btnRemoveScreen.Location = new Point(299, 462);
            btnRemoveScreen.Margin = new Padding(4, 6, 4, 6);
            btnRemoveScreen.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemoveScreen.Name = "btnRemoveScreen";
            btnRemoveScreen.NoAccentTextColor = Color.Empty;
            btnRemoveScreen.Size = new Size(157, 36);
            btnRemoveScreen.TabIndex = 36;
            btnRemoveScreen.Text = "Eliminar";
            btnRemoveScreen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemoveScreen.UseAccentColor = false;
            btnRemoveScreen.UseVisualStyleBackColor = true;
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
            btnSave.Location = new Point(299, 510);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(157, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Guardar";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // GestionPermisosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 561);
            Controls.Add(btnSave);
            Controls.Add(btnRemoveScreen);
            Controls.Add(btnAddScreen);
            Controls.Add(lblPantallas);
            Controls.Add(dgvScreens);
            Controls.Add(lblTipoPermiso);
            Controls.Add(cbxTipoPermiso);
            Controls.Add(lblModulo);
            Controls.Add(cbxModulo);
            Controls.Add(btnDelete);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GestionPermisosForm";
            Text = "GestionPermisosPopup";
            Load += GestionPermisosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScreens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblTipoPermiso;
        private MaterialSkin.Controls.MaterialLabel lblModulo;
        private MaterialSkin.Controls.MaterialLabel lblNombre;
        private MaterialSkin.Controls.MaterialLabel lblPantallas;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private MaterialSkin.Controls.MaterialButton btnSearch;
        private MaterialSkin.Controls.MaterialTextBox txtNombre;
        private MaterialSkin.Controls.MaterialComboBox cbxModulo;
        private MaterialSkin.Controls.MaterialComboBox cbxTipoPermiso;
        private DataGridView dgvScreens;
        private MaterialSkin.Controls.MaterialButton btnAddScreen;
        private MaterialSkin.Controls.MaterialButton btnRemoveScreen;
        private MaterialSkin.Controls.MaterialButton btnSave;
    }
}