namespace JewelCatalogue
{
    partial class frmAllJewelsBarcodePrint
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPageNos = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblTotItems = new System.Windows.Forms.Label();
            this.btnGenerateBarcode = new System.Windows.Forms.Button();
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
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(698, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(492, 186);
            this.crystalReportViewer1.TabIndex = 176;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 14);
            this.label4.TabIndex = 173;
            this.label4.Text = "Select Page No :";
            // 
            // cmbPageNos
            // 
            this.cmbPageNos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPageNos.FormattingEnabled = true;
            this.cmbPageNos.Location = new System.Drawing.Point(366, 371);
            this.cmbPageNos.Name = "cmbPageNos";
            this.cmbPageNos.Size = new System.Drawing.Size(72, 22);
            this.cmbPageNos.TabIndex = 168;
            this.cmbPageNos.SelectedIndexChanged += new System.EventHandler(this.cmbPageNos_SelectedIndexChanged);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(366, 420);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 29);
            this.btnNext.TabIndex = 170;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(249, 420);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(81, 29);
            this.btnPrevious.TabIndex = 169;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblTotItems
            // 
            this.lblTotItems.AutoSize = true;
            this.lblTotItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotItems.Location = new System.Drawing.Point(698, 247);
            this.lblTotItems.Name = "lblTotItems";
            this.lblTotItems.Size = new System.Drawing.Size(77, 14);
            this.lblTotItems.TabIndex = 174;
            this.lblTotItems.Text = "Total Items";
            // 
            // btnGenerateBarcode
            // 
            this.btnGenerateBarcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBarcode.Location = new System.Drawing.Point(876, 215);
            this.btnGenerateBarcode.Name = "btnGenerateBarcode";
            this.btnGenerateBarcode.Size = new System.Drawing.Size(124, 29);
            this.btnGenerateBarcode.TabIndex = 177;
            this.btnGenerateBarcode.Text = "Generate Barcode";
            this.btnGenerateBarcode.UseVisualStyleBackColor = true;
            this.btnGenerateBarcode.Click += new System.EventHandler(this.btnGenerateBarcode_Click);
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
            this.dgvJewel.Location = new System.Drawing.Point(3, 12);
            this.dgvJewel.Name = "dgvJewel";
            this.dgvJewel.RowTemplate.Height = 24;
            this.dgvJewel.Size = new System.Drawing.Size(689, 354);
            this.dgvJewel.TabIndex = 175;
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
            this.StyleNo.Width = 76;
            // 
            // JewelDesc
            // 
            this.JewelDesc.HeaderText = "Jewel Desc";
            this.JewelDesc.Name = "JewelDesc";
            this.JewelDesc.ReadOnly = true;
            this.JewelDesc.Width = 76;
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
            this.DiaPcs.Width = 40;
            // 
            // DiaWt
            // 
            this.DiaWt.HeaderText = "Dia Wt";
            this.DiaWt.Name = "DiaWt";
            this.DiaWt.ReadOnly = true;
            this.DiaWt.Width = 50;
            // 
            // GrsWt
            // 
            this.GrsWt.HeaderText = "Gold Pcs";
            this.GrsWt.Name = "GrsWt";
            this.GrsWt.ReadOnly = true;
            this.GrsWt.Width = 40;
            // 
            // NetWt
            // 
            this.NetWt.HeaderText = "Gold Wt";
            this.NetWt.Name = "NetWt";
            this.NetWt.ReadOnly = true;
            this.NetWt.Width = 50;
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeselectAll.Location = new System.Drawing.Point(783, 213);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(87, 31);
            this.btnDeselectAll.TabIndex = 179;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(698, 213);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(79, 31);
            this.btnSelectAll.TabIndex = 178;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1006, 215);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 29);
            this.btnClose.TabIndex = 180;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAllJewelsBarcodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1192, 622);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnGenerateBarcode);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.dgvJewel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPageNos);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblTotItems);
            this.Name = "frmAllJewelsBarcodePrint";
            this.Text = "All Jewels Barcode Print";
            this.Load += new System.EventHandler(this.frmAllJewelsBarcodePrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbPageNos;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button btnPrevious;
        internal System.Windows.Forms.Label lblTotItems;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        internal System.Windows.Forms.Button btnGenerateBarcode;
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
        internal System.Windows.Forms.Button btnDeselectAll;
        internal System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClose;
    }
}