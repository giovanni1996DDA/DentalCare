namespace UI.Perofessional_layout
{
    partial class ProfessionalLayoutForm
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
            tbcProfessionalPanel = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tbcProfessionalPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tbcProfessionalPanel
            // 
            tbcProfessionalPanel.Controls.Add(tabPage1);
            tbcProfessionalPanel.Controls.Add(tabPage2);
            tbcProfessionalPanel.Depth = 0;
            tbcProfessionalPanel.Dock = DockStyle.Fill;
            tbcProfessionalPanel.Location = new Point(3, 64);
            tbcProfessionalPanel.MouseState = MaterialSkin.MouseState.HOVER;
            tbcProfessionalPanel.Multiline = true;
            tbcProfessionalPanel.Name = "tbcProfessionalPanel";
            tbcProfessionalPanel.RightToLeft = RightToLeft.No;
            tbcProfessionalPanel.SelectedIndex = 0;
            tbcProfessionalPanel.Size = new Size(1018, 701);
            tbcProfessionalPanel.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1010, 673);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1010, 673);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ProfessionalLayoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(tbcProfessionalPanel);
            DrawerTabControl = tbcProfessionalPanel;
            Name = "ProfessionalLayoutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bienvenido ";
            Load += ProfessionalLayoutForm_Load;
            tbcProfessionalPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tbcProfessionalPanel;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}