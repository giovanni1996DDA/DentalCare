namespace UI.Generic.FormsParametrizaciones.FormsRestoreBackup
{
    partial class RestoreBackupForm
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
            btnBackup = new MaterialSkin.Controls.MaterialButton();
            lblBackupPath = new MaterialSkin.Controls.MaterialLabel();
            txtBackup = new MaterialSkin.Controls.MaterialTextBox();
            groupBox2 = new GroupBox();
            btnRestore = new MaterialSkin.Controls.MaterialButton();
            lblRestorePath = new MaterialSkin.Controls.MaterialLabel();
            cbxBackups = new MaterialSkin.Controls.MaterialComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBackup);
            groupBox1.Controls.Add(lblBackupPath);
            groupBox1.Controls.Add(txtBackup);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(621, 157);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Backup";
            // 
            // btnBackup
            // 
            btnBackup.AutoSize = false;
            btnBackup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackup.Depth = 0;
            btnBackup.HighEmphasis = true;
            btnBackup.Icon = null;
            btnBackup.Location = new Point(457, 102);
            btnBackup.Margin = new Padding(4, 6, 4, 6);
            btnBackup.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackup.Name = "btnBackup";
            btnBackup.NoAccentTextColor = Color.Empty;
            btnBackup.Size = new Size(157, 36);
            btnBackup.TabIndex = 30;
            btnBackup.Text = "Crear";
            btnBackup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackup.UseAccentColor = false;
            btnBackup.UseVisualStyleBackColor = true;
            // 
            // lblBackupPath
            // 
            lblBackupPath.AutoSize = true;
            lblBackupPath.Depth = 0;
            lblBackupPath.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBackupPath.Location = new Point(29, 74);
            lblBackupPath.MouseState = MaterialSkin.MouseState.HOVER;
            lblBackupPath.Name = "lblBackupPath";
            lblBackupPath.Size = new Size(146, 19);
            lblBackupPath.TabIndex = 4;
            lblBackupPath.Text = "Directorio de backup";
            // 
            // txtBackup
            // 
            txtBackup.AnimateReadOnly = false;
            txtBackup.BorderStyle = BorderStyle.None;
            txtBackup.Depth = 0;
            txtBackup.Enabled = false;
            txtBackup.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBackup.LeadingIcon = null;
            txtBackup.Location = new Point(217, 43);
            txtBackup.MaxLength = 50;
            txtBackup.MouseState = MaterialSkin.MouseState.OUT;
            txtBackup.Multiline = false;
            txtBackup.Name = "txtBackup";
            txtBackup.Size = new Size(398, 50);
            txtBackup.TabIndex = 0;
            txtBackup.Text = "";
            txtBackup.TrailingIcon = null;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbxBackups);
            groupBox2.Controls.Add(btnRestore);
            groupBox2.Controls.Add(lblRestorePath);
            groupBox2.Font = new Font("Segoe UI", 14F);
            groupBox2.Location = new Point(12, 175);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(621, 157);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Restaurar Backup";
            // 
            // btnRestore
            // 
            btnRestore.AutoSize = false;
            btnRestore.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRestore.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRestore.Depth = 0;
            btnRestore.HighEmphasis = true;
            btnRestore.Icon = null;
            btnRestore.Location = new Point(457, 102);
            btnRestore.Margin = new Padding(4, 6, 4, 6);
            btnRestore.MouseState = MaterialSkin.MouseState.HOVER;
            btnRestore.Name = "btnRestore";
            btnRestore.NoAccentTextColor = Color.Empty;
            btnRestore.Size = new Size(157, 36);
            btnRestore.TabIndex = 30;
            btnRestore.Text = "Restaurar";
            btnRestore.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRestore.UseAccentColor = false;
            btnRestore.UseVisualStyleBackColor = true;
            // 
            // lblRestorePath
            // 
            lblRestorePath.AutoSize = true;
            lblRestorePath.Depth = 0;
            lblRestorePath.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRestorePath.Location = new Point(29, 74);
            lblRestorePath.MouseState = MaterialSkin.MouseState.HOVER;
            lblRestorePath.Name = "lblRestorePath";
            lblRestorePath.Size = new Size(182, 19);
            lblRestorePath.TabIndex = 4;
            lblRestorePath.Text = "Directorio de restauracion";
            // 
            // cbxBackups
            // 
            cbxBackups.AutoResize = false;
            cbxBackups.BackColor = Color.FromArgb(255, 255, 255);
            cbxBackups.Depth = 0;
            cbxBackups.DrawMode = DrawMode.OwnerDrawVariable;
            cbxBackups.DropDownHeight = 174;
            cbxBackups.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxBackups.DropDownWidth = 121;
            cbxBackups.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxBackups.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxBackups.FormattingEnabled = true;
            cbxBackups.IntegralHeight = false;
            cbxBackups.ItemHeight = 43;
            cbxBackups.Location = new Point(217, 44);
            cbxBackups.MaxDropDownItems = 4;
            cbxBackups.MouseState = MaterialSkin.MouseState.OUT;
            cbxBackups.Name = "cbxBackups";
            cbxBackups.Size = new Size(397, 49);
            cbxBackups.StartIndex = 0;
            cbxBackups.TabIndex = 31;
            // 
            // RestoreBackupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 600);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RestoreBackupForm";
            Text = "RestoreBackupForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel lblBackupPath;
        private MaterialSkin.Controls.MaterialTextBox txtBackup;
        private MaterialSkin.Controls.MaterialButton btnBackup;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialButton btnRestore;
        private MaterialSkin.Controls.MaterialLabel lblRestorePath;
        private MaterialSkin.Controls.MaterialComboBox cbxBackups;
    }
}