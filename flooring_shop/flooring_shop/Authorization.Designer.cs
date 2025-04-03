
namespace flooring_shop
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.LoginIn = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.Logintxt = new System.Windows.Forms.TextBox();
            this.Pwdtxt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EyeBtn = new System.Windows.Forms.Label();
            this.captchaTextBox = new System.Windows.Forms.TextBox();
            this.refreshCapthaButton = new System.Windows.Forms.Button();
            this.CaptchaPanel = new System.Windows.Forms.Panel();
            this.СaptchaLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CaptchaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginIn
            // 
            this.LoginIn.BackColor = System.Drawing.Color.PeachPuff;
            this.LoginIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginIn.Location = new System.Drawing.Point(12, 213);
            this.LoginIn.Name = "LoginIn";
            this.LoginIn.Size = new System.Drawing.Size(317, 64);
            this.LoginIn.TabIndex = 3;
            this.LoginIn.Text = "Войти";
            this.LoginIn.UseVisualStyleBackColor = false;
            this.LoginIn.Click += new System.EventHandler(this.LoginIn_Click);
            // 
            // Login
            // 
            this.Login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Login.AutoSize = true;
            this.Login.Location = new System.Drawing.Point(12, 54);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(58, 23);
            this.Login.TabIndex = 1;
            this.Login.Text = "Логин";
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(12, 128);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(69, 23);
            this.Password.TabIndex = 2;
            this.Password.Text = "Пароль";
            // 
            // Logintxt
            // 
            this.Logintxt.Location = new System.Drawing.Point(12, 80);
            this.Logintxt.Name = "Logintxt";
            this.Logintxt.Size = new System.Drawing.Size(317, 30);
            this.Logintxt.TabIndex = 1;
            this.Logintxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Logintxt_KeyPress);
            // 
            // Pwdtxt
            // 
            this.Pwdtxt.Location = new System.Drawing.Point(12, 154);
            this.Pwdtxt.Name = "Pwdtxt";
            this.Pwdtxt.Size = new System.Drawing.Size(283, 30);
            this.Pwdtxt.TabIndex = 2;
            this.Pwdtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pwdtxt_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 283);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(646, 101);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // EyeBtn
            // 
            this.EyeBtn.AutoSize = true;
            this.EyeBtn.Location = new System.Drawing.Point(301, 157);
            this.EyeBtn.Name = "EyeBtn";
            this.EyeBtn.Size = new System.Drawing.Size(32, 23);
            this.EyeBtn.TabIndex = 7;
            this.EyeBtn.Text = "👁";
            this.EyeBtn.Click += new System.EventHandler(this.EyeBtn_Click);
            // 
            // captchaTextBox
            // 
            this.captchaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.captchaTextBox.Location = new System.Drawing.Point(339, 154);
            this.captchaTextBox.Name = "captchaTextBox";
            this.captchaTextBox.Size = new System.Drawing.Size(316, 30);
            this.captchaTextBox.TabIndex = 8;
            // 
            // refreshCapthaButton
            // 
            this.refreshCapthaButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshCapthaButton.BackColor = System.Drawing.Color.PeachPuff;
            this.refreshCapthaButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshCapthaButton.Location = new System.Drawing.Point(338, 213);
            this.refreshCapthaButton.Name = "refreshCapthaButton";
            this.refreshCapthaButton.Size = new System.Drawing.Size(157, 64);
            this.refreshCapthaButton.TabIndex = 9;
            this.refreshCapthaButton.Text = "Новая CAPTCHA";
            this.refreshCapthaButton.UseVisualStyleBackColor = false;
            this.refreshCapthaButton.Click += new System.EventHandler(this.refreshCapthaButton_Click);
            // 
            // CaptchaPanel
            // 
            this.CaptchaPanel.Controls.Add(this.СaptchaLabel);
            this.CaptchaPanel.Location = new System.Drawing.Point(339, 51);
            this.CaptchaPanel.Name = "CaptchaPanel";
            this.CaptchaPanel.Size = new System.Drawing.Size(200, 100);
            this.CaptchaPanel.TabIndex = 11;
            // 
            // СaptchaLabel
            // 
            this.СaptchaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.СaptchaLabel.AutoSize = true;
            this.СaptchaLabel.Location = new System.Drawing.Point(54, 36);
            this.СaptchaLabel.Name = "СaptchaLabel";
            this.СaptchaLabel.Size = new System.Drawing.Size(0, 23);
            this.СaptchaLabel.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Авторизация";
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(667, 396);
            this.Controls.Add(this.CaptchaPanel);
            this.Controls.Add(this.refreshCapthaButton);
            this.Controls.Add(this.captchaTextBox);
            this.Controls.Add(this.EyeBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Pwdtxt);
            this.Controls.Add(this.Logintxt);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.LoginIn);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1240, 511);
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Authorization_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CaptchaPanel.ResumeLayout(false);
            this.CaptchaPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginIn;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox Logintxt;
        private System.Windows.Forms.TextBox Pwdtxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label EyeBtn;
        private System.Windows.Forms.TextBox captchaTextBox;
        private System.Windows.Forms.Button refreshCapthaButton;
        private System.Windows.Forms.Panel CaptchaPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label СaptchaLabel;
    }
}