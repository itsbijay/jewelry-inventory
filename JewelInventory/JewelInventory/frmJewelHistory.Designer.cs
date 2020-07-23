namespace JewelInventory
{
    partial class frmJewelHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJewelHistory));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCertiNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesignCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJewelNumber = new System.Windows.Forms.TextBox();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(956, 44);
            this.lblHeader.Text = "       Jewel Search/ History";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(793, 535);
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(726, 535);
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 41);
            this.groupBox1.Size = new System.Drawing.Size(850, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(1, 516);
            this.groupBox2.Size = new System.Drawing.Size(857, 10);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(659, 535);
            this.btnNext.Size = new System.Drawing.Size(61, 23);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(589, 535);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dgvJewel);
            this.groupBox4.Location = new System.Drawing.Point(5, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(850, 373);
            this.groupBox4.TabIndex = 1013;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Jewel History";
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJewel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJewel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJewel.Location = new System.Drawing.Point(10, 18);
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
            this.dgvJewel.Size = new System.Drawing.Size(827, 344);
            this.dgvJewel.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtCertiNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDesignCode);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtJewelNumber);
            this.groupBox3.Controls.Add(this.btnShowHistory);
            this.groupBox3.Location = new System.Drawing.Point(5, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 77);
            this.groupBox3.TabIndex = 1012;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lookup";
            // 
            // txtCertiNo
            // 
            this.txtCertiNo.CausesValidation = false;
            this.txtCertiNo.Location = new System.Drawing.Point(581, 35);
            this.txtCertiNo.MaxLength = 255;
            this.txtCertiNo.Name = "txtCertiNo";
            this.txtCertiNo.Size = new System.Drawing.Size(100, 20);
            this.txtCertiNo.TabIndex = 2;
            this.txtCertiNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ondgDataControlKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 1038;
            this.label5.Text = "Certificate No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(464, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 1037;
            this.label4.Text = "OR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 1036;
            this.label3.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(252, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1035;
            this.label2.Text = "Jewel DesignCode";
            // 
            // txtDesignCode
            // 
            this.txtDesignCode.CausesValidation = false;
            this.txtDesignCode.Location = new System.Drawing.Point(358, 37);
            this.txtDesignCode.MaxLength = 255;
            this.txtDesignCode.Name = "txtDesignCode";
            this.txtDesignCode.Size = new System.Drawing.Size(100, 20);
            this.txtDesignCode.TabIndex = 1;
            this.txtDesignCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ondgDataControlKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1033;
            this.label1.Text = "Jewel Number";
            // 
            // txtJewelNumber
            // 
            this.txtJewelNumber.CausesValidation = false;
            this.txtJewelNumber.Location = new System.Drawing.Point(99, 37);
            this.txtJewelNumber.MaxLength = 255;
            this.txtJewelNumber.Name = "txtJewelNumber";
            this.txtJewelNumber.Size = new System.Drawing.Size(100, 20);
            this.txtJewelNumber.TabIndex = 0;
            this.txtJewelNumber.TextChanged += new System.EventHandler(this.txtJewelNumber_TextChanged);
            this.txtJewelNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ondgDataControlKeyDown);
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Location = new System.Drawing.Point(701, 34);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(93, 23);
            this.btnShowHistory.TabIndex = 3;
            this.btnShowHistory.Text = "Show History";
            this.btnShowHistory.UseVisualStyleBackColor = true;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // frmJewelHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 569);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJewelHistory";
            this.Text = "Jewel Search/ History";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.TextBox txtJewelNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesignCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCertiNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;

    }
}