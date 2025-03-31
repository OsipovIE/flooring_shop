namespace flooring_shop
{
    partial class DeleteProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteProductForm));
            this.DGVCMMSpecProd = new System.Windows.Forms.DataGridView();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.CmbFilter = new System.Windows.Forms.ComboBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCMMSpecProd)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCMMSpecProd
            // 
            this.DGVCMMSpecProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCMMSpecProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCMMSpecProd.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVCMMSpecProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCMMSpecProd.Location = new System.Drawing.Point(12, 54);
            this.DGVCMMSpecProd.Name = "DGVCMMSpecProd";
            this.DGVCMMSpecProd.RowHeadersWidth = 51;
            this.DGVCMMSpecProd.RowTemplate.Height = 30;
            this.DGVCMMSpecProd.Size = new System.Drawing.Size(773, 325);
            this.DGVCMMSpecProd.TabIndex = 101;
            this.DGVCMMSpecProd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCMMSpecProd_CellContentClick);
            // 
            // CmbSort
            // 
            this.CmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSort.ForeColor = System.Drawing.SystemColors.InfoText;
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Location = new System.Drawing.Point(326, 12);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(231, 36);
            this.CmbSort.TabIndex = 104;
            // 
            // CmbFilter
            // 
            this.CmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilter.ForeColor = System.Drawing.SystemColors.InfoText;
            this.CmbFilter.FormattingEnabled = true;
            this.CmbFilter.Location = new System.Drawing.Point(563, 12);
            this.CmbFilter.Name = "CmbFilter";
            this.CmbFilter.Size = new System.Drawing.Size(222, 36);
            this.CmbFilter.TabIndex = 103;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSearch.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TxtSearch.Location = new System.Drawing.Point(15, 12);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(305, 35);
            this.TxtSearch.TabIndex = 102;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.PeachPuff;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(12, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(210, 65);
            this.btnDelete.TabIndex = 105;
            this.btnDelete.Text = "Удалить товар";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // DeleteProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(797, 463);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.CmbSort);
            this.Controls.Add(this.CmbFilter);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.DGVCMMSpecProd);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(815, 510);
            this.Name = "DeleteProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление товара";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeleteProductForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCMMSpecProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVCMMSpecProd;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.ComboBox CmbFilter;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button btnDelete;
    }
}