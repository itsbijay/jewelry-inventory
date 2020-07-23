using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI;
using JetCoders.Shared;
using Connections.Dataset;

namespace JewelInventory
{
    public partial class frmCreditNote : frmDataEntry
    {
        private const string _columndate = "Date";
        private const string _columncustomrecode = "Customer Code";
        private const string _columninvoiceno = "Invoice No";
        private const string _columnamount = "Amount";
        private const string _columnstatus = "Status";
        private const string _columnview = "View";

        private const string _columnactive = "Is Active";

        readonly ITransactionService _transactionService;
        readonly ICustomerService _customerServices;
        readonly IDataSetProvider _dataSetProvider;

        public frmCreditNote()
        {
            InitializeComponent();
        }

        public frmCreditNote(ITransactionService transactionServices, ICustomerService customerServices, IDataSetProvider dataSetProvider)
            : this()
        {
            _transactionService = transactionServices;
            _customerServices = customerServices;
            _dataSetProvider = dataSetProvider;
        }

        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndate, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncustomrecode, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columninvoiceno, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnstatus, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnamount, true));

            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columnview));
            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columnactive));

            mapGrid.CellContentClick += dgvJewel_CellContentClick;
        }

        private void frmCreditNote_Load(object sender, EventArgs e)
        {
            BindMemoForm();
            ConfigDataGridView(dgvCreditNote);
            dtCosting.Value = DateTime.Today;
        }

        private void BindMemoForm()
        {
            txtAmount.KeyPress += WinEvents.AllowNumeric_KeyPress;
            cboCustomer.DataSource = _customerServices.GetAllCustomers();
            cboCustomer.SelectedIndexChanged += oncboCustomerChanged;
            cboCustomer.SelectedIndex = -1;
        }

        void oncboCustomerChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex == -1)
                return;

            var customer = (Customer) cboCustomer.SelectedItem;
            cboInvoice.DataSource = _transactionService.GetJewelTransactionInvoices()
                                        .Where(c => c.TransactionPartyRef == customer.CustomersCode)
                                        .Select(x => x.InvoiceNumber);

            BindDataGrid(customer.CustomersCode);
        }

        private void BindDataGrid(string customerCode)
        {
            var dsCreditNote = _transactionService.GetCreditNotes().Where(x => x.CustomerCode == customerCode)
                    .OrderByDescending(x => x.TransactionDate).ThenByDescending(x => x.IsActive);
            dgvCreditNote.Rows.Clear();

            var _newRowNumber = dgvCreditNote.RowCount;

            foreach (var detail in dsCreditNote.ToList())
            {
                dgvCreditNote.Rows.Add(1);
                dgvCreditNote.Rows[_newRowNumber].Height = 50;
                dgvCreditNote.Rows[_newRowNumber].Cells[_columndate.ToLowerCaseColumnName()].Value = detail.TransactionDate;
                dgvCreditNote.Rows[_newRowNumber].Cells[_columncustomrecode.ToLowerCaseColumnName()].Value = detail.CustomerCode;

                dgvCreditNote.Rows[_newRowNumber].Cells[_columninvoiceno.ToLowerCaseColumnName()].Value = detail.InvoiceNo;
                dgvCreditNote.Rows[_newRowNumber].Cells[_columnamount.ToLowerCaseColumnName()].Value = detail.Amount;
                dgvCreditNote.Rows[_newRowNumber].Cells[_columnstatus.ToLowerCaseColumnName()].Value = detail.IsActive ? "UnCleared" : "Cleared";

                dgvCreditNote.Rows[_newRowNumber].Cells[_columnview.ToLowerCaseColumnName()].Value = "View";
                dgvCreditNote.Rows[_newRowNumber].Cells[_columnview.ToLowerCaseColumnName()].Tag = detail.Id;

                dgvCreditNote.Rows[_newRowNumber].Cells[_columnactive.ToLowerCaseColumnName()].Value = detail.IsActive ? "Done Payment" : "Undo Payment";
                dgvCreditNote.Rows[_newRowNumber].Cells[_columnactive.ToLowerCaseColumnName()].Tag = detail.Id;

                _newRowNumber = _newRowNumber + 1;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var customer = (Customer)cboCustomer.SelectedItem;
            var invoiceCode = (string)cboInvoice.SelectedItem;

            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            var request = new CreditNoteRequest
            {
                CreditNote = new CreditNote
                {
                    TransactionDate = dtCosting.Value,
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    CustomerCode = customer.CustomersCode,
                    IsActive =  true,
                    Description = txtDescription.Text,
                    InvoiceNo = invoiceCode
                }
            };

            var response = _transactionService.CreateCreditNote(request);
            if (false == response.IsValid)
            {
                MessageBox.Show(response.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            ShowCreditNoteReport(request.CreditNote.Id);
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var row = dgvCreditNote[e.ColumnIndex, e.RowIndex];
            var id = row.Tag;
            if (row.Value.ToString() == "View")
            {
                ShowCreditNoteReport((int)id);
            }
            else if (row.Value.ToString() == "Done Payment" || row.Value.ToString() == "Undo Payment")
            {
                var crn = _transactionService.GetCreditNotes().Single(x => x.Id == (int)id);
                crn.IsActive = !crn.IsActive;
                var request = new CreditNoteRequest { CreditNote = crn };
                _transactionService.CreateCreditNote(request);
                BindDataGrid(crn.CustomerCode);
            }
        }

        private void ShowCreditNoteReport(int id)
        {
            var creditNoteDataSet = new CreditNoteDataSet();
            var firmTable = creditNoteDataSet.Tables["FirmMaster"];
            var otherInfo = creditNoteDataSet.Tables["OtherInfo"];

            _dataSetProvider.GetFirmDataTable(firmTable);
            var crn = _transactionService.GetCreditNotes().Single(x => x.Id == id);
            var customer = (Customer)cboCustomer.SelectedItem;

            var otherRow = otherInfo.NewRow();
            otherRow["InvoiceNo"] = crn.InvoiceNo;
            otherRow["TransactionDate"] = crn.TransactionDate;
            otherRow["ContactName"] = customer.ContactName;
            otherRow["ContactNo"] = customer.Address.Phone;
            otherRow["Address"] = customer.Address.ToString();
            otherRow["Particulars"] = crn.Description;
            otherRow["TotalAmount"] = crn.Amount;
            otherRow["VATNumber"] = customer.VATNumber;
            otherRow["CSTNumber"] = customer.CSTNumber;
            otherRow["AmountInWords"] = SpellNumber.SpellInWord(crn.Amount);

            otherInfo.Rows.Add(otherRow);

            var orderReport = new frmReport
            {
                ReportPath = ReportUtility.ResolveReportPath(ReportConstants.CreditNoteReport),
                ReportDataSet = creditNoteDataSet
            };
            orderReport.Show();
        }
    }
}


