
namespace flooring_shop
{
    partial class SellerOrderGo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerOrderGo));
            this.BackToProductsBtn = new System.Windows.Forms.Button();
            this.CartDataGridView = new System.Windows.Forms.DataGridView();
            this.TotalPriceLabel = new System.Windows.Forms.Label();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.DiscountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CartDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackToProductsBtn
            // 
            this.BackToProductsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackToProductsBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.BackToProductsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackToProductsBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackToProductsBtn.Location = new System.Drawing.Point(28, 384);
            this.BackToProductsBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.BackToProductsBtn.Name = "BackToProductsBtn";
            this.BackToProductsBtn.Size = new System.Drawing.Size(200, 100);
            this.BackToProductsBtn.TabIndex = 4;
            this.BackToProductsBtn.Text = "Вернуться к товарам";
            this.BackToProductsBtn.UseVisualStyleBackColor = false;
            this.BackToProductsBtn.Click += new System.EventHandler(this.BackToProductsBtn_Click_1);
            // 
            // CartDataGridView
            // 
            this.CartDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CartDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.CartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CartDataGridView.Location = new System.Drawing.Point(0, 0);
            this.CartDataGridView.Name = "CartDataGridView";
            this.CartDataGridView.RowHeadersWidth = 51;
            this.CartDataGridView.RowTemplate.Height = 30;
            this.CartDataGridView.Size = new System.Drawing.Size(718, 344);
            this.CartDataGridView.TabIndex = 5;
            // 
            // TotalPriceLabel
            // 
            this.TotalPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalPriceLabel.AutoSize = true;
            this.TotalPriceLabel.Location = new System.Drawing.Point(464, 385);
            this.TotalPriceLabel.Name = "TotalPriceLabel";
            this.TotalPriceLabel.Size = new System.Drawing.Size(61, 23);
            this.TotalPriceLabel.TabIndex = 6;
            this.TotalPriceLabel.Text = "Итого:";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConfirmBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConfirmBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfirmBtn.Location = new System.Drawing.Point(240, 384);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(200, 100);
            this.ConfirmBtn.TabIndex = 7;
            this.ConfirmBtn.Text = "Оформить заказ";
            this.ConfirmBtn.UseVisualStyleBackColor = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click_1);
            // 
            // DiscountLabel
            // 
            this.DiscountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DiscountLabel.AutoSize = true;
            this.DiscountLabel.Location = new System.Drawing.Point(464, 408);
            this.DiscountLabel.Name = "DiscountLabel";
            this.DiscountLabel.Size = new System.Drawing.Size(68, 23);
            this.DiscountLabel.TabIndex = 8;
            this.DiscountLabel.Text = "Скидка:";
            // 
            // SellerOrderGo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(717, 513);
            this.ControlBox = false;
            this.Controls.Add(this.DiscountLabel);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.TotalPriceLabel);
            this.Controls.Add(this.CartDataGridView);
            this.Controls.Add(this.BackToProductsBtn);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SellerOrderGo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформить заказ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SellerOrderGo_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.CartDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BackToProductsBtn;
        private System.Windows.Forms.DataGridView CartDataGridView;
        private System.Windows.Forms.Label TotalPriceLabel;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label DiscountLabel;
    }
}