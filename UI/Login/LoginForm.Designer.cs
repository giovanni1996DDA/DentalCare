namespace UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtUname = new MaterialSkin.Controls.MaterialTextBox();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            btnLogin = new MaterialSkin.Controls.MaterialButton();
            btnExit = new MaterialSkin.Controls.MaterialButton();
            lblPassword = new MaterialSkin.Controls.MaterialLabel();
            lblUname = new MaterialSkin.Controls.MaterialLabel();
            chkShowPassword = new MaterialSkin.Controls.MaterialCheckbox();
            lchShowPassword = new MaterialSkin.Controls.MaterialLabel();
            imgLoginImg = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgLoginImg).BeginInit();
            SuspendLayout();
            // 
            // txtUname
            // 
            txtUname.AnimateReadOnly = false;
            txtUname.BorderStyle = BorderStyle.None;
            txtUname.Depth = 0;
            txtUname.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUname.LeadingIcon = null;
            txtUname.Location = new Point(50, 264);
            txtUname.MaxLength = 50;
            txtUname.MouseState = MaterialSkin.MouseState.OUT;
            txtUname.Multiline = false;
            txtUname.Name = "txtUname";
            txtUname.Size = new Size(306, 50);
            txtUname.TabIndex = 0;
            txtUname.Text = "";
            txtUname.TrailingIcon = null;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.AnimateReadOnly = false;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(50, 359);
            txtPassword.MaxLength = 50;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Password = true;
            txtPassword.Size = new Size(306, 50);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "";
            txtPassword.TrailingIcon = null;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = false;
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.Location = new Point(50, 483);
            btnLogin.Margin = new Padding(4, 6, 4, 6);
            btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Size = new Size(306, 50);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Ingresar";
            btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.AutoSize = false;
            btnExit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExit.BackColor = SystemColors.ControlDark;
            btnExit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExit.Depth = 0;
            btnExit.HighEmphasis = true;
            btnExit.Icon = null;
            btnExit.Location = new Point(50, 545);
            btnExit.Margin = new Padding(4, 6, 4, 6);
            btnExit.MouseState = MaterialSkin.MouseState.HOVER;
            btnExit.Name = "btnExit";
            btnExit.NoAccentTextColor = Color.Empty;
            btnExit.Size = new Size(306, 50);
            btnExit.TabIndex = 4;
            btnExit.Text = "Salir";
            btnExit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnExit.UseAccentColor = false;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Depth = 0;
            lblPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPassword.Location = new Point(50, 337);
            lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(82, 19);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Contraseña";
            // 
            // lblUname
            // 
            lblUname.AutoSize = true;
            lblUname.Depth = 0;
            lblUname.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUname.ForeColor = SystemColors.ControlLightLight;
            lblUname.Location = new Point(50, 242);
            lblUname.MouseState = MaterialSkin.MouseState.HOVER;
            lblUname.Name = "lblUname";
            lblUname.Size = new Size(55, 19);
            lblUname.TabIndex = 6;
            lblUname.Text = "Usuario";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckAlign = ContentAlignment.MiddleCenter;
            chkShowPassword.Depth = 0;
            chkShowPassword.Location = new Point(321, 412);
            chkShowPassword.Margin = new Padding(0);
            chkShowPassword.MouseLocation = new Point(-1, -1);
            chkShowPassword.MouseState = MaterialSkin.MouseState.HOVER;
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.ReadOnly = false;
            chkShowPassword.RightToLeft = RightToLeft.Yes;
            chkShowPassword.Ripple = true;
            chkShowPassword.Size = new Size(35, 37);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.TextAlign = ContentAlignment.MiddleCenter;
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // lchShowPassword
            // 
            lchShowPassword.AutoSize = true;
            lchShowPassword.Depth = 0;
            lchShowPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lchShowPassword.Location = new Point(179, 421);
            lchShowPassword.MouseState = MaterialSkin.MouseState.HOVER;
            lchShowPassword.Name = "lchShowPassword";
            lchShowPassword.Size = new Size(139, 19);
            lchShowPassword.TabIndex = 8;
            lchShowPassword.Text = "Mostrar contraseña";
            // 
            // imgLoginImg
            // 
            imgLoginImg.Image = (Image)resources.GetObject("imgLoginImg.Image");
            imgLoginImg.Location = new Point(100, 12);
            imgLoginImg.Name = "imgLoginImg";
            imgLoginImg.Size = new Size(200, 200);
            imgLoginImg.SizeMode = PictureBoxSizeMode.Zoom;
            imgLoginImg.TabIndex = 9;
            imgLoginImg.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 631);
            Controls.Add(imgLoginImg);
            Controls.Add(lchShowPassword);
            Controls.Add(chkShowPassword);
            Controls.Add(lblUname);
            Controls.Add(lblPassword);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUname);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)imgLoginImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtUname;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialButton btnExit;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialLabel lblUname;
        private MaterialSkin.Controls.MaterialCheckbox chkShowPassword;
        private MaterialSkin.Controls.MaterialLabel lchShowPassword;
        private PictureBox imgLoginImg;
    }
}