
namespace flooring_shop
{
    partial class CommoditySpecialist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommoditySpecialist));
            this.DGVCMMSpecProd = new System.Windows.Forms.DataGridView();
            this.addProdBtn = new System.Windows.Forms.Button();
            this.deleteProdBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.CmbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCMMSpecProd)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCMMSpecProd
            // 
            this.DGVCMMSpecProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCMMSpecProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCMMSpecProd.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVCMMSpecProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCMMSpecProd.Location = new System.Drawing.Point(12, 91);
            this.DGVCMMSpecProd.Name = "DGVCMMSpecProd";
            this.DGVCMMSpecProd.RowHeadersWidth = 51;
            this.DGVCMMSpecProd.RowTemplate.Height = 30;
            this.DGVCMMSpecProd.Size = new System.Drawing.Size(770, 325);
            this.DGVCMMSpecProd.TabIndex = 100;
            this.DGVCMMSpecProd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCMMSpecProd_CellDoubleClick);
            // 
            // addProdBtn
            // 
            this.addProdBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addProdBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.addProdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addProdBtn.Location = new System.Drawing.Point(12, 434);
            this.addProdBtn.Name = "addProdBtn";
            this.addProdBtn.Size = new System.Drawing.Size(210, 65);
            this.addProdBtn.TabIndex = 2;
            this.addProdBtn.Text = "Добавить товар";
            this.addProdBtn.UseVisualStyleBackColor = false;
            this.addProdBtn.Click += new System.EventHandler(this.addProdBtn_Click);
            // 
            // deleteProdBtn
            // 
            this.deleteProdBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteProdBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.deleteProdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteProdBtn.Location = new System.Drawing.Point(228, 434);
            this.deleteProdBtn.Name = "deleteProdBtn";
            this.deleteProdBtn.Size = new System.Drawing.Size(210, 65);
            this.deleteProdBtn.TabIndex = 3;
            this.deleteProdBtn.Text = "Удалить товар";
            this.deleteProdBtn.UseVisualStyleBackColor = false;
            this.deleteProdBtn.Click += new System.EventHandler(this.deleteProdBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Товаровед - ";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSearch.Location = new System.Drawing.Point(308, 18);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(474, 30);
            this.TxtSearch.TabIndex = 5;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged_1);
            // 
            // CmbSort
            // 
            this.CmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Location = new System.Drawing.Point(307, 54);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(231, 31);
            this.CmbSort.TabIndex = 7;
            this.CmbSort.SelectedIndexChanged += new System.EventHandler(this.CmbSort_SelectedIndexChanged);
            // 
            // CmbFilter
            // 
            this.CmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilter.FormattingEnabled = true;
            this.CmbFilter.Location = new System.Drawing.Point(560, 54);
            this.CmbFilter.Name = "CmbFilter";
            this.CmbFilter.Size = new System.Drawing.Size(222, 31);
            this.CmbFilter.TabIndex = 6;
            this.CmbFilter.SelectedIndexChanged += new System.EventHandler(this.CmbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 101;
            this.label2.Text = "Товары";
            // 
            // CommoditySpecialist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(796, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbSort);
            this.Controls.Add(this.CmbFilter);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteProdBtn);
            this.Controls.Add(this.addProdBtn);
            this.Controls.Add(this.DGVCMMSpecProd);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(812, 558);
            this.Name = "CommoditySpecialist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товаровед";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommoditySpecialist_FormClosed);
            this.Load += new System.EventHandler(this.CommoditySpecialist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCMMSpecProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVCMMSpecProd;
        private System.Windows.Forms.Button addProdBtn;
        private System.Windows.Forms.Button deleteProdBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.ComboBox CmbFilter;
        private System.Windows.Forms.Label label2;
    }
}

