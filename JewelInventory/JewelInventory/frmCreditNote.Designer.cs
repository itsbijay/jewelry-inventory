namespace JewelInventory
{
    partial class frmCreditNote
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboInvoice = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvCreditNote = new System.Windows.Forms.DataGridView();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.dtCosting = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditNote)).BeginInit();
            this.gbCustomer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Location = new System.Drawing.Point(-5, -6);
            this.lblHeader.Size = new System.Drawing.Size(685, 53);
            this.lblHeader.Text = "    Credit Note";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(605, 465);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(534, 465);
            this.btnSave.Size = new System.Drawing.Size(64, 25);
            this.btnSave.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 45);
            this.groupBox1.Size = new System.Drawing.Size(667, 12);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 446);
            this.groupBox2.Size = new System.Drawing.Size(658, 11);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(469, 465);
            this.btnNext.Size = new System.Drawing.Size(60, 24);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(387, 465);
            this.btnPrev.Size = new System.Drawing.Size(77, 23);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(289, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Amount";
            // 
            // cboInvoice
            // 
            this.cboInvoice.AccessibleName = "Invoice No";
            this.cboInvoice.FormattingEnabled = true;
            this.cboInvoice.Location = new System.Drawing.Point(347, 26);
            this.cboInvoice.Name = "cboInvoice";
            this.cboInvoice.Size = new System.Drawing.Size(121, 21);
            this.cboInvoice.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "Description";
            this.txtDescription.Location = new System.Drawing.Point(93, 63);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(161, 46);
            this.txtDescription.TabIndex = 7;
            // 
            // txtAmount
            // 
            this.txtAmount.AccessibleName = "Amount";
            this.txtAmount.Location = new System.Drawing.Point(347, 56);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 8;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(484, 86);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(90, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dgvCreditNote
            // 
            this.dgvCreditNote.AllowUserToAddRows = false;
            this.dgvCreditNote.AllowUserToResizeRows = false;
            this.dgvCreditNote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCreditNote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCreditNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvCreditNote.Location = new System.Drawing.Point(9, 17);
            this.dgvCreditNote.MultiSelect = false;
            this.dgvCreditNote.Name = "dgvCreditNote";
            this.dgvCreditNote.ReadOnly = true;
            this.dgvCreditNote.RowHeadersVisible = false;
            this.dgvCreditNote.RowHeadersWidth = 50;
            this.dgvCreditNote.Size = new System.Drawing.Size(645, 227);
            this.dgvCreditNote.TabIndex = 10;
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.dtCosting);
            this.gbCustomer.Controls.Add(this.label11);
            this.gbCustomer.Controls.Add(this.cboCustomer);
            this.gbCustomer.Controls.Add(this.label1);
            this.gbCustomer.Controls.Add(this.btnGenerate);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Controls.Add(this.txtAmount);
            this.gbCustomer.Controls.Add(this.txtDescription);
            this.gbCustomer.Controls.Add(this.label4);
            this.gbCustomer.Controls.Add(this.cboInvoice);
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Location = new System.Drawing.Point(7, 62);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(662, 120);
            this.gbCustomer.TabIndex = 11;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Credit Note Details";
            // 
            // dtCosting
            // 
            this.dtCosting.AccessibleName = "Transaction";
            this.dtCosting.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCosting.Location = new System.Drawing.Point(347, 87);
            this.dtCosting.Margin = new System.Windows.Forms.Padding(2);
            this.dtCosting.Name = "dtCosting";
            this.dtCosting.Size = new System.Drawing.Size(99, 20);
            this.dtCosting.TabIndex = 46;
            this.dtCosting.Value = new System.DateTime(2012, 4, 5, 21, 57, 41, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(296, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Date ";
            // 
            // cboCustomer
            // 
            this.cboCustomer.AccessibleName = "Customer";
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(93, 29);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(121, 21);
            this.cboCustomer.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCreditNote);
            this.groupBox3.Location = new System.Drawing.Point(7, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(663, 257);
            this.groupBox3.TabIndex = 1006;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Credit Note";
            // 
            // frmCreditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(674, 497);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbCustomer);
            this.Name = "frmCreditNote";
            this.Text = "Credit Note";
            this.Load += new System.EventHandler(this.frmCreditNote_Load);
            this.Controls.SetChildIndex(this.gbCustomer, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditNote)).EndInit();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboInvoice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvCreditNote;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtCosting;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label1;

    }
}