namespace JewelInventory
{
	partial class frmManageTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.cboTran = new System.Windows.Forms.ComboBox();
            this.cboTranType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.lnkRTS = new System.Windows.Forms.LinkLabel();
            this.lblCostingChart = new System.Windows.Forms.LinkLabel();
            this.lnkExportTag = new System.Windows.Forms.LinkLabel();
            this.lnkExportSticker = new System.Windows.Forms.LinkLabel();
            this.groupBox3.SuspendLayout();
            this.grpSupplier.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(923, 44);
            this.lblHeader.Text = "       Manage Transactions";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(817, 541);
            this.btnCancel.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(746, 541);
            this.btnSave.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 43);
            this.groupBox1.Size = new System.Drawing.Size(884, 11);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-21, 541);
            this.groupBox2.Size = new System.Drawing.Size(944, 0);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(682, 541);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(617, 541);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.grpSupplier);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnGo);
            this.groupBox3.Controls.Add(this.cboTran);
            this.groupBox3.Controls.Add(this.cboTranType);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(6, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 68);
            this.groupBox3.TabIndex = 1010;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter Transaction Lookup";
            // 
            // grpSupplier
            // 
            this.grpSupplier.Controls.Add(this.label4);
            this.grpSupplier.Controls.Add(this.cboSupplier);
            this.grpSupplier.Controls.Add(this.grpCustomer);
            this.grpSupplier.Location = new System.Drawing.Point(285, 19);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(234, 37);
            this.grpSupplier.TabIndex = 1024;
            this.grpSupplier.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1023;
            this.label4.Text = "  Supplier :";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(66, 12);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(162, 21);
            this.cboSupplier.TabIndex = 0;
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.label3);
            this.grpCustomer.Controls.Add(this.cboCustomer);
            this.grpCustomer.Location = new System.Drawing.Point(0, 0);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(234, 37);
            this.grpCustomer.TabIndex = 1022;
            this.grpCustomer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1023;
            this.label3.Text = "Customer :";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(66, 13);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(162, 21);
            this.cboCustomer.TabIndex = 1022;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(531, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1020;
            this.label2.Text = "Transactions :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(26, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1019;
            this.label1.Text = "Transaction Type :";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(741, 32);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cboTran
            // 
            this.cboTran.FormattingEnabled = true;
            this.cboTran.Location = new System.Drawing.Point(609, 33);
            this.cboTran.Name = "cboTran";
            this.cboTran.Size = new System.Drawing.Size(121, 21);
            this.cboTran.TabIndex = 1;
            // 
            // cboTranType
            // 
            this.cboTranType.FormattingEnabled = true;
            this.cboTranType.Location = new System.Drawing.Point(123, 33);
            this.cboTranType.Name = "cboTranType";
            this.cboTranType.Size = new System.Drawing.Size(142, 21);
            this.cboTranType.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.chkSelectAll);
            this.groupBox4.Controls.Add(this.dgvJewel);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(6, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(885, 384);
            this.groupBox4.TabIndex = 1011;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transactions";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(11, 16);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // dgvJewel
            // 
            this.dgvJewel.AllowUserToAddRows = false;
            this.dgvJewel.AllowUserToResizeRows = false;
            this.dgvJewel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvJewel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJewel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJewel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJewel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJewel.Location = new System.Drawing.Point(10, 33);
            this.dgvJewel.MultiSelect = false;
            this.dgvJewel.Name = "dgvJewel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJewel.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvJewel.RowHeadersVisible = false;
            this.dgvJewel.RowHeadersWidth = 50;
            this.dgvJewel.RowTemplate.Height = 25;
            this.dgvJewel.Size = new System.Drawing.Size(865, 341);
            this.dgvJewel.TabIndex = 0;
            this.dgvJewel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJewel_CellClick);
            this.dgvJewel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJewel_CellContentClick);
            // 
            // lnkRTS
            // 
            this.lnkRTS.AutoSize = true;
            this.lnkRTS.Location = new System.Drawing.Point(307, 528);
            this.lnkRTS.Name = "lnkRTS";
            this.lnkRTS.Size = new System.Drawing.Size(86, 13);
            this.lnkRTS.TabIndex = 3;
            this.lnkRTS.TabStop = true;
            this.lnkRTS.Text = "Return To Stock";
            this.lnkRTS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRTS_LinkClicked);
            // 
            // lblCostingChart
            // 
            this.lblCostingChart.AutoSize = true;
            this.lblCostingChart.Location = new System.Drawing.Point(28, 528);
            this.lblCostingChart.Name = "lblCostingChart";
            this.lblCostingChart.Size = new System.Drawing.Size(103, 13);
            this.lblCostingChart.TabIndex = 0;
            this.lblCostingChart.TabStop = true;
            this.lblCostingChart.Text = "Export Costing Chart";
            this.lblCostingChart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCostingChart_LinkClicked);
            // 
            // lnkExportTag
            // 
            this.lnkExportTag.AutoSize = true;
            this.lnkExportTag.Location = new System.Drawing.Point(147, 528);
            this.lnkExportTag.Name = "lnkExportTag";
            this.lnkExportTag.Size = new System.Drawing.Size(59, 13);
            this.lnkExportTag.TabIndex = 1;
            this.lnkExportTag.TabStop = true;
            this.lnkExportTag.Text = "Export Tag";
            this.lnkExportTag.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExportTag_LinkClicked);
            // 
            // lnkExportSticker
            // 
            this.lnkExportSticker.AutoSize = true;
            this.lnkExportSticker.Location = new System.Drawing.Point(220, 528);
            this.lnkExportSticker.Name = "lnkExportSticker";
            this.lnkExportSticker.Size = new System.Drawing.Size(73, 13);
            this.lnkExportSticker.TabIndex = 2;
            this.lnkExportSticker.TabStop = true;
            this.lnkExportSticker.Text = "Export Sticker";
            this.lnkExportSticker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExportSticker_LinkClicked);
            // 
            // frmManageTransaction
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(906, 599);
            this.Controls.Add(this.lnkExportSticker);
            this.Controls.Add(this.lnkExportTag);
            this.Controls.Add(this.lblCostingChart);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lnkRTS);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmManageTransaction";
            this.Text = "Manage Transactions";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.lnkRTS, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.lblCostingChart, 0);
            this.Controls.SetChildIndex(this.lnkExportTag, 0);
            this.Controls.SetChildIndex(this.lnkExportSticker, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpSupplier.ResumeLayout(false);
            this.grpSupplier.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox cboTran;
		private System.Windows.Forms.ComboBox cboTranType;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.LinkLabel lnkRTS;
        private System.Windows.Forms.LinkLabel lblCostingChart;
        private System.Windows.Forms.LinkLabel lnkExportTag;
        private System.Windows.Forms.LinkLabel lnkExportSticker;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.GroupBox grpSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.CheckBox chkSelectAll;

	}
}