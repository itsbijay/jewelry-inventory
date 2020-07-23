namespace JewelInventory
{
    partial class frmCostingValuation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnCostingValuation = new System.Windows.Forms.Button();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDataControl = new System.Windows.Forms.DataGridView();
            this.dgid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgparticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgminimumamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataControl)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(597, 44);
            this.lblHeader.Text = "       Costing Valuation";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(494, 448);
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(421, 448);
            this.btnSave.Size = new System.Drawing.Size(71, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(9, 41);
            this.groupBox1.Size = new System.Drawing.Size(556, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(9, 427);
            this.groupBox2.Size = new System.Drawing.Size(556, 10);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(348, 449);
            this.btnNext.Size = new System.Drawing.Size(71, 23);
            this.btnNext.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(275, 449);
            this.btnPrev.Size = new System.Drawing.Size(71, 23);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnCostingValuation);
            this.groupBox9.Controls.Add(this.dtToDate);
            this.groupBox9.Controls.Add(this.dtFromDate);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.dgDataControl);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox9.Location = new System.Drawing.Point(9, 59);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(556, 367);
            this.groupBox9.TabIndex = 1014;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Costing Valuation Report";
            // 
            // btnCostingValuation
            // 
            this.btnCostingValuation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCostingValuation.Location = new System.Drawing.Point(384, 26);
            this.btnCostingValuation.Name = "btnCostingValuation";
            this.btnCostingValuation.Size = new System.Drawing.Size(75, 23);
            this.btnCostingValuation.TabIndex = 2;
            this.btnCostingValuation.Text = "Show";
            this.btnCostingValuation.UseVisualStyleBackColor = true;
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(245, 27);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(112, 20);
            this.dtToDate.TabIndex = 1;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(68, 27);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtFromDate.TabIndex = 0;
            this.dtFromDate.Value = new System.DateTime(2014, 4, 24, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(191, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "From Date";
            // 
            // dgDataControl
            // 
            this.dgDataControl.AllowUserToAddRows = false;
            this.dgDataControl.AllowUserToResizeRows = false;
            this.dgDataControl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDataControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDataControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgid,
            this.category,
            this.dgparticulars,
            this.dgtype,
            this.dgamount,
            this.dgminimumamount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDataControl.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgDataControl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgDataControl.Location = new System.Drawing.Point(6, 75);
            this.dgDataControl.Name = "dgDataControl";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDataControl.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgDataControl.RowHeadersVisible = false;
            this.dgDataControl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.NullValue = "000.00";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDataControl.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDataControl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgDataControl.Size = new System.Drawing.Size(541, 281);
            this.dgDataControl.TabIndex = 3;
            // 
            // dgid
            // 
            this.dgid.HeaderText = "Id";
            this.dgid.Name = "dgid";
            this.dgid.ReadOnly = true;
            this.dgid.Visible = false;
            // 
            // category
            // 
            this.category.HeaderText = "CATEGORY";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // dgparticulars
            // 
            this.dgparticulars.HeaderText = "DGPARTICULARS";
            this.dgparticulars.Name = "dgparticulars";
            this.dgparticulars.ReadOnly = true;
            this.dgparticulars.Width = 110;
            // 
            // dgtype
            // 
            this.dgtype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgtype.DividerWidth = 2;
            this.dgtype.HeaderText = "TYPE";
            this.dgtype.Name = "dgtype";
            this.dgtype.ReadOnly = true;
            this.dgtype.Width = 120;
            // 
            // dgamount
            // 
            this.dgamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgamount.DividerWidth = 2;
            this.dgamount.HeaderText = "Amount (Rs.)";
            this.dgamount.Name = "dgamount";
            this.dgamount.ToolTipText = "Amount per gram";
            // 
            // dgminimumamount
            // 
            this.dgminimumamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgminimumamount.HeaderText = "Minimum Amount (Rs.)";
            this.dgminimumamount.Name = "dgminimumamount";
            // 
            // frmCostingValuation
            // 
            this.AcceptButton = this.btnCostingValuation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 482);
            this.Controls.Add(this.groupBox9);
            this.Name = "frmCostingValuation";
            this.Text = "Valuation";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.groupBox9, 0);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnCostingValuation;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDataControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgid;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgparticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgminimumamount;

    }
}