namespace JewelCatalogue
{
	partial class frmCatalogue
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.grpfilters = new System.Windows.Forms.GroupBox();
            this.lblSeWt = new System.Windows.Forms.Label();
            this.cmbWeight = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtWeightTo = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtWeightFrom = new System.Windows.Forms.TextBox();
            this.lnkfilter = new System.Windows.Forms.LinkLabel();
            this.txtQuotationNo = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGrsWt = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblGoldWeight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiamondPieces = new System.Windows.Forms.Label();
            this.lblDiamondWeight = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnJewelDescription = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbJewelDescription = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.grpfilters.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvJewel.Location = new System.Drawing.Point(12, 12);
            this.dgvJewel.Name = "dgvJewel";
            this.dgvJewel.RowTemplate.Height = 24;
            this.dgvJewel.Size = new System.Drawing.Size(898, 412);
            this.dgvJewel.TabIndex = 151;
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
            this.JewelImage.Width = 47;
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
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.grpfilters);
            this.GroupBox1.Controls.Add(this.lnkfilter);
            this.GroupBox1.Controls.Add(this.txtQuotationNo);
            this.GroupBox1.Controls.Add(this.txtCustomerName);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.lblGrsWt);
            this.GroupBox1.Controls.Add(this.lblCustomerName);
            this.GroupBox1.Controls.Add(this.lblGoldWeight);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.lblDiamondPieces);
            this.GroupBox1.Controls.Add(this.lblDiamondWeight);
            this.GroupBox1.Controls.Add(this.lblTotal);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.btnSelectAll);
            this.GroupBox1.Controls.Add(this.btnJewelDescription);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cmbJewelDescription);
            this.GroupBox1.Controls.Add(this.btnClose);
            this.GroupBox1.Controls.Add(this.btnNewOrder);
            this.GroupBox1.Controls.Add(this.btnProcess);
            this.GroupBox1.Location = new System.Drawing.Point(12, 433);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox1.Size = new System.Drawing.Size(898, 187);
            this.GroupBox1.TabIndex = 170;
            this.GroupBox1.TabStop = false;
            // 
            // grpfilters
            // 
            this.grpfilters.Controls.Add(this.lblSeWt);
            this.grpfilters.Controls.Add(this.cmbWeight);
            this.grpfilters.Controls.Add(this.lblTo);
            this.grpfilters.Controls.Add(this.txtWeightTo);
            this.grpfilters.Controls.Add(this.lblFrom);
            this.grpfilters.Controls.Add(this.txtWeightFrom);
            this.grpfilters.Location = new System.Drawing.Point(116, 53);
            this.grpfilters.Name = "grpfilters";
            this.grpfilters.Size = new System.Drawing.Size(493, 58);
            this.grpfilters.TabIndex = 201;
            this.grpfilters.TabStop = false;
            this.grpfilters.Text = "Filters";
            // 
            // lblSeWt
            // 
            this.lblSeWt.AutoSize = true;
            this.lblSeWt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeWt.Location = new System.Drawing.Point(257, 26);
            this.lblSeWt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeWt.Name = "lblSeWt";
            this.lblSeWt.Size = new System.Drawing.Size(91, 14);
            this.lblSeWt.TabIndex = 48;
            this.lblSeWt.Text = "Diamond Wt :";
            // 
            // cmbWeight
            // 
            this.cmbWeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeight.FormattingEnabled = true;
            this.cmbWeight.Items.AddRange(new object[] {
            "Diamond Wt",
            "Gr Wt",
            "Net Wt",
            "Diamond Pcs"});
            this.cmbWeight.Location = new System.Drawing.Point(356, 18);
            this.cmbWeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbWeight.Name = "cmbWeight";
            this.cmbWeight.Size = new System.Drawing.Size(130, 22);
            this.cmbWeight.TabIndex = 47;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(143, 26);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(30, 14);
            this.lblTo.TabIndex = 38;
            this.lblTo.Text = "To :";
            // 
            // txtWeightTo
            // 
            this.txtWeightTo.Location = new System.Drawing.Point(175, 18);
            this.txtWeightTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWeightTo.MaxLength = 9;
            this.txtWeightTo.Name = "txtWeightTo";
            this.txtWeightTo.Size = new System.Drawing.Size(74, 22);
            this.txtWeightTo.TabIndex = 37;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(10, 26);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 14);
            this.lblFrom.TabIndex = 39;
            this.lblFrom.Text = "From :";
            // 
            // txtWeightFrom
            // 
            this.txtWeightFrom.Location = new System.Drawing.Point(61, 18);
            this.txtWeightFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWeightFrom.MaxLength = 9;
            this.txtWeightFrom.Name = "txtWeightFrom";
            this.txtWeightFrom.Size = new System.Drawing.Size(74, 22);
            this.txtWeightFrom.TabIndex = 36;
            // 
            // lnkfilter
            // 
            this.lnkfilter.AutoSize = true;
            this.lnkfilter.Location = new System.Drawing.Point(9, 79);
            this.lnkfilter.Name = "lnkfilter";
            this.lnkfilter.Size = new System.Drawing.Size(84, 14);
            this.lnkfilter.TabIndex = 200;
            this.lnkfilter.TabStop = true;
            this.lnkfilter.Text = "Advance Filter";
            this.lnkfilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkfilter_LinkClicked);
            // 
            // txtQuotationNo
            // 
            this.txtQuotationNo.Location = new System.Drawing.Point(107, 21);
            this.txtQuotationNo.MaxLength = 4;
            this.txtQuotationNo.Name = "txtQuotationNo";
            this.txtQuotationNo.Size = new System.Drawing.Size(75, 22);
            this.txtQuotationNo.TabIndex = 7;
            this.txtQuotationNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuotationNo_KeyPress);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerName.Location = new System.Drawing.Point(301, 21);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(210, 22);
            this.txtCustomerName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 172;
            this.label2.Text = "Quotation No :";
            // 
            // lblGrsWt
            // 
            this.lblGrsWt.AutoSize = true;
            this.lblGrsWt.BackColor = System.Drawing.Color.White;
            this.lblGrsWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrsWt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrsWt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGrsWt.Location = new System.Drawing.Point(678, 145);
            this.lblGrsWt.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblGrsWt.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblGrsWt.Name = "lblGrsWt";
            this.lblGrsWt.Size = new System.Drawing.Size(80, 20);
            this.lblGrsWt.TabIndex = 150;
            this.lblGrsWt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomerName.Location = new System.Drawing.Point(188, 27);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(111, 14);
            this.lblCustomerName.TabIndex = 172;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // lblGoldWeight
            // 
            this.lblGoldWeight.AutoSize = true;
            this.lblGoldWeight.BackColor = System.Drawing.Color.White;
            this.lblGoldWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoldWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoldWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGoldWeight.Location = new System.Drawing.Point(582, 145);
            this.lblGoldWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblGoldWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblGoldWeight.Name = "lblGoldWeight";
            this.lblGoldWeight.Size = new System.Drawing.Size(80, 20);
            this.lblGoldWeight.TabIndex = 149;
            this.lblGoldWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(678, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 147;
            this.label7.Text = "Gold Pcs.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(582, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 148;
            this.label6.Text = "Gold Wt.";
            // 
            // lblDiamondPieces
            // 
            this.lblDiamondPieces.AutoSize = true;
            this.lblDiamondPieces.BackColor = System.Drawing.Color.White;
            this.lblDiamondPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiamondPieces.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiamondPieces.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamondPieces.Location = new System.Drawing.Point(488, 145);
            this.lblDiamondPieces.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblDiamondPieces.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblDiamondPieces.Name = "lblDiamondPieces";
            this.lblDiamondPieces.Size = new System.Drawing.Size(80, 20);
            this.lblDiamondPieces.TabIndex = 145;
            this.lblDiamondPieces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiamondWeight
            // 
            this.lblDiamondWeight.AutoSize = true;
            this.lblDiamondWeight.BackColor = System.Drawing.Color.White;
            this.lblDiamondWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiamondWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiamondWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamondWeight.Location = new System.Drawing.Point(392, 145);
            this.lblDiamondWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblDiamondWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblDiamondWeight.Name = "lblDiamondWeight";
            this.lblDiamondWeight.Size = new System.Drawing.Size(80, 20);
            this.lblDiamondWeight.TabIndex = 146;
            this.lblDiamondWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(292, 145);
            this.lblTotal.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 20);
            this.lblTotal.TabIndex = 143;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(488, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 142;
            this.label9.Text = "Dia. Pcs.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(392, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 141;
            this.label8.Text = "Dia. Wt.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(292, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 144;
            this.label5.Text = "Total Items";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(742, 71);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(70, 24);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Text = "&Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnJewelDescription
            // 
            this.btnJewelDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJewelDescription.Location = new System.Drawing.Point(658, 69);
            this.btnJewelDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnJewelDescription.Name = "btnJewelDescription";
            this.btnJewelDescription.Size = new System.Drawing.Size(76, 24);
            this.btnJewelDescription.TabIndex = 5;
            this.btnJewelDescription.Text = "&Jewel";
            this.btnJewelDescription.UseVisualStyleBackColor = true;
            this.btnJewelDescription.Click += new System.EventHandler(this.btnJewelDescription_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(533, 29);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(122, 14);
            this.Label1.TabIndex = 140;
            this.Label1.Text = "Jewel Description :";
            // 
            // cmbJewelDescription
            // 
            this.cmbJewelDescription.FormattingEnabled = true;
            this.cmbJewelDescription.Location = new System.Drawing.Point(658, 21);
            this.cmbJewelDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbJewelDescription.Name = "cmbJewelDescription";
            this.cmbJewelDescription.Size = new System.Drawing.Size(156, 22);
            this.cmbJewelDescription.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(185, 141);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 31);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewOrder.Location = new System.Drawing.Point(98, 141);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(79, 31);
            this.btnNewOrder.TabIndex = 10;
            this.btnNewOrder.Text = "New Order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(11, 141);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(79, 31);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // frmCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 624);
            this.Controls.Add(this.dgvJewel);
            this.Controls.Add(this.GroupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCatalogue";
            this.Text = "Product Catalogue";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.grpfilters.ResumeLayout(false);
            this.grpfilters.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnNewOrder;
		internal System.Windows.Forms.Button btnProcess;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSelectAll;
        internal System.Windows.Forms.Button btnJewelDescription;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbJewelDescription;
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
        public System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtQuotationNo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.LinkLabel lnkfilter;
        private System.Windows.Forms.GroupBox grpfilters;
        internal System.Windows.Forms.Label lblSeWt;
        internal System.Windows.Forms.ComboBox cmbWeight;
        internal System.Windows.Forms.Label lblTo;
        internal System.Windows.Forms.TextBox txtWeightTo;
        internal System.Windows.Forms.Label lblFrom;
        internal System.Windows.Forms.TextBox txtWeightFrom;
	}
}