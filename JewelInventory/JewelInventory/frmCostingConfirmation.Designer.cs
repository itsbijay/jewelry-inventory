namespace JewelInventory
{
    partial class frmCostingConfirmation
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCostingSheet = new System.Windows.Forms.Button();
            this.btnPrintSticker = new System.Windows.Forms.Button();
            this.btnPrintTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(368, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCostingSheet
            // 
            this.btnCostingSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCostingSheet.Location = new System.Drawing.Point(275, 152);
            this.btnCostingSheet.Name = "btnCostingSheet";
            this.btnCostingSheet.Size = new System.Drawing.Size(87, 23);
            this.btnCostingSheet.TabIndex = 7;
            this.btnCostingSheet.Text = "Costing Sheet";
            this.btnCostingSheet.UseVisualStyleBackColor = true;
            // 
            // btnPrintSticker
            // 
            this.btnPrintSticker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSticker.Location = new System.Drawing.Point(182, 152);
            this.btnPrintSticker.Name = "btnPrintSticker";
            this.btnPrintSticker.Size = new System.Drawing.Size(87, 23);
            this.btnPrintSticker.TabIndex = 6;
            this.btnPrintSticker.Text = "Print Sticker";
            this.btnPrintSticker.UseVisualStyleBackColor = true;
            // 
            // btnPrintTag
            // 
            this.btnPrintTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTag.Location = new System.Drawing.Point(89, 152);
            this.btnPrintTag.Name = "btnPrintTag";
            this.btnPrintTag.Size = new System.Drawing.Size(87, 23);
            this.btnPrintTag.TabIndex = 4;
            this.btnPrintTag.Text = "Print Tag";
            this.btnPrintTag.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Items Saved Successfuly";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCostingConfirmation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 376);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCostingSheet);
            this.Controls.Add(this.btnPrintSticker);
            this.Controls.Add(this.btnPrintTag);
            this.Controls.Add(this.label1);
            this.Name = "frmCostingConfirmation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmConstingConfirmation";
            this.Load += new System.EventHandler(this.frmContingConfirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCostingSheet;
        private System.Windows.Forms.Button btnPrintSticker;
        private System.Windows.Forms.Button btnPrintTag;
        private System.Windows.Forms.Label label1;

    }
}