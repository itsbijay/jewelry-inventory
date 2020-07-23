using System;
using System.Windows.Forms;

namespace JewelCatalogue
{
	partial class frmAdvancesearch
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
			this.button1 = new System.Windows.Forms.Button();
			this.grpFilter = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDiaPcsTo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDiaPcsFm = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtWtDiaWtTo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtWtDiaWtFr = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNetWtTo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNetWtFm = new System.Windows.Forms.TextBox();
			this.lblTo = new System.Windows.Forms.Label();
			this.txtGrWtTo = new System.Windows.Forms.TextBox();
			this.lblFrom = new System.Windows.Forms.Label();
			this.txtGrWtFm = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.grpFilter.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(187, 158);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "&Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// grpFilter
			// 
			this.grpFilter.Controls.Add(this.label10);
			this.grpFilter.Controls.Add(this.label9);
			this.grpFilter.Controls.Add(this.label8);
			this.grpFilter.Controls.Add(this.label7);
			this.grpFilter.Controls.Add(this.label5);
			this.grpFilter.Controls.Add(this.txtDiaPcsTo);
			this.grpFilter.Controls.Add(this.label6);
			this.grpFilter.Controls.Add(this.txtDiaPcsFm);
			this.grpFilter.Controls.Add(this.label3);
			this.grpFilter.Controls.Add(this.txtWtDiaWtTo);
			this.grpFilter.Controls.Add(this.label4);
			this.grpFilter.Controls.Add(this.txtWtDiaWtFr);
			this.grpFilter.Controls.Add(this.label1);
			this.grpFilter.Controls.Add(this.txtNetWtTo);
			this.grpFilter.Controls.Add(this.label2);
			this.grpFilter.Controls.Add(this.txtNetWtFm);
			this.grpFilter.Controls.Add(this.lblTo);
			this.grpFilter.Controls.Add(this.txtGrWtTo);
			this.grpFilter.Controls.Add(this.lblFrom);
			this.grpFilter.Controls.Add(this.txtGrWtFm);
			this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpFilter.Location = new System.Drawing.Point(12, 12);
			this.grpFilter.Name = "grpFilter";
			this.grpFilter.Size = new System.Drawing.Size(352, 140);
			this.grpFilter.TabIndex = 1;
			this.grpFilter.TabStop = false;
			this.grpFilter.Text = "Filters";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(262, 111);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(81, 13);
			this.label10.TabIndex = 59;
			this.label10.Text = "Diamond Pcs";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(262, 86);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(47, 13);
			this.label9.TabIndex = 58;
			this.label9.Text = "Net Wt";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(262, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 57;
			this.label8.Text = "Gr Wt";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(262, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 13);
			this.label7.TabIndex = 56;
			this.label7.Text = "Diamond Wt";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(148, 82);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 14);
			this.label5.TabIndex = 54;
			this.label5.Text = "To :";
			// 
			// txtDiaPcsTo
			// 
			this.txtDiaPcsTo.Location = new System.Drawing.Point(180, 104);
			this.txtDiaPcsTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtDiaPcsTo.MaxLength = 9;
			this.txtDiaPcsTo.Name = "txtDiaPcsTo";
			this.txtDiaPcsTo.Size = new System.Drawing.Size(74, 20);
			this.txtDiaPcsTo.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(15, 106);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 14);
			this.label6.TabIndex = 55;
			this.label6.Text = "From :";
			// 
			// txtDiaPcsFm
			// 
			this.txtDiaPcsFm.Location = new System.Drawing.Point(66, 104);
			this.txtDiaPcsFm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtDiaPcsFm.MaxLength = 9;
			this.txtDiaPcsFm.Name = "txtDiaPcsFm";
			this.txtDiaPcsFm.Size = new System.Drawing.Size(74, 20);
			this.txtDiaPcsFm.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(148, 32);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 14);
			this.label3.TabIndex = 50;
			this.label3.Text = "To :";
			// 
			// txtWtDiaWtTo
			// 
			this.txtWtDiaWtTo.Location = new System.Drawing.Point(180, 33);
			this.txtWtDiaWtTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtWtDiaWtTo.MaxLength = 9;
			this.txtWtDiaWtTo.Name = "txtWtDiaWtTo";
			this.txtWtDiaWtTo.Size = new System.Drawing.Size(74, 20);
			this.txtWtDiaWtTo.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(15, 32);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 14);
			this.label4.TabIndex = 51;
			this.label4.Text = "From :";
			// 
			// txtWtDiaWtFr
			// 
			this.txtWtDiaWtFr.Location = new System.Drawing.Point(66, 33);
			this.txtWtDiaWtFr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtWtDiaWtFr.MaxLength = 9;
			this.txtWtDiaWtFr.Name = "txtWtDiaWtFr";
			this.txtWtDiaWtFr.Size = new System.Drawing.Size(74, 20);
			this.txtWtDiaWtFr.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(148, 106);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 14);
			this.label1.TabIndex = 46;
			this.label1.Text = "To :";
			// 
			// txtNetWtTo
			// 
			this.txtNetWtTo.Location = new System.Drawing.Point(180, 79);
			this.txtNetWtTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtNetWtTo.MaxLength = 9;
			this.txtNetWtTo.Name = "txtNetWtTo";
			this.txtNetWtTo.Size = new System.Drawing.Size(74, 20);
			this.txtNetWtTo.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(15, 82);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 14);
			this.label2.TabIndex = 47;
			this.label2.Text = "From :";
			// 
			// txtNetWtFm
			// 
			this.txtNetWtFm.Location = new System.Drawing.Point(66, 79);
			this.txtNetWtFm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtNetWtFm.MaxLength = 9;
			this.txtNetWtFm.Name = "txtNetWtFm";
			this.txtNetWtFm.Size = new System.Drawing.Size(74, 20);
			this.txtNetWtFm.TabIndex = 5;
			// 
			// lblTo
			// 
			this.lblTo.AutoSize = true;
			this.lblTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTo.Location = new System.Drawing.Point(148, 58);
			this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(30, 14);
			this.lblTo.TabIndex = 42;
			this.lblTo.Text = "To :";
			// 
			// txtGrWtTo
			// 
			this.txtGrWtTo.Location = new System.Drawing.Point(180, 57);
			this.txtGrWtTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtGrWtTo.MaxLength = 9;
			this.txtGrWtTo.Name = "txtGrWtTo";
			this.txtGrWtTo.Size = new System.Drawing.Size(74, 20);
			this.txtGrWtTo.TabIndex = 4;
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFrom.Location = new System.Drawing.Point(15, 58);
			this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(42, 14);
			this.lblFrom.TabIndex = 43;
			this.lblFrom.Text = "From :";
			// 
			// txtGrWtFm
			// 
			this.txtGrWtFm.Location = new System.Drawing.Point(66, 57);
			this.txtGrWtFm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtGrWtFm.MaxLength = 9;
			this.txtGrWtFm.Name = "txtGrWtFm";
			this.txtGrWtFm.Size = new System.Drawing.Size(74, 20);
			this.txtGrWtFm.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(100, 158);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "&Ok";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmAdvancesearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 189);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.grpFilter);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmAdvancesearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Advance Filter";
			this.Load += new System.EventHandler(this.frmAdvancesearch_Load);
			this.grpFilter.ResumeLayout(false);
			this.grpFilter.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox grpFilter;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox txtDiaPcsTo;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox txtDiaPcsFm;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtWtDiaWtTo;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtWtDiaWtFr;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtNetWtTo;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtNetWtFm;
		internal System.Windows.Forms.Label lblTo;
		internal System.Windows.Forms.TextBox txtGrWtTo;
		internal System.Windows.Forms.Label lblFrom;
		internal System.Windows.Forms.TextBox txtGrWtFm;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button2;

	    private readonly Action<object, KeyPressEventArgs> dest = delegate(object sender, KeyPressEventArgs e)
	    {
	        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
	        {
	            e.Handled = true;
	        }

	        // only allow one decimal point
	        if (e.KeyChar == '.'
	            && (sender as TextBox).Text.IndexOf('.') > -1)
	        {
	            e.Handled = true;
	        }
	    };
	}
}