namespace UI.NonProfessional.TurnosForms
{
    partial class ModifyTurnoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyTurnoForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox3 = new GroupBox();
            dtpFechaHoraTurno = new DateTimePicker();
            lblFechaTurno = new MaterialSkin.Controls.MaterialLabel();
            groupBox2 = new GroupBox();
            lblNroDoc = new MaterialSkin.Controls.MaterialLabel();
            txtNroDoc = new MaterialSkin.Controls.MaterialTextBox();
            cbxTipoDocumento = new MaterialSkin.Controls.MaterialComboBox();
            txtApellidoPac = new MaterialSkin.Controls.MaterialTextBox();
            txtNombrePac = new MaterialSkin.Controls.MaterialTextBox();
            lblNombrePac = new MaterialSkin.Controls.MaterialLabel();
            btnSearchPac = new MaterialSkin.Controls.MaterialButton();
            lblPaciente = new MaterialSkin.Controls.MaterialLabel();
            lblApellidoPac = new MaterialSkin.Controls.MaterialLabel();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            groupBox1 = new GroupBox();
            lblApellidoProf = new MaterialSkin.Controls.MaterialLabel();
            lblNombreProf = new MaterialSkin.Controls.MaterialLabel();
            txtApellidoProf = new MaterialSkin.Controls.MaterialTextBox();
            txtNombreProf = new MaterialSkin.Controls.MaterialTextBox();
            btnSearchProf = new MaterialSkin.Controls.MaterialButton();
            cbxEspecialidad = new MaterialSkin.Controls.MaterialComboBox();
            lblEspecialidad = new MaterialSkin.Controls.MaterialLabel();
            groupBox4 = new GroupBox();
            btnSearchTurno = new MaterialSkin.Controls.MaterialButton();
            dtpFechaHasta = new DateTimePicker();
            lblHasta = new MaterialSkin.Controls.MaterialLabel();
            dtpFechaDesde = new DateTimePicker();
            lblDesde = new MaterialSkin.Controls.MaterialLabel();
            dgvTurnos = new DataGridView();
            btnEliminar = new MaterialSkin.Controls.MaterialButton();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dtpFechaHoraTurno);
            groupBox3.Controls.Add(lblFechaTurno);
            groupBox3.Font = new Font("Segoe UI", 14F);
            groupBox3.Location = new Point(473, 517);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(560, 103);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos del turno";
            // 
            // dtpFechaHoraTurno
            // 
            dtpFechaHoraTurno.CalendarFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFechaHoraTurno.CustomFormat = "dd.MM.yyyy - HH:mm'hs'";
            dtpFechaHoraTurno.Enabled = false;
            dtpFechaHoraTurno.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFechaHoraTurno.Format = DateTimePickerFormat.Custom;
            dtpFechaHoraTurno.Location = new Point(222, 43);
            dtpFechaHoraTurno.Name = "dtpFechaHoraTurno";
            dtpFechaHoraTurno.Size = new Size(256, 26);
            dtpFechaHoraTurno.TabIndex = 15;
            dtpFechaHoraTurno.Value = new DateTime(2024, 10, 31, 16, 48, 38, 0);
            // 
            // lblFechaTurno
            // 
            lblFechaTurno.AutoSize = true;
            lblFechaTurno.Depth = 0;
            lblFechaTurno.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFechaTurno.Location = new Point(28, 51);
            lblFechaTurno.MouseState = MaterialSkin.MouseState.HOVER;
            lblFechaTurno.Name = "lblFechaTurno";
            lblFechaTurno.Size = new Size(158, 19);
            lblFechaTurno.TabIndex = 9;
            lblFechaTurno.Text = "Fecha y hora del turno";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblNroDoc);
            groupBox2.Controls.Add(txtNroDoc);
            groupBox2.Controls.Add(cbxTipoDocumento);
            groupBox2.Controls.Add(txtApellidoPac);
            groupBox2.Controls.Add(txtNombrePac);
            groupBox2.Controls.Add(lblNombrePac);
            groupBox2.Controls.Add(btnSearchPac);
            groupBox2.Controls.Add(lblPaciente);
            groupBox2.Controls.Add(lblApellidoPac);
            groupBox2.Font = new Font("Segoe UI", 14F);
            groupBox2.Location = new Point(473, 244);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(560, 267);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del paciente";
            // 
            // lblNroDoc
            // 
            lblNroDoc.AutoSize = true;
            lblNroDoc.Depth = 0;
            lblNroDoc.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNroDoc.Location = new Point(28, 117);
            lblNroDoc.MouseState = MaterialSkin.MouseState.HOVER;
            lblNroDoc.Name = "lblNroDoc";
            lblNroDoc.Size = new Size(164, 19);
            lblNroDoc.TabIndex = 21;
            lblNroDoc.Text = "Número de Documento";
            // 
            // txtNroDoc
            // 
            txtNroDoc.AnimateReadOnly = false;
            txtNroDoc.BorderStyle = BorderStyle.None;
            txtNroDoc.Depth = 0;
            txtNroDoc.Enabled = false;
            txtNroDoc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNroDoc.LeadingIcon = null;
            txtNroDoc.Location = new Point(222, 86);
            txtNroDoc.MaxLength = 50;
            txtNroDoc.MouseState = MaterialSkin.MouseState.OUT;
            txtNroDoc.Multiline = false;
            txtNroDoc.Name = "txtNroDoc";
            txtNroDoc.Size = new Size(256, 50);
            txtNroDoc.TabIndex = 20;
            txtNroDoc.Text = "";
            txtNroDoc.TrailingIcon = null;
            // 
            // cbxTipoDocumento
            // 
            cbxTipoDocumento.AutoResize = false;
            cbxTipoDocumento.BackColor = Color.FromArgb(255, 255, 255);
            cbxTipoDocumento.Depth = 0;
            cbxTipoDocumento.DrawMode = DrawMode.OwnerDrawVariable;
            cbxTipoDocumento.DropDownHeight = 174;
            cbxTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoDocumento.DropDownWidth = 121;
            cbxTipoDocumento.Enabled = false;
            cbxTipoDocumento.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxTipoDocumento.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxTipoDocumento.FormattingEnabled = true;
            cbxTipoDocumento.IntegralHeight = false;
            cbxTipoDocumento.ItemHeight = 43;
            cbxTipoDocumento.Location = new Point(222, 31);
            cbxTipoDocumento.MaxDropDownItems = 4;
            cbxTipoDocumento.MouseState = MaterialSkin.MouseState.OUT;
            cbxTipoDocumento.Name = "cbxTipoDocumento";
            cbxTipoDocumento.Size = new Size(256, 49);
            cbxTipoDocumento.StartIndex = 0;
            cbxTipoDocumento.TabIndex = 16;
            // 
            // txtApellidoPac
            // 
            txtApellidoPac.AnimateReadOnly = false;
            txtApellidoPac.BorderStyle = BorderStyle.None;
            txtApellidoPac.Depth = 0;
            txtApellidoPac.Enabled = false;
            txtApellidoPac.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtApellidoPac.LeadingIcon = null;
            txtApellidoPac.Location = new Point(222, 199);
            txtApellidoPac.MaxLength = 50;
            txtApellidoPac.MouseState = MaterialSkin.MouseState.OUT;
            txtApellidoPac.Multiline = false;
            txtApellidoPac.Name = "txtApellidoPac";
            txtApellidoPac.Size = new Size(256, 50);
            txtApellidoPac.TabIndex = 17;
            txtApellidoPac.Text = "";
            txtApellidoPac.TrailingIcon = null;
            // 
            // txtNombrePac
            // 
            txtNombrePac.AnimateReadOnly = false;
            txtNombrePac.BorderStyle = BorderStyle.None;
            txtNombrePac.Depth = 0;
            txtNombrePac.Enabled = false;
            txtNombrePac.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombrePac.LeadingIcon = null;
            txtNombrePac.Location = new Point(222, 142);
            txtNombrePac.MaxLength = 50;
            txtNombrePac.MouseState = MaterialSkin.MouseState.OUT;
            txtNombrePac.Multiline = false;
            txtNombrePac.Name = "txtNombrePac";
            txtNombrePac.Size = new Size(256, 50);
            txtNombrePac.TabIndex = 14;
            txtNombrePac.Text = "";
            txtNombrePac.TrailingIcon = null;
            // 
            // lblNombrePac
            // 
            lblNombrePac.AutoSize = true;
            lblNombrePac.Depth = 0;
            lblNombrePac.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNombrePac.Location = new Point(29, 173);
            lblNombrePac.MouseState = MaterialSkin.MouseState.HOVER;
            lblNombrePac.Name = "lblNombrePac";
            lblNombrePac.Size = new Size(57, 19);
            lblNombrePac.TabIndex = 18;
            lblNombrePac.Text = "Nombre";
            // 
            // btnSearchPac
            // 
            btnSearchPac.AutoSize = false;
            btnSearchPac.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearchPac.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearchPac.Depth = 0;
            btnSearchPac.Enabled = false;
            btnSearchPac.HighEmphasis = true;
            btnSearchPac.Icon = (Image)resources.GetObject("btnSearchPac.Icon");
            btnSearchPac.Location = new Point(485, 86);
            btnSearchPac.Margin = new Padding(4, 6, 4, 6);
            btnSearchPac.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearchPac.Name = "btnSearchPac";
            btnSearchPac.NoAccentTextColor = Color.Empty;
            btnSearchPac.Size = new Size(50, 50);
            btnSearchPac.TabIndex = 13;
            btnSearchPac.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearchPac.UseAccentColor = false;
            btnSearchPac.UseVisualStyleBackColor = true;
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Depth = 0;
            lblPaciente.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPaciente.Location = new Point(28, 61);
            lblPaciente.MouseState = MaterialSkin.MouseState.HOVER;
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(140, 19);
            lblPaciente.TabIndex = 6;
            lblPaciente.Text = "Tipo de Documento";
            // 
            // lblApellidoPac
            // 
            lblApellidoPac.AutoSize = true;
            lblApellidoPac.Depth = 0;
            lblApellidoPac.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblApellidoPac.Location = new Point(29, 230);
            lblApellidoPac.MouseState = MaterialSkin.MouseState.HOVER;
            lblApellidoPac.Name = "lblApellidoPac";
            lblApellidoPac.Size = new Size(58, 19);
            lblApellidoPac.TabIndex = 19;
            lblApellidoPac.Text = "Apellido";
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
            btnSave.Location = new Point(876, 629);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(157, 36);
            btnSave.TabIndex = 39;
            btnSave.Text = "Guardar";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblApellidoProf);
            groupBox1.Controls.Add(lblNombreProf);
            groupBox1.Controls.Add(txtApellidoProf);
            groupBox1.Controls.Add(txtNombreProf);
            groupBox1.Controls.Add(btnSearchProf);
            groupBox1.Controls.Add(cbxEspecialidad);
            groupBox1.Controls.Add(lblEspecialidad);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(473, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(560, 226);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del profesional";
            // 
            // lblApellidoProf
            // 
            lblApellidoProf.AutoSize = true;
            lblApellidoProf.Depth = 0;
            lblApellidoProf.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblApellidoProf.Location = new Point(28, 130);
            lblApellidoProf.MouseState = MaterialSkin.MouseState.HOVER;
            lblApellidoProf.Name = "lblApellidoProf";
            lblApellidoProf.Size = new Size(143, 19);
            lblApellidoProf.TabIndex = 23;
            lblApellidoProf.Text = "Apellido Profesional";
            // 
            // lblNombreProf
            // 
            lblNombreProf.AutoSize = true;
            lblNombreProf.Depth = 0;
            lblNombreProf.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNombreProf.Location = new Point(29, 180);
            lblNombreProf.MouseState = MaterialSkin.MouseState.HOVER;
            lblNombreProf.Name = "lblNombreProf";
            lblNombreProf.Size = new Size(142, 19);
            lblNombreProf.TabIndex = 22;
            lblNombreProf.Text = "Nombre Profesional";
            // 
            // txtApellidoProf
            // 
            txtApellidoProf.AnimateReadOnly = false;
            txtApellidoProf.BorderStyle = BorderStyle.None;
            txtApellidoProf.Depth = 0;
            txtApellidoProf.Enabled = false;
            txtApellidoProf.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtApellidoProf.LeadingIcon = null;
            txtApellidoProf.Location = new Point(222, 99);
            txtApellidoProf.MaxLength = 50;
            txtApellidoProf.MouseState = MaterialSkin.MouseState.OUT;
            txtApellidoProf.Multiline = false;
            txtApellidoProf.Name = "txtApellidoProf";
            txtApellidoProf.Size = new Size(256, 50);
            txtApellidoProf.TabIndex = 21;
            txtApellidoProf.Text = "";
            txtApellidoProf.TrailingIcon = null;
            // 
            // txtNombreProf
            // 
            txtNombreProf.AnimateReadOnly = false;
            txtNombreProf.BorderStyle = BorderStyle.None;
            txtNombreProf.Depth = 0;
            txtNombreProf.Enabled = false;
            txtNombreProf.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombreProf.LeadingIcon = null;
            txtNombreProf.Location = new Point(222, 155);
            txtNombreProf.MaxLength = 50;
            txtNombreProf.MouseState = MaterialSkin.MouseState.OUT;
            txtNombreProf.Multiline = false;
            txtNombreProf.Name = "txtNombreProf";
            txtNombreProf.Size = new Size(256, 50);
            txtNombreProf.TabIndex = 20;
            txtNombreProf.Text = "";
            txtNombreProf.TrailingIcon = null;
            // 
            // btnSearchProf
            // 
            btnSearchProf.AutoSize = false;
            btnSearchProf.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearchProf.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearchProf.Depth = 0;
            btnSearchProf.Enabled = false;
            btnSearchProf.HighEmphasis = true;
            btnSearchProf.Icon = (Image)resources.GetObject("btnSearchProf.Icon");
            btnSearchProf.Location = new Point(485, 99);
            btnSearchProf.Margin = new Padding(4, 6, 4, 6);
            btnSearchProf.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearchProf.Name = "btnSearchProf";
            btnSearchProf.NoAccentTextColor = Color.Empty;
            btnSearchProf.Size = new Size(50, 50);
            btnSearchProf.TabIndex = 12;
            btnSearchProf.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearchProf.UseAccentColor = false;
            btnSearchProf.UseVisualStyleBackColor = true;
            // 
            // cbxEspecialidad
            // 
            cbxEspecialidad.AutoResize = false;
            cbxEspecialidad.BackColor = Color.FromArgb(255, 255, 255);
            cbxEspecialidad.Depth = 0;
            cbxEspecialidad.DrawMode = DrawMode.OwnerDrawVariable;
            cbxEspecialidad.DropDownHeight = 174;
            cbxEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEspecialidad.DropDownWidth = 121;
            cbxEspecialidad.Enabled = false;
            cbxEspecialidad.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbxEspecialidad.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxEspecialidad.FormattingEnabled = true;
            cbxEspecialidad.IntegralHeight = false;
            cbxEspecialidad.ItemHeight = 43;
            cbxEspecialidad.Location = new Point(222, 44);
            cbxEspecialidad.MaxDropDownItems = 4;
            cbxEspecialidad.MouseState = MaterialSkin.MouseState.OUT;
            cbxEspecialidad.Name = "cbxEspecialidad";
            cbxEspecialidad.Size = new Size(256, 49);
            cbxEspecialidad.StartIndex = 0;
            cbxEspecialidad.TabIndex = 10;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Depth = 0;
            lblEspecialidad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEspecialidad.Location = new Point(28, 74);
            lblEspecialidad.MouseState = MaterialSkin.MouseState.HOVER;
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(91, 19);
            lblEspecialidad.TabIndex = 4;
            lblEspecialidad.Text = "Especialidad";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnSearchTurno);
            groupBox4.Controls.Add(dtpFechaHasta);
            groupBox4.Controls.Add(lblHasta);
            groupBox4.Controls.Add(dtpFechaDesde);
            groupBox4.Controls.Add(lblDesde);
            groupBox4.Controls.Add(dgvTurnos);
            groupBox4.Font = new Font("Segoe UI", 14F);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(455, 608);
            groupBox4.TabIndex = 39;
            groupBox4.TabStop = false;
            groupBox4.Text = "Turnos";
            // 
            // btnSearchTurno
            // 
            btnSearchTurno.AutoSize = false;
            btnSearchTurno.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearchTurno.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearchTurno.Depth = 0;
            btnSearchTurno.HighEmphasis = true;
            btnSearchTurno.Icon = (Image)resources.GetObject("btnSearchTurno.Icon");
            btnSearchTurno.Location = new Point(365, 155);
            btnSearchTurno.Margin = new Padding(4, 6, 4, 6);
            btnSearchTurno.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearchTurno.Name = "btnSearchTurno";
            btnSearchTurno.NoAccentTextColor = Color.Empty;
            btnSearchTurno.Size = new Size(50, 50);
            btnSearchTurno.TabIndex = 24;
            btnSearchTurno.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearchTurno.UseAccentColor = false;
            btnSearchTurno.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.CalendarFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFechaHasta.CustomFormat = "dd.MM.yyyy - HH:mm'hs'";
            dtpFechaHasta.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFechaHasta.Format = DateTimePickerFormat.Custom;
            dtpFechaHasta.Location = new Point(228, 123);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(187, 26);
            dtpFechaHasta.TabIndex = 19;
            dtpFechaHasta.Value = new DateTime(2024, 10, 31, 16, 48, 38, 0);
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Depth = 0;
            lblHasta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblHasta.Location = new Point(30, 130);
            lblHasta.MouseState = MaterialSkin.MouseState.HOVER;
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(90, 19);
            lblHasta.TabIndex = 18;
            lblHasta.Text = "Fecha Hasta";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.CalendarFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFechaDesde.CustomFormat = "dd.MM.yyyy - HH:mm'hs'";
            dtpFechaDesde.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpFechaDesde.Format = DateTimePickerFormat.Custom;
            dtpFechaDesde.Location = new Point(228, 75);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(187, 26);
            dtpFechaDesde.TabIndex = 17;
            dtpFechaDesde.Value = new DateTime(2024, 10, 31, 16, 48, 38, 0);
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Depth = 0;
            lblDesde.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDesde.Location = new Point(30, 82);
            lblDesde.MouseState = MaterialSkin.MouseState.HOVER;
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(92, 19);
            lblDesde.TabIndex = 16;
            lblDesde.Text = "Fecha Desde";
            // 
            // dgvTurnos
            // 
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AllowUserToOrderColumns = true;
            dgvTurnos.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTurnos.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTurnos.GridColor = SystemColors.ScrollBar;
            dgvTurnos.Location = new Point(30, 213);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = true;
            dgvTurnos.Size = new Size(385, 361);
            dgvTurnos.TabIndex = 0;
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
            btnEliminar.Location = new Point(711, 629);
            btnEliminar.Margin = new Padding(4, 6, 4, 6);
            btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.NoAccentTextColor = Color.Empty;
            btnEliminar.Size = new Size(157, 36);
            btnEliminar.TabIndex = 42;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEliminar.UseAccentColor = false;
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // ModifyTurnoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 730);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ModifyTurnoForm";
            Text = "ModifyTurnoForm";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private DateTimePicker dtpFechaHoraTurno;
        private MaterialSkin.Controls.MaterialLabel lblFechaTurno;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel lblNroDoc;
        private MaterialSkin.Controls.MaterialTextBox txtNroDoc;
        private MaterialSkin.Controls.MaterialComboBox cbxTipoDocumento;
        private MaterialSkin.Controls.MaterialTextBox txtApellidoPac;
        private MaterialSkin.Controls.MaterialTextBox txtNombrePac;
        private MaterialSkin.Controls.MaterialLabel lblNombrePac;
        private MaterialSkin.Controls.MaterialButton btnSearchPac;
        private MaterialSkin.Controls.MaterialLabel lblPaciente;
        private MaterialSkin.Controls.MaterialLabel lblApellidoPac;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel lblApellidoProf;
        private MaterialSkin.Controls.MaterialLabel lblNombreProf;
        private MaterialSkin.Controls.MaterialTextBox txtApellidoProf;
        private MaterialSkin.Controls.MaterialTextBox txtNombreProf;
        private MaterialSkin.Controls.MaterialButton btnSearchProf;
        private MaterialSkin.Controls.MaterialComboBox cbxEspecialidad;
        private MaterialSkin.Controls.MaterialLabel lblEspecialidad;
        private GroupBox groupBox4;
        private MaterialSkin.Controls.MaterialButton btnSearchTurno;
        private DateTimePicker dtpFechaHasta;
        private MaterialSkin.Controls.MaterialLabel lblHasta;
        private DateTimePicker dtpFechaDesde;
        private MaterialSkin.Controls.MaterialLabel lblDesde;
        private DataGridView dgvTurnos;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
    }
}