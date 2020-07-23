namespace JewelCatalogue
{
	partial class frmAllCatalogueProduct
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblTotItems = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuotationNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblGrsWt = new System.Windows.Forms.Label();
            this.lblGoldWeight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiamondPieces = new System.Windows.Forms.Label();
            this.lblDiamondWeight = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.JewelImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.JewelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JewelDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetalColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaPcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrsWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.SystemColors.Info;
            this.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProductName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProductName.Location = new System.Drawing.Point(10, 20);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(237, 40);
            this.lblProductName.TabIndex = 216;
            this.lblProductName.Text = "Product Name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotItems
            // 
            this.lblTotItems.AutoSize = true;
            this.lblTotItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotItems.Location = new System.Drawing.Point(686, 46);
            this.lblTotItems.Name = "lblTotItems";
            this.lblTotItems.Size = new System.Drawing.Size(77, 14);
            this.lblTotItems.TabIndex = 215;
            this.lblTotItems.Text = "Total Items";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuotationNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.lblGrsWt);
            this.groupBox1.Controls.Add(this.lblGoldWeight);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDiamondPieces);
            this.groupBox1.Controls.Add(this.lblDiamondWeight);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnDeselectAll);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(10, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(923, 108);
            this.groupBox1.TabIndex = 203;
            this.groupBox1.TabStop = false;
            // 
            // txtQuotationNo
            // 
            this.txtQuotationNo.Location = new System.Drawing.Point(104, 19);
            this.txtQuotationNo.MaxLength = 4;
            this.txtQuotationNo.Name = "txtQuotationNo";
            this.txtQuotationNo.Size = new System.Drawing.Size(76, 20);
            this.txtQuotationNo.TabIndex = 0;
            this.txtQuotationNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuotationNo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 164;
            this.label2.Text = "Quotation No :";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(299, 19);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(210, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomerName.Location = new System.Drawing.Point(186, 25);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(111, 14);
            this.lblCustomerName.TabIndex = 162;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // lblGrsWt
            // 
            this.lblGrsWt.AutoSize = true;
            this.lblGrsWt.BackColor = System.Drawing.Color.White;
            this.lblGrsWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrsWt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrsWt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGrsWt.Location = new System.Drawing.Point(815, 79);
            this.lblGrsWt.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblGrsWt.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblGrsWt.Name = "lblGrsWt";
            this.lblGrsWt.Size = new System.Drawing.Size(80, 20);
            this.lblGrsWt.TabIndex = 160;
            this.lblGrsWt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGoldWeight
            // 
            this.lblGoldWeight.AutoSize = true;
            this.lblGoldWeight.BackColor = System.Drawing.Color.White;
            this.lblGoldWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoldWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoldWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGoldWeight.Location = new System.Drawing.Point(719, 79);
            this.lblGoldWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblGoldWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblGoldWeight.Name = "lblGoldWeight";
            this.lblGoldWeight.Size = new System.Drawing.Size(80, 20);
            this.lblGoldWeight.TabIndex = 159;
            this.lblGoldWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(815, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 157;
            this.label7.Text = "Gold Pcs.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(719, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 158;
            this.label6.Text = "Gold Wt.";
            // 
            // lblDiamondPieces
            // 
            this.lblDiamondPieces.AutoSize = true;
            this.lblDiamondPieces.BackColor = System.Drawing.Color.White;
            this.lblDiamondPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiamondPieces.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiamondPieces.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamondPieces.Location = new System.Drawing.Point(625, 79);
            this.lblDiamondPieces.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblDiamondPieces.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblDiamondPieces.Name = "lblDiamondPieces";
            this.lblDiamondPieces.Size = new System.Drawing.Size(80, 20);
            this.lblDiamondPieces.TabIndex = 155;
            this.lblDiamondPieces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiamondWeight
            // 
            this.lblDiamondWeight.AutoSize = true;
            this.lblDiamondWeight.BackColor = System.Drawing.Color.White;
            this.lblDiamondWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiamondWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiamondWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamondWeight.Location = new System.Drawing.Point(529, 79);
            this.lblDiamondWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblDiamondWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblDiamondWeight.Name = "lblDiamondWeight";
            this.lblDiamondWeight.Size = new System.Drawing.Size(80, 20);
            this.lblDiamondWeight.TabIndex = 156;
            this.lblDiamondWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(429, 79);
            this.lblTotal.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 20);
            this.lblTotal.TabIndex = 153;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(625, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 152;
            this.label9.Text = "Dia. Pcs.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(529, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 151;
            this.label8.Text = "Dia. Wt.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(429, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 154;
            this.label5.Text = "Total Items";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeselectAll.Location = new System.Drawing.Point(175, 68);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(87, 31);
            this.btnDeselectAll.TabIndex = 4;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(90, 68);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(79, 31);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(5, 68);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(79, 31);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(268, 68);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 31);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvJewel
            // 
            this.dgvJewel.AllowUserToAddRows = false;
            this.dgvJewel.AllowUserToDeleteRows = false;
            this.dgvJewel.AllowUserToOrderColumns = true;
            this.dgvJewel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJewel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.JewelImage,
            this.JewelNo,
            this.StyleNo,
            this.JewelDesc,
            this.MetalColor,
            this.Path,
            this.DiaPcs,
            this.DiaWt,
            this.GrsWt,
            this.NetWt});
            this.dgvJewel.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvJewel.Location = new System.Drawing.Point(10, 73);
            this.dgvJewel.Name = "dgvJewel";
            this.dgvJewel.RowTemplate.Height = 24;
            this.dgvJewel.Size = new System.Drawing.Size(923, 337);
            this.dgvJewel.TabIndex = 217;
            this.dgvJewel.TabStop = false;
            // 
            // Select
            // 
            this.Select.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Select.HeaderText = "";
            this.Select.MinimumWidth = 30;
            this.Select.Name = "Select";
            this.Select.ToolTipText = "Select Product";
            this.Select.Width = 30;
            // 
            // JewelImage
            // 
            this.JewelImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.JewelImage.FillWeight = 50F;
            this.JewelImage.HeaderText = "Image";
            this.JewelImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.JewelImage.Name = "JewelImage";
            this.JewelImage.ReadOnly = true;
            this.JewelImage.ToolTipText = "Click here for Thumbnails";
            this.JewelImage.Width = 42;
            // 
            // JewelNo
            // 
            this.JewelNo.HeaderText = "Jewel No";
            this.JewelNo.Name = "JewelNo";
            this.JewelNo.ReadOnly = true;
            this.JewelNo.Width = 76;
            // 
            // StyleNo
            // 
            this.StyleNo.HeaderText = "Style No";
            this.StyleNo.Name = "StyleNo";
            this.StyleNo.ReadOnly = true;
            this.StyleNo.Width = 93;
            // 
            // JewelDesc
            // 
            this.JewelDesc.HeaderText = "Jewel Desc";
            this.JewelDesc.Name = "JewelDesc";
            this.JewelDesc.ReadOnly = true;
            this.JewelDesc.Width = 56;
            // 
            // MetalColor
            // 
            this.MetalColor.HeaderText = "Metal Color";
            this.MetalColor.Name = "MetalColor";
            this.MetalColor.ReadOnly = true;
            this.MetalColor.Width = 46;
            // 
            // Path
            // 
            this.Path.HeaderText = "Image Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.Visible = false;
            this.Path.Width = 5;
            // 
            // DiaPcs
            // 
            this.DiaPcs.HeaderText = "Dia Pcs";
            this.DiaPcs.Name = "DiaPcs";
            this.DiaPcs.ReadOnly = true;
            this.DiaPcs.Width = 69;
            // 
            // DiaWt
            // 
            this.DiaWt.HeaderText = "Dia Wt";
            this.DiaWt.Name = "DiaWt";
            this.DiaWt.ReadOnly = true;
            this.DiaWt.Width = 65;
            // 
            // GrsWt
            // 
            this.GrsWt.HeaderText = "Gold Pcs";
            this.GrsWt.Name = "GrsWt";
            this.GrsWt.ReadOnly = true;
            this.GrsWt.Width = 60;
            // 
            // NetWt
            // 
            this.NetWt.HeaderText = "Gold Wt";
            this.NetWt.Name = "NetWt";
            this.NetWt.ReadOnly = true;
            this.NetWt.Width = 66;
            // 
            // frmAllCatalogueProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 530);
            this.Controls.Add(this.dgvJewel);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblTotItems);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmAllCatalogueProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All  Products";
            this.Load += new System.EventHandler(this.frmAllCatalogueProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnProcess;
		internal System.Windows.Forms.Label lblTotItems;
		internal System.Windows.Forms.Button btnDeselectAll;
		internal System.Windows.Forms.Button btnSelectAll;
        internal System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblGrsWt;
        private System.Windows.Forms.Label lblGoldWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDiamondPieces;
        private System.Windows.Forms.Label lblDiamondWeight;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtQuotationNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewImageColumn JewelImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn JewelNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn JewelDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetalColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaPcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaWt;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrsWt;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWt;
	}
}