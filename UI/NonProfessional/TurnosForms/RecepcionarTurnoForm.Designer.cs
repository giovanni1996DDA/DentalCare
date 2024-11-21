namespace UI.NonProfessional.TurnosForms
{
    partial class RecepcionarTurnoForm
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
            groupBox4 = new GroupBox();
            dtpFecha = new DateTimePicker();
            lblFecha = new MaterialSkin.Controls.MaterialLabel();
            dgvTurnos = new DataGridView();
            btnRecepcionar = new MaterialSkin.Controls.MaterialButton();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dtpFecha);
            groupBox4.Controls.Add(lblFecha);
            groupBox4.Controls.Add(dgvTurnos);
            groupBox4.Font = new Font("Segoe UI", 14F);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(991, 608);
            groupBox4.TabIndex = 40;
            groupBox4.TabStop = false;
            groupBox4.Text = "Turnos";
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFecha.CustomFormat = "dd.MM.yyyy";
            dtpFecha.Enabled = false;
            dtpFecha.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(226, 34);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(187, 26);
            dtpFecha.TabIndex = 17;
            dtpFecha.Value = new DateTime(2024, 10, 31, 16, 48, 38, 0);
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Depth = 0;
            lblFecha.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFecha.Location = new Point(30, 41);
            lblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(92, 19);
            lblFecha.TabIndex = 16;
            lblFecha.Text = "Fecha Desde";
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
            dgvTurnos.Location = new Point(30, 66);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = true;
            dgvTurnos.Size = new Size(929, 508);
            dgvTurnos.TabIndex = 0;
            // 
            // btnRecepcionar
            // 
            btnRecepcionar.AutoSize = false;
            btnRecepcionar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRecepcionar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRecepcionar.Depth = 0;
            btnRecepcionar.Enabled = false;
            btnRecepcionar.HighEmphasis = true;
            btnRecepcionar.Icon = null;
            btnRecepcionar.Location = new Point(846, 629);
            btnRecepcionar.Margin = new Padding(4, 6, 4, 6);
            btnRecepcionar.MouseState = MaterialSkin.MouseState.HOVER;
            btnRecepcionar.Name = "btnRecepcionar";
            btnRecepcionar.NoAccentTextColor = Color.Empty;
            btnRecepcionar.Size = new Size(157, 36);
            btnRecepcionar.TabIndex = 41;
            btnRecepcionar.Text = "Recepcionar";
            btnRecepcionar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRecepcionar.UseAccentColor = false;
            btnRecepcionar.UseVisualStyleBackColor = true;
            // 
            // RecepcionarTurnoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 730);
            Controls.Add(btnRecepcionar);
            Controls.Add(groupBox4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecepcionarTurnoForm";
            Text = "RecepcionarTurnoForm";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox4;
        private DateTimePicker dtpFecha;
        private MaterialSkin.Controls.MaterialLabel lblFecha;
        private DataGridView dgvTurnos;
        private MaterialSkin.Controls.MaterialButton btnRecepcionar;
    }
}