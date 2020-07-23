using System.Windows.Forms;
using System.Drawing;
using JetCoders.Shared;

namespace JetCoders.Forms.UI
{
    public class GridExtension
    {
        public static DataGridViewTextBoxColumn GetDescriptionColumn(string column, bool isReadlyOnly, bool isHidden = false)
        {
            var columnForDescription = new DataGridViewTextBoxColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column,
                ReadOnly = isReadlyOnly,
                Width = 200,
                Visible = !isHidden
            };

            if (isReadlyOnly)
                columnForDescription.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray };

            columnForDescription.SortMode = DataGridViewColumnSortMode.NotSortable;

            return columnForDescription;
        }

        public static DataGridViewLinkColumn GetButtonColumn(string column)
        {
            var columnForButton = new DataGridViewLinkColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            return columnForButton;
        }

        public static DataGridViewColumn GetCheckBxColumn(string column, bool check = false)
        {
            var columnChk = new DataGridViewCheckBoxColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column,
                Width = 50,
                Visible = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            return columnChk;
        }

        public static DataGridViewColumn GetImageColumn(string column)
        {
            var columnImg = new DataGridViewImageColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                FillWeight = 50,
                Width = 47,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            return columnImg;
        }

        public static void FormatImageCell(DataGridView mapGrid, string coloumn)
        {
            var image = (mapGrid.Columns[coloumn] as DataGridViewImageColumn);
            if (image == null) return;
            image.FillWeight = 50;
            image.Width = 47;
            image.SortMode = DataGridViewColumnSortMode.NotSortable;
            image.ImageLayout = DataGridViewImageCellLayout.Zoom;image.ImageLayout = DataGridViewImageCellLayout.Zoom;
            image.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public static void FormatToUpperCaseTextBox(DataGridView mapGrid, string coloumn, int maxlength= 255)
        {
            var textbox = (mapGrid.Columns[coloumn] as DataGridViewTextBoxColumn);
            if (textbox != null) textbox.MaxInputLength = maxlength;
        }
    }

    
}
