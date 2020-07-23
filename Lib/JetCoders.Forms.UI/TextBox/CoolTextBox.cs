using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace JetCoders.Forms.UI.Input
{
	/// <summary>
	/// Summary description for CoolTextBox.
	/// </summary>
	public class CoolTextBox : UserControl
	{
		private Color borderColor = Color.LightSteelBlue;
		public Color BorderColor
		{
			get
			{
				return borderColor;
			}
			set
			{
				if (borderColor != value)
				{
					borderColor = value;
					Invalidate();
				}
			}
		}

		public Color SelectedItemBackColor
		{
			get
			{
				return autoCompleteTextBox1.PopupSelectionBackColor;
			}
			set
			{
				autoCompleteTextBox1.PopupSelectionBackColor = value;
			}
		}

		public Color SelectedItemForeColor
		{
			get
			{
				return autoCompleteTextBox1.PopupSelectionForeColor;
			}
			set
			{
				autoCompleteTextBox1.PopupSelectionForeColor = value;
			}
		}

		[Editor(typeof(AutoCompleteEntryCollection.AutoCompleteEntryCollectionEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteEntryCollection Items
		{
			get
			{
				return autoCompleteTextBox1.Items;
			}
			set
			{
				autoCompleteTextBox1.Items = value;
			}
		}

		[Editor(typeof(AutoCompleteTriggerCollection.AutoCompleteTriggerCollectionEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteTriggerCollection Triggers
		{
			get
			{
				return autoCompleteTextBox1.Triggers;
			}
			set
			{
				autoCompleteTextBox1.Triggers = value;
			}
		}

		[Browsable(true)]
		public override string Text
		{
			get
			{
				return autoCompleteTextBox1.Text;
			}
			set
			{
				autoCompleteTextBox1.Text = value;
			}
		}

		public override Color ForeColor
		{
			get
			{
				return autoCompleteTextBox1.ForeColor;
			}
			set
			{
				autoCompleteTextBox1.ForeColor = value;
			}
		}

		public override ContextMenu ContextMenu
		{
			get
			{
				return autoCompleteTextBox1.ContextMenu;
			}
			set
			{
				autoCompleteTextBox1.ContextMenu = value;
			}
		}

		public int PopupWidth
		{
			get
			{
				return autoCompleteTextBox1.PopupWidth;
			}
			set
			{
				autoCompleteTextBox1.PopupWidth = value;
			}
		}

        private AutoCompleteTextBox autoCompleteTextBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private readonly Container _components = null;

		public CoolTextBox()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			Rectangle rect = ClientRectangle;
			rect.Width -= 1;
			rect.Height -= 1;
			var p = new Pen(BorderColor);
			e.Graphics.DrawRectangle(p, rect);
			
			p = new Pen(Color.FromArgb(100, BorderColor)); 
			rect.Inflate(-1, -1);
			e.Graphics.DrawRectangle(p, rect);
			
			p = new Pen(Color.FromArgb(45, BorderColor)); 
			rect.Inflate(-1, -1);
			e.Graphics.DrawRectangle(p, rect);

			p = new Pen(Color.FromArgb(15, BorderColor)); 
			rect.Inflate(-1, -1);
			e.Graphics.DrawRectangle(p, rect);

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(_components != null)
				{
					_components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            autoCompleteTextBox1 = new JetCoders.Forms.UI.Input.AutoCompleteTextBox();
            SuspendLayout();
            // 
            // autoCompleteTextBox1
            // 
            autoCompleteTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            autoCompleteTextBox1.Location = new System.Drawing.Point(4, 4);
            autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            autoCompleteTextBox1.PopupBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            autoCompleteTextBox1.PopupOffset = new System.Drawing.Point(0, 4);
            autoCompleteTextBox1.PopupSelectionBackColor = System.Drawing.SystemColors.ControlText;
            autoCompleteTextBox1.PopupSelectionForeColor = System.Drawing.SystemColors.HighlightText;
            autoCompleteTextBox1.PopupWidth = 350;
            autoCompleteTextBox1.Size = new System.Drawing.Size(0, 20);
            autoCompleteTextBox1.TabIndex = 0;
            autoCompleteTextBox1.SizeChanged += new System.EventHandler(TextBox_SizeChanged);
            // 
            // CoolTextBox
            // 
            AutoSize = true;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(autoCompleteTextBox1);
            Name = "CoolTextBox";
            Padding = new System.Windows.Forms.Padding(4);
            Size = new System.Drawing.Size(8, 8);
            ResumeLayout(false);
            PerformLayout();

		}
		#endregion

		private void TextBox_SizeChanged(object sender, EventArgs e)
		{
		    var tb = sender as AutoCompleteTextBox;

		    if (tb != null) Height = tb.Height + 8;
		}
	}
}
