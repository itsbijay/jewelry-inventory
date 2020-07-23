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
    public partial class frmSalesReturnTransactions : frmDataEntry
    {
        private readonly ITransactionService _transactionService;
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
        private const string _columncanceltran = "CANCEL";

        public frmSalesReturnTransactions()
        {
            InitializeComponent();
        }

        public frmSalesReturnTransactions(ITransactionService transactionService,
                                    ICustomerService customerServices, IReportService reportService)
            : this()
        {
            _transactionService = transactionService;
            _customerServices = customerServices;
            _reportService = reportService;

            BindMemoForm();
            ConfigDataGridView(dgvJewel);
        }

        private void BindMemoForm()
        {
            dtFromDate.Value = DateTime.Today.AddMonths(-6);
            dtToDate.Value = DateTime.Today;
            cboCustomer.DataSource = _customerServices.GetActiveCustomers();
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
            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columncanceltran));

            mapGrid.CellContentClick += dgvJewel_CellContentClick;
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
            var partyref = (cboCustomer.SelectedItem as Customer).CustomersCode;
            var lookups = _transactionService.GetJewelTransactionsLookUp();

            lookups = (from l in lookups
                       join i in _transactionService.GetJewelTransactionInvoices() on l.MemoNumber equals i.InvoiceNumber
                       where i.Cancelled == false && l.TransactionPartyRef == partyref &&
                             l.TransactionType_Enum == (short)TransactionType.SalesInTransaction &&
                             (EntityFunctions.TruncateTime(l.TransactionDate) >= dtFromDate.Value &&
                              EntityFunctions.TruncateTime(l.TransactionDate) <= dtToDate.Value)
                       select l
                );

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

                dgvJewel.Rows[_newRowNumber].Cells[_columncanceltran.ToLowerCaseColumnName()].Value = "Cancel Transaction";
                dgvJewel.Rows[_newRowNumber].Cells[_columncanceltran.ToLowerCaseColumnName()].Tag = tran.TransactionLookupId;

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
                return;
            }
            if (value == "Detail")
            {
                var detail = (Int32)dgvJewel[e.ColumnIndex, e.RowIndex].Tag;
                ShowDetailReport(detail);
                return;
            }
            if (value == "Cancel Transaction")
            {
                var lookupid = (Int32)dgvJewel[e.ColumnIndex, e.RowIndex].Tag;
                CancelTransaction(lookupid);
            }
        }

        private void CancelTransaction(int lookupid)
        {
            var isYes = MessageBox.Show(Resources.frmManageTransaction_lnkRTS_LinkClicked_Are_you_sure_want_to_return_stock_into_account, Resources.frmManageTransaction_lnkRTS_LinkClicked_Return_To_Stock, MessageBoxButtons.OKCancel) == DialogResult.OK;

            if (isYes)
            {
                var request = new JewelTransactionRequest();

                var lookup = _transactionService.GetJewelTransactionsLookUp().Single(x => x.TransactionLookupId == lookupid);
                var clookup = new TransactionLookup
                {
                    Remarks = lookup.Remarks,
                    TransactionPartyRef = lookup.TransactionPartyRef,
                    ContactName = lookup.ContactName,
                    ReferenceMemoNumber = lookup.MemoNumber,
                    DocNumber = lookup.DocNumber,
                    TransactionType = TransactionType.SalesInReturnTransaction,
                    TransactionLookupId = 0,
                    TransactionDate = DateTime.Now
                };

                foreach (var trans in lookup.JewelTransactions)
                {
                    var item = new JewelTransaction
                    {
                        CostingDetail = trans.CostingDetail,
                        TransactionType = TransactionType.SalesInReturnTransaction,
                        MetalColor = trans.MetalColor,
                        CStonePcs = trans.CStonePcs,
                        CStoneWeight = trans.CStoneWeight,
                        CertificateNumber = trans.CertificateNumber,
                        DesignCode = trans.DesignCode,
                        StonePcs = trans.StonePcs,
                        KT = trans.KT,
                        JewelItemCategory = trans.JewelItemCategory,
                        JewelNumber = trans.JewelNumber,
                        JewelType = trans.JewelType,
                        TotalWeight = trans.TotalWeight,
                        MetalWeight = trans.MetalWeight,
                        StoneWeight = trans.StoneWeight,
                        Properties = trans.Properties,
                        TransactionPartyRef = trans.TransactionPartyRef,
                        TransactionDate = DateTime.Today,
                        TotalAmount = trans.TotalAmount
                    };
                    clookup.JewelTransactions.Add(item);
                }

                if (clookup.JewelTransactions.Any())
                {
                    request.TransactionLookup = clookup;
                    var response = _transactionService.CreateJewelTransaction(request);
                    ShowManagedModalForm<frmCostingConfirmation>(Owner as frmMDIParent, response.TransactionLookup);
                }
                else
                {
                    MessageBox.Show(Resources.frmManageTransaction_lnkRTS_LinkClicked_no_item_available_to_be_returned_);
                    return;
                }

                FindTransaction();
            }
        }

        private void ShowDetailReport(int id)
        {
            var lookup = _transactionService.GetJewelTransactionsLookUpById(id);
            var transactionType = lookup.TransactionType;

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
            var transactionType = lookup.TransactionType;

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
    }
}