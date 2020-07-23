namespace JewelInventory
{
    partial class frmJewelStockReport
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
            this.btnShowReport = new System.Windows.Forms.Button();
            this.lblMetalType = new System.Windows.Forms.Label();
            this.cboKT = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStoneType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnShowReport.Location = new System.Drawing.Point(668, 22);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(87, 25);
            this.btnShowReport.TabIndex = 7;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // lblMetalType
            // 
            this.lblMetalType.AutoSize = true;
            this.lblMetalType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMetalType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMetalType.Location = new System.Drawing.Point(13, 33);
            this.lblMetalType.Name = "lblMetalType";
            this.lblMetalType.Size = new System.Drawing.Size(123, 14);
            this.lblMetalType.TabIndex = 8;
            this.lblMetalType.Text = "Select Metal Type :";
            // 
            // cboKT
            // 
            this.cboKT.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cboKT.FormattingEnabled = true;
            this.cboKT.Location = new System.Drawing.Point(157, 26);
            this.cboKT.Name = "cboKT";
            this.cboKT.Size = new System.Drawing.Size(161, 21);
            this.cboKT.TabIndex = 4;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(17, 61);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(871, 548);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ToolPanelWidth = 233;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(339, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select Stone Type :";
            // 
            // cboStoneType
            // 
            this.cboStoneType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cboStoneType.FormattingEnabled = true;
            this.cboStoneType.Location = new System.Drawing.Point(486, 26);
            this.cboStoneType.Name = "cboStoneType";
            this.cboStoneType.Size = new System.Drawing.Size(161, 21);
            this.cboStoneType.TabIndex = 10;
            // 
            // frmJewelStockReport
            // 
            this.AcceptButton = this.btnShowReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 623);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboStoneType);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.lblMetalType);
            this.Controls.Add(this.cboKT);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmJewelStockReport";
            this.Text = "Jewel Stock Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label lblMetalType;
        private System.Windows.Forms.ComboBox cboKT;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStoneType;
    }
}