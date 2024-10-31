namespace UI.NonProfessional.TurnosForms
{
    partial class FindProfesionalPopUp
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
            btnSelect = new MaterialSkin.Controls.MaterialButton();
            btnCancel = new MaterialSkin.Controls.MaterialButton();
            dgvProfesionales = new DataGridView();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvProfesionales).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelect
            // 
            btnSelect.AutoSize = false;
            btnSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSelect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSelect.Depth = 0;
            btnSelect.HighEmphasis = true;
            btnSelect.Icon = null;
            btnSelect.Location = new Point(230, 328);
            btnSelect.Margin = new Padding(4, 6, 4, 6);
            btnSelect.MouseState = MaterialSkin.MouseState.HOVER;
            btnSelect.Name = "btnSelect";
            btnSelect.NoAccentTextColor = Color.Empty;
            btnSelect.Size = new Size(158, 36);
            btnSelect.TabIndex = 8;
            btnSelect.Text = "Agregar";
            btnSelect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSelect.UseAccentColor = false;
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = false;
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancel.Depth = 0;
            btnCancel.HighEmphasis = true;
            btnCancel.Icon = null;
            btnCancel.Location = new Point(396, 328);
            btnCancel.Margin = new Padding(4, 6, 4, 6);
            btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancel.Name = "btnCancel";
            btnCancel.NoAccentTextColor = Color.Empty;
            btnCancel.Size = new Size(158, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancel.UseAccentColor = false;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvProfesionales
            // 
            dgvProfesionales.AllowUserToAddRows = false;
            dgvProfesionales.AllowUserToDeleteRows = false;
            dgvProfesionales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesionales.Location = new Point(6, 31);
            dgvProfesionales.Name = "dgvProfesionales";
            dgvProfesionales.ReadOnly = true;
            dgvProfesionales.Size = new Size(530, 267);
            dgvProfesionales.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvProfesionales);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(542, 304);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccionar profesional";
            // 
            // FindProfesionalPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 378);
            Controls.Add(groupBox1);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FindProfesionalPopUp";
            Text = "FindProfesionalForm";
            ((System.ComponentModel.ISupportInitialize)dgvProfesionales).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSelect;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private DataGridView dgvProfesionales;
        private GroupBox groupBox1;
    }
}