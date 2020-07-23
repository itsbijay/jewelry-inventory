namespace JewelInventory
{
	partial class frmObjectBinder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgDataControl = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAllowOnTop = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataControl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgDataControl);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Binder Header";
            // 
            // dgDataControl
            // 
            this.dgDataControl.AllowUserToAddRows = false;
            this.dgDataControl.AllowUserToDeleteRows = false;
            this.dgDataControl.AllowUserToOrderColumns = true;
            this.dgDataControl.AllowUserToResizeRows = false;
            this.dgDataControl.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgDataControl.CausesValidation = false;
            this.dgDataControl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgDataControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataControl.Location = new System.Drawing.Point(22, 19);
            this.dgDataControl.Name = "dgDataControl";
            this.dgDataControl.RowHeadersVisible = false;
            this.dgDataControl.Size = new System.Drawing.Size(506, 355);
            this.dgDataControl.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(253, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAllowOnTop
            // 
            this.chkAllowOnTop.AutoSize = true;
            this.chkAllowOnTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAllowOnTop.Location = new System.Drawing.Point(13, 409);
            this.chkAllowOnTop.Name = "chkAllowOnTop";
            this.chkAllowOnTop.Size = new System.Drawing.Size(98, 17);
            this.chkAllowOnTop.TabIndex = 2;
            this.chkAllowOnTop.Text = "Always On Top";
            this.chkAllowOnTop.UseVisualStyleBackColor = true;
            this.chkAllowOnTop.CheckedChanged += new System.EventHandler(this.chkAllowOnTop_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::JewelInventory.Properties.Resources.Print;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(486, 403);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(54, 35);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage_1);
            // 
            // frmObjectBinder
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(580, 444);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkAllowOnTop);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmObjectBinder";
            this.Text = "Object Binder";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDataControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgDataControl;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox chkAllowOnTop;
		private System.Windows.Forms.Button btnPrint;
		private System.Drawing.Printing.PrintDocument printDocument;
	}
}