using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using JetCoders.Forms.UI.Win32;

namespace JetCoders.Forms.UI.Input
{
	/// <summary>
	/// Summary description for AutoCompleteTextBox.
	/// </summary>
	[Serializable]
	public class AutoCompleteTextBox : TextBox
	{

		#region Classes and Structures

		public enum EntryMode
		{
			Text,
			List
		}

		/// <summary>
		/// This is the class we will use to hook mouse events.
		/// </summary>
		private class WinHook : NativeWindow
		{
			private readonly AutoCompleteTextBox tb;

			/// <summary>
			/// Initializes a new instance of <see cref="WinHook"/>
			/// </summary>
			/// <param name="tbox">The <see cref="AutoCompleteTextBox"/> the hook is running for.</param>
			public WinHook(AutoCompleteTextBox tbox)
			{
				tb = tbox;
			}

			/// <summary>
			/// Look for any kind of mouse activity that is not in the
			/// text box itself, and hide the popup if it is visible.
			/// </summary>
			/// <param name="m"></param>
			protected override void WndProc(ref Message m)
			{
				switch (m.Msg)
				{
					case Messages.WM_LBUTTONDOWN:
					case Messages.WM_LBUTTONDBLCLK:
					case Messages.WM_MBUTTONDOWN:
					case Messages.WM_MBUTTONDBLCLK:
					case Messages.WM_RBUTTONDOWN:
					case Messages.WM_RBUTTONDBLCLK:
					case Messages.WM_NCLBUTTONDOWN:
					case Messages.WM_NCMBUTTONDOWN:
					case Messages.WM_NCRBUTTONDOWN:
					{
						// Lets check to see where the event took place
						Form form = tb.FindForm();
					    if (form != null)
					    {
					        var p = form.PointToScreen(new Point((int)m.LParam));
					        var p2 = tb.PointToScreen(new Point(0, 0));
					        var rect = new Rectangle(p2, tb.Size);
					        // Hide the popup if it is not in the text box
					        if (!rect.Contains(p))
					        {
					            tb.HideList();
					        }
					    }
					} break;
					case Messages.WM_SIZE:
					case Messages.WM_MOVE:
					{
						tb.HideList();
					} break;
					// This is the message that gets sent when a childcontrol gets activity
					case Messages.WM_PARENTNOTIFY:
					{
						switch ((int)m.WParam)
						{
							case Messages.WM_LBUTTONDOWN:
							case Messages.WM_LBUTTONDBLCLK:
							case Messages.WM_MBUTTONDOWN:
							case Messages.WM_MBUTTONDBLCLK:
							case Messages.WM_RBUTTONDOWN:
							case Messages.WM_RBUTTONDBLCLK:
							case Messages.WM_NCLBUTTONDOWN:
							case Messages.WM_NCMBUTTONDOWN:
							case Messages.WM_NCRBUTTONDOWN:
							{
								// Same thing as before
								var form = tb.FindForm();
							    if (form != null)
							    {
							        var p = form.PointToScreen(new Point((int)m.LParam));
							        var p2 = tb.PointToScreen(new Point(0, 0));
							        var rect = new Rectangle(p2, tb.Size);
							        if (!rect.Contains(p))
							        {
							            tb.HideList();
							        }
							    }
							} break;
						}
					} break;
				}
				
				base.WndProc (ref m);
			}
		}

		#endregion

		#region Members

		private readonly ListBox list;
		protected Form popup;
		private WinHook hook;

		#endregion

		#region Properties

		private EntryMode mode = EntryMode.Text;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public EntryMode Mode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
			}
		}

		private AutoCompleteEntryCollection items = new AutoCompleteEntryCollection();
		[Editor(typeof(AutoCompleteEntryCollection.AutoCompleteEntryCollectionEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteEntryCollection Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
			}
		}

		private AutoCompleteTriggerCollection triggers = new AutoCompleteTriggerCollection();
		[Editor(typeof(AutoCompleteTriggerCollection.AutoCompleteTriggerCollectionEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AutoCompleteTriggerCollection Triggers
		{
			get
			{
				return triggers;
			}
			set
			{
				triggers = value;
			}
		}

		[Browsable(true)]
		[Description("The width of the popup (-1 will auto-size the popup to the width of the textbox).")]
		public int PopupWidth
		{
			get
			{
				return popup.Width;
			}
			set {
			    popup.Width = value == -1 ? Width : value;
			}
		}

		public BorderStyle PopupBorderStyle
		{
			get
			{
				return list.BorderStyle;
			}
			set
			{
				list.BorderStyle = value;
			}
		}

		private Point popOffset = new Point(12, 0);
		[Description("The popup defaults to the lower left edge of the textbox.")]
		public Point PopupOffset
		{
			get
			{
				return popOffset;
			}
			set
			{
				popOffset = value;
			}
		}

		private Color popSelectBackColor = SystemColors.Highlight;
		public Color PopupSelectionBackColor
		{
			get
			{
				return popSelectBackColor;
			}
			set
			{
				popSelectBackColor = value;
			}
		}

		private Color popSelectForeColor = SystemColors.HighlightText;
		public Color PopupSelectionForeColor
		{
			get
			{
				return popSelectForeColor;
			}
			set
			{
				popSelectForeColor = value;
			}
		}

		private bool triggersEnabled = true;
		protected bool TriggersEnabled
		{
			get
			{
				return triggersEnabled;
			}
			set
			{
				triggersEnabled = value;
			}
		}

		[Browsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				TriggersEnabled = false;
				base.Text = value;
				TriggersEnabled = true;
			}
		}

		#endregion

		public AutoCompleteTextBox()
		{
			// Create the form that will hold the filter
			popup = new Form
			{
			    StartPosition = FormStartPosition.Manual,
			    ShowInTaskbar = false,
			    FormBorderStyle = FormBorderStyle.None,
			    TopMost = true
			};
		    popup.Deactivate += Popup_Deactivate;

			// Create the filter box that will hold mathcing items
			list = new ListBox {Cursor = Cursors.Hand, BorderStyle = BorderStyle.None};
		    list.SelectedIndexChanged += List_SelectedIndexChanged;
			list.MouseDown += List_MouseDown;
			list.ItemHeight = 14;
			list.DrawMode = DrawMode.OwnerDrawFixed;
			list.DrawItem += List_DrawItem;
			list.Dock = DockStyle.Fill;
		
			// Add the filter box to the popup form
			popup.Controls.Add(list);

			// Add default triggers.
			triggers.Add(new TextLengthTrigger(2));
			triggers.Add(new ShortCutTrigger(Keys.Enter, TriggerState.SelectAndConsume));
			triggers.Add(new ShortCutTrigger(Keys.Tab, TriggerState.Select));
			triggers.Add(new ShortCutTrigger(Keys.Control | Keys.Space, TriggerState.ShowAndConsume));
			triggers.Add(new ShortCutTrigger(Keys.Escape, TriggerState.HideAndConsume));
		}

		protected virtual bool DefaultCmdKey(ref Message msg, Keys keyData)
		{
			bool val = base.ProcessCmdKey (ref msg, keyData);

			if (TriggersEnabled)
			{
				switch (Triggers.OnCommandKey(keyData))
				{
					case TriggerState.ShowAndConsume:
					{
						val = true;
						ShowList();
					} break;
					case TriggerState.Show:
					{
						ShowList();
					} break;
					case TriggerState.HideAndConsume:
					{
						val = true;
						HideList();
					} break;
					case TriggerState.Hide:
					{
						HideList();
					} break;
					case TriggerState.SelectAndConsume:
					{
						if (popup.Visible)
						{
							val = true;
							SelectCurrentItem();
						}
					} break;
					case TriggerState.Select:
					{
						if (popup.Visible)
						{
							SelectCurrentItem();
						}
					} break;
				}
			}

			return val;
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Up:
				{
					Mode = EntryMode.List;
					if (list.SelectedIndex > 0)
					{
						list.SelectedIndex--;
					}
					return true;
				} 
				case Keys.Down:
				{
					Mode = EntryMode.List;
					if (list.SelectedIndex < list.Items.Count - 1)
					{
						list.SelectedIndex++;
					}
					return true;
				}
				default:
				{
					return DefaultCmdKey(ref msg, keyData);
				}
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged (e);

			if (TriggersEnabled)
			{
				switch (Triggers.OnTextChanged(Text))
				{
					case TriggerState.Show:
					{
						ShowList();
					} break;
					case TriggerState.Hide:
					{
						HideList();
					} break;
					default:
					{
						UpdateList();
					} break;
				}
			}
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);

			if (!(Focused || popup.Focused || list.Focused))
			{
				HideList();
			}
		}

		protected virtual void SelectCurrentItem()
		{
			if (list.SelectedIndex == -1)
			{
				return;
			}

			Focus();
			Text = list.SelectedItem.ToString();
			if (Text.Length > 0)
			{
				SelectionStart = Text.Length;
			}

			HideList();
		}

		protected virtual void ShowList()
		{
			if (popup.Visible == false)
			{
				list.SelectedIndex = -1;
				UpdateList();
				Point p = PointToScreen(new Point(0,0));
				p.X += PopupOffset.X;
				p.Y += Height + PopupOffset.Y;
				popup.Location = p;

			    if (list.Items.Count <= 0) 
                    return;

			    popup.Show();
			    if (hook == null)
			    {
			        hook = new WinHook(this);
			        var findForm = FindForm();
			        if (findForm != null) hook.AssignHandle(findForm.Handle);
			    }
			    Focus();
			} 
			else
			{
				UpdateList();
			}
		}

		protected virtual void HideList()
		{
			Mode = EntryMode.Text;
			if (hook != null)
				hook.ReleaseHandle();
			hook = null;
			popup.Hide();
		}

		protected virtual void UpdateList()
		{
			object selectedItem = list.SelectedItem;

			list.Items.Clear();
			list.Items.AddRange(FilterList(Items).ToObjectArray());

			if (selectedItem != null &&
				list.Items.Contains(selectedItem))
			{
				EntryMode oldMode = Mode;
				Mode = EntryMode.List;
				list.SelectedItem = selectedItem;
				Mode = oldMode;
			}

			if (list.Items.Count == 0)
			{
				HideList();
			} 
			else
			{
				int visItems = list.Items.Count;
				if (visItems > 8)
					visItems = 8;

				popup.Height = (visItems * list.ItemHeight) + 2;
				switch (BorderStyle)
				{
					case BorderStyle.FixedSingle:
					{
						popup.Height += 2;
					} break;
					case BorderStyle.Fixed3D:
					{
						popup.Height += 4;
					} break;
				    default:
					{
					} break;
				}
				
				popup.Width = PopupWidth;

				if (list.Items.Count > 0 &&
					list.SelectedIndex == -1)
				{
					EntryMode oldMode = Mode;
					Mode = EntryMode.List;
					list.SelectedIndex = 0;
					Mode = oldMode;
				}

			}
		}

		protected virtual AutoCompleteEntryCollection FilterList(AutoCompleteEntryCollection filter)
		{
			var newList = new AutoCompleteEntryCollection();
			foreach (IAutoCompleteEntry entry in filter)
			{
				if (entry.MatchStrings.Any(match => match.ToUpper().StartsWith(Text.ToUpper())))
				{
				    newList.Add(entry);
				}
			}
			return newList;
		}

		private void List_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Mode != EntryMode.List)
			{
				SelectCurrentItem();
			}
		}

		private void List_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i=0; i<list.Items.Count; i++)
			{
				if (list.GetItemRectangle(i).Contains(e.X, e.Y))
				{
					list.SelectedIndex = i;
					SelectCurrentItem();
				}
			}
			HideList();
		}

		private void List_DrawItem(object sender, DrawItemEventArgs e)
		{
		    if (e.State == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(PopupSelectionBackColor), e.Bounds);
				e.Graphics.DrawString(list.Items[e.Index].ToString(), e.Font, new SolidBrush(PopupSelectionForeColor), e.Bounds, StringFormat.GenericDefault);
			} 
			else
			{
				e.DrawBackground();
				e.Graphics.DrawString(list.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
			}
		}

		private void Popup_Deactivate(object sender, EventArgs e)
		{
			if (!(Focused || popup.Focused || list.Focused))
			{
				HideList();
			}
		}

	}
}
