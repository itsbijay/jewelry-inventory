namespace JewelInventory
{
	partial class frmBarcodePrinter
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
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(517, 321);
            this.crystalReportViewer.TabIndex = 177;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmBarcodePrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 321);
            this.Controls.Add(this.crystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBarcodePrinter";
            this.ShowInTaskbar = false;
            this.Text = "Barcode Printer";
            this.Load += new System.EventHandler(this.frmBarcodePrinter_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
	}
}