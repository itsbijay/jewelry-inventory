namespace JewelInventory
{
    partial class frmMasterMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterMaintenance));
            this.grpMaintainJewel = new System.Windows.Forms.GroupBox();
            this.grpEditor = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.cboHeads = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboJewelNumber = new System.Windows.Forms.ComboBox();
            this.grpMaintainJewel.SuspendLayout();
            this.grpEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(578, 44);
            this.lblHeader.Text = "       Master Maintenance";
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(373, 378);
            this.btnCancel.Size = new System.Drawing.Size(65, 26);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(304, 378);
            this.btnSave.Size = new System.Drawing.Size(65, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 46);
            this.groupBox1.Size = new System.Drawing.Size(434, 13);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 359);
            this.groupBox2.Size = new System.Drawing.Size(433, 13);
            // 
            // btnNext
            // 
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Location = new System.Drawing.Point(239, 378);
            this.btnNext.Size = new System.Drawing.Size(65, 26);
            // 
            // btnPrev
            // 
            this.btnPrev.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev.Location = new System.Drawing.Point(172, 378);
            this.btnPrev.Size = new System.Drawing.Size(65, 26);
            // 
            // grpMaintainJewel
            // 
            this.grpMaintainJewel.Controls.Add(this.grpEditor);
            this.grpMaintainJewel.Controls.Add(this.label5);
            this.grpMaintainJewel.Controls.Add(this.label1);
            this.grpMaintainJewel.Controls.Add(this.cboJewelNumber);
            this.grpMaintainJewel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpMaintainJewel.Location = new System.Drawing.Point(6, 60);
            this.grpMaintainJewel.Name = "grpMaintainJewel";
            this.grpMaintainJewel.Size = new System.Drawing.Size(433, 295);
            this.grpMaintainJewel.TabIndex = 1006;
            this.grpMaintainJewel.TabStop = false;
            this.grpMaintainJewel.Text = "Master Maintainance";
            // 
            // grpEditor
            // 
            this.grpEditor.Controls.Add(this.label4);
            this.grpEditor.Controls.Add(this.txtNewValue);
            this.grpEditor.Controls.Add(this.label3);
            this.grpEditor.Controls.Add(this.label2);
            this.grpEditor.Controls.Add(this.txtOldValue);
            this.grpEditor.Controls.Add(this.cboHeads);
            this.grpEditor.Enabled = false;
            this.grpEditor.Location = new System.Drawing.Point(9, 62);
            this.grpEditor.Name = "grpEditor";
            this.grpEditor.Size = new System.Drawing.Size(290, 151);
            this.grpEditor.TabIndex = 9;
            this.grpEditor.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(19, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "New Value";
            // 
            // txtNewValue
            // 
            this.txtNewValue.AccessibleName = "New Value";
            this.txtNewValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewValue.Location = new System.Drawing.Point(87, 103);
            this.txtNewValue.MaxLength = 255;
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(121, 20);
            this.txtNewValue.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(19, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Old Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(19, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Head";
            // 
            // txtOldValue
            // 
            this.txtOldValue.Location = new System.Drawing.Point(87, 66);
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.ReadOnly = true;
            this.txtOldValue.Size = new System.Drawing.Size(121, 20);
            this.txtOldValue.TabIndex = 1;
            // 
            // cboHeads
            // 
            this.cboHeads.AccessibleName = "Jewel Heads";
            this.cboHeads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHeads.FormattingEnabled = true;
            this.cboHeads.Items.AddRange(new object[] {
            "CertificateNumber",
            "DesignCode",
            "MetalColor"});
            this.cboHeads.Location = new System.Drawing.Point(87, 27);
            this.cboHeads.Name = "cboHeads";
            this.cboHeads.Size = new System.Drawing.Size(121, 21);
            this.cboHeads.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(382, 52);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jewel Number";
            // 
            // cboJewelNumber
            // 
            this.cboJewelNumber.AccessibleName = "Jewel Number";
            this.cboJewelNumber.FormattingEnabled = true;
            this.cboJewelNumber.Location = new System.Drawing.Point(98, 27);
            this.cboJewelNumber.Name = "cboJewelNumber";
            this.cboJewelNumber.Size = new System.Drawing.Size(121, 21);
            this.cboJewelNumber.TabIndex = 0;
            // 
            // frmMasterMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 410);
            this.Controls.Add(this.grpMaintainJewel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmMasterMaintenance";
            this.Text = "Master Maintenance";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.grpMaintainJewel, 0);
            this.grpMaintainJewel.ResumeLayout(false);
            this.grpMaintainJewel.PerformLayout();
            this.grpEditor.ResumeLayout(false);
            this.grpEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaintainJewel;
        private System.Windows.Forms.ComboBox cboJewelNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpEditor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.ComboBox cboHeads;
    }
}