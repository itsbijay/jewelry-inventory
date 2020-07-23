namespace JewelInventory
{
	public partial class frmCostingRates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnCosting = new System.Windows.Forms.Button();
            this.btnClearAllItems = new System.Windows.Forms.Button();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.dgCostingFormat = new System.Windows.Forms.DataGridView();
            this.btnAddtoList = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupConsignmentIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCostingFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Size = new System.Drawing.Size(879, 44);
            this.lblHeader.Text = "       Purchase Transaction";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(801, 595);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(729, 595);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(8, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(857, 9);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(8, 575);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(857, 8);
            this.groupBox2.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(661, 595);
            this.btnNext.TabIndex = 0;
            this.btnNext.Visible = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(591, 595);
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
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(8, 58);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(858, 95);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Supplier Information";
            // 
            // txtDocNo
            // 
            this.txtDocNo.AccessibleName = "Document No";
            this.txtDocNo.CausesValidation = false;
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
            this.txtContactName.Size = new System.Drawing.Size(151, 20);
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
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // groupConsignmentIn
            // 
            this.groupConsignmentIn.Controls.Add(this.btnCosting);
            this.groupConsignmentIn.Controls.Add(this.btnClearAllItems);
            this.groupConsignmentIn.Controls.Add(this.btnClearGrid);
            this.groupConsignmentIn.Controls.Add(this.flowLayout);
            this.groupConsignmentIn.Controls.Add(this.dgCostingFormat);
            this.groupConsignmentIn.Controls.Add(this.btnAddtoList);
            this.groupConsignmentIn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupConsignmentIn.Location = new System.Drawing.Point(8, 157);
            this.groupConsignmentIn.Name = "groupConsignmentIn";
            this.groupConsignmentIn.Size = new System.Drawing.Size(858, 417);
            this.groupConsignmentIn.TabIndex = 51;
            this.groupConsignmentIn.TabStop = false;
            this.groupConsignmentIn.Text = "Manage Purchase";
            // 
            // btnCosting
            // 
            this.btnCosting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCosting.Location = new System.Drawing.Point(325, 310);
            this.btnCosting.Name = "btnCosting";
            this.btnCosting.Size = new System.Drawing.Size(41, 23);
            this.btnCosting.TabIndex = 4;
            this.btnCosting.Text = "....";
            this.btnCosting.UseVisualStyleBackColor = true;
            this.btnCosting.Click += new System.EventHandler(this.btnCosting_Click);
            // 
            // btnClearAllItems
            // 
            this.btnClearAllItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearAllItems.Location = new System.Drawing.Point(223, 310);
            this.btnClearAllItems.Name = "btnClearAllItems";
            this.btnClearAllItems.Size = new System.Drawing.Size(96, 23);
            this.btnClearAllItems.TabIndex = 3;
            this.btnClearAllItems.Text = "Clear All Items >>";
            this.btnClearAllItems.UseVisualStyleBackColor = true;
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearGrid.Location = new System.Drawing.Point(119, 310);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(96, 23);
            this.btnClearGrid.TabIndex = 2;
            this.btnClearGrid.Text = "Refresh Grid >>";
            this.btnClearGrid.UseVisualStyleBackColor = true;
            // 
            // flowLayout
            // 
            this.flowLayout.AutoScroll = true;
            this.flowLayout.AutoSize = true;
            this.flowLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayout.Location = new System.Drawing.Point(11, 339);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayout.Size = new System.Drawing.Size(839, 58);
            this.flowLayout.TabIndex = 5;
            // 
            // dgCostingFormat
            // 
            this.dgCostingFormat.AllowUserToAddRows = false;
            this.dgCostingFormat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgCostingFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCostingFormat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCostingFormat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgCostingFormat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgCostingFormat.Location = new System.Drawing.Point(11, 19);
            this.dgCostingFormat.MultiSelect = false;
            this.dgCostingFormat.Name = "dgCostingFormat";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCostingFormat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgCostingFormat.RowHeadersVisible = false;
            this.dgCostingFormat.RowHeadersWidth = 50;
            this.dgCostingFormat.RowTemplate.Height = 25;
            this.dgCostingFormat.Size = new System.Drawing.Size(839, 284);
            this.dgCostingFormat.TabIndex = 0;
            // 
            // btnAddtoList
            // 
            this.btnAddtoList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddtoList.Location = new System.Drawing.Point(11, 313);
            this.btnAddtoList.Name = "btnAddtoList";
            this.btnAddtoList.Size = new System.Drawing.Size(96, 20);
            this.btnAddtoList.TabIndex = 1;
            this.btnAddtoList.Text = "Add To List >>";
            this.btnAddtoList.UseVisualStyleBackColor = true;
            // 
            // frmCostingRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(878, 638);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupConsignmentIn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCostingRates";
            this.Text = "Costing Chart";
            this.Load += new System.EventHandler(this.frmCostingRates_Load);
            this.Controls.SetChildIndex(this.groupConsignmentIn, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupConsignmentIn.ResumeLayout(false);
            this.groupConsignmentIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCostingFormat)).EndInit();
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
        private System.Windows.Forms.DataGridView dgCostingFormat;
		private System.Windows.Forms.TextBox txtDocNo;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddtoList;
		private System.Windows.Forms.FlowLayoutPanel flowLayout;
		private System.Windows.Forms.Button btnClearAllItems;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.Button btnCosting;
    }
}