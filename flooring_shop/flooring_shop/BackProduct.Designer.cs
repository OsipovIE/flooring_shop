namespace flooring_shop
{
    partial class BackProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackProduct));
            this.BackOrderproduct = new System.Windows.Forms.Button();
            this.BackProdDataGridView = new System.Windows.Forms.DataGridView();
            this.BackToHistoryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BackProdDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackOrderproduct
            // 
            this.BackOrderproduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackOrderproduct.BackColor = System.Drawing.Color.PeachPuff;
            this.BackOrderproduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackOrderproduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackOrderproduct.Location = new System.Drawing.Point(241, 381);
            this.BackOrderproduct.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.BackOrderproduct.Name = "BackOrderproduct";
            this.BackOrderproduct.Size = new System.Drawing.Size(200, 100);
            this.BackOrderproduct.TabIndex = 11;
            this.BackOrderproduct.Text = "Вернуть заказ";
            this.BackOrderproduct.UseVisualStyleBackColor = false;
            this.BackOrderproduct.Click += new System.EventHandler(this.BackOrderproduct_Click);
            // 
            // BackProdDataGridView
            // 
            this.BackProdDataGridView.AllowUserToDeleteRows = false;
            this.BackProdDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackProdDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackProdDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.BackProdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BackProdDataGridView.Location = new System.Drawing.Point(1, -3);
            this.BackProdDataGridView.Name = "BackProdDataGridView";
            this.BackProdDataGridView.RowHeadersWidth = 51;
            this.BackProdDataGridView.RowTemplate.Height = 30;
            this.BackProdDataGridView.Size = new System.Drawing.Size(718, 344);
            this.BackProdDataGridView.TabIndex = 9;
            // 
            // BackToHistoryBtn
            // 
            this.BackToHistoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackToHistoryBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.BackToHistoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackToHistoryBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackToHistoryBtn.Location = new System.Drawing.Point(29, 381);
            this.BackToHistoryBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.BackToHistoryBtn.Name = "BackToHistoryBtn";
            this.BackToHistoryBtn.Size = new System.Drawing.Size(200, 100);
            this.BackToHistoryBtn.TabIndex = 8;
            this.BackToHistoryBtn.Text = "Вернуться к истории";
            this.BackToHistoryBtn.UseVisualStyleBackColor = false;
            this.BackToHistoryBtn.Click += new System.EventHandler(this.BackToHistoryBtn_Click);
            // 
            // BackProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(717, 513);
            this.ControlBox = false;
            this.Controls.Add(this.BackOrderproduct);
            this.Controls.Add(this.BackProdDataGridView);
            this.Controls.Add(this.BackToHistoryBtn);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BackProduct";
            this.Text = "Возврат товара";
            ((System.ComponentModel.ISupportInitialize)(this.BackProdDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackOrderproduct;
        private System.Windows.Forms.DataGridView BackProdDataGridView;
        private System.Windows.Forms.Button BackToHistoryBtn;
    }
}