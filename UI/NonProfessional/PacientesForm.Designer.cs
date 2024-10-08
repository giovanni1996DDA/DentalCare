namespace UI.NonProfessional
{
    partial class PacientesForm
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
            TabCtrlPacientes = new MaterialSkin.Controls.MaterialTabControl();
            pgFind = new TabPage();
            pgModify = new TabPage();
            pgCreate = new TabPage();
            TabCtrlPacientes.SuspendLayout();
            SuspendLayout();
            // 
            // TabCtrlPacientes
            // 
            TabCtrlPacientes.Controls.Add(pgFind);
            TabCtrlPacientes.Controls.Add(pgModify);
            TabCtrlPacientes.Controls.Add(pgCreate);
            TabCtrlPacientes.Depth = 0;
            TabCtrlPacientes.Dock = DockStyle.Bottom;
            TabCtrlPacientes.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabCtrlPacientes.Location = new Point(0, 0);
            TabCtrlPacientes.MouseState = MaterialSkin.MouseState.HOVER;
            TabCtrlPacientes.Multiline = true;
            TabCtrlPacientes.Name = "TabCtrlPacientes";
            TabCtrlPacientes.SelectedIndex = 0;
            TabCtrlPacientes.Size = new Size(800, 450);
            TabCtrlPacientes.TabIndex = 1;
            // 
            // pgFind
            // 
            pgFind.Location = new Point(4, 24);
            pgFind.Name = "pgFind";
            pgFind.Size = new Size(792, 422);
            pgFind.TabIndex = 2;
            pgFind.Text = "Buscar";
            pgFind.UseVisualStyleBackColor = true;
            // 
            // pgModify
            // 
            pgModify.Location = new Point(4, 24);
            pgModify.Name = "pgModify";
            pgModify.Padding = new Padding(3);
            pgModify.Size = new Size(792, 422);
            pgModify.TabIndex = 1;
            pgModify.Text = "Modificar";
            pgModify.UseVisualStyleBackColor = true;
            // 
            // pgCreate
            // 
            pgCreate.Location = new Point(4, 24);
            pgCreate.Name = "pgCreate";
            pgCreate.Padding = new Padding(3);
            pgCreate.Size = new Size(792, 422);
            pgCreate.TabIndex = 0;
            pgCreate.Text = "Crear";
            pgCreate.UseVisualStyleBackColor = true;
            // 
            // PacientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TabCtrlPacientes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PacientesForm";
            Text = "PacienteForm";
            TabCtrlPacientes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl TabCtrlPacientes;
        private TabPage pgCreate;
        private TabPage pgModify;
        private TabPage pgFind;
    }
}