namespace JewelInventory
{
    partial class frmSalesOrder
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDiamondPieces = new System.Windows.Forms.Label();
            this.lblDiamondWeight = new System.Windows.Forms.Label();
            this.lblNetWeight = new System.Windows.Forms.Label();
            this.lblGrossWeight = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpStep1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOC = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cboPaymentTerm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtSalesDt = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvJewel = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            this.grpStep1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(1100, 44);
            this.lblHeader.Text = "       Sales Order Form";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(932, 569);
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(866, 569);
            this.btnSave.Size = new System.Drawing.Size(62, 23);
            this.btnSave.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Size = new System.Drawing.Size(986, 12);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(9, 550);
            this.groupBox2.Size = new System.Drawing.Size(987, 14);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(799, 570);
            this.btnNext.Size = new System.Drawing.Size(62, 23);
            this.btnNext.Visible = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(732, 570);
            this.btnPrev.Visible = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDiamondPieces);
            this.groupBox3.Controls.Add(this.lblDiamondWeight);
            this.groupBox3.Controls.Add(this.lblNetWeight);
            this.groupBox3.Controls.Add(this.lblGrossWeight);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(264, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(501, 74);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Jewel";
            // 
            // lblDiamondPieces
            // 
            this.lblDiamondPieces.AutoSize = true;
            this.lblDiamondPieces.BackColor = System.Drawing.Color.White;
            this.lblDiamondPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiamondPieces.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiamondPieces.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamondPieces.Location = new System.Drawing.Point(402, 47);
            this.lblDiamondPieces.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblDiamondPieces.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblDiamondPieces.Name = "lblDiamondPieces";
            this.lblDiamondPieces.Size = new System.Drawing.Size(80, 20);
            this.lblDiamondPieces.TabIndex = 19;
            this.lblDiamondPieces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiamondWeight
            // 
            this.lblDiamondWeight.AutoSize = true;
            this.lblDiamondWeight.BackColor = System.Drawing.Color.White;
            this.lblDiamondWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiamondWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiamondWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiamondWeight.Location = new System.Drawing.Point(306, 47);
            this.lblDiamondWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblDiamondWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblDiamondWeight.Name = "lblDiamondWeight";
            this.lblDiamondWeight.Size = new System.Drawing.Size(80, 20);
            this.lblDiamondWeight.TabIndex = 21;
            this.lblDiamondWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.BackColor = System.Drawing.Color.White;
            this.lblNetWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNetWeight.Location = new System.Drawing.Point(210, 47);
            this.lblNetWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblNetWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(80, 20);
            this.lblNetWeight.TabIndex = 20;
            this.lblNetWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrossWeight
            // 
            this.lblGrossWeight.AutoSize = true;
            this.lblGrossWeight.BackColor = System.Drawing.Color.White;
            this.lblGrossWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrossWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossWeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGrossWeight.Location = new System.Drawing.Point(114, 47);
            this.lblGrossWeight.MaximumSize = new System.Drawing.Size(100, 120);
            this.lblGrossWeight.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblGrossWeight.Name = "lblGrossWeight";
            this.lblGrossWeight.Size = new System.Drawing.Size(80, 20);
            this.lblGrossWeight.TabIndex = 18;
            this.lblGrossWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(14, 47);
            this.lblTotal.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 20);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(402, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Dia. Pcs.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(306, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dia. Wt.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(210, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Net Wt.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(114, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Gr. Wt.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total Items";
            // 
            // grpStep1
            // 
            this.grpStep1.BackColor = System.Drawing.Color.Transparent;
            this.grpStep1.Controls.Add(this.label1);
            this.grpStep1.Controls.Add(this.txtRemarks);
            this.grpStep1.Controls.Add(this.button1);
            this.grpStep1.Controls.Add(this.btnInvoice);
            this.grpStep1.Controls.Add(this.txtNetAmount);
            this.grpStep1.Controls.Add(this.label15);
            this.grpStep1.Controls.Add(this.txtTotalAmount);
            this.grpStep1.Controls.Add(this.label14);
            this.grpStep1.Controls.Add(this.txtOC);
            this.grpStep1.Controls.Add(this.label13);
            this.grpStep1.Controls.Add(this.txtVat);
            this.grpStep1.Controls.Add(this.label12);
            this.grpStep1.Controls.Add(this.groupBox4);
            this.grpStep1.Controls.Add(this.dgvJewel);
            this.grpStep1.Controls.Add(this.groupBox3);
            this.grpStep1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpStep1.Location = new System.Drawing.Point(7, 55);
            this.grpStep1.Name = "grpStep1";
            this.grpStep1.Size = new System.Drawing.Size(989, 494);
            this.grpStep1.TabIndex = 1006;
            this.grpStep1.TabStop = false;
            this.grpStep1.Text = "Sales Order ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(22, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1011;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.CausesValidation = false;
            this.txtRemarks.Location = new System.Drawing.Point(77, 383);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(177, 55);
            this.txtRemarks.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(682, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Email";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Enabled = false;
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInvoice.Location = new System.Drawing.Point(549, 465);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(120, 23);
            this.btnInvoice.TabIndex = 2;
            this.btnInvoice.Text = "Generate Invoices";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.AccessibleName = "ContactName";
            this.txtNetAmount.BackColor = System.Drawing.Color.White;
            this.txtNetAmount.Location = new System.Drawing.Point(886, 371);
            this.txtNetAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtNetAmount.MaxLength = 200;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(94, 20);
            this.txtNetAmount.TabIndex = 8;
            this.txtNetAmount.Text = "0";
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(788, 375);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "Net Amount :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.AccessibleName = "ContactName";
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.Location = new System.Drawing.Point(865, 462);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.MaxLength = 200;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(115, 20);
            this.txtTotalAmount.TabIndex = 11;
            this.txtTotalAmount.Text = "0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(781, 466);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Total Amount :";
            // 
            // txtOC
            // 
            this.txtOC.AccessibleName = "ContactName";
            this.txtOC.BackColor = System.Drawing.Color.White;
            this.txtOC.Location = new System.Drawing.Point(886, 432);
            this.txtOC.Margin = new System.Windows.Forms.Padding(2);
            this.txtOC.MaxLength = 200;
            this.txtOC.Name = "txtOC";
            this.txtOC.ReadOnly = true;
            this.txtOC.Size = new System.Drawing.Size(94, 20);
            this.txtOC.TabIndex = 10;
            this.txtOC.Text = "0";
            this.txtOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(776, 436);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Other Charges :";
            // 
            // txtVat
            // 
            this.txtVat.AccessibleName = "ContactName";
            this.txtVat.BackColor = System.Drawing.Color.White;
            this.txtVat.Location = new System.Drawing.Point(886, 401);
            this.txtVat.Margin = new System.Windows.Forms.Padding(2);
            this.txtVat.MaxLength = 200;
            this.txtVat.Name = "txtVat";
            this.txtVat.ReadOnly = true;
            this.txtVat.Size = new System.Drawing.Size(94, 20);
            this.txtVat.TabIndex = 9;
            this.txtVat.Text = "0";
            this.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(823, 405);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "VAT :";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtAddress);
            this.groupBox4.Controls.Add(this.lblAddress);
            this.groupBox4.Controls.Add(this.cboPaymentTerm);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnGo);
            this.groupBox4.Controls.Add(this.cboCustomer);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtContactName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtSalesDt);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(15, 14);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(859, 98);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sales Information";
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleName = "Address";
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Location = new System.Drawing.Point(328, 54);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(179, 37);
            this.txtAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAddress.Location = new System.Drawing.Point(266, 58);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 66;
            this.lblAddress.Text = "Address :";
            // 
            // cboPaymentTerm
            // 
            this.cboPaymentTerm.AccessibleName = "Payment Term";
            this.cboPaymentTerm.FormattingEnabled = true;
            this.cboPaymentTerm.Items.AddRange(new object[] {
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days"});
            this.cboPaymentTerm.Location = new System.Drawing.Point(620, 22);
            this.cboPaymentTerm.Margin = new System.Windows.Forms.Padding(2);
            this.cboPaymentTerm.Name = "cboPaymentTerm";
            this.cboPaymentTerm.Size = new System.Drawing.Size(104, 21);
            this.cboPaymentTerm.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(525, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Payment Term : ";
            // 
            // btnGo
            // 
            this.btnGo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGo.Location = new System.Drawing.Point(743, 54);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(108, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cboCustomer
            // 
            this.cboCustomer.AccessibleName = "Customer";
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(328, 22);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(154, 21);
            this.cboCustomer.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(260, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Customer :";
            // 
            // txtContactName
            // 
            this.txtContactName.AccessibleName = "ContactName";
            this.txtContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactName.Location = new System.Drawing.Point(88, 54);
            this.txtContactName.Margin = new System.Windows.Forms.Padding(2);
            this.txtContactName.MaxLength = 200;
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(151, 20);
            this.txtContactName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(36, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Name :";
            // 
            // dtSalesDt
            // 
            this.dtSalesDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSalesDt.Location = new System.Drawing.Point(88, 22);
            this.dtSalesDt.Margin = new System.Windows.Forms.Padding(2);
            this.dtSalesDt.Name = "dtSalesDt";
            this.dtSalesDt.Size = new System.Drawing.Size(99, 20);
            this.dtSalesDt.TabIndex = 0;
            this.dtSalesDt.Value = new System.DateTime(2012, 4, 5, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(41, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Date :";
            // 
            // dgvJewel
            // 
            this.dgvJewel.AllowUserToAddRows = false;
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
            this.dgvJewel.Location = new System.Drawing.Point(15, 118);
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
            this.dgvJewel.Size = new System.Drawing.Size(967, 246);
            this.dgvJewel.TabIndex = 0;
            this.dgvJewel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJewel_CellContentClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmSalesOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 602);
            this.Controls.Add(this.grpStep1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmSalesOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marketing Order Form";
            this.Controls.SetChildIndex(this.grpStep1, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrev, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpStep1.ResumeLayout(false);
            this.grpStep1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJewel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lblDiamondPieces;
		private System.Windows.Forms.Label lblDiamondWeight;
		private System.Windows.Forms.Label lblNetWeight;
		private System.Windows.Forms.Label lblGrossWeight;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpStep1;
		private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgvJewel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtSalesDt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox cboPaymentTerm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
	}
}