namespace UI.Generic
{
    partial class UsuariosForm
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
            tbcUsuarios = new TabControl();
            SuspendLayout();
            // 
            // tbcUsuarios
            // 
            tbcUsuarios.Dock = DockStyle.Fill;
            tbcUsuarios.Location = new Point(0, 0);
            tbcUsuarios.Name = "tbcUsuarios";
            tbcUsuarios.SelectedIndex = 0;
            tbcUsuarios.Size = new Size(1018, 701);
            tbcUsuarios.TabIndex = 0;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 701);
            Controls.Add(tbcUsuarios);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Usuarios";
            Text = "Usuarios";
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcUsuarios;
    }
}