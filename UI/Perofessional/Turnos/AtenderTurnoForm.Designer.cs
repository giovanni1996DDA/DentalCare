namespace UI.Perofessional.Turnos
{
    partial class AtenderTurnoForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnAtender = new MaterialSkin.Controls.MaterialButton();
            groupBox4 = new GroupBox();
            dgvTurnos = new DataGridView();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // btnAtender
            // 
            btnAtender.AutoSize = false;
            btnAtender.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAtender.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAtender.Depth = 0;
            btnAtender.Enabled = false;
            btnAtender.HighEmphasis = true;
            btnAtender.Icon = null;
            btnAtender.Location = new Point(846, 629);
            btnAtender.Margin = new Padding(4, 6, 4, 6);
            btnAtender.MouseState = MaterialSkin.MouseState.HOVER;
            btnAtender.Name = "btnAtender";
            btnAtender.NoAccentTextColor = Color.Empty;
            btnAtender.Size = new Size(157, 36);
            btnAtender.TabIndex = 43;
            btnAtender.Text = "Atender";
            btnAtender.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAtender.UseAccentColor = false;
            btnAtender.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvTurnos);
            groupBox4.Font = new Font("Segoe UI", 14F);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(991, 608);
            groupBox4.TabIndex = 42;
            groupBox4.TabStop = false;
            groupBox4.Text = "Turnos";
            // 
            // dgvTurnos
            // 
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AllowUserToOrderColumns = true;
            dgvTurnos.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTurnos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTurnos.GridColor = SystemColors.ScrollBar;
            dgvTurnos.Location = new Point(30, 31);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = true;
            dgvTurnos.Size = new Size(929, 543);
            dgvTurnos.TabIndex = 0;
            // 
            // AtenderTurnoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 730);
            Controls.Add(btnAtender);
            Controls.Add(groupBox4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AtenderTurnoForm";
            Text = "AtenderTurnoForm";
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnAtender;
        private GroupBox groupBox4;
        private DataGridView dgvTurnos;
    }
}