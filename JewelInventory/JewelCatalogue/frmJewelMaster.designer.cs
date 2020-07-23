namespace JewelCatalogue
{
    partial class frmJewelMaster
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.cboMetalColor = new System.Windows.Forms.ComboBox();
            this.cboJewelDesc = new System.Windows.Forms.ComboBox();
            this.lblSlashGold = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblSlashDiamond = new System.Windows.Forms.Label();
            this.lblDiamond = new System.Windows.Forms.Label();
            this.txtGrsWt = new System.Windows.Forms.TextBox();
            this.lblMetalColor = new System.Windows.Forms.Label();
            this.txtDiamondWt = new System.Windows.Forms.TextBox();
            this.txtStyleNo = new System.Windows.Forms.TextBox();
            this.txtNetWt = new System.Windows.Forms.TextBox();
            this.lblStyleNo = new System.Windows.Forms.Label();
            this.txtDiamondPcs = new System.Windows.Forms.TextBox();
            this.btnImageUpload = new System.Windows.Forms.Button();
            this.jewelPictureBox = new System.Windows.Forms.PictureBox();
            this.txtJewelNo = new System.Windows.Forms.TextBox();
            this.lblJewelDesc = new System.Windows.Forms.Label();
            this.lblJewelNo = new System.Windows.Forms.Label();
            this.btnPrintSticker = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jewelPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(1028, 44);
            this.lblHeader.Text = "  Jewel Master";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(951, 483);
            this.btnCancel.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(880, 485);
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(573, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-6, 464);
            this.groupBox2.Size = new System.Drawing.Size(1046, 8);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(816, 485);
            this.btnNext.TabIndex = 13;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(748, 485);
            this.btnPrev.TabIndex = 12;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cboMetalColor);
            this.groupBox.Controls.Add(this.cboJewelDesc);
            this.groupBox.Controls.Add(this.lblSlashGold);
            this.groupBox.Controls.Add(this.lblGold);
            this.groupBox.Controls.Add(this.lblSlashDiamond);
            this.groupBox.Controls.Add(this.lblDiamond);
            this.groupBox.Controls.Add(this.txtGrsWt);
            this.groupBox.Controls.Add(this.lblMetalColor);
            this.groupBox.Controls.Add(this.txtDiamondWt);
            this.groupBox.Controls.Add(this.txtStyleNo);
            this.groupBox.Controls.Add(this.txtNetWt);
            this.groupBox.Controls.Add(this.lblStyleNo);
            this.groupBox.Controls.Add(this.txtDiamondPcs);
            this.groupBox.Controls.Add(this.btnImageUpload);
            this.groupBox.Controls.Add(this.jewelPictureBox);
            this.groupBox.Controls.Add(this.txtJewelNo);
            this.groupBox.Controls.Add(this.lblJewelDesc);
            this.groupBox.Controls.Add(this.lblJewelNo);
            this.groupBox.Location = new System.Drawing.Point(12, 64);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(432, 260);
            this.groupBox.TabIndex = 1028;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Jewel Master";
            // 
            // cboMetalColor
            // 
            this.cboMetalColor.FormattingEnabled = true;
            this.cboMetalColor.Items.AddRange(new object[] {
            "YELLOW",
            "SILVER"});
            this.cboMetalColor.Location = new System.Drawing.Point(115, 138);
            this.cboMetalColor.Name = "cboMetalColor";
            this.cboMetalColor.Size = new System.Drawing.Size(121, 21);
            this.cboMetalColor.TabIndex = 3;
            // 
            // cboJewelDesc
            // 
            this.cboJewelDesc.FormattingEnabled = true;
            this.cboJewelDesc.Location = new System.Drawing.Point(115, 101);
            this.cboJewelDesc.Name = "cboJewelDesc";
            this.cboJewelDesc.Size = new System.Drawing.Size(121, 21);
            this.cboJewelDesc.TabIndex = 2;
            // 
            // lblSlashGold
            // 
            this.lblSlashGold.AutoSize = true;
            this.lblSlashGold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlashGold.Location = new System.Drawing.Point(166, 212);
            this.lblSlashGold.Name = "lblSlashGold";
            this.lblSlashGold.Size = new System.Drawing.Size(12, 13);
            this.lblSlashGold.TabIndex = 1038;
            this.lblSlashGold.Text = "/";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGold.Location = new System.Drawing.Point(14, 212);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(96, 13);
            this.lblGold.TabIndex = 1035;
            this.lblGold.Text = "Net Wt/Gross Wt :";
            // 
            // lblSlashDiamond
            // 
            this.lblSlashDiamond.AutoSize = true;
            this.lblSlashDiamond.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlashDiamond.Location = new System.Drawing.Point(166, 176);
            this.lblSlashDiamond.Name = "lblSlashDiamond";
            this.lblSlashDiamond.Size = new System.Drawing.Size(12, 13);
            this.lblSlashDiamond.TabIndex = 1034;
            this.lblSlashDiamond.Text = "/";
            // 
            // lblDiamond
            // 
            this.lblDiamond.AutoSize = true;
            this.lblDiamond.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamond.Location = new System.Drawing.Point(6, 176);
            this.lblDiamond.Name = "lblDiamond";
            this.lblDiamond.Size = new System.Drawing.Size(104, 13);
            this.lblDiamond.TabIndex = 1031;
            this.lblDiamond.Text = "Diamond (Pcs/ Wt) :";
            // 
            // txtGrsWt
            // 
            this.txtGrsWt.AccessibleDescription = "Gold Wt";
            this.txtGrsWt.Location = new System.Drawing.Point(179, 209);
            this.txtGrsWt.MaxLength = 10;
            this.txtGrsWt.Name = "txtGrsWt";
            this.txtGrsWt.Size = new System.Drawing.Size(50, 20);
            this.txtGrsWt.TabIndex = 7;
            // 
            // lblMetalColor
            // 
            this.lblMetalColor.AutoSize = true;
            this.lblMetalColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMetalColor.Location = new System.Drawing.Point(44, 141);
            this.lblMetalColor.Name = "lblMetalColor";
            this.lblMetalColor.Size = new System.Drawing.Size(66, 13);
            this.lblMetalColor.TabIndex = 1030;
            this.lblMetalColor.Text = "Metal Color :";
            // 
            // txtDiamondWt
            // 
            this.txtDiamondWt.AccessibleDescription = "Diamond Wt";
            this.txtDiamondWt.Location = new System.Drawing.Point(179, 176);
            this.txtDiamondWt.MaxLength = 10;
            this.txtDiamondWt.Name = "txtDiamondWt";
            this.txtDiamondWt.Size = new System.Drawing.Size(50, 20);
            this.txtDiamondWt.TabIndex = 5;
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.AccessibleName = "Style No";
            this.txtStyleNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStyleNo.Location = new System.Drawing.Point(115, 62);
            this.txtStyleNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtStyleNo.MaxLength = 50;
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.Size = new System.Drawing.Size(137, 20);
            this.txtStyleNo.TabIndex = 1;
            // 
            // txtNetWt
            // 
            this.txtNetWt.AccessibleDescription = "";
            this.txtNetWt.AccessibleName = "Gold Pcs";
            this.txtNetWt.Location = new System.Drawing.Point(115, 209);
            this.txtNetWt.MaxLength = 10;
            this.txtNetWt.Name = "txtNetWt";
            this.txtNetWt.Size = new System.Drawing.Size(50, 20);
            this.txtNetWt.TabIndex = 6;
            this.txtNetWt.Leave += new System.EventHandler(this.txtGrsWt_Leave);
            // 
            // lblStyleNo
            // 
            this.lblStyleNo.AutoSize = true;
            this.lblStyleNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStyleNo.Location = new System.Drawing.Point(57, 69);
            this.lblStyleNo.Name = "lblStyleNo";
            this.lblStyleNo.Size = new System.Drawing.Size(53, 13);
            this.lblStyleNo.TabIndex = 1028;
            this.lblStyleNo.Text = "Style No :";
            // 
            // txtDiamondPcs
            // 
            this.txtDiamondPcs.AccessibleDescription = "Diamond Pcs";
            this.txtDiamondPcs.Location = new System.Drawing.Point(115, 176);
            this.txtDiamondPcs.MaxLength = 10;
            this.txtDiamondPcs.Name = "txtDiamondPcs";
            this.txtDiamondPcs.Size = new System.Drawing.Size(50, 20);
            this.txtDiamondPcs.TabIndex = 4;
            // 
            // btnImageUpload
            // 
            this.btnImageUpload.Location = new System.Drawing.Point(304, 129);
            this.btnImageUpload.Name = "btnImageUpload";
            this.btnImageUpload.Size = new System.Drawing.Size(75, 23);
            this.btnImageUpload.TabIndex = 8;
            this.btnImageUpload.Text = "Upload..";
            this.btnImageUpload.UseVisualStyleBackColor = true;
            this.btnImageUpload.Click += new System.EventHandler(this.btnimgUpload_Click);
            // 
            // jewelPictureBox
            // 
            this.jewelPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jewelPictureBox.Location = new System.Drawing.Point(304, 19);
            this.jewelPictureBox.Name = "jewelPictureBox";
            this.jewelPictureBox.Size = new System.Drawing.Size(113, 104);
            this.jewelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jewelPictureBox.TabIndex = 1026;
            this.jewelPictureBox.TabStop = false;
            this.jewelPictureBox.WaitOnLoad = true;
            // 
            // txtJewelNo
            // 
            this.txtJewelNo.AccessibleName = "Jewel No";
            this.txtJewelNo.CausesValidation = false;
            this.txtJewelNo.Enabled = false;
            this.txtJewelNo.Location = new System.Drawing.Point(115, 27);
            this.txtJewelNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtJewelNo.Name = "txtJewelNo";
            this.txtJewelNo.Size = new System.Drawing.Size(91, 20);
            this.txtJewelNo.TabIndex = 0;
            // 
            // lblJewelDesc
            // 
            this.lblJewelDesc.AutoSize = true;
            this.lblJewelDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJewelDesc.Location = new System.Drawing.Point(14, 104);
            this.lblJewelDesc.Name = "lblJewelDesc";
            this.lblJewelDesc.Size = new System.Drawing.Size(96, 13);
            this.lblJewelDesc.TabIndex = 1007;
            this.lblJewelDesc.Text = "Jewel Description :";
            // 
            // lblJewelNo
            // 
            this.lblJewelNo.AutoSize = true;
            this.lblJewelNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJewelNo.Location = new System.Drawing.Point(57, 34);
            this.lblJewelNo.Name = "lblJewelNo";
            this.lblJewelNo.Size = new System.Drawing.Size(57, 13);
            this.lblJewelNo.TabIndex = 1009;
            this.lblJewelNo.Text = "Jewel No :";
            // 
            // btnPrintSticker
            // 
            this.btnPrintSticker.Enabled = false;
            this.btnPrintSticker.Location = new System.Drawing.Point(29, 339);
            this.btnPrintSticker.Name = "btnPrintSticker";
            this.btnPrintSticker.Size = new System.Drawing.Size(75, 23);
            this.btnPrintSticker.TabIndex = 10;
            this.btnPrintSticker.Text = "Print Sticker";
            this.btnPrintSticker.UseVisualStyleBackColor = true;
            this.btnPrintSticker.Click += new System.EventHandler(this.btnPrintSticker_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.ShowReadOnly = true;
            this.fileDialog.Title = "Select jewel image to upload";
            this.fileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDialog_FileOk);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(450, 68);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(515, 285);
            this.crystalReportViewer1.TabIndex = 11;
            // 
            // frmJewelMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 518);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnPrintSticker);
            this.Name = "frmJewelMaster";
            this.Text = "frmJewelMaster";
            this.Controls.SetChildIndex(this.btnPrintSticker, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jewelPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox txtJewelNo;
		private System.Windows.Forms.Button btnImageUpload;
		private System.Windows.Forms.PictureBox jewelPictureBox;
        private System.Windows.Forms.Label lblJewelDesc;
		private System.Windows.Forms.Label lblJewelNo;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnPrintSticker;
        private System.Windows.Forms.Label lblMetalColor;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.Label lblStyleNo;
		private System.Windows.Forms.Label lblSlashDiamond;
        private System.Windows.Forms.Label lblDiamond;
		private System.Windows.Forms.Label lblSlashGold;
        private System.Windows.Forms.Label lblGold;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txtDiamondPcs;
        private System.Windows.Forms.TextBox txtNetWt;
        private System.Windows.Forms.TextBox txtDiamondWt;
        private System.Windows.Forms.ComboBox cboMetalColor;
        private System.Windows.Forms.ComboBox cboJewelDesc;
        private System.Windows.Forms.TextBox txtGrsWt;

    }
}