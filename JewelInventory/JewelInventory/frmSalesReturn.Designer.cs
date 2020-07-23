namespace JewelInventory
{
	partial class frmSalesReturn
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(683, 44);
            this.lblHeader.Text = "       Sales return";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(606, 432);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(535, 432);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Size = new System.Drawing.Size(666, 8);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(7, 418);
            this.groupBox2.Size = new System.Drawing.Size(666, 8);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(470, 432);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(403, 432);
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(7, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(664, 347);
            this.groupBox3.TabIndex = 1006;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sales Return";
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 469);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Return";
            this.Load += new System.EventHandler(this.frmSalesReturn_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox3;

    }
}