using System;
using System.Collections.Generic;
using System.Linq;
using Connections.Services;

namespace Connections
{
    public class JewelCalculation : IJewelCalculation
    {
        private readonly ITransactionService _transactionServices;
        public JewelCalculation(ITransactionService transactionServices)
        {
            _transactionServices = transactionServices;
        }

        public CalculateResponse Calculate(CostingRates costingRates,
            IList<JewelTransaction> jewelTransactions)
        {
            var response = new CalculateResponse();

            var lookupKey = Guid.NewGuid();

            foreach (var tran in jewelTransactions)
            {
                decimal _metalAmount = 0M, _diamondAmount = 0M, _cstoneAmount = 0M, _certAmount = 0M, _laborAmount = 0M, _stampingAmount = 0M;

                var transactionDetails = tran.Properties.ItemDetails;

                // Metal Net Amount
                var rate = costingRates.CostingItems.Single(x => x.ProductCategory == ProductCategory.Metal && x.Particulars == transactionDetails.MetalDetail.MetalKT);
                _metalAmount = Math.Max(transactionDetails.MetalDetail.MetalNetWt * rate.Amount, 0);
                transactionDetails.MetalDetail.MetalNetAmount = _metalAmount;

                // Labour Detail
                var labourCosting = costingRates.CostingItems.Single(x =>
                                            x.Particulars == transactionDetails.ItemDescription
                                            && x.ProductCategory == ProductCategory.Labour
                                            );
                if (Convert.ToDecimal(transactionDetails.MetalDetail.MetalNetWt) * labourCosting.Amount <= labourCosting.MinimumAmount)
                    _laborAmount = Math.Max(labourCosting.MinimumAmount, 0);
                else
                    _laborAmount = Convert.ToDecimal(transactionDetails.MetalDetail.MetalNetWt) * labourCosting.Amount;

                transactionDetails.LabourCharges = _laborAmount;

                // Diamond Net Amount
                if (tran.StonePcs > 0)
                {
                    var diamondDetails = transactionDetails.StoneDetail.StoneChart.StoneMetaDetailList;
                    diamondDetails.ForEach(dia =>
                    {
                        var diaCosting = costingRates.CostingItems.Single(x =>
                                               x.Particulars == transactionDetails.StoneDetail.StoneType
                                            && x.ConfigurationValue == dia.StoneSieveSz
                                            && x.ProductCategory == ProductCategory.Stone
                                         );

                        dia.StoneValue = dia.StoneWt * diaCosting.Amount;
                        _diamondAmount += dia.StoneValue;
                    });

                    transactionDetails.StoneDetail.StoneNetAmount = _diamondAmount;
                    if (tran.JewelItemCategory == JewelItemCategory.Gold)
                    {
                        if (
                            costingRates.CertificateRate.Items.Any(
                                x => x.RangeMinValue <= tran.StoneWeight && x.RangeMaxValue >= tran.StoneWeight))
                        {
                            var certCosting = costingRates.CertificateRate.Items.Single(x => x.RangeMinValue <= tran.StoneWeight && x.RangeMaxValue >= tran.StoneWeight);
                            _certAmount = certCosting.Amount * tran.StoneWeight;

                            transactionDetails.CertificateCharges = _certAmount;                            
                        }
                        else
                        {
                            response.AddValidationError("CertificateCosting", "Certificate costing is not defined for weight." + tran.StoneWeight);    
                        }
                        
                    }
                    _stampingAmount = tran.Properties.ItemDetails.StampingCharges;
                }

                // ColorStone Net Amount
                if (tran.CStonePcs > 0)
                {
                    var colorStoneDetails = transactionDetails.ColorStoneDetail;
                    var csCosting = costingRates.CostingItems.Single(x =>
                                            x.Particulars == colorStoneDetails.ColorStoneType
                                            && x.ProductCategory == ProductCategory.ColorStone
                                        );

                    _cstoneAmount = colorStoneDetails.ColorStoneNetWt * csCosting.Amount;
                    transactionDetails.ColorStoneDetail.ColorStoneNetAmount = _cstoneAmount;
                    _stampingAmount = tran.Properties.ItemDetails.StampingCharges;
                }

                tran.CostingDetail = new CostingDetail { Properties = costingRates };
                tran.Properties = new TransactionDetails { ItemDetails = transactionDetails };
                tran.TotalAmount = Math.Max(_metalAmount + _diamondAmount + _cstoneAmount + _certAmount + _laborAmount + _stampingAmount, 0);

                tran.JewelTransactionRowId = lookupKey;
            }
            return response;
        }
    }
}