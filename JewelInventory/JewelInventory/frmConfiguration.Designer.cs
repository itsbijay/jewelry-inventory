namespace JewelInventory
{
	partial class frmConfiguration
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
            this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.rdoStockTpeGold = new System.Windows.Forms.RadioButton();
            this.rdoStockTpeSilver = new System.Windows.Forms.RadioButton();
            this.grpboxdescription = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.rdoStockTpeAlloy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtPerticulars = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblParticulars = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkDisabled = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxConfiguration.SuspendLayout();
            this.grpboxdescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(430, 44);
            this.lblHeader.Text = "       Manage Configurations";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(356, 387);
            this.btnCancel.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(285, 387);
            this.btnSave.TabIndex = 1;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-5, 41);
            this.groupBox1.Size = new System.Drawing.Size(428, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-5, 368);
            this.groupBox2.Size = new System.Drawing.Size(425, 10);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(672, 553);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(605, 553);
            // 
            // groupBoxConfiguration
            // 
            this.groupBoxConfiguration.Controls.Add(this.rdoStockTpeGold);
            this.groupBoxConfiguration.Controls.Add(this.rdoStockTpeSilver);
            this.groupBoxConfiguration.Controls.Add(this.grpboxdescription);
            this.groupBoxConfiguration.Controls.Add(this.rdoStockTpeAlloy);
            this.groupBoxConfiguration.Controls.Add(this.label1);
            this.groupBoxConfiguration.Controls.Add(this.label2);
            this.groupBoxConfiguration.Controls.Add(this.txtRemarks);
            this.groupBoxConfiguration.Controls.Add(this.txtPerticulars);
            this.groupBoxConfiguration.Controls.Add(this.cboCategory);
            this.groupBoxConfiguration.Controls.Add(this.lblParticulars);
            this.groupBoxConfiguration.Controls.Add(this.lblCategory);
            this.groupBoxConfiguration.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxConfiguration.Location = new System.Drawing.Point(10, 54);
            this.groupBoxConfiguration.Name = "groupBoxConfiguration";
            this.groupBoxConfiguration.Size = new System.Drawing.Size(411, 248);
            this.groupBoxConfiguration.TabIndex = 48;
            this.groupBoxConfiguration.TabStop = false;
            this.groupBoxConfiguration.Text = "Manage Configurations";
            // 
            // rdoStockTpeGold
            // 
            this.rdoStockTpeGold.AutoSize = true;
            this.rdoStockTpeGold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoStockTpeGold.Location = new System.Drawing.Point(265, 70);
            this.rdoStockTpeGold.Name = "rdoStockTpeGold";
            this.rdoStockTpeGold.Size = new System.Drawing.Size(47, 17);
            this.rdoStockTpeGold.TabIndex = 3;
            this.rdoStockTpeGold.Text = "Gold";
            this.rdoStockTpeGold.UseVisualStyleBackColor = true;
            this.rdoStockTpeGold.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdoStockTpeSilver
            // 
            this.rdoStockTpeSilver.AutoSize = true;
            this.rdoStockTpeSilver.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoStockTpeSilver.Location = new System.Drawing.Point(194, 70);
            this.rdoStockTpeSilver.Name = "rdoStockTpeSilver";
            this.rdoStockTpeSilver.Size = new System.Drawing.Size(51, 17);
            this.rdoStockTpeSilver.TabIndex = 2;
            this.rdoStockTpeSilver.Text = "Silver";
            this.rdoStockTpeSilver.UseVisualStyleBackColor = true;
            // 
            // grpboxdescription
            // 
            this.grpboxdescription.Controls.Add(this.label6);
            this.grpboxdescription.Controls.Add(this.txtValue);
            this.grpboxdescription.Location = new System.Drawing.Point(57, 126);
            this.grpboxdescription.Name = "grpboxdescription";
            this.grpboxdescription.Size = new System.Drawing.Size(266, 36);
            this.grpboxdescription.TabIndex = 1013;
            this.grpboxdescription.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(1, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Description:";
            // 
            // txtValue
            // 
            this.txtValue.AccessibleName = "Description";
            this.txtValue.Location = new System.Drawing.Point(75, 9);
            this.txtValue.MaxLength = 255;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(185, 20);
            this.txtValue.TabIndex = 0;
            // 
            // rdoStockTpeAlloy
            // 
            this.rdoStockTpeAlloy.AutoSize = true;
            this.rdoStockTpeAlloy.Checked = true;
            this.rdoStockTpeAlloy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoStockTpeAlloy.Location = new System.Drawing.Point(132, 70);
            this.rdoStockTpeAlloy.Name = "rdoStockTpeAlloy";
            this.rdoStockTpeAlloy.Size = new System.Drawing.Size(47, 17);
            this.rdoStockTpeAlloy.TabIndex = 1;
            this.rdoStockTpeAlloy.TabStop = true;
            this.rdoStockTpeAlloy.Text = "Alloy";
            this.rdoStockTpeAlloy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(55, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Stock Type :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(68, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.AccessibleName = "Remarks";
            this.txtRemarks.CausesValidation = false;
            this.txtRemarks.Location = new System.Drawing.Point(132, 168);
            this.txtRemarks.MaxLength = 255;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(186, 48);
            this.txtRemarks.TabIndex = 5;
            // 
            // txtPerticulars
            // 
            this.txtPerticulars.AccessibleName = "Perticular";
            this.txtPerticulars.Location = new System.Drawing.Point(132, 99);
            this.txtPerticulars.MaxLength = 255;
            this.txtPerticulars.Name = "txtPerticulars";
            this.txtPerticulars.Size = new System.Drawing.Size(186, 20);
            this.txtPerticulars.TabIndex = 4;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(132, 34);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(186, 21);
            this.cboCategory.TabIndex = 0;
            // 
            // lblParticulars
            // 
            this.lblParticulars.AutoSize = true;
            this.lblParticulars.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblParticulars.Location = new System.Drawing.Point(61, 106);
            this.lblParticulars.Name = "lblParticulars";
            this.lblParticulars.Size = new System.Drawing.Size(62, 13);
            this.lblParticulars.TabIndex = 52;
            this.lblParticulars.Text = "Particulars :";
            // 
            // lblCategory
            // 
            this.lblCategory.AccessibleName = "Category";
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCategory.Location = new System.Drawing.Point(30, 39);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(93, 13);
            this.lblCategory.TabIndex = 54;
            this.lblCategory.Text = "Costing Category :";
            // 
            // chkDisabled
            // 
            this.chkDisabled.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDisabled.Location = new System.Drawing.Point(365, 325);
            this.chkDisabled.Name = "chkDisabled";
            this.chkDisabled.Size = new System.Drawing.Size(56, 17);
            this.chkDisabled.TabIndex = 0;
            this.chkDisabled.Text = "Active";
            this.chkDisabled.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 39);
            this.label3.TabIndex = 1010;
            this.label3.Text = "1) Once a year is added cannot be modified, \r\nYour need to inactive record and cr" +
    "eate new record again.\r\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1011;
            this.label4.Text = "Note :";
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkDisabled);
            this.Controls.Add(this.groupBoxConfiguration);
            this.Name = "frmConfiguration";
            this.Text = "Manage Configurations";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.Controls.SetChildIndex(this.groupBoxConfiguration, 0);
            this.Controls.SetChildIndex(this.chkDisabled, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.groupBoxConfiguration.ResumeLayout(false);
            this.groupBoxConfiguration.PerformLayout();
            this.grpboxdescription.ResumeLayout(false);
            this.grpboxdescription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBoxConfiguration;
		private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblParticulars;
        private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.TextBox txtPerticulars;
		private System.Windows.Forms.CheckBox chkDisabled;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoStockTpeSilver;
        private System.Windows.Forms.RadioButton rdoStockTpeAlloy;
        private System.Windows.Forms.RadioButton rdoStockTpeGold;
        private System.Windows.Forms.GroupBox grpboxdescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValue;

	}
}