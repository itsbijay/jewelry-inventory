namespace JewelCatalogue
{
	partial class frmMDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDIParent));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.lblError = new System.Windows.Forms.Label();
            this.autoComplete = new JetCoders.Forms.UI.Input.CoolTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.firstToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.previousToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lastToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.username = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.manageJewelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printTagForAllJewelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.marketingCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.firmInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpbtn = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(0, 418);
            this.lblError.Margin = new System.Windows.Forms.Padding(10);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 10;
            // 
            // autoComplete
            // 
            this.autoComplete.AutoSize = true;
            this.autoComplete.BackColor = System.Drawing.SystemColors.Window;
            this.autoComplete.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.autoComplete.Enabled = false;
            this.autoComplete.Location = new System.Drawing.Point(539, 25);
            this.autoComplete.Name = "autoComplete";
            this.autoComplete.Padding = new System.Windows.Forms.Padding(4);
            this.autoComplete.PopupWidth = 350;
            this.autoComplete.SelectedItemBackColor = System.Drawing.SystemColors.ControlText;
            this.autoComplete.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.autoComplete.Size = new System.Drawing.Size(156, 28);
            this.autoComplete.TabIndex = 6;
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.toolStripSeparator10,
            this.editToolStripButton,
            this.toolStripSeparator11,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.firstToolStripButton,
            this.previousToolStripButton,
            this.nextToolStripButton,
            this.lastToolStripButton,
            this.toolStripSeparator13,
            this.refreshToolStripButton,
            this.toolStripSeparator2,
            this.toolStripSearch,
            this.toolStripSeparator12});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(842, 31);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(54, 28);
            this.addToolStripButton.Text = "Add";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 31);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(53, 28);
            this.editToolStripButton.Text = "Edit";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 31);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(66, 28);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // firstToolStripButton
            // 
            this.firstToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("firstToolStripButton.Image")));
            this.firstToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstToolStripButton.Name = "firstToolStripButton";
            this.firstToolStripButton.Size = new System.Drawing.Size(56, 28);
            this.firstToolStripButton.Text = "First";
            // 
            // previousToolStripButton
            // 
            this.previousToolStripButton.Enabled = false;
            this.previousToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("previousToolStripButton.Image")));
            this.previousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousToolStripButton.Name = "previousToolStripButton";
            this.previousToolStripButton.Size = new System.Drawing.Size(76, 28);
            this.previousToolStripButton.Text = "Previous";
            // 
            // nextToolStripButton
            // 
            this.nextToolStripButton.Enabled = false;
            this.nextToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nextToolStripButton.Image")));
            this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextToolStripButton.Name = "nextToolStripButton";
            this.nextToolStripButton.Size = new System.Drawing.Size(58, 28);
            this.nextToolStripButton.Text = "Next";
            // 
            // lastToolStripButton
            // 
            this.lastToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lastToolStripButton.Image")));
            this.lastToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastToolStripButton.Name = "lastToolStripButton";
            this.lastToolStripButton.Size = new System.Drawing.Size(55, 28);
            this.lastToolStripButton.Text = "Last";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 31);
            this.toolStripSeparator13.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(73, 28);
            this.refreshToolStripButton.Text = "Refresh";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 180, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(23, 28);
            this.toolStripSearch.Click += new System.EventHandler(this.toolStripSearch_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 31);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.username});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(842, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // username
            // 
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenu,
            this.toolsMenu,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(842, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageJewelsToolStripMenuItem,
            this.printTagForAllJewelsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(121, 20);
            this.editMenu.Text = "Manage &Transactions";
            // 
            // manageJewelsToolStripMenuItem
            // 
            this.manageJewelsToolStripMenuItem.Name = "manageJewelsToolStripMenuItem";
            this.manageJewelsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.J)));
            this.manageJewelsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.manageJewelsToolStripMenuItem.Text = "Manage &Jewels";
            this.manageJewelsToolStripMenuItem.Click += new System.EventHandler(this.manageJewelsToolStripMenuItem_Click);
            // 
            // printTagForAllJewelsToolStripMenuItem
            // 
            this.printTagForAllJewelsToolStripMenuItem.Name = "printTagForAllJewelsToolStripMenuItem";
            this.printTagForAllJewelsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.printTagForAllJewelsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.printTagForAllJewelsToolStripMenuItem.Text = "Print Tag for all Jewels";
            this.printTagForAllJewelsToolStripMenuItem.Click += new System.EventHandler(this.printTagForAllJewelsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marketingCatalogueToolStripMenuItem,
            this.toolStripSeparator14,
            this.firmInfoToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator4});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(68, 20);
            this.toolsMenu.Text = "Catalogue";
            // 
            // marketingCatalogueToolStripMenuItem
            // 
            this.marketingCatalogueToolStripMenuItem.Name = "marketingCatalogueToolStripMenuItem";
            this.marketingCatalogueToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.marketingCatalogueToolStripMenuItem.Text = "Catalogue Order";
            this.marketingCatalogueToolStripMenuItem.Click += new System.EventHandler(this.marketingCatalogueToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(170, 6);
            // 
            // firmInfoToolStripMenuItem
            // 
            this.firmInfoToolStripMenuItem.Name = "firmInfoToolStripMenuItem";
            this.firmInfoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.firmInfoToolStripMenuItem.Text = "Marketing Catalogue";
            this.firmInfoToolStripMenuItem.Click += new System.EventHandler(this.firmInfoToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.settingsToolStripMenuItem.Text = "App Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(62, 20);
            this.windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(40, 20);
            this.helpMenu.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(159, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpbtn
            // 
            this.helpbtn.Image = global::JewelCatalogue.Properties.Resources.help;
            this.helpbtn.Location = new System.Drawing.Point(718, 190);
            this.helpbtn.Name = "helpbtn";
            this.helpbtn.Size = new System.Drawing.Size(34, 28);
            this.helpbtn.TabIndex = 12;
            this.helpbtn.UseVisualStyleBackColor = true;
            this.helpbtn.Click += new System.EventHandler(this.helpbtn_Click);
            // 
            // frmMDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 453);
            this.Controls.Add(this.helpbtn);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.autoComplete);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMDIParent";
            this.Text = "JEWEL CATALOGUE";
            this.toolTip.SetToolTip(this, "JEWEL CATALOGUE");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMDIParent_FormClosed);
            this.Load += new System.EventHandler(this.frmMDIParent_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
		private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripButton addToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.ToolStripButton firstToolStripButton;
		private System.Windows.Forms.ToolStripButton previousToolStripButton;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private System.Windows.Forms.ToolStripButton lastToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripButton refreshToolStripButton;
		public System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripSearch;
		public JetCoders.Forms.UI.Input.CoolTextBox autoComplete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripStatusLabel username;
        private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.ToolStripMenuItem firmInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageJewelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ToolStripMenuItem marketingCatalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printTagForAllJewelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button helpbtn;
	}
}



