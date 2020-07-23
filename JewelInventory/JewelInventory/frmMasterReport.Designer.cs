namespace JewelInventory
{
	partial class frmMasterReport
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSelectedReport = new System.Windows.Forms.ComboBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.cboMasterReportType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(14, 62);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(854, 622);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ToolPanelWidth = 233;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Master :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(307, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Report :";
            // 
            // cboSelectedReport
            // 
            this.cboSelectedReport.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cboSelectedReport.FormattingEnabled = true;
            this.cboSelectedReport.Location = new System.Drawing.Point(423, 27);
            this.cboSelectedReport.Name = "cboSelectedReport";
            this.cboSelectedReport.Size = new System.Drawing.Size(191, 21);
            this.cboSelectedReport.TabIndex = 1;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnShowReport.Location = new System.Drawing.Point(631, 25);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(87, 25);
            this.btnShowReport.TabIndex = 2;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // cboMasterReportType
            // 
            this.cboMasterReportType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cboMasterReportType.FormattingEnabled = true;
            this.cboMasterReportType.Location = new System.Drawing.Point(129, 27);
            this.cboMasterReportType.Name = "cboMasterReportType";
            this.cboMasterReportType.Size = new System.Drawing.Size(161, 21);
            this.cboMasterReportType.TabIndex = 0;
            this.cboMasterReportType.SelectedIndexChanged += new System.EventHandler(this.cboMasterReportType_SelectedIndexChanged);
            // 
            // frmMasterReport
            // 
            this.AcceptButton = this.btnShowReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 705);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.cboSelectedReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMasterReportType);
            this.Controls.Add(this.crystalReportViewer1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "frmMasterReport";
            this.Text = "Masters Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboSelectedReport;
		private System.Windows.Forms.Button btnShowReport;
		private System.Windows.Forms.ComboBox cboMasterReportType;
	}
}