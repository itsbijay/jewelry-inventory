namespace JewelInventory
{
	partial class frmSettings
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdomanual = new System.Windows.Forms.RadioButton();
            this.rdoexcel = new System.Windows.Forms.RadioButton();
            this.btnExcelBrowse = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.lblExcelPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageBrowse.Location = new System.Drawing.Point(462, 67);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(42, 25);
            this.btnImageBrowse.TabIndex = 1;
            this.btnImageBrowse.Text = "...";
            this.btnImageBrowse.UseVisualStyleBackColor = true;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(162, 69);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(292, 20);
            this.txtImagePath.TabIndex = 0;
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagePath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblImagePath.Location = new System.Drawing.Point(27, 75);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(131, 14);
            this.lblImagePath.TabIndex = 28;
            this.lblImagePath.Text = "Image Directory Path :";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(441, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(542, 44);
            this.lblHeader.TabIndex = 24;
            this.lblHeader.Text = "     Settings";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(372, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(38, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Stock Inward Type :";
            // 
            // rdomanual
            // 
            this.rdomanual.AutoSize = true;
            this.rdomanual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdomanual.Checked = true;
            this.rdomanual.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdomanual.Location = new System.Drawing.Point(161, 137);
            this.rdomanual.Name = "rdomanual";
            this.rdomanual.Size = new System.Drawing.Size(87, 17);
            this.rdomanual.TabIndex = 2;
            this.rdomanual.TabStop = true;
            this.rdomanual.Text = "Manual Entry";
            this.rdomanual.UseVisualStyleBackColor = true;
            // 
            // rdoexcel
            // 
            this.rdoexcel.AutoSize = true;
            this.rdoexcel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoexcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoexcel.Location = new System.Drawing.Point(265, 137);
            this.rdoexcel.Name = "rdoexcel";
            this.rdoexcel.Size = new System.Drawing.Size(88, 17);
            this.rdoexcel.TabIndex = 3;
            this.rdoexcel.Text = "Excel Upload";
            this.rdoexcel.UseVisualStyleBackColor = true;
            // 
            // btnExcelBrowse
            // 
            this.btnExcelBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelBrowse.Location = new System.Drawing.Point(462, 101);
            this.btnExcelBrowse.Name = "btnExcelBrowse";
            this.btnExcelBrowse.Size = new System.Drawing.Size(42, 25);
            this.btnExcelBrowse.TabIndex = 5;
            this.btnExcelBrowse.Text = "...";
            this.btnExcelBrowse.UseVisualStyleBackColor = true;
            this.btnExcelBrowse.Click += new System.EventHandler(this.btnExcelBrowse_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(162, 103);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(292, 20);
            this.txtExcelPath.TabIndex = 4;
            // 
            // lblExcelPath
            // 
            this.lblExcelPath.AutoSize = true;
            this.lblExcelPath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblExcelPath.Location = new System.Drawing.Point(12, 105);
            this.lblExcelPath.Name = "lblExcelPath";
            this.lblExcelPath.Size = new System.Drawing.Size(144, 14);
            this.lblExcelPath.TabIndex = 33;
            this.lblExcelPath.Text = "Excel file Directory Path :";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 246);
            this.Controls.Add(this.btnExcelBrowse);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.lblExcelPath);
            this.Controls.Add(this.rdoexcel);
            this.Controls.Add(this.rdomanual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImageBrowse);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblImagePath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblImagePath;
		private System.Windows.Forms.TextBox txtImagePath;
		private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdomanual;
        private System.Windows.Forms.RadioButton rdoexcel;
        private System.Windows.Forms.Button btnExcelBrowse;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Label lblExcelPath;
	}
}