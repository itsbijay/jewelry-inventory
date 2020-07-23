using System;
using Connections;
using System.Linq;
using JetCoders.Forms.UI;
using System.Windows.Forms;
using System.Data.Objects;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmPartyTransaction : frmDataEntry
    {
        private readonly ITransactionService _transactionService;
        private readonly ISupplierService _supplierService;
        private readonly ICustomerService _customerServices;
        private readonly IReportService _reportService;

        private const string _columntrandate = "DATE";
        private const string _columntrantpe = "TYPE";
        private const string _columntranparty = "PARTY";
        private const string _columntranqty = "QTY/ PCS";
        private const string _columninvioceno = "INVOICE/ MEMO NO";
        private const string _columnrefno = "REF/ DOC NO";
        private const string _columnnetamount = "NET AMOUNT";
        private const string _columninviocepmterm = "PAYMENT TERM";
        private const string _columninviocesummary = "SUMMARY";
        private const string _columninviocedetail = "DETAIL";

        public frmPartyTransaction()
        {
            InitializeComponent();
        }

        public frmPartyTransaction(ITransactionService transactionService, ISupplierService supplierService,
                                    ICustomerService customerServices, IReportService reportService)
            : this()
        {
            _transactionService = transactionService;
            _supplierService = supplierService;
            _customerServices = customerServices;
            _reportService = reportService;

            BindMemoForm();
            ConfigDataGridView(dgvJewel);
        }

        private void BindMemoForm()
        {
            dtFromDate.Value = DateTime.Today.AddMonths(-6);
            dtToDate.Value = DateTime.Today;

            cboTranType.DataSource = Enum.GetNames(typeof(TransactionType));
            cboCustomer.DataSource = _customerServices.GetActiveCustomers();
            cboSupplier.DataSource = _supplierService.GetActiveSuppliers();
        }

        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntrandate, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntrantpe, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntranparty, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntranqty, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnnetamount, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnrefno, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columninvioceno, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columninviocepmterm, true));
            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columninviocesummary));
            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columninviocedetail));

            mapGrid.CellContentClick += dgvJewel_CellContentClick;
        }

        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            grpCustomer.SendToBack();
            grpSupplier.BringToFront();
        }

        private void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            grpCustomer.BringToFront();
            grpSupplier.SendToBack();
        }

        private void btnShowTransactions_Click(object sender, EventArgs e)
        {
            if (dtFromDate.Value > dtToDate.Value)
            {
                MessageBox.Show(Resources.frmPartyTransaction_btnShowTransactions_Click_Please_correct_transaction_date_);
                return;
            }
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            FindTransaction();
        }

        private void FindTransaction()
        {
            dgvJewel.Rows.Clear();
            var partyref = rdoCustomer.Checked
                                ? (cboCustomer.SelectedItem as Customer).CustomersCode
                                : (cboSupplier.SelectedItem as Supplier).SupplierCode;
            var tranType = (TransactionType)Enum.Parse(typeof(TransactionType), cboTranType.SelectedItem.ToString());
            var lookups = _transactionService.GetJewelTransactionsLookUp();

            if (tranType == TransactionType.NotSet)
            {
                lookups = lookups.Where(x => x.TransactionPartyRef == partyref &&
                                                 (EntityFunctions.TruncateTime(x.TransactionDate) >= dtFromDate.Value && EntityFunctions.TruncateTime(x.TransactionDate) <= dtToDate.Value))
                                                 .OrderByDescending(x => x.TransactionDate);
            }
            else
            {
                lookups = lookups.Where(x => x.TransactionPartyRef == partyref &&
                                                    x.TransactionType_Enum == (short)tranType &&
                                                 (EntityFunctions.TruncateTime(x.TransactionDate) >= dtFromDate.Value && EntityFunctions.TruncateTime(x.TransactionDate) <= dtToDate.Value))
                                                 .OrderByDescending(x => x.TransactionDate);

            }
            

            if (!lookups.Any())
            {
                MessageBox.Show(Resources.frmPartyTransaction_FindTransaction_No_transaction_found_for_this_period_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var _newRowNumber = 0;
            foreach (var tran in lookups)
            {
                var invoice = _transactionService.GetJewelTransactionInvoices()
                                                       .SingleOrDefault(x => x.InvoiceNumber == tran.MemoNumber);
                dgvJewel.Rows.Add(1);

                dgvJewel.Rows[_newRowNumber].Cells[_columntrandate.ToLowerCaseColumnName()].Value = tran.TransactionDate.ToString("g");
                dgvJewel.Rows[_newRowNumber].Cells[_columntrantpe.ToLowerCaseColumnName()].Value = tran.TransactionType.GetDescription();
                dgvJewel.Rows[_newRowNumber].Cells[_columntranparty.ToLowerCaseColumnName()].Value = tran.TransactionPartyRef;
                dgvJewel.Rows[_newRowNumber].Cells[_columntranqty.ToLowerCaseColumnName()].Value = tran.JewelTransactions.Count();
                dgvJewel.Rows[_newRowNumber].Cells[_columnnetamount.ToLowerCaseColumnName()].Value = tran.NetAmount;
                dgvJewel.Rows[_newRowNumber].Cells[_columnrefno.ToLowerCaseColumnName()].Value = tran.DocNumber;

                dgvJewel.Rows[_newRowNumber].Cells[_columninvioceno.ToLowerCaseColumnName()].Value = tran.MemoNumber;
                dgvJewel.Rows[_newRowNumber].Cells[_columninviocepmterm.ToLowerCaseColumnName()].Value = invoice != null ? invoice.PaymentTerm : string.Empty;

                dgvJewel.Rows[_newRowNumber].Cells[_columninviocesummary.ToLowerCaseColumnName()].Value = "Summary";
                dgvJewel.Rows[_newRowNumber].Cells[_columninviocesummary.ToLowerCaseColumnName()].Tag = tran.TransactionLookupId;

                dgvJewel.Rows[_newRowNumber].Cells[_columninviocedetail.ToLowerCaseColumnName()].Value = "Detail";
                dgvJewel.Rows[_newRowNumber].Cells[_columninviocedetail.ToLowerCaseColumnName()].Tag = tran.TransactionLookupId;

                _newRowNumber = _newRowNumber + 1;

                dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;
            }
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var value = dgvJewel[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (value == "Summary")
            {
                var summary = (Int32)dgvJewel[e.ColumnIndex, e.RowIndex].Tag;
                ShowSummartyReport(summary);
            }
            if (value == "Detail")
            {
                var detail = (Int32)dgvJewel[e.ColumnIndex, e.RowIndex].Tag;
                ShowDetailReport(detail);
            }
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowDetailReport(int id)
        {
            var lookup = _transactionService.GetJewelTransactionsLookUpById(id);
            TransactionType transactionType = lookup.TransactionType;

            var request = new TaxInvoiceReportRequest
            {
                TransactionNumber = lookup.MemoNumber,
                TransactionType = transactionType
            };

            var response = _reportService.GetTransactionDetailReport(request);

            var orderReport = new frmReport
            {
                ReportPath = ReportUtility.GetTaxInvoiceDetailReportPath(transactionType),
                ReportDataSet = response.TaxInvoiceDetailDataSet
            };
            orderReport.Show();
        }

        private void ShowSummartyReport(int id)
        {
            var lookup = _transactionService.GetJewelTransactionsLookUpById(id);
            TransactionType transactionType = lookup.TransactionType;

            var request = new TaxInvoiceReportRequest
            {
                TransactionNumber = lookup.MemoNumber,
                TransactionType = transactionType
            };

            var response = _reportService.GetTransactionSumaryReport(request);

            var orderReport = new frmReport
            {
                ReportPath = ReportUtility.GetTaxInvoiceSummaryReportPath(transactionType),
                ReportDataSet = response.TaxInvoiceSummaryDataSet
            };
            orderReport.Show();
        }

        private void frmPartyTransaction_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboTranType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}