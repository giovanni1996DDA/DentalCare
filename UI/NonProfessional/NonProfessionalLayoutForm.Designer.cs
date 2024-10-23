using Services.Domain;
using Services.Facade;
using UI.Exceptions;

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
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
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
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.BackColor = SystemColors.MenuHighlight;
            materialButton1.BackgroundImageLayout = ImageLayout.None;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(985, 27);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(37, 36);
            materialButton1.TabIndex = 1;
            materialButton1.Text = "materialButton1";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = false;
            // 
            // NonProfessionalLayoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(materialButton1);
            Controls.Add(TabCtrlMain);
            DrawerTabControl = TabCtrlMain;
            Name = "NonProfessionalLayoutForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabCtrlMain;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}