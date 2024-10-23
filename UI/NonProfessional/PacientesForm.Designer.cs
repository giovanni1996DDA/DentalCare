using Services.Domain;
using Services.Facade;
using UI.Enums;

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
            SuspendLayout();
            // 
            // TabCtrlPacientes
            // 
            TabCtrlPacientes.Dock = DockStyle.Fill;
            TabCtrlPacientes.Location = new Point(0, 0);
            TabCtrlPacientes.Name = "TabCtrlPacientes";
            TabCtrlPacientes.SelectedIndex = 0;
            TabCtrlPacientes.Size = new Size(1018, 701);
            TabCtrlPacientes.TabIndex = 0;
            // 
            // PacientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 701);
            Controls.Add(TabCtrlPacientes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PacientesForm";
            Text = "PacienteForm";
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabCtrlPacientes;
    }
}