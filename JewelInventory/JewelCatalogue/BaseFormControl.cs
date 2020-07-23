using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using Connections.Entities;
using JetCoders.Shared;
using JewelCatalogue.Properties;
using NLog;
using System.Drawing;

namespace JewelCatalogue
{
	public class BaseFormControl : Form, IValidator
	{
		private IWinSettingProvider _winsetting;
		private IinventoryContainer _coredatacontext;
		private frmMDIParent _frmMDIParent;
		private readonly ErrorProvider baseErrorControl;
		private Dictionary<String, String> _errors { get; set; }
		private readonly List<Control> _crtl;
		protected static Logger Logger = LogManager.GetCurrentClassLogger();

		public BaseFormControl()
		{
			_errors = new Dictionary<String, String>();
			_crtl = new List<Control>();
			baseErrorControl = new ErrorProvider();
		}

        protected void ShowManagedForm<T>(Form owner, OwnerType ownerType = OwnerType.MdiOwner) where T : Form
        {
            var type = typeof(T);
            if (owner != null && owner.IsMdiContainer)
            {
                bool isAlreadyOpen = owner.MdiChildren.Any(x => x.Name == type.Name);
                if (isAlreadyOpen)
                {
                    owner.MdiChildren.Single(x => x.Name == type.Name).Activate();
                    return;
                }
            }
            var form = (T)BootStrapper.Container.Resolve(type, type.Name);
            if (owner != null)
            {
                if (ownerType == OwnerType.MdiOwner)
                {
                    form.MdiParent = owner;
                }
                else
                {
                    form.Owner = owner;
                }
                form.WindowState = FormWindowState.Maximized;
            }

            //if (form is frmlstCosting) form.TopMost = true;
            form.Show();
        }

		public frmMDIParent MDIForm
		{
			get { return _frmMDIParent ?? (_frmMDIParent = (frmMDIParent) Application.OpenForms["frmMDIParent"]); }
		}

		protected void SetMDIMode(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e == null) return;

			if (MDIForm.ActiveMdiChild != null)
			{
				var form = MDIForm.ActiveMdiChild as frmDataEntry;
				if (form == null) return;

				form.ToolStripItems_Clicked(sender, e);
			}
		}

		protected override void OnActivated(EventArgs e)
		{
			if (MDIForm == null)
				goto baseactivation;

			MDIAction();

		baseactivation:
			base.OnActivated(e);
		}

		public void MDIAction()
		{
			if ((MDIForm.ActiveMdiChild is INavigable))
			{
				var child = MDIForm.ActiveMdiChild as INavigable;

				switch (child.MdiMode)
				{
					case FormMode.Normal:
						MDIForm.toolStrip.Enabled = true;
						MDIForm.toolStrip.Items["addToolStripButton"].Enabled = true;

						if (child.HasNext || child.HasPrev)
						{
							MDIForm.toolStrip.Items["lastToolStripButton"].Enabled = true;
							MDIForm.toolStrip.Items["firstToolStripButton"].Enabled = true;
						}
						break;
					case FormMode.Edit:
						foreach (var i in MDIForm.toolStrip.Items)
						{
						    var toolStripItem = i as ToolStripItem;
						    if (toolStripItem != null) toolStripItem.Enabled = false;
						}

				        MDIForm.toolStrip.Enabled = true;
						MDIForm.toolStrip.Items["addToolStripButton"].Enabled = false;
						MDIForm.toolStrip.Items["editToolStripButton"].Enabled = false;
						
						break;
					case FormMode.Add:
						foreach (var toolStripItem in MDIForm.toolStrip.Items.OfType<ToolStripItem>())
						{
						    toolStripItem.Enabled = false;
						}

				        MDIForm.toolStrip.Enabled = true;
						MDIForm.toolStrip.Items["addToolStripButton"].Enabled = false;
						MDIForm.toolStrip.Items["editToolStripButton"].Enabled = false;
						break;
					
				}

				//MDIForm.toolStrip.Items["toolStripPrint"].Enabled = true;
				MDIForm.toolStrip.Items["refreshToolStripButton"].Enabled = true;
				MDIForm.toolStrip.Items["toolStripSearch"].Enabled = true;
			}
			else
			{
				foreach (var i in MDIForm.toolStrip.Items)
				{
				    using (var toolStripItem = i as ToolStripItem)
				    {
				        if (toolStripItem != null) toolStripItem.Enabled = false;
				    }
				}
			}
		}

		public void CellClick(DataGridView dataGridView, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1) return;

			if (e.ColumnIndex == 1)
			{
				var ImageWide = new frmProductWideImage
				{
				    pbProductImage = {Image = (Image) dataGridView["JewelImage", e.RowIndex].Value},
				    lblStyleName = {Text = Convert.ToString(dataGridView["StyleNo", e.RowIndex].Value)},
				    Text = Convert.ToString(dataGridView["StyleNo", e.RowIndex].Value),
				    lblColor = {Text = Convert.ToString(dataGridView["MetalColor", e.RowIndex].Value)},
				    lblNetWt = {Text = Convert.ToString(dataGridView["NetWt", e.RowIndex].Value)},
				    lblGrsWt = {Text = Convert.ToString(dataGridView["GrsWt", e.RowIndex].Value)},
				    lblDiWt = {Text = Convert.ToString(dataGridView["DiaWt", e.RowIndex].Value)},
				    lblDiPcs = {Text = Convert.ToString(dataGridView["DiaPcs", e.RowIndex].Value)}
				};
			    ImageWide.Show();
			}
		}

		public void CellMouseMove(DataGridView dataGridView, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == 1)
			{
				Cursor.Current = Cursors.Hand;
				dataGridView.Columns[1].ToolTipText = Resources.BaseFormControl_CellMouseMove_Click_here_for_Thumbnails;
			}
		}

		public void CloseOrderForm(DataGridView dataGridView, Form form)
		{
			if (dataGridView.RowCount > 0)
			{
				if (MessageBox.Show(Resources.BaseFormControl_CloseOrderForm_Are_you_sure_want_to_cancel_order_, "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
					return;
			}
			form.Close();
		}

		#region Settings
		protected IWinSettingProvider CoreSettings
		{
			get
			{
				if (_winsetting != null)
					return _winsetting;

				return _winsetting = GetServiceFor<WinSettingProvider>();
			}
		}

		protected IinventoryContainer CoreDataContext
		{
			get
			{
				if (_coredatacontext != null)
					return _coredatacontext;

				return _coredatacontext = new inventoryContainer();
			}
		}

		private T GetServiceFor<T>()
		{
			Type type = typeof(T);
			return (T)BootStrapper.Container.Resolve(type, type.Name);
		}
		#endregion

		#region IValidator

		public int ErrorCount { get { return _errors.Count; } }

		public Dictionary<String, String> AllErrors { get { return _errors; } }

		public void AddValidationError(String key, String value)
		{
			_errors.Add(key, value);
		}

		public bool IsValid
		{
			get
			{
				Form form = MDIForm != null ? MDIForm.ActiveMdiChild ?? ActiveForm : ActiveForm;

				return _validateForm(form);
			}
		}

		/// <summary>
		/// To validate control for require field validation. set AccessibleName for that control
		/// To avoid the validation on a control Set CausesValidation to false for that control
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		protected virtual bool _validateForm(Form form)
		{
			if (form == null)
				return false;

			_errors.Clear();
			baseErrorControl.Clear();

			// Need to stop blinking of errorCrtlList control behavious
			var errorCrtlList = new List<Control>();
			_crtl.Clear();
			bool _isValid = true;

			FindInputControls(form.Controls);

			foreach (var crtl in _crtl)
			{
				if (crtl is TextBox)
				{
					var _textControl = crtl as TextBox;
                    if (_textControl.CausesValidation && _textControl.Enabled && !_textControl.ReadOnly && _textControl.Text.IsEmpty())
					{
						_isValid = false;
						AddValidationError(_textControl.Name, _textControl.AccessibleName + " is required field.");
						errorCrtlList.Add(_textControl);
					}
				}
				if (crtl is ComboBox)
				{
					var _comboControl = crtl as ComboBox;
					if (_comboControl.CausesValidation && _comboControl.SelectedIndex == -1)
					{
						_isValid = false;
						AddValidationError(_comboControl.Name, _comboControl.AccessibleName + " is required field.");
						errorCrtlList.Add(_comboControl);
					}
				}
			}

			foreach (var crtl in errorCrtlList)
			{
				baseErrorControl.SetError(crtl, crtl.AccessibleName + " is required field.");
			}

			return _isValid;
		}

		private void FindInputControls(Control.ControlCollection controls)
		{
			foreach (Control ctrl in controls)
			{
				if (ctrl is TextBox || ctrl is ComboBox || ctrl is RadioButton || ctrl is CheckBox)
				{
					if (ctrl.Enabled)
						_crtl.Add(ctrl);
				}
				FindInputControls(ctrl.Controls);
			}
		}
		#endregion
	}
}