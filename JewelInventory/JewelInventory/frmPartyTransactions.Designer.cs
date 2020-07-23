namespace JewelInventory
{
    partial class frmPartyTransaction
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTranType = new System.Windows.Forms.ComboBox();
            this.btnShowTransactions = new System.Windows.Forms.Button();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grpSupplier.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(987, 44);
            this.lblHeader.Text = "       Party Transaction Lookup";
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(825, 527);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(758, 528);
            this.btnSave.TabIndex = 0;
            this.btnSave.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 41);
            this.groupBox1.Size = new System.Drawing.Size(886, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 513);
            this.groupBox2.Size = new System.Drawing.Size(885, 8);
            // 
            // btnNext
            // 
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Location = new System.Drawing.Point(691, 528);
            this.btnNext.Size = new System.Drawing.Size(65, 25);
            // 
            // btnPrev
            // 
            this.btnPrev.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev.Location = new System.Drawing.Point(624, 528);
            this.btnPrev.Size = new System.Drawing.Size(65, 25);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dgvJewel);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(6, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(885, 364);
            this.groupBox4.TabIndex = 1013;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Party Transactions";
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
            this.dgvJewel.Location = new System.Drawing.Point(10, 22);
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
            this.dgvJewel.Size = new System.Drawing.Size(865, 330);
            this.dgvJewel.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboTranType);
            this.groupBox3.Controls.Add(this.btnShowTransactions);
            this.groupBox3.Controls.Add(this.dtToDate);
            this.groupBox3.Controls.Add(this.dtFromDate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.rdoCustomer);
            this.groupBox3.Controls.Add(this.rdoSupplier);
            this.groupBox3.Controls.Add(this.grpSupplier);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(6, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(885, 85);
            this.groupBox3.TabIndex = 1012;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter Transaction Lookup";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(271, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 1030;
            this.label5.Text = "Transaction Type :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cboTranType
            // 
            this.cboTranType.AccessibleName = "Transaction Type";
            this.cboTranType.FormattingEnabled = true;
            this.cboTranType.Location = new System.Drawing.Point(371, 32);
            this.cboTranType.Name = "cboTranType";
            this.cboTranType.Size = new System.Drawing.Size(142, 21);
            this.cboTranType.TabIndex = 1029;
            this.cboTranType.SelectedIndexChanged += new System.EventHandler(this.cboTranType_SelectedIndexChanged);
            // 
            // btnShowTransactions
            // 
            this.btnShowTransactions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowTransactions.Location = new System.Drawing.Point(736, 57);
            this.btnShowTransactions.Name = "btnShowTransactions";
            this.btnShowTransactions.Size = new System.Drawing.Size(109, 23);
            this.btnShowTransactions.TabIndex = 2;
            this.btnShowTransactions.Text = "Show Transactions";
            this.btnShowTransactions.UseVisualStyleBackColor = true;
            this.btnShowTransactions.Click += new System.EventHandler(this.btnShowTransactions_Click);
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(740, 32);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(105, 20);
            this.dtToDate.TabIndex = 1;
            this.dtToDate.Value = new System.DateTime(2014, 4, 26, 0, 0, 0, 0);
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(583, 32);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(103, 20);
            this.dtFromDate.TabIndex = 0;
            this.dtFromDate.Value = new System.DateTime(2014, 4, 26, 0, 0, 0, 0);
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(690, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1028;
            this.label2.Text = "To Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(523, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1027;
            this.label1.Text = "From Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoCustomer.Location = new System.Drawing.Point(101, 62);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(69, 17);
            this.rdoCustomer.TabIndex = 4;
            this.rdoCustomer.TabStop = true;
            this.rdoCustomer.Text = "Customer";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            this.rdoCustomer.CheckedChanged += new System.EventHandler(this.rdoCustomer_CheckedChanged);
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Checked = true;
            this.rdoSupplier.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoSupplier.Location = new System.Drawing.Point(30, 62);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(63, 17);
            this.rdoSupplier.TabIndex = 3;
            this.rdoSupplier.TabStop = true;
            this.rdoSupplier.Text = "Supplier";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            this.rdoSupplier.CheckedChanged += new System.EventHandler(this.rdoSupplier_CheckedChanged);
            // 
            // grpSupplier
            // 
            this.grpSupplier.Controls.Add(this.label4);
            this.grpSupplier.Controls.Add(this.cboSupplier);
            this.grpSupplier.Controls.Add(this.grpCustomer);
            this.grpSupplier.Location = new System.Drawing.Point(29, 19);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(238, 37);
            this.grpSupplier.TabIndex = 1024;
            this.grpSupplier.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(10, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 1023;
            this.label4.Text = "Supplier :";
            // 
            // cboSupplier
            // 
            this.cboSupplier.AccessibleName = "Supplier";
            this.cboSupplier.CausesValidation = false;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(66, 12);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(161, 21);
            this.cboSupplier.TabIndex = 0;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.label3);
            this.grpCustomer.Controls.Add(this.cboCustomer);
            this.grpCustomer.Location = new System.Drawing.Point(1, 0);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(236, 37);
            this.grpCustomer.TabIndex = 1022;
            this.grpCustomer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1023;
            this.label3.Text = "Customer :";
            // 
            // cboCustomer
            // 
            this.cboCustomer.AccessibleName = "Customer";
            this.cboCustomer.CausesValidation = false;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(66, 12);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(160, 21);
            this.cboCustomer.TabIndex = 1022;
            // 
            // frmPartyTransaction
            // 
            this.AcceptButton = this.btnShowTransactions;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 562);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmPartyTransaction";
            this.Text = "Party Transactions";
            this.Load += new System.EventHandler(this.frmPartyTransaction_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpSupplier.ResumeLayout(false);
            this.grpSupplier.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.GroupBox grpSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.RadioButton rdoCustomer;
        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.Button btnCostingValuation;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowTransactions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTranType;

    }
}