using System;
using Connections;
using System.Linq;
using JetCoders.Shared;
using System.Windows.Forms;

namespace JewelCatalogue
{
    public abstract class frmNavigableForm<T>
                : frmDataEntry
        where T : IEntityBase
    {
        PagedItem<T> _currentItem;
        protected const int TotalPages = 1;

        public abstract void BindValues(T entity);

        public int CurrentItemIndex
        {
            get
            {
                if (CurrentItem == null)
                    return 1;

                return CurrentItem.Position;
            }
        }

        protected IQueryable<T> QueryableItems { get; set; }

        protected PagedItem<T> CurrentItem
        {
            get { return _currentItem ?? (_currentItem = new PagedItem<T>(QueryableItems, 0)); }
            set { _currentItem = value; }
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    btnSave.Enabled = true;
                    break;
                case "Edit":
                    btnSave.Enabled = true;
                    break;
                case "Next":
                    {
                        CurrentItem = new PagedItem<T>(QueryableItems, CurrentItemIndex + 1);
                        BindValues(CurrentItem.Entity);
                        if (!CurrentItem.HasNextRecord)
                            MDIForm.toolStrip.Items["nextToolStripButton"].Enabled = false;
                        break;
                    }
                case "Previous":
                    {
                        CurrentItem = new PagedItem<T>(QueryableItems, CurrentItemIndex - 1);
                        BindValues(CurrentItem.Entity);
                        if (!CurrentItem.HasPreviousRecord)
                            MDIForm.toolStrip.Items["previousToolStripButton"].Enabled = false;
                        break;
                    }
                case "First":
                    {
                        CurrentItem = new PagedItem<T>(QueryableItems, 1);
                        BindValues(CurrentItem.Entity);
                        if (!CurrentItem.HasPreviousRecord)
                            MDIForm.toolStrip.Items["previousToolStripButton"].Enabled = false;
                        break;
                    }
                case "Last":
                    {
                        CurrentItem = new PagedItem<T>(QueryableItems, CurrentItem.TotalRecords);
                        BindValues(CurrentItem.Entity);
                        if (!CurrentItem.HasNextRecord)
                            MDIForm.toolStrip.Items["nextToolStripButton"].Enabled = false;
                        break;
                    }
                case "Refresh":
                    {
                        btnSave.Enabled = false;
                        OnActivated(null);
                        break;
                    }
                case "Search":
                    {
                        break;
                    }
                default:
                    btnSave.Enabled = false;
                    break;
            }

            MDIAction();
            base.ToolStripItems_Clicked(sender, e);
        }

        protected override void OnActivated(EventArgs e)
        {
            foreach (var i in MDIForm.toolStrip.Items)
            {
                using (var toolStripItem = i as ToolStripItem)
                {
                    if (toolStripItem != null) toolStripItem.Enabled = false;
                }
            }

            MDIForm.toolStrip.Items["editToolStripButton"].Enabled = CurrentItem != null;

            base.OnActivated(e);
        }

        // http://support.microsoft.com/kb/320584
        // Navigatoion with left & right keys through record.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (((INavigable)this).MdiMode != FormMode.Normal)
                return base.ProcessCmdKey(ref msg, keyData);

            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                ToolStripItemClickedEventArgs args;
                switch (keyData)
                {
                    case Keys.Right:
                        args = new ToolStripItemClickedEventArgs(new ToolStripButton("Next"));
                        ToolStripItems_Clicked(this, args);
                        break;
                    case Keys.Left:
                        args = new ToolStripItemClickedEventArgs(new ToolStripButton("Previous"));
                        ToolStripItems_Clicked(this, args);
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
