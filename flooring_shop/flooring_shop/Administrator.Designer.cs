
namespace flooring_shop
{
    partial class Administrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrator));
            this.AdminUsersBtn = new System.Windows.Forms.Button();
            this.AdminWordBtn = new System.Windows.Forms.Button();
            this.AdminForms = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdminName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AdminUsersBtn
            // 
            this.AdminUsersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminUsersBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.AdminUsersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdminUsersBtn.Location = new System.Drawing.Point(12, 132);
            this.AdminUsersBtn.Name = "AdminUsersBtn";
            this.AdminUsersBtn.Size = new System.Drawing.Size(454, 64);
            this.AdminUsersBtn.TabIndex = 1;
            this.AdminUsersBtn.Text = "Пользователи";
            this.AdminUsersBtn.UseVisualStyleBackColor = false;
            this.AdminUsersBtn.Click += new System.EventHandler(this.AdminUsersBtn_Click);
            // 
            // AdminWordBtn
            // 
            this.AdminWordBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminWordBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.AdminWordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdminWordBtn.Location = new System.Drawing.Point(12, 212);
            this.AdminWordBtn.Name = "AdminWordBtn";
            this.AdminWordBtn.Size = new System.Drawing.Size(454, 64);
            this.AdminWordBtn.TabIndex = 2;
            this.AdminWordBtn.Text = "Сформировать отчет";
            this.AdminWordBtn.UseVisualStyleBackColor = false;
            this.AdminWordBtn.Click += new System.EventHandler(this.AdminWordBtn_Click);
            // 
            // AdminForms
            // 
            this.AdminForms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminForms.AutoSize = true;
            this.AdminForms.Location = new System.Drawing.Point(12, 96);
            this.AdminForms.Name = "AdminForms";
            this.AdminForms.Size = new System.Drawing.Size(135, 23);
            this.AdminForms.TabIndex = 3;
            this.AdminForms.Text = "Выбор действий";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выбор действий";
            // 
            // AdminName
            // 
            this.AdminName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminName.AutoSize = true;
            this.AdminName.Location = new System.Drawing.Point(12, 41);
            this.AdminName.Name = "AdminName";
            this.AdminName.Size = new System.Drawing.Size(143, 23);
            this.AdminName.TabIndex = 4;
            this.AdminName.Text = "Администратор -";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(12, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(454, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "Настройки";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(481, 404);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AdminName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdminForms);
            this.Controls.Add(this.AdminWordBtn);
            this.Controls.Add(this.AdminUsersBtn);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Administrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Administrator_FormClosing);
            this.Load += new System.EventHandler(this.Administrator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AdminUsersBtn;
        private System.Windows.Forms.Button AdminWordBtn;
        private System.Windows.Forms.Label AdminForms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AdminName;
        private System.Windows.Forms.Button button1;
    }
}