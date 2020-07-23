using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using Connections.Entities;
using JetCoders.Shared;
using JewelInventory.Properties;
using NLog;
using System.Drawing;

namespace JewelInventory
{
    public class BaseFormControl : Form, IValidator
    {
        private IWinSettingProvider _winsetting;
        private IinventoryContainer _coredatacontext;
        private frmMDIParent _frmMdiParent;
        private readonly ErrorProvider _baseErrorControl;
        private Dictionary<String, String> Errors { get; set; }
        private readonly List<Control> _crtl;
        protected static Logger Logger = LogManager.GetCurrentClassLogger();

        public BaseFormControl()
        {
            Errors = new Dictionary<String, String>();
            _crtl = new List<Control>();
            _baseErrorControl = new ErrorProvider();
        }

        protected object FormData { get; set; }
        protected bool IsEdited { get; set; }

        protected void ShowManagedForm<T>(BaseFormControl owner, OwnerType ownerType = OwnerType.MdiOwner, object data = null) where T : BaseFormControl
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
            form.FormData = data;
            form.Show();
        }

        protected void ShowManagedModalForm<T>(BaseFormControl owner, object data = null) where T : BaseFormControl
        {
            var type = typeof(T);

            var form = (T)BootStrapper.Container.Resolve(type, type.Name);
            form.Owner = owner;
            form.FormData = data;
            form.CenterToScreen();
            form.ShowDialog();
        }

        public frmMDIParent MDIForm
        {
            get { return _frmMdiParent ?? (_frmMdiParent = (frmMDIParent) Application.OpenForms["frmMDIParent"]); }
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

            MdiAction();

        baseactivation:
            base.OnActivated(e);
        }

        public void MdiAction()
        {
            if ((MDIForm.ActiveMdiChild is INavigable))
            {
                var child = MDIForm.ActiveMdiChild as INavigable;

                switch (child.MdiMode)
                {
                    case FormMode.Normal:
                        IsEdited = false;

                        MDIForm.toolStrip.Enabled = true;
                        MDIForm.toolStrip.Items["addToolStripButton"].Enabled = true;

                        MDIForm.toolStrip.Items["nextToolStripButton"].Enabled = true;
                        MDIForm.toolStrip.Items["previousToolStripButton"].Enabled = true;

                        if (!child.HasNext)
                            MDIForm.toolStrip.Items["nextToolStripButton"].Enabled = false;

                        if (!child.HasPrev)
                            MDIForm.toolStrip.Items["previousToolStripButton"].Enabled = false;

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

                        IsEdited = true;
                        MDIForm.toolStrip.Enabled = true;
                        MDIForm.toolStrip.Items["addToolStripButton"].Enabled = false;
                        MDIForm.toolStrip.Items["editToolStripButton"].Enabled = false;

                        break;
                    case FormMode.Add:
                        foreach (var i in MDIForm.toolStrip.Items)
                        {
                            var toolStripItem = i as ToolStripItem;
                            if (toolStripItem != null) toolStripItem.Enabled = false;
                        }

                        IsEdited = true;
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
                    var toolStripItem = i as ToolStripItem;
                    if (toolStripItem != null) toolStripItem.Enabled = false;
                }
            }
        }

        public void CellClick(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {
                using (var imageWide = new frmProductWideImage())
                {
                    imageWide.pbProductImage.Image = (Image)dataGridView["JewelImage", e.RowIndex].Value;
                    imageWide.lblStyleName.Text = Convert.ToString(dataGridView["StyleNo", e.RowIndex].Value);
                    imageWide.Text = Convert.ToString(dataGridView["StyleNo", e.RowIndex].Value);
                    imageWide.lblColor.Text = Convert.ToString(dataGridView["MetalColor", e.RowIndex].Value);
                    imageWide.lblGoldWt.Text = Convert.ToString(dataGridView["GoldWt", e.RowIndex].Value);
                    imageWide.lblDiWt.Text = Convert.ToString(dataGridView["DiaWt", e.RowIndex].Value);
                    imageWide.lblDiPcs.Text = Convert.ToString(dataGridView["DiaPcs", e.RowIndex].Value);
                    imageWide.Show();
                }
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
                if (MessageBox.Show(Resources.BaseFormControl_CloseOrderForm_Are_you_sure_want_to_cancel_order_, @"Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
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

        public int ErrorCount { get { return Errors.Count; } }

        public Dictionary<String, String> AllErrors { get { return Errors; } }

        public void AddValidationError(String key, String value)
        {
            Errors.Add(key, value);
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

            Errors.Clear();
            _baseErrorControl.Clear();

            // Need to stop blinking of errorCrtlList control behavious
            var errorCrtlList = new List<Control>();
            _crtl.Clear();
            var isValid = true;

            FindInputControls(form.Controls);

            foreach (var crtl in _crtl)
            {
                if (crtl is TextBox)
                {
                    var textControl = crtl as TextBox;
                    if (textControl.CausesValidation && textControl.Enabled && !textControl.ReadOnly && textControl.Text.IsEmpty())
                    {
                        isValid = false;
                        AddValidationError(textControl.Name, textControl.AccessibleName + " is required field.");
                        errorCrtlList.Add(textControl);
                    }
                }
                if (crtl is ComboBox)
                {
                    var comboControl = crtl as ComboBox;
                    if (comboControl.CausesValidation && comboControl.SelectedIndex == -1)
                    {
                        isValid = false;
                        AddValidationError(comboControl.Name, comboControl.AccessibleName + " is required field.");
                        errorCrtlList.Add(comboControl);
                    }
                }
            }

            foreach (var crtl in errorCrtlList)
            {
                _baseErrorControl.SetError(crtl, crtl.AccessibleName + " is required field.");
            }

            return isValid;
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormControl));
            this.SuspendLayout();
            // 
            // BaseFormControl
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseFormControl";
            this.ResumeLayout(false);

        }
    }
}