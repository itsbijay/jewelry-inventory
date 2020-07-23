namespace JewelCatalogue
{
	partial class frmProduct
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
			this.lblTotItems = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbPageNos = new System.Windows.Forms.ComboBox();
			this.lblProductName = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnHome = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
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
			((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTotItems
			// 
			this.lblTotItems.AutoSize = true;
			this.lblTotItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotItems.Location = new System.Drawing.Point(663, 48);
			this.lblTotItems.Name = "lblTotItems";
			this.lblTotItems.Size = new System.Drawing.Size(77, 14);
			this.lblTotItems.TabIndex = 166;
			this.lblTotItems.Text = "Total Items";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(15, 534);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 14);
			this.label4.TabIndex = 165;
			this.label4.Text = "Select Page No :";
			// 
			// cmbPageNos
			// 
			this.cmbPageNos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbPageNos.FormattingEnabled = true;
			this.cmbPageNos.Location = new System.Drawing.Point(135, 531);
			this.cmbPageNos.Name = "cmbPageNos";
			this.cmbPageNos.Size = new System.Drawing.Size(72, 22);
			this.cmbPageNos.TabIndex = 0;
			this.cmbPageNos.SelectedIndexChanged += new System.EventHandler(this.cmbPageNos_SelectedIndexChanged);
			// 
			// lblProductName
			// 
			this.lblProductName.BackColor = System.Drawing.SystemColors.Info;
			this.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblProductName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProductName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblProductName.Location = new System.Drawing.Point(18, 22);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(237, 40);
			this.lblProductName.TabIndex = 163;
			this.lblProductName.Text = "Product Name";
			this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnNext
			// 
			this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(479, 524);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(81, 29);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next >";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnHome
			// 
			this.btnHome.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHome.Location = new System.Drawing.Point(883, 524);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(81, 29);
			this.btnHome.TabIndex = 3;
			this.btnHome.Text = "Home";
			this.btnHome.UseVisualStyleBackColor = true;
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrevious.Location = new System.Drawing.Point(381, 524);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(81, 29);
			this.btnPrevious.TabIndex = 1;
			this.btnPrevious.Text = "< Previous";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
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
			this.dgvJewel.Location = new System.Drawing.Point(20, 65);
			this.dgvJewel.Name = "dgvJewel";
			this.dgvJewel.RowTemplate.Height = 24;
			this.dgvJewel.Size = new System.Drawing.Size(946, 440);
			this.dgvJewel.TabIndex = 167;
			this.dgvJewel.TabStop = false;
			this.dgvJewel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJewel_CellClick);
			this.dgvJewel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJewel_CellContentClick);
			this.dgvJewel.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvJewel_CellMouseMove);
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
			this.JewelImage.Width = 46;
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
			// frmProduct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(978, 587);
			this.Controls.Add(this.dgvJewel);
			this.Controls.Add(this.lblTotItems);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbPageNos);
			this.Controls.Add(this.lblProductName);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnHome);
			this.Controls.Add(this.btnPrevious);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.Name = "frmProduct";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Products";
			this.Load += new System.EventHandler(this.frmProduct_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProduct_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label lblTotItems;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.ComboBox cmbPageNos;
		internal System.Windows.Forms.Label lblProductName;
		internal System.Windows.Forms.Button btnNext;
		internal System.Windows.Forms.Button btnHome;
        internal System.Windows.Forms.Button btnPrevious;
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

