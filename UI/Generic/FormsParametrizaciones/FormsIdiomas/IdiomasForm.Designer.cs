namespace UI.Generic.FormsParametrizaciones.FormsIdiomas
{
    partial class IdiomasForm
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
            lblRol = new MaterialSkin.Controls.MaterialLabel();
            cbxIdiomas = new MaterialSkin.Controls.MaterialComboBox();
            btnSave = new MaterialSkin.Controls.MaterialButton();
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
            lblRol.Size = new Size(136, 19);
            lblRol.TabIndex = 14;
            lblRol.Text = "Seleccionar Idioma";
            // 
            // cbxIdiomas
            // 
            cbxIdiomas.AutoResize = false;
            cbxIdiomas.BackColor = Color.FromArgb(255, 255, 255);
            cbxIdiomas.Depth = 0;
            cbxIdiomas.DrawMode = DrawMode.OwnerDrawVariable;
            cbxIdiomas.DropDownHeight = 174;
            cbxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdiomas.DropDownWidth = 121;
            cbxIdiomas.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxIdiomas.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxIdiomas.FormattingEnabled = true;
            cbxIdiomas.IntegralHeight = false;
            cbxIdiomas.ItemHeight = 43;
            cbxIdiomas.Location = new Point(12, 31);
            cbxIdiomas.MaxDropDownItems = 4;
            cbxIdiomas.MouseState = MaterialSkin.MouseState.OUT;
            cbxIdiomas.Name = "cbxIdiomas";
            cbxIdiomas.Size = new Size(447, 49);
            cbxIdiomas.StartIndex = 0;
            cbxIdiomas.TabIndex = 16;
            // 
            // btnSave
            // 
            btnSave.AutoSize = false;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(302, 89);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(157, 36);
            btnSave.TabIndex = 17;
            btnSave.Text = "Guardar";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // IdiomasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 600);
            Controls.Add(btnSave);
            Controls.Add(cbxIdiomas);
            Controls.Add(lblRol);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IdiomasForm";
            Text = "IdiomasForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblRol;
        private MaterialSkin.Controls.MaterialComboBox cbxIdiomas;
        private MaterialSkin.Controls.MaterialButton btnSave;
    }
}