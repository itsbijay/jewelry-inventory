namespace JewelInventory
{
    partial class frmLooseDiamonds
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblype = new System.Windows.Forms.Label();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.lblQuality = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.cboParty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtLooseDiamonds = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(645, 44);
            this.lblHeader.Text = "       Loose Diamonds Stock In";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(566, 442);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(495, 442);
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Size = new System.Drawing.Size(629, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(7, 421);
            this.groupBox2.Size = new System.Drawing.Size(629, 11);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(430, 444);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(363, 444);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.dgvJewel);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(7, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(627, 357);
            this.groupBox3.TabIndex = 1019;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loose Diamonds Stock In";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboTerms);
            this.groupBox4.Controls.Add(this.cboType);
            this.groupBox4.Controls.Add(this.lblype);
            this.groupBox4.Controls.Add(this.txtQuality);
            this.groupBox4.Controls.Add(this.lblQuality);
            this.groupBox4.Controls.Add(this.lblCode);
            this.groupBox4.Controls.Add(this.cboParty);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtLooseDiamonds);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(8, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(604, 72);
            this.groupBox4.TabIndex = 1030;
            this.groupBox4.TabStop = false;
            // 
            // cboTerms
            // 
            this.cboTerms.AccessibleName = "Paymeny Terms";
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Items.AddRange(new object[] {
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days"});
            this.cboTerms.Location = new System.Drawing.Point(480, 43);
            this.cboTerms.Margin = new System.Windows.Forms.Padding(2);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(99, 21);
            this.cboTerms.TabIndex = 5;
            // 
            // cboType
            // 
            this.cboType.AccessibleName = "Diamond Type";
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(76, 43);
            this.cboType.Margin = new System.Windows.Forms.Padding(2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(99, 21);
            this.cboType.TabIndex = 2;
            // 
            // lblype
            // 
            this.lblype.AutoSize = true;
            this.lblype.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblype.Location = new System.Drawing.Point(19, 47);
            this.lblype.Name = "lblype";
            this.lblype.Size = new System.Drawing.Size(37, 13);
            this.lblype.TabIndex = 1038;
            this.lblype.Text = "Type :";
            // 
            // txtQuality
            // 
            this.txtQuality.AccessibleDescription = "Quality";
            this.txtQuality.Location = new System.Drawing.Point(255, 44);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(99, 20);
            this.txtQuality.TabIndex = 3;
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuality.Location = new System.Drawing.Point(198, 48);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(45, 13);
            this.lblQuality.TabIndex = 1037;
            this.lblQuality.Text = "Quality :";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCode.Location = new System.Drawing.Point(379, 51);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(78, 13);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "Payment Term:";
            // 
            // cboParty
            // 
            this.cboParty.AccessibleName = "Customer";
            this.cboParty.FormattingEnabled = true;
            this.cboParty.Location = new System.Drawing.Point(256, 18);
            this.cboParty.Margin = new System.Windows.Forms.Padding(2);
            this.cboParty.Name = "cboParty";
            this.cboParty.Size = new System.Drawing.Size(181, 21);
            this.cboParty.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(195, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1035;
            this.label2.Text = "Supplier:";
            // 
            // dtLooseDiamonds
            // 
            this.dtLooseDiamonds.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLooseDiamonds.Location = new System.Drawing.Point(76, 18);
            this.dtLooseDiamonds.Margin = new System.Windows.Forms.Padding(2);
            this.dtLooseDiamonds.Name = "dtLooseDiamonds";
            this.dtLooseDiamonds.Size = new System.Drawing.Size(99, 20);
            this.dtLooseDiamonds.TabIndex = 0;
            this.dtLooseDiamonds.Value = new System.DateTime(2012, 4, 5, 21, 57, 41, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(19, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 1034;
            this.label11.Text = "Date :";
            // 
            // dgvJewel
            // 
            this.dgvJewel.AllowUserToAddRows = false;
            this.dgvJewel.AllowUserToDeleteRows = false;
            this.dgvJewel.AllowUserToOrderColumns = true;
            this.dgvJewel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJewel.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvJewel.Location = new System.Drawing.Point(8, 113);
            this.dgvJewel.Margin = new System.Windows.Forms.Padding(10);
            this.dgvJewel.Name = "dgvJewel";
            this.dgvJewel.RowTemplate.Height = 24;
            this.dgvJewel.Size = new System.Drawing.Size(604, 217);
            this.dgvJewel.TabIndex = 0;
            this.dgvJewel.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmLooseDiamonds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 475);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmLooseDiamonds";
            this.Text = "Loose Diamonds";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ComboBox cboParty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtLooseDiamonds;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblype;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}