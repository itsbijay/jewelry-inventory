using System.Data;
using Connections.Dataset;
using System.Collections.Generic;
using System;

namespace Connections
{
    public class DataSetProvider : IDataSetProvider
    {
        readonly IFirmService _firmService;
        readonly ITransactionService _transactionService;

        public DataSetProvider(IFirmService firmService, ITransactionService transactionService)
        {
            _firmService = firmService;
            _transactionService = transactionService;
        }

        public CostingChartDataSet GetCostingChartDataSet(List<Int32> requests)
        {
            var orderDataSet = new CostingChartDataSet();

            var dtcostingReport = orderDataSet.Tables["Costing"];
            var dtstoneDetail = orderDataSet.Tables["StoneDetails"];

            foreach (var item in requests)
            {
                var jewelTran = _transactionService.GetJewelTransactionsById(item);
                if (jewelTran == null) return orderDataSet;

                var costing = dtcostingReport.NewRow();

                costing["TRID"] = jewelTran.JewelTransactionId;
                costing["CERNO"] = jewelTran.CertificateNumber;
                costing["DESIGNNO"] = jewelTran.DesignCode;
                costing["TYPE"] = jewelTran.JewelType;
                costing["GRWT"] = jewelTran.TotalWeight;
                costing["NTWT"] = jewelTran.MetalWeight;
                costing["GAMT"] = jewelTran.Properties.ItemDetails.MetalDetail.MetalNetAmount;
                costing["COLOR"] = jewelTran.MetalColor;
                costing["DIAPCS"] = jewelTran.StonePcs;
                costing["DIAWT"] = jewelTran.StoneWeight;
                costing["DIATYPE"] = jewelTran.Properties.ItemDetails.StoneDetail.StoneType;
                costing["SIEVSZ"] = String.Empty;
                costing["DPCS"] = default(int);
                costing["DWT"] = default(decimal);
                costing["DPR"] = default(decimal);
                costing["CPCS"] = jewelTran.CStonePcs;
                costing["CWT"] = jewelTran.CStoneWeight;
                costing["STONEVAL"] = jewelTran.StonePcs == 0 ? jewelTran.Properties.ItemDetails.ColorStoneDetail.ColorStoneNetAmount : jewelTran.Properties.ItemDetails.StoneDetail.StoneNetAmount;
                costing["LABR"] = jewelTran.Properties.ItemDetails.LabourCharges;
                costing["CERT"] = jewelTran.Properties.ItemDetails.CertificateCharges;
                costing["STAMP"] = jewelTran.Properties.ItemDetails.StampingCharges;
                costing["AMT"] = jewelTran.TotalAmount;
                dtcostingReport.Rows.Add(costing);

                foreach (var detail in jewelTran.Properties.ItemDetails.StoneDetail.StoneChart.StoneMetaDetailList)
                {
                    DataRow stone = dtstoneDetail.NewRow();
                    stone["TRID"] = jewelTran.JewelTransactionId;
                    stone["SIEVSZ"] = 6.0;//detail.StoneSieveSz;
                    stone["DIAPCS"] = 5;//detail.StonePcs;
                    stone["DIAWT"] = 4.5;//detail.StoneWt;
                    stone["DIAPR"] = 3.2;//detail.StoneValue;
                    dtstoneDetail.Rows.Add(stone);
                }
            }
            return orderDataSet;
        }

        public DataTable GetFirmDataTable(DataTable firmDataTable)
        {
            var firm = _firmService.GetFrimMaster();

            if (firm == null) return firmDataTable;
            var firmRow = firmDataTable.NewRow();

            firmRow["FirmMasterId"] = firm.FirmMasterId;
            firmRow["FirmName"] = firm.FirmName;
            firmRow["FirmEmail"] = firm.FirmEmail;
            firmRow["FirmTopHeader"] = firm.FirmTopHeader;
            firmRow["FirmHeader"] = firm.FirmHeader;
            firmRow["FirmWebsite"] = firm.FirmWebsite;
            firmRow["FirmLogo"] = firm.FirmLogo;
            firmRow["FirmAddress"] = firm.FirmAddress;
            firmRow["FirmAdditionalInfo"] = firm.FirmAdditionalInfo;
            firmRow["FirmVATNumber"] = firm.FirmVATNumber;
            firmRow["FirmTINNumber"] = firm.FirmTINNumber;
            firmRow["Tax"] = firm.Tax;
            firmRow["OtherTax"] = firm.OtherTax;

            firmDataTable.Rows.Add(firmRow);

            return firmDataTable;
        }
    }
}
