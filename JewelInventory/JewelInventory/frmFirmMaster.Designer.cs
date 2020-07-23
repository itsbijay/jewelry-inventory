namespace JewelInventory
{
	partial class frmFirmMaster
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblHeaderOrSlogan = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAdditionalInformation = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLogo = new System.Windows.Forms.TextBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.txtHeaderOrSlogan = new System.Windows.Forms.TextBox();
            this.txtAdditionalInformation = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblVATNumber = new System.Windows.Forms.Label();
            this.lblTINNumber = new System.Windows.Forms.Label();
            this.txtVATNumber = new System.Windows.Forms.TextBox();
            this.txtTINNumber = new System.Windows.Forms.TextBox();
            this.lblTAX = new System.Windows.Forms.Label();
            this.txtTAX = new System.Windows.Forms.TextBox();
            this.lblOtherTAX = new System.Windows.Forms.Label();
            this.txtOtherTAX = new System.Windows.Forms.TextBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.grpContainer = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTopHeader = new System.Windows.Forms.TextBox();
            this.lnkEditFirmInfo = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Size = new System.Drawing.Size(615, 44);
            this.lblHeader.Text = "    Firm Master";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(496, 547);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(425, 547);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Size = new System.Drawing.Size(62, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Size = new System.Drawing.Size(552, 12);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(7, 526);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(552, 12);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(360, 547);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Size = new System.Drawing.Size(62, 23);
            this.btnNext.TabIndex = 13;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(293, 547);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrev.TabIndex = 12;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(109, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 1006;
            this.lblName.Text = "Name :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEmail.Location = new System.Drawing.Point(112, 58);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 1007;
            this.lblEmail.Text = "Email :";
            // 
            // lblHeaderOrSlogan
            // 
            this.lblHeaderOrSlogan.AutoSize = true;
            this.lblHeaderOrSlogan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeaderOrSlogan.Location = new System.Drawing.Point(31, 118);
            this.lblHeaderOrSlogan.Name = "lblHeaderOrSlogan";
            this.lblHeaderOrSlogan.Size = new System.Drawing.Size(119, 13);
            this.lblHeaderOrSlogan.TabIndex = 1008;
            this.lblHeaderOrSlogan.Text = "Report Header Slogan :";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWebsite.Location = new System.Drawing.Point(99, 150);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(52, 13);
            this.lblWebsite.TabIndex = 1009;
            this.lblWebsite.Text = "Website :";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLogo.Location = new System.Drawing.Point(66, 184);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(84, 13);
            this.lblLogo.TabIndex = 1010;
            this.lblLogo.Text = "Company Logo :";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAddress.Location = new System.Drawing.Point(99, 342);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 1011;
            this.lblAddress.Text = "Address :";
            // 
            // lblAdditionalInformation
            // 
            this.lblAdditionalInformation.AutoSize = true;
            this.lblAdditionalInformation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAdditionalInformation.Location = new System.Drawing.Point(36, 388);
            this.lblAdditionalInformation.Name = "lblAdditionalInformation";
            this.lblAdditionalInformation.Size = new System.Drawing.Size(114, 13);
            this.lblAdditionalInformation.TabIndex = 1012;
            this.lblAdditionalInformation.Text = "Additional Information :";
            // 
            // txtName
            // 
            this.txtName.AccessibleName = "Company Name";
            this.txtName.Location = new System.Drawing.Point(164, 19);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.AccessibleName = "Email";
            this.txtEmail.Location = new System.Drawing.Point(164, 51);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(212, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleName = "Address";
            this.txtAddress.Location = new System.Drawing.Point(164, 338);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.MaxLength = 400;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(320, 33);
            this.txtAddress.TabIndex = 10;
            // 
            // txtLogo
            // 
            this.txtLogo.AccessibleName = "Logo";
            this.txtLogo.CausesValidation = false;
            this.txtLogo.Location = new System.Drawing.Point(164, 180);
            this.txtLogo.Margin = new System.Windows.Forms.Padding(2);
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.Size = new System.Drawing.Size(298, 20);
            this.txtLogo.TabIndex = 4;
            // 
            // txtWebsite
            // 
            this.txtWebsite.AccessibleName = "Website";
            this.txtWebsite.CausesValidation = false;
            this.txtWebsite.Location = new System.Drawing.Point(165, 146);
            this.txtWebsite.Margin = new System.Windows.Forms.Padding(2);
            this.txtWebsite.MaxLength = 255;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(212, 20);
            this.txtWebsite.TabIndex = 4;
            // 
            // txtHeaderOrSlogan
            // 
            this.txtHeaderOrSlogan.AccessibleName = "Header Text";
            this.txtHeaderOrSlogan.Location = new System.Drawing.Point(164, 113);
            this.txtHeaderOrSlogan.Margin = new System.Windows.Forms.Padding(2);
            this.txtHeaderOrSlogan.MaxLength = 255;
            this.txtHeaderOrSlogan.Name = "txtHeaderOrSlogan";
            this.txtHeaderOrSlogan.Size = new System.Drawing.Size(212, 20);
            this.txtHeaderOrSlogan.TabIndex = 3;
            this.txtHeaderOrSlogan.TextChanged += new System.EventHandler(this.txtHeaderOrSlogan_TextChanged);
            // 
            // txtAdditionalInformation
            // 
            this.txtAdditionalInformation.AccessibleName = "Additional Information";
            this.txtAdditionalInformation.CausesValidation = false;
            this.txtAdditionalInformation.Location = new System.Drawing.Point(164, 384);
            this.txtAdditionalInformation.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdditionalInformation.MaxLength = 400;
            this.txtAdditionalInformation.Multiline = true;
            this.txtAdditionalInformation.Name = "txtAdditionalInformation";
            this.txtAdditionalInformation.Size = new System.Drawing.Size(320, 33);
            this.txtAdditionalInformation.TabIndex = 11;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(466, 180);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 20);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblVATNumber
            // 
            this.lblVATNumber.AutoSize = true;
            this.lblVATNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVATNumber.Location = new System.Drawing.Point(76, 221);
            this.lblVATNumber.Name = "lblVATNumber";
            this.lblVATNumber.Size = new System.Drawing.Size(74, 13);
            this.lblVATNumber.TabIndex = 1021;
            this.lblVATNumber.Text = "VAT Number :";
            // 
            // lblTINNumber
            // 
            this.lblTINNumber.AutoSize = true;
            this.lblTINNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTINNumber.Location = new System.Drawing.Point(52, 252);
            this.lblTINNumber.Name = "lblTINNumber";
            this.lblTINNumber.Size = new System.Drawing.Size(98, 13);
            this.lblTINNumber.TabIndex = 1022;
            this.lblTINNumber.Text = "C.S.T TIN Number:";
            // 
            // txtVATNumber
            // 
            this.txtVATNumber.AccessibleName = "VAT Number";
            this.txtVATNumber.CausesValidation = false;
            this.txtVATNumber.Location = new System.Drawing.Point(164, 214);
            this.txtVATNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtVATNumber.MaxLength = 255;
            this.txtVATNumber.Name = "txtVATNumber";
            this.txtVATNumber.Size = new System.Drawing.Size(212, 20);
            this.txtVATNumber.TabIndex = 6;
            // 
            // txtTINNumber
            // 
            this.txtTINNumber.AccessibleName = "CST TIN Number";
            this.txtTINNumber.CausesValidation = false;
            this.txtTINNumber.Location = new System.Drawing.Point(164, 245);
            this.txtTINNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtTINNumber.MaxLength = 255;
            this.txtTINNumber.Name = "txtTINNumber";
            this.txtTINNumber.Size = new System.Drawing.Size(212, 20);
            this.txtTINNumber.TabIndex = 7;
            // 
            // lblTAX
            // 
            this.lblTAX.AutoSize = true;
            this.lblTAX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTAX.Location = new System.Drawing.Point(116, 282);
            this.lblTAX.Name = "lblTAX";
            this.lblTAX.Size = new System.Drawing.Size(34, 13);
            this.lblTAX.TabIndex = 1023;
            this.lblTAX.Text = "TAX :";
            // 
            // txtTAX
            // 
            this.txtTAX.AccessibleName = "CST TIN Number";
            this.txtTAX.CausesValidation = false;
            this.txtTAX.Location = new System.Drawing.Point(164, 275);
            this.txtTAX.Margin = new System.Windows.Forms.Padding(2);
            this.txtTAX.MaxLength = 255;
            this.txtTAX.Name = "txtTAX";
            this.txtTAX.Size = new System.Drawing.Size(50, 20);
            this.txtTAX.TabIndex = 8;
            // 
            // lblOtherTAX
            // 
            this.lblOtherTAX.AutoSize = true;
            this.lblOtherTAX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOtherTAX.Location = new System.Drawing.Point(87, 310);
            this.lblOtherTAX.Name = "lblOtherTAX";
            this.lblOtherTAX.Size = new System.Drawing.Size(63, 13);
            this.lblOtherTAX.TabIndex = 1025;
            this.lblOtherTAX.Text = "Other TAX :";
            // 
            // txtOtherTAX
            // 
            this.txtOtherTAX.AccessibleName = "CST TIN Number";
            this.txtOtherTAX.CausesValidation = false;
            this.txtOtherTAX.Location = new System.Drawing.Point(164, 307);
            this.txtOtherTAX.Margin = new System.Windows.Forms.Padding(2);
            this.txtOtherTAX.MaxLength = 255;
            this.txtOtherTAX.Name = "txtOtherTAX";
            this.txtOtherTAX.Size = new System.Drawing.Size(50, 20);
            this.txtOtherTAX.TabIndex = 9;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(410, 19);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(126, 122);
            this.picLogo.TabIndex = 1026;
            this.picLogo.TabStop = false;
            // 
            // grpContainer
            // 
            this.grpContainer.Controls.Add(this.label1);
            this.grpContainer.Controls.Add(this.txtTopHeader);
            this.grpContainer.Controls.Add(this.txtWebsite);
            this.grpContainer.Controls.Add(this.picLogo);
            this.grpContainer.Controls.Add(this.txtEmail);
            this.grpContainer.Controls.Add(this.txtOtherTAX);
            this.grpContainer.Controls.Add(this.lblHeaderOrSlogan);
            this.grpContainer.Controls.Add(this.lblOtherTAX);
            this.grpContainer.Controls.Add(this.txtName);
            this.grpContainer.Controls.Add(this.txtTAX);
            this.grpContainer.Controls.Add(this.lblName);
            this.grpContainer.Controls.Add(this.lblTAX);
            this.grpContainer.Controls.Add(this.lblAddress);
            this.grpContainer.Controls.Add(this.txtTINNumber);
            this.grpContainer.Controls.Add(this.lblAdditionalInformation);
            this.grpContainer.Controls.Add(this.txtVATNumber);
            this.grpContainer.Controls.Add(this.lblLogo);
            this.grpContainer.Controls.Add(this.lblTINNumber);
            this.grpContainer.Controls.Add(this.lblEmail);
            this.grpContainer.Controls.Add(this.lblVATNumber);
            this.grpContainer.Controls.Add(this.lblWebsite);
            this.grpContainer.Controls.Add(this.btnBrowse);
            this.grpContainer.Controls.Add(this.txtAddress);
            this.grpContainer.Controls.Add(this.txtAdditionalInformation);
            this.grpContainer.Controls.Add(this.txtLogo);
            this.grpContainer.Controls.Add(this.txtHeaderOrSlogan);
            this.grpContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpContainer.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpContainer.Location = new System.Drawing.Point(7, 59);
            this.grpContainer.Name = "grpContainer";
            this.grpContainer.Size = new System.Drawing.Size(552, 424);
            this.grpContainer.TabIndex = 1027;
            this.grpContainer.TabStop = false;
            this.grpContainer.Text = "Firm Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(45, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1028;
            this.label1.Text = "Report Top Header :";
            // 
            // txtTopHeader
            // 
            this.txtTopHeader.AccessibleName = "Header Text";
            this.txtTopHeader.Location = new System.Drawing.Point(164, 81);
            this.txtTopHeader.Margin = new System.Windows.Forms.Padding(2);
            this.txtTopHeader.MaxLength = 255;
            this.txtTopHeader.Name = "txtTopHeader";
            this.txtTopHeader.Size = new System.Drawing.Size(212, 20);
            this.txtTopHeader.TabIndex = 2;
            // 
            // lnkEditFirmInfo
            // 
            this.lnkEditFirmInfo.AutoSize = true;
            this.lnkEditFirmInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEditFirmInfo.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkEditFirmInfo.Location = new System.Drawing.Point(11, 503);
            this.lnkEditFirmInfo.Name = "lnkEditFirmInfo";
            this.lnkEditFirmInfo.Size = new System.Drawing.Size(82, 13);
            this.lnkEditFirmInfo.TabIndex = 1027;
            this.lnkEditFirmInfo.TabStop = true;
            this.lnkEditFirmInfo.Text = "Edit Firm Info";
            this.lnkEditFirmInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditFirmInfo_LinkClicked);
            // 
            // frmFirmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 577);
            this.Controls.Add(this.grpContainer);
            this.Controls.Add(this.lnkEditFirmInfo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFirmMaster";
            this.Text = "Firm Master";
            this.Load += new System.EventHandler(this.frmFirmMaster_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.lnkEditFirmInfo, 0);
            this.Controls.SetChildIndex(this.grpContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpContainer.ResumeLayout(false);
            this.grpContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblHeaderOrSlogan;
		private System.Windows.Forms.Label lblWebsite;
		private System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.Label lblAdditionalInformation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtLogo;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.TextBox txtHeaderOrSlogan;
        private System.Windows.Forms.TextBox txtAdditionalInformation;
        private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label lblVATNumber;
		private System.Windows.Forms.Label lblTINNumber;
		private System.Windows.Forms.TextBox txtVATNumber;
		private System.Windows.Forms.TextBox txtTINNumber;
		private System.Windows.Forms.Label lblTAX;
		private System.Windows.Forms.TextBox txtTAX;
		private System.Windows.Forms.Label lblOtherTAX;
		private System.Windows.Forms.TextBox txtOtherTAX;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.GroupBox grpContainer;
		private System.Windows.Forms.LinkLabel lnkEditFirmInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTopHeader;
	}
}