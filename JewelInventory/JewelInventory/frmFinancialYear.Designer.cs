namespace JewelInventory
{
	public partial class frmFinancialYear
    {
        #region Initializing stuffs
        private System.Windows.Forms.GroupBox grpFinYear;
        private System.Windows.Forms.TextBox txtYearCode;
        private System.Windows.Forms.Label lblFinyear;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinancialYear));
            this.grpFinYear = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYearCode = new System.Windows.Forms.TextBox();
            this.lblFinyear = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkcancelled = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.grpFinYear.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(482, 44);
            this.lblHeader.Text = "       Financial Year Entry";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 324);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(327, 324);
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Size = new System.Drawing.Size(454, 11);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 303);
            this.groupBox2.Size = new System.Drawing.Size(454, 11);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(261, 325);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(194, 325);
            // 
            // grpFinYear
            // 
            this.grpFinYear.Controls.Add(this.dtTo);
            this.grpFinYear.Controls.Add(this.dtFrom);
            this.grpFinYear.Controls.Add(this.label2);
            this.grpFinYear.Controls.Add(this.label1);
            this.grpFinYear.Controls.Add(this.txtYearCode);
            this.grpFinYear.Controls.Add(this.lblFinyear);
            this.grpFinYear.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpFinYear.Location = new System.Drawing.Point(8, 59);
            this.grpFinYear.Name = "grpFinYear";
            this.grpFinYear.Size = new System.Drawing.Size(309, 158);
            this.grpFinYear.TabIndex = 1006;
            this.grpFinYear.TabStop = false;
            this.grpFinYear.Text = "Financial Year";
            // 
            // dtTo
            // 
            this.dtTo.AccessibleName = "To Date";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(123, 79);
            this.dtTo.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(144, 20);
            this.dtTo.TabIndex = 2;
            // 
            // dtFrom
            // 
            this.dtFrom.AccessibleName = "From Date";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(123, 48);
            this.dtFrom.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(144, 20);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date :";
            // 
            // txtYearCode
            // 
            this.txtYearCode.AccessibleName = "Financial Year";
            this.txtYearCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYearCode.Location = new System.Drawing.Point(123, 16);
            this.txtYearCode.MaxLength = 20;
            this.txtYearCode.Name = "txtYearCode";
            this.txtYearCode.Size = new System.Drawing.Size(146, 20);
            this.txtYearCode.TabIndex = 0;
            // 
            // lblFinyear
            // 
            this.lblFinyear.AutoSize = true;
            this.lblFinyear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFinyear.Location = new System.Drawing.Point(6, 20);
            this.lblFinyear.Name = "lblFinyear";
            this.lblFinyear.Size = new System.Drawing.Size(111, 13);
            this.lblFinyear.TabIndex = 0;
            this.lblFinyear.Text = "Financial Year Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(457, 39);
            this.label3.TabIndex = 1008;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1009;
            this.label4.Text = "Note :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkcancelled);
            this.groupBox4.Controls.Add(this.chkActive);
            this.groupBox4.Location = new System.Drawing.Point(17, 163);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(154, 48);
            this.groupBox4.TabIndex = 1011;
            this.groupBox4.TabStop = false;
            // 
            // chkcancelled
            // 
            this.chkcancelled.AutoSize = true;
            this.chkcancelled.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkcancelled.Location = new System.Drawing.Point(72, 16);
            this.chkcancelled.Name = "chkcancelled";
            this.chkcancelled.Size = new System.Drawing.Size(73, 17);
            this.chkcancelled.TabIndex = 1;
            this.chkcancelled.Text = "Cancelled";
            this.chkcancelled.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkActive.Location = new System.Drawing.Point(10, 16);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 0;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // frmFinancialYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(482, 366);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpFinYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "frmFinancialYear";
            this.Text = "Financial Year Entry";
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.grpFinYear, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.grpFinYear.ResumeLayout(false);
            this.grpFinYear.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkcancelled;
        private System.Windows.Forms.CheckBox chkActive;


    }
}