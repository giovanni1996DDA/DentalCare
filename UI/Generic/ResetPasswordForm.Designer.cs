namespace UI.Generic
{
    partial class ResetPasswordForm
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
            lchShowPassword = new MaterialSkin.Controls.MaterialLabel();
            chkShowPassword = new MaterialSkin.Controls.MaterialCheckbox();
            lblPassword = new MaterialSkin.Controls.MaterialLabel();
            btnReset = new MaterialSkin.Controls.MaterialButton();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            SuspendLayout();
            // 
            // lchShowPassword
            // 
            lchShowPassword.AutoSize = true;
            lchShowPassword.Depth = 0;
            lchShowPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lchShowPassword.Location = new Point(141, 93);
            lchShowPassword.MouseState = MaterialSkin.MouseState.HOVER;
            lchShowPassword.Name = "lchShowPassword";
            lchShowPassword.Size = new Size(139, 19);
            lchShowPassword.TabIndex = 13;
            lchShowPassword.Text = "Mostrar contraseña";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckAlign = ContentAlignment.MiddleCenter;
            chkShowPassword.Depth = 0;
            chkShowPassword.Location = new Point(283, 84);
            chkShowPassword.Margin = new Padding(0);
            chkShowPassword.MouseLocation = new Point(-1, -1);
            chkShowPassword.MouseState = MaterialSkin.MouseState.HOVER;
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.ReadOnly = false;
            chkShowPassword.RightToLeft = RightToLeft.Yes;
            chkShowPassword.Ripple = true;
            chkShowPassword.Size = new Size(35, 37);
            chkShowPassword.TabIndex = 12;
            chkShowPassword.TextAlign = ContentAlignment.MiddleCenter;
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Depth = 0;
            lblPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPassword.Location = new Point(12, 9);
            lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(129, 19);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Nueva contraseña";
            // 
            // btnReset
            // 
            btnReset.AutoSize = false;
            btnReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnReset.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnReset.Depth = 0;
            btnReset.HighEmphasis = true;
            btnReset.Icon = null;
            btnReset.Location = new Point(12, 155);
            btnReset.Margin = new Padding(4, 6, 4, 6);
            btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            btnReset.Name = "btnReset";
            btnReset.NoAccentTextColor = Color.Empty;
            btnReset.Size = new Size(306, 50);
            btnReset.TabIndex = 10;
            btnReset.Text = "Resetar contraseña";
            btnReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnReset.UseAccentColor = false;
            btnReset.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.AnimateReadOnly = false;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(11, 31);
            txtPassword.MaxLength = 50;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Password = true;
            txtPassword.Size = new Size(306, 50);
            txtPassword.TabIndex = 9;
            txtPassword.Text = "";
            txtPassword.TrailingIcon = null;
            // 
            // RessetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 258);
            Controls.Add(lchShowPassword);
            Controls.Add(chkShowPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnReset);
            Controls.Add(txtPassword);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RessetPasswordForm";
            Text = "RessetPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lchShowPassword;
        private MaterialSkin.Controls.MaterialCheckbox chkShowPassword;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialButton btnReset;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
    }
}