namespace JewelInventory
{
	public partial class frmExcelCostingRates
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
            this.components = new System.ComponentModel.Container();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtCosting = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupConsignmentIn = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUploadError = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnCosting = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExcelfile = new System.Windows.Forms.TextBox();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CERTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesignCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaPcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMetalCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStoneCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStampCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLbrCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colcertprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupConsignmentIn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Size = new System.Drawing.Size(922, 44);
            this.lblHeader.Text = "       Costing Rates";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(796, 600);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(724, 600);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(8, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(855, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(8, 578);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(856, 10);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(656, 600);
            this.btnNext.TabIndex = 1;
            this.btnNext.Visible = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(586, 600);
            this.btnPrev.Visible = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtDocNo);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtRemarks);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtContactName);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cboCustomer);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtCosting);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 52);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(854, 95);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Supplier Information";
            // 
            // txtDocNo
            // 
            this.txtDocNo.AccessibleName = "Document No";
            this.txtDocNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocNo.Location = new System.Drawing.Point(645, 19);
            this.txtDocNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocNo.MaxLength = 255;
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(136, 20);
            this.txtDocNo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(547, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Doc/ Ref Number :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.AccessibleName = "Remarks";
            this.txtRemarks.CausesValidation = false;
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Location = new System.Drawing.Point(341, 53);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarks.MaxLength = 255;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(194, 36);
            this.txtRemarks.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(289, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Remarks :";
            // 
            // txtContactName
            // 
            this.txtContactName.AccessibleName = "ContactName";
            this.txtContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactName.Location = new System.Drawing.Point(341, 22);
            this.txtContactName.Margin = new System.Windows.Forms.Padding(2);
            this.txtContactName.MaxLength = 255;
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(110, 20);
            this.txtContactName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(289, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Name :";
            // 
            // cboCustomer
            // 
            this.cboCustomer.AccessibleName = "Customer";
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(88, 53);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(181, 21);
            this.cboCustomer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(26, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Supplier :";
            // 
            // dtCosting
            // 
            this.dtCosting.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCosting.Location = new System.Drawing.Point(88, 22);
            this.dtCosting.Margin = new System.Windows.Forms.Padding(2);
            this.dtCosting.Name = "dtCosting";
            this.dtCosting.Size = new System.Drawing.Size(99, 20);
            this.dtCosting.TabIndex = 0;
            this.dtCosting.Value = new System.DateTime(2012, 4, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(41, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Date :";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupConsignmentIn
            // 
            this.groupConsignmentIn.BackColor = System.Drawing.Color.Transparent;
            this.groupConsignmentIn.Controls.Add(this.flowLayoutPanel1);
            this.groupConsignmentIn.Location = new System.Drawing.Point(8, 151);
            this.groupConsignmentIn.Name = "groupConsignmentIn";
            this.groupConsignmentIn.Size = new System.Drawing.Size(854, 418);
            this.groupConsignmentIn.TabIndex = 51;
            this.groupConsignmentIn.TabStop = false;
            this.groupConsignmentIn.Text = "Manage Purchase";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtUploadError);
            this.flowLayoutPanel1.Controls.Add(this.groupBox8);
            this.flowLayoutPanel1.Controls.Add(this.dgvJewel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(825, 377);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // txtUploadError
            // 
            this.txtUploadError.BackColor = System.Drawing.Color.White;
            this.txtUploadError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUploadError.CausesValidation = false;
            this.txtUploadError.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUploadError.ForeColor = System.Drawing.Color.Red;
            this.txtUploadError.Location = new System.Drawing.Point(10, 10);
            this.txtUploadError.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.txtUploadError.Multiline = true;
            this.txtUploadError.Name = "txtUploadError";
            this.txtUploadError.ReadOnly = true;
            this.txtUploadError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUploadError.Size = new System.Drawing.Size(1001, 1);
            this.txtUploadError.TabIndex = 4;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnCosting);
            this.groupBox8.Controls.Add(this.linkLabel1);
            this.groupBox8.Controls.Add(this.btnBrowseFile);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.txtExcelfile);
            this.groupBox8.Location = new System.Drawing.Point(10, 21);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(804, 53);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Upload Purchases Details";
            // 
            // btnCosting
            // 
            this.btnCosting.AutoSize = true;
            this.btnCosting.Location = new System.Drawing.Point(613, 27);
            this.btnCosting.Name = "btnCosting";
            this.btnCosting.Size = new System.Drawing.Size(73, 13);
            this.btnCosting.TabIndex = 1009;
            this.btnCosting.TabStop = true;
            this.btnCosting.Text = "Costing Rates";
            this.btnCosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCosting_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(691, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Download Sample File";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDownloadSample_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(436, 16);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(67, 23);
            this.btnBrowseFile.TabIndex = 1;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Upload select worksheet";
            // 
            // txtExcelfile
            // 
            this.txtExcelfile.CausesValidation = false;
            this.txtExcelfile.Location = new System.Drawing.Point(176, 19);
            this.txtExcelfile.Name = "txtExcelfile";
            this.txtExcelfile.Size = new System.Drawing.Size(254, 20);
            this.txtExcelfile.TabIndex = 0;
            // 
            // dgvJewel
            // 
            this.dgvJewel.AllowUserToAddRows = false;
            this.dgvJewel.AllowUserToDeleteRows = false;
            this.dgvJewel.AllowUserToOrderColumns = true;
            this.dgvJewel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJewel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.CERTNO,
            this.DesignCode,
            this.KT,
            this.GrWt,
            this.NetWt,
            this.DiaWt,
            this.DiaPcs,
            this.ColWt,
            this.ColPcs,
            this.ColMetalCharges,
            this.ColStoneCharges,
            this.ColStampCharges,
            this.ColLbrCharges,
            this.Colcertprice,
            this.ColTotalCharges});
            this.dgvJewel.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvJewel.Location = new System.Drawing.Point(10, 94);
            this.dgvJewel.Margin = new System.Windows.Forms.Padding(10);
            this.dgvJewel.Name = "dgvJewel";
            this.dgvJewel.RowTemplate.Height = 24;
            this.dgvJewel.Size = new System.Drawing.Size(804, 217);
            this.dgvJewel.TabIndex = 0;
            this.dgvJewel.TabStop = false;
            // 
            // Select
            // 
            this.Select.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Select.HeaderText = "";
            this.Select.MinimumWidth = 30;
            this.Select.Name = "Select";
            this.Select.ToolTipText = "Select Product";
            this.Select.Visible = false;
            this.Select.Width = 30;
            // 
            // CERTNO
            // 
            this.CERTNO.HeaderText = "CERTNO";
            this.CERTNO.Name = "CERTNO";
            this.CERTNO.ReadOnly = true;
            this.CERTNO.Width = 70;
            // 
            // DesignCode
            // 
            this.DesignCode.HeaderText = "DESIGNCODE";
            this.DesignCode.Name = "DesignCode";
            this.DesignCode.ReadOnly = true;
            // 
            // KT
            // 
            this.KT.HeaderText = "KT";
            this.KT.Name = "KT";
            this.KT.ReadOnly = true;
            this.KT.Width = 46;
            // 
            // GrWt
            // 
            this.GrWt.HeaderText = "GM WT";
            this.GrWt.Name = "GrWt";
            this.GrWt.ReadOnly = true;
            this.GrWt.Width = 80;
            // 
            // NetWt
            // 
            this.NetWt.HeaderText = "Net WT";
            this.NetWt.Name = "NetWt";
            this.NetWt.ReadOnly = true;
            this.NetWt.Width = 80;
            // 
            // DiaWt
            // 
            this.DiaWt.HeaderText = "DIA WT";
            this.DiaWt.Name = "DiaWt";
            this.DiaWt.ReadOnly = true;
            this.DiaWt.Width = 80;
            // 
            // DiaPcs
            // 
            this.DiaPcs.HeaderText = "DIA PCS";
            this.DiaPcs.Name = "DiaPcs";
            this.DiaPcs.ReadOnly = true;
            this.DiaPcs.Width = 80;
            // 
            // ColWt
            // 
            this.ColWt.HeaderText = "C.WT";
            this.ColWt.Name = "ColWt";
            this.ColWt.ReadOnly = true;
            this.ColWt.Width = 80;
            // 
            // ColPcs
            // 
            this.ColPcs.HeaderText = "C.PCS";
            this.ColPcs.Name = "ColPcs";
            this.ColPcs.ReadOnly = true;
            this.ColPcs.Width = 80;
            // 
            // ColMetalCharges
            // 
            this.ColMetalCharges.HeaderText = "G.AMT";
            this.ColMetalCharges.Name = "ColMetalCharges";
            // 
            // ColStoneCharges
            // 
            this.ColStoneCharges.HeaderText = "DIA.VAL";
            this.ColStoneCharges.Name = "ColStoneCharges";
            // 
            // ColStampCharges
            // 
            this.ColStampCharges.HeaderText = "STAMP";
            this.ColStampCharges.Name = "ColStampCharges";
            // 
            // ColLbrCharges
            // 
            this.ColLbrCharges.HeaderText = "LABR";
            this.ColLbrCharges.Name = "ColLbrCharges";
            // 
            // Colcertprice
            // 
            this.Colcertprice.HeaderText = "CERTPRICE";
            this.Colcertprice.Name = "Colcertprice";
            // 
            // ColTotalCharges
            // 
            this.ColTotalCharges.HeaderText = "AMT";
            this.ColTotalCharges.Name = "ColTotalCharges";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // frmExcelCostingRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(868, 638);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupConsignmentIn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExcelCostingRates";
            this.Text = "Costing Chart";
            this.Load += new System.EventHandler(this.frmCostingRates_Load);
            this.Controls.SetChildIndex(this.groupConsignmentIn, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupConsignmentIn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cboCustomer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtCosting;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtContactName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupConsignmentIn;
		private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TextBox txtUploadError;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button btnBrowseFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtExcelfile;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.DataGridView dgvJewel;
		private System.Windows.Forms.LinkLabel btnCosting;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
		private System.Windows.Forms.DataGridViewTextBoxColumn CERTNO;
		private System.Windows.Forms.DataGridViewTextBoxColumn DesignCode;
		private System.Windows.Forms.DataGridViewTextBoxColumn KT;
		private System.Windows.Forms.DataGridViewTextBoxColumn GrWt;
		private System.Windows.Forms.DataGridViewTextBoxColumn NetWt;
		private System.Windows.Forms.DataGridViewTextBoxColumn DiaWt;
		private System.Windows.Forms.DataGridViewTextBoxColumn DiaPcs;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColWt;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColPcs;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColMetalCharges;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColStoneCharges;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColStampCharges;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColLbrCharges;
		private System.Windows.Forms.DataGridViewTextBoxColumn Colcertprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalCharges;
    }
}