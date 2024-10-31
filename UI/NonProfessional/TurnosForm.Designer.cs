namespace UI.NonProfessional
{
    partial class TurnosForm
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
            tbcTurnos = new TabControl();
            SuspendLayout();
            // 
            // tbcTurnos
            // 
            tbcTurnos.Dock = DockStyle.Fill;
            tbcTurnos.Location = new Point(0, 0);
            tbcTurnos.Name = "tbcTurnos";
            tbcTurnos.SelectedIndex = 0;
            tbcTurnos.Size = new Size(1018, 701);
            tbcTurnos.TabIndex = 0;
            // 
            // TurnosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 701);
            Controls.Add(tbcTurnos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TurnosForm";
            Text = "TurnosForm";
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcTurnos;
    }
}