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
            TabCtrlPacientes = new TabControl();
            Create = new TabPage();
            Modify = new TabPage();
            Visualize = new TabPage();
            TabCtrlPacientes.SuspendLayout();
            SuspendLayout();
            // 
            // TabCtrlPacientes
            // 
            TabCtrlPacientes.Controls.Add(Create);
            TabCtrlPacientes.Controls.Add(Modify);
            TabCtrlPacientes.Controls.Add(Visualize);
            TabCtrlPacientes.Dock = DockStyle.Fill;
            TabCtrlPacientes.Location = new Point(0, 0);
            TabCtrlPacientes.Name = "TabCtrlPacientes";
            TabCtrlPacientes.SelectedIndex = 0;
            TabCtrlPacientes.Size = new Size(800, 450);
            TabCtrlPacientes.TabIndex = 0;
            // 
            // Create
            // 
            Create.Location = new Point(4, 24);
            Create.Name = "Create";
            Create.Padding = new Padding(3);
            Create.Size = new Size(792, 422);
            Create.TabIndex = 0;
            Create.Text = "Crear";
            Create.UseVisualStyleBackColor = true;
            // 
            // Modify
            // 
            Modify.Location = new Point(4, 24);
            Modify.Name = "Modify";
            Modify.Padding = new Padding(3);
            Modify.Size = new Size(792, 422);
            Modify.TabIndex = 1;
            Modify.Text = "Modificar";
            Modify.UseVisualStyleBackColor = true;
            // 
            // Visualize
            // 
            Visualize.Location = new Point(4, 24);
            Visualize.Name = "Visualize";
            Visualize.Size = new Size(792, 422);
            Visualize.TabIndex = 2;
            Visualize.Text = "Visualizar";
            Visualize.UseVisualStyleBackColor = true;
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

        private TabControl TabCtrlPacientes;
        private TabPage Create;
        private TabPage Modify;
        private TabPage Visualize;
    }
}