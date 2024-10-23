namespace UI.NonProfessional
{
    partial class ParametrizacionesForm
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
            tabCtrlParametrizaciones = new TabControl();
            SuspendLayout();
            // 
            // tabCtrlParametrizaciones
            // 
            tabCtrlParametrizaciones.Dock = DockStyle.Fill;
            tabCtrlParametrizaciones.Location = new Point(0, 0);
            tabCtrlParametrizaciones.Name = "tabCtrlParametrizaciones";
            tabCtrlParametrizaciones.SelectedIndex = 0;
            tabCtrlParametrizaciones.Size = new Size(1018, 701);
            tabCtrlParametrizaciones.TabIndex = 0;
            // 
            // ParametrizacionesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 701);
            Controls.Add(tabCtrlParametrizaciones);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ParametrizacionesForm";
            Text = "ParametrizacionesForm";
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabCtrlParametrizaciones;
    }
}