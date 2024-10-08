namespace UI.NonProfessional
{
    partial class NonProfessionalLayoutForm
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
            TabCtrlMain = new MaterialSkin.Controls.MaterialTabControl();
            SuspendLayout();
            // 
            // TabCtrlMain
            // 
            TabCtrlMain.Depth = 0;
            TabCtrlMain.Dock = DockStyle.Fill;
            TabCtrlMain.Location = new Point(3, 64);
            TabCtrlMain.MouseState = MaterialSkin.MouseState.HOVER;
            TabCtrlMain.Multiline = true;
            TabCtrlMain.Name = "TabCtrlMain";
            TabCtrlMain.SelectedIndex = 0;
            TabCtrlMain.Size = new Size(1018, 701);
            TabCtrlMain.TabIndex = 0;
            // 
            // NonProfessionalLayoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(TabCtrlMain);
            DrawerTabControl = TabCtrlMain;
            Name = "NonProfessionalLayoutForm";
            Load += NonProfessionalLayoutForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabCtrlMain;
    }
}