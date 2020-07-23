namespace JewelInventory
{
    partial class frmTaxInvoiceReport
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
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cboFinancialYear = new System.Windows.Forms.ComboBox();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.rdoSummary = new System.Windows.Forms.RadioButton();
            this.rdoDetail = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnShowReport.Location = new System.Drawing.Point(556, 67);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(87, 25);
            this.btnShowReport.TabIndex = 5;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.AccessibleName = "Transaction Type";
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(458, 40);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(173, 21);
            this.cboTransactionType.TabIndex = 1;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTransactionType.Location = new System.Drawing.Point(292, 46);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(160, 14);
            this.lblTransactionType.TabIndex = 10;
            this.lblTransactionType.Text = "Select Transaction Type :";
            // 
            // cboFinancialYear
            // 
            this.cboFinancialYear.FormattingEnabled = true;
            this.cboFinancialYear.Location = new System.Drawing.Point(157, 39);
            this.cboFinancialYear.Name = "cboFinancialYear";
            this.cboFinancialYear.Size = new System.Drawing.Size(129, 21);
            this.cboFinancialYear.TabIndex = 0;
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinancialYear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFinancialYear.Location = new System.Drawing.Point(14, 46);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(137, 14);
            this.lblFinancialYear.TabIndex = 8;
            this.lblFinancialYear.Text = "Select Financial Year :";
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.AutoScroll = true;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(17, 99);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.Size = new System.Drawing.Size(941, 552);
            this.crystalReportViewer.TabIndex = 6;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ToolPanelWidth = 233;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AccessibleName = "Invoice No";
            this.txtInvoiceNo.Location = new System.Drawing.Point(738, 41);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(147, 20);
            this.txtInvoiceNo.TabIndex = 2;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInvoiceNo.Location = new System.Drawing.Point(649, 46);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(83, 14);
            this.lblInvoiceNo.TabIndex = 12;
            this.lblInvoiceNo.Text = "Invoice No. :";
            // 
            // rdoSummary
            // 
            this.rdoSummary.AutoSize = true;
            this.rdoSummary.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.rdoSummary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoSummary.Location = new System.Drawing.Point(468, 74);
            this.rdoSummary.Name = "rdoSummary";
            this.rdoSummary.Size = new System.Drawing.Size(82, 18);
            this.rdoSummary.TabIndex = 4;
            this.rdoSummary.TabStop = true;
            this.rdoSummary.Text = "Summary";
            this.rdoSummary.UseVisualStyleBackColor = true;
            // 
            // rdoDetail
            // 
            this.rdoDetail.AutoSize = true;
            this.rdoDetail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.rdoDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoDetail.Location = new System.Drawing.Point(388, 74);
            this.rdoDetail.Name = "rdoDetail";
            this.rdoDetail.Size = new System.Drawing.Size(60, 18);
            this.rdoDetail.TabIndex = 3;
            this.rdoDetail.TabStop = true;
            this.rdoDetail.Text = "Detail";
            this.rdoDetail.UseVisualStyleBackColor = true;
            // 
            // frmTaxInvoiceReport
            // 
            this.AcceptButton = this.btnShowReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 665);
            this.Controls.Add(this.rdoDetail);
            this.Controls.Add(this.rdoSummary);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.cboTransactionType);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.cboFinancialYear);
            this.Controls.Add(this.lblFinancialYear);
            this.Controls.Add(this.crystalReportViewer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTaxInvoiceReport";
            this.Text = "Tax Invoice Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button btnShowReport;
		private System.Windows.Forms.ComboBox cboTransactionType;
		private System.Windows.Forms.Label lblTransactionType;
		private System.Windows.Forms.ComboBox cboFinancialYear;
		private System.Windows.Forms.Label lblFinancialYear;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
		private System.Windows.Forms.TextBox txtInvoiceNo;
		private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.RadioButton rdoSummary;
        private System.Windows.Forms.RadioButton rdoDetail;

	}
}