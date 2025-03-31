
namespace flooring_shop
{
    partial class SellerOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerOrder));
            this.OrderBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVProdOrderSeller = new System.Windows.Forms.DataGridView();
            this.CmbFilter = new System.Windows.Forms.ComboBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.AddOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProdOrderSeller)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderBtn
            // 
            this.OrderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OrderBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OrderBtn.ForeColor = System.Drawing.Color.Black;
            this.OrderBtn.Location = new System.Drawing.Point(12, 433);
            this.OrderBtn.Name = "OrderBtn";
            this.OrderBtn.Size = new System.Drawing.Size(210, 65);
            this.OrderBtn.TabIndex = 0;
            this.OrderBtn.Text = "Оформить заказ";
            this.OrderBtn.UseVisualStyleBackColor = false;
            this.OrderBtn.Click += new System.EventHandler(this.OrderBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Товары";
            // 
            // DGVProdOrderSeller
            // 
            this.DGVProdOrderSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVProdOrderSeller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProdOrderSeller.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVProdOrderSeller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProdOrderSeller.Location = new System.Drawing.Point(12, 107);
            this.DGVProdOrderSeller.Name = "DGVProdOrderSeller";
            this.DGVProdOrderSeller.RowHeadersWidth = 51;
            this.DGVProdOrderSeller.RowTemplate.Height = 30;
            this.DGVProdOrderSeller.Size = new System.Drawing.Size(770, 315);
            this.DGVProdOrderSeller.TabIndex = 100;
            // 
            // CmbFilter
            // 
            this.CmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilter.FormattingEnabled = true;
            this.CmbFilter.Location = new System.Drawing.Point(560, 62);
            this.CmbFilter.Name = "CmbFilter";
            this.CmbFilter.Size = new System.Drawing.Size(222, 31);
            this.CmbFilter.TabIndex = 3;
            this.CmbFilter.SelectedIndexChanged += new System.EventHandler(this.CmbFilter_SelectedIndexChanged_1);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSearch.Location = new System.Drawing.Point(308, 12);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(474, 30);
            this.TxtSearch.TabIndex = 4;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // CmbSort
            // 
            this.CmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Location = new System.Drawing.Point(307, 62);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(231, 31);
            this.CmbSort.TabIndex = 5;
            this.CmbSort.SelectedIndexChanged += new System.EventHandler(this.CmbSort_SelectedIndexChanged_1);
            // 
            // AddOrder
            // 
            this.AddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddOrder.BackColor = System.Drawing.Color.PeachPuff;
            this.AddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddOrder.ForeColor = System.Drawing.Color.Black;
            this.AddOrder.Location = new System.Drawing.Point(228, 433);
            this.AddOrder.Name = "AddOrder";
            this.AddOrder.Size = new System.Drawing.Size(210, 65);
            this.AddOrder.TabIndex = 6;
            this.AddOrder.Text = "Добавить в заказ";
            this.AddOrder.UseVisualStyleBackColor = false;
            this.AddOrder.Click += new System.EventHandler(this.AddOrder_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(444, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 65);
            this.button1.TabIndex = 7;
            this.button1.Text = "История заказов";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SellerOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(794, 511);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddOrder);
            this.Controls.Add(this.CmbSort);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.CmbFilter);
            this.Controls.Add(this.DGVProdOrderSeller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrderBtn);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(810, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(810, 550);
            this.Name = "SellerOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товары";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SellerOrder_FormClosed);
            this.Load += new System.EventHandler(this.SellerOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProdOrderSeller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OrderBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVProdOrderSeller;
        private System.Windows.Forms.ComboBox CmbFilter;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.Button AddOrder;
        private System.Windows.Forms.Button button1;
    }
}