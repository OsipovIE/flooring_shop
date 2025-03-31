
namespace flooring_shop
{
    partial class AdminUsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUsersForm));
            this.DGVUsers = new System.Windows.Forms.DataGridView();
            this.EditUserBtn = new System.Windows.Forms.Button();
            this.DeleteUserBtn = new System.Windows.Forms.Button();
            this.AddUserBtn = new System.Windows.Forms.Button();
            this.Users = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVUsers
            // 
            this.DGVUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUsers.Location = new System.Drawing.Point(12, 43);
            this.DGVUsers.Name = "DGVUsers";
            this.DGVUsers.RowHeadersWidth = 51;
            this.DGVUsers.Size = new System.Drawing.Size(541, 264);
            this.DGVUsers.TabIndex = 0;
            // 
            // EditUserBtn
            // 
            this.EditUserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditUserBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.EditUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditUserBtn.Location = new System.Drawing.Point(379, 326);
            this.EditUserBtn.Name = "EditUserBtn";
            this.EditUserBtn.Size = new System.Drawing.Size(174, 69);
            this.EditUserBtn.TabIndex = 1;
            this.EditUserBtn.Text = "Изменить";
            this.EditUserBtn.UseVisualStyleBackColor = false;
            this.EditUserBtn.Click += new System.EventHandler(this.EditUserBtn_Click_1);
            // 
            // DeleteUserBtn
            // 
            this.DeleteUserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteUserBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.DeleteUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteUserBtn.Location = new System.Drawing.Point(185, 326);
            this.DeleteUserBtn.Name = "DeleteUserBtn";
            this.DeleteUserBtn.Size = new System.Drawing.Size(174, 69);
            this.DeleteUserBtn.TabIndex = 2;
            this.DeleteUserBtn.Text = "Удалить";
            this.DeleteUserBtn.UseVisualStyleBackColor = false;
            this.DeleteUserBtn.Click += new System.EventHandler(this.DeleteUserBtn_Click_1);
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddUserBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.AddUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddUserBtn.Location = new System.Drawing.Point(12, 326);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(152, 69);
            this.AddUserBtn.TabIndex = 3;
            this.AddUserBtn.Text = "Добавить";
            this.AddUserBtn.UseVisualStyleBackColor = false;
            this.AddUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click_1);
            // 
            // Users
            // 
            this.Users.AutoSize = true;
            this.Users.Location = new System.Drawing.Point(12, 9);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(120, 23);
            this.Users.TabIndex = 4;
            this.Users.Text = "Пользователи";
            // 
            // AdminUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(565, 407);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.AddUserBtn);
            this.Controls.Add(this.DeleteUserBtn);
            this.Controls.Add(this.EditUserBtn);
            this.Controls.Add(this.DGVUsers);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AdminUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminUsersForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVUsers;
        private System.Windows.Forms.Button EditUserBtn;
        private System.Windows.Forms.Button DeleteUserBtn;
        private System.Windows.Forms.Button AddUserBtn;
        private System.Windows.Forms.Label Users;
    }
}