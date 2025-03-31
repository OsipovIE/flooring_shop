
namespace flooring_shop
{
    partial class AdministratorWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministratorWord));
            this.period = new System.Windows.Forms.Label();
            this.PeriodCB = new System.Windows.Forms.ComboBox();
            this.PeriodWordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // period
            // 
            this.period.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.period.AutoSize = true;
            this.period.Location = new System.Drawing.Point(19, 14);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(75, 23);
            this.period.TabIndex = 0;
            this.period.Text = "Период:";
            // 
            // PeriodCB
            // 
            this.PeriodCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeriodCB.FormattingEnabled = true;
            this.PeriodCB.Location = new System.Drawing.Point(23, 40);
            this.PeriodCB.Name = "PeriodCB";
            this.PeriodCB.Size = new System.Drawing.Size(395, 31);
            this.PeriodCB.TabIndex = 1;
            // 
            // PeriodWordBtn
            // 
            this.PeriodWordBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeriodWordBtn.BackColor = System.Drawing.Color.PeachPuff;
            this.PeriodWordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PeriodWordBtn.Location = new System.Drawing.Point(23, 109);
            this.PeriodWordBtn.Name = "PeriodWordBtn";
            this.PeriodWordBtn.Size = new System.Drawing.Size(395, 66);
            this.PeriodWordBtn.TabIndex = 2;
            this.PeriodWordBtn.Text = "Сформировать";
            this.PeriodWordBtn.UseVisualStyleBackColor = false;
            this.PeriodWordBtn.Click += new System.EventHandler(this.PeriodWordBtn_Click_1);
            // 
            // AdministratorWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(430, 187);
            this.Controls.Add(this.PeriodWordBtn);
            this.Controls.Add(this.PeriodCB);
            this.Controls.Add(this.period);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AdministratorWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование отчета о прибыли";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorWord_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label period;
        private System.Windows.Forms.ComboBox PeriodCB;
        private System.Windows.Forms.Button PeriodWordBtn;
    }
}