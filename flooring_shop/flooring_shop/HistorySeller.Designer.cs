
namespace flooring_shop
{
    partial class HistorySeller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorySeller));
            this.DGVHistoryOrder = new System.Windows.Forms.DataGridView();
            this.CheckOrderBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CloseProdIsOr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistoryOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVHistoryOrder
            // 
            this.DGVHistoryOrder.AllowUserToAddRows = false;
            this.DGVHistoryOrder.AllowUserToDeleteRows = false;
            this.DGVHistoryOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVHistoryOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVHistoryOrder.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVHistoryOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistoryOrder.Location = new System.Drawing.Point(0, 0);
            this.DGVHistoryOrder.Name = "DGVHistoryOrder";
            this.DGVHistoryOrder.ReadOnly = true;
            this.DGVHistoryOrder.RowHeadersWidth = 51;
            this.DGVHistoryOrder.RowTemplate.Height = 30;
            this.DGVHistoryOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVHistoryOrder.Size = new System.Drawing.Size(882, 287);
            this.DGVHistoryOrder.TabIndex = 0;
            // 
            // CheckOrderBtn
            // 
            this.CheckOrderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckOrderBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.CheckOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckOrderBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckOrderBtn.Location = new System.Drawing.Point(224, 317);
            this.CheckOrderBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckOrderBtn.Name = "CheckOrderBtn";
            this.CheckOrderBtn.Size = new System.Drawing.Size(200, 100);
            this.CheckOrderBtn.TabIndex = 6;
            this.CheckOrderBtn.Text = "Создать чек";
            this.CheckOrderBtn.UseVisualStyleBackColor = false;
            this.CheckOrderBtn.Click += new System.EventHandler(this.CheckOrderBtn_Click_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(442, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 100);
            this.button1.TabIndex = 8;
            this.button1.Text = "Перейти к товарам";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CloseProdIsOr
            // 
            this.CloseProdIsOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseProdIsOr.BackColor = System.Drawing.Color.PeachPuff;
            this.CloseProdIsOr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseProdIsOr.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseProdIsOr.Location = new System.Drawing.Point(12, 317);
            this.CloseProdIsOr.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CloseProdIsOr.Name = "CloseProdIsOr";
            this.CloseProdIsOr.Size = new System.Drawing.Size(200, 100);
            this.CloseProdIsOr.TabIndex = 9;
            this.CloseProdIsOr.Text = "Вернуть товар";
            this.CloseProdIsOr.UseVisualStyleBackColor = false;
            this.CloseProdIsOr.Click += new System.EventHandler(this.CloseProdIsOr_Click);
            // 
            // HistorySeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(880, 429);
            this.Controls.Add(this.CloseProdIsOr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckOrderBtn);
            this.Controls.Add(this.DGVHistoryOrder);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HistorySeller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История заказов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HistorySeller_FormClosed_1);
            this.Load += new System.EventHandler(this.HistorySeller_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistoryOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVHistoryOrder;
        private System.Windows.Forms.Button CheckOrderBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CloseProdIsOr;
    }
}